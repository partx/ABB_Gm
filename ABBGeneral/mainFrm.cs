using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using ABB.Robotics.Controllers;
using ABB.Robotics.Controllers.Discovery;
using ABB.Robotics.Controllers.RapidDomain;
using ABB.Robotics.Controllers.IOSystemDomain;
using System.Threading;
using System.Resources;
using System.Drawing.Drawing2D;
using DrawMapClass;

namespace ABBGeneral
{
    
    public partial class mainFrm : Form
    {
        #region global variable
        static System.Threading.Mutex _mutex;   //

        static ArrayList varList = null;
        static ArrayList ioList = null;
        private string taskName ;
        private string moduleName;
        private NetworkScanner netScanner = null;   //ABB        
        private NetworkWatcher netWatcher = null;
        private ABB.Robotics.Controllers.RapidDomain.Task[] tasks = null;
        private Controller ctl = null;
        private RapidData rd = null;
        

        
        #endregion 
        public mainFrm()
        {
            InitializeComponent();
        }

        
        #region winform loading
        private void mainForm_Load(object sender, EventArgs e)
        {

            varList = new ArrayList();
            ioList = new ArrayList();

            
            /////////////////////////////////////////////////////////////
            ///create a mutex to only a instance
            //////////////////////////////////////////////////////////////
           
                bool createNew;
                Attribute guid_attr = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute));
                string guid = ((GuidAttribute)guid_attr).Value;

                _mutex = new System.Threading.Mutex(true, guid, out createNew);
                if (false == createNew)
                {
                    MessageBox.Show("only a instance");
                    this.Close();
                }
                _mutex.ReleaseMutex();
           

            /////////////////////////////////////////////////////////////
            ///starting watcher
            ////////////////////////////////////////////////////////////
                netScanner = new NetworkScanner();     //

            if(this.netWatcher !=null)          //
            {
                this.netWatcher.Dispose();      //
                this.netWatcher = null;
            }
            this.netWatcher = new NetworkWatcher(netScanner.Controllers);       //watching controller
            this.netWatcher.Found += new EventHandler<NetworkWatcherEventArgs>(HandleFoundEvent);   //online event
            this.netWatcher.Lost += new EventHandler<NetworkWatcherEventArgs>(HandleLostEvent);     //offline event
            this.netWatcher.EnableRaisingEvents = true;         //active event

            ///////////////////////////////////////////////////////////
            ///drawing winform
            //////////////////////////////////////////////////////////
            
            int ledWidth = SystemInformation.VirtualScreen.Width;
            int ledHeight = SystemInformation.VirtualScreen.Height;
            this.MaximumSize=new Size(ledWidth,ledHeight);    //
            this.MinimumSize=new Size(ledWidth,ledHeight);
            ///calculate some var
            panelHide.Top = 0;
            panelHide.Left = 0;
            panelHide.Width = ledWidth;
            panelHide.Height = ledHeight;
            
            DrawMap.GoldenSectionST gsTop, gsLeft;
            
            double topOffset = ledHeight;
            double leftOffset = ledWidth;
            for (int i = 0; i < 4; i++)
            {
                gsTop = DrawMap.GoldenSection(topOffset);
                topOffset = gsTop.shortGS;
                gsLeft = DrawMap.GoldenSection(leftOffset);
                leftOffset = gsLeft.shortGS;
            }
            int topO = (int)topOffset;
            int leftO = (int)leftOffset;

            drawMap1.Top = 0;
            drawMap1.Left = 0;
            drawMap1.Width=leftO + 19 * topO;
            drawMap1.Height= 5 * topO + 15 * (topO / 3);

            int topOff = drawMap1.Height;
            int leftOff = drawMap1.Width;

            listViewController.Top = topO;
            listViewController.Left = leftOff;
            listViewController.Width = this.ClientRectangle.Width - leftOff - leftO;
            listViewController.Height = topOff;
            int colWidth = listViewController.Width / 7;
            for (int i = 0; i < 7; i++)
                listViewController.Columns[i].Width = colWidth;

            panelLeftTop.Top = topOff + 2 * topO;
            panelLeftTop.Left = leftO;
            panelLeftTop.Width = listViewController.Width/2;
            panelLeftTop.Height = (this.ClientRectangle.Height - topOff-3 * topO);

            panelLeftBottom.Top = panelLeftTop.Top;
            panelLeftBottom.Left = panelLeftTop.Right+leftO;
            panelLeftBottom.Width = panelLeftTop.Width;
            panelLeftBottom.Height = panelLeftTop.Height;

            int labelWidth = listViewController.Right - panelLeftBottom.Right - leftO;
            int labelHeight = topO;
            labelMode.Top = panelLeftTop.Top;
            labelMode.Left = panelLeftBottom.Right + leftO;
            labelMode.Size = new Size(labelWidth, labelHeight);
            labelMode.Text = "N/A";

            labelStatus.Top = labelMode.Bottom + topO / 2;
            labelStatus.Left = labelMode.Left;
            labelStatus.Size = new Size(labelWidth, labelHeight);
            labelStatus.Text = "N/A";

            labelExecStatus.Top = labelStatus.Bottom + topO / 2;
            labelExecStatus.Left = labelMode.Left;
            labelExecStatus.Size = new Size(labelWidth, labelHeight);
            labelExecStatus.Text = "N/A";

            buttonExit.Size = new Size(labelWidth, 2 * labelHeight);
            buttonExit.Top = panelLeftBottom.Bottom - 2 * labelHeight;
            buttonExit.Left = labelMode.Left;
            buttonExit.Enabled = true;

            buttonStart.Size = new Size(labelWidth, 2 * labelHeight);
            buttonStart.Top = panelLeftBottom.Bottom - 4 * labelHeight - topO;
            buttonStart.Left = labelMode.Left;
            buttonStart.Enabled = false;

            textBoxRapidList.Top = labelExecStatus.Bottom + topO;
            textBoxRapidList.Left = labelMode.Left;
            textBoxRapidList.Width = labelWidth;
            textBoxRapidList.Height = buttonStart.Top - labelExecStatus.Bottom - 2 * topO;
            textBoxRapidList.Enabled = false;


            buttonIO.Top = topO;
            buttonIO.Left = leftO;
            buttonIO.Size=new Size(panelLeftTop.Width - 2 * leftO,2*topO);
            buttonIO.Enabled = false;

            groupBoxInfo.Top = buttonIO.Bottom;
            groupBoxInfo.Left = leftO;
            groupBoxInfo.Width = panelLeftTop.Width-2*leftO;
            groupBoxInfo.Height = panelLeftTop.Height-4*topO;
            for (int i = 0; i < 2; i++)
                listViewInfo.Columns[i].Width = listViewInfo.Width / 2 - 5;
            listViewInfo.Enabled = false;
            groupBoxInfo.Enabled = false;
            groupBoxInfo.Visible = false;

            groupBoxMonitor.Top = buttonIO.Bottom;
            groupBoxMonitor.Left = leftO;
            groupBoxMonitor.Width = panelLeftTop.Width - 2 * leftO;
            groupBoxMonitor.Height = panelLeftTop.Height - 4 * topO;
            for (int i = 0; i < 3; i++)
                listViewMonitor.Columns[i].Width = listViewMonitor.Width / 3 - 2;
            listViewMonitor.Enabled = false;
            groupBoxMonitor.Enabled = false;

            groupBoxPERS.Top = topO;
            groupBoxPERS.Left = leftO;
            groupBoxPERS.Width = panelLeftTop.Width - 2 * leftO;
            groupBoxPERS.Height = 7 * topO;
            groupBoxPERS.Enabled = false;

            groupBoxData.Top = groupBoxPERS.Bottom+topO;
            groupBoxData.Left = leftO;
            groupBoxData.Width = panelLeftTop.Width - 2 * leftO;
            groupBoxData.Height = panelLeftBottom.Height - groupBoxPERS.Bottom - 2*topO;
            listViewData.Columns[0].Width = listViewMonitor.Width / 3 - 2;
            listViewData.Columns[1].Width = listViewMonitor.Width - listViewData.Columns[0].Width;
            listViewData.Enabled = false;
            groupBoxData.Enabled = false;

            comboBoxTask.Top = topO;
            comboBoxTask.Left = leftO;
            comboBoxTask.Width = (groupBoxData.Width - 3*leftO)/2;
            comboBoxTask.Enabled = false;

            comboBoxModule.Top = topO;
            comboBoxModule.Left = comboBoxTask.Right + leftO;
            comboBoxModule.Width = comboBoxTask.Width;
            comboBoxModule.Enabled = false;

            textBoxName.Top = comboBoxModule.Bottom+topO/2;
            textBoxName.Left = leftO;
            textBoxName.Width = comboBoxTask.Width;
            textBoxName.Enabled = false;

            buttonInput.Top = textBoxName.Bottom + topO/2;
            buttonInput.Left = leftO;
            buttonInput.Size = new Size(textBoxName.Width, textBoxName.Height);
            buttonInput.Enabled = false;

            buttonClear.Top = buttonInput.Top;
            buttonClear.Left = comboBoxModule.Left;
            buttonClear.Size = new Size(textBoxName.Width, textBoxName.Height);
            buttonClear.Enabled = false;


            panelHide.Visible = false;
           

            //////////////////////////////////////////////////////////
            ///scaning
            /////////////////////////////////////////////////////////
            ScanControllerToListView();

            
        }
        #endregion
       
        #region fill to listview 
        private void ScanControllerToListView()
        {
            netScanner.Scan();
            ControllerInfoCollection controllers = netScanner.Controllers;

            /////////////////////////////////////////////////////////////////
            ///filling
            ////////////////////////////////////////////////////////////////
            listViewController.Items.Clear();
            ListViewItem item = null;
            foreach(ControllerInfo controllerInfo in controllers)
            {
                item = new ListViewItem(controllerInfo.IPAddress.ToString());
                item.SubItems.Add(controllerInfo.Id);
                item.SubItems.Add(controllerInfo.Availability.ToString());
                item.SubItems.Add(controllerInfo.IsVirtual.ToString());
                item.SubItems.Add(controllerInfo.SystemName);
                item.SubItems.Add(controllerInfo.Version.ToString());
                item.SubItems.Add(controllerInfo.ControllerName);
                this.listViewController.Items.Add(item);
                item.Tag = controllerInfo;

            }
        }
        #endregion

        #region finding new controller
        void HandleFoundEvent(object sender,NetworkWatcherEventArgs e)
        {
            this.Invoke(new EventHandler<NetworkWatcherEventArgs>(AddControllerToListView), new Object[] { this, e });
            
        }
        private void AddControllerToListView(object sender,NetworkWatcherEventArgs e)
        {
            ScanControllerToListView();
        }
        #endregion

        #region offline event
        void HandleLostEvent(object sender,NetworkWatcherEventArgs e)
        {
            this.Invoke(new EventHandler<NetworkWatcherEventArgs>(RemoveControllerToListView), new Object[] { this, e });
        }

        private void RemoveControllerToListView(object sender,NetworkWatcherEventArgs e)
        {
            ScanControllerToListView();
        }
        #endregion
      

        #region active controller
        private void listViewController_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = this.listViewController.SelectedItems[0];
                if(item.Tag!=null)
                {
                    ControllerInfo controllerInfo = (ControllerInfo)item.Tag;
                    if(controllerInfo.Availability==Availability.Available)
                    {
                        LogonController(controllerInfo);    //log on
                        GetRapid();                         //get rapid list
                        GetIOAndData();                     //get io and data

                        textBoxName.Enabled = true;
                        buttonInput.Enabled = true;
                        buttonStart.Enabled = true;
                        listViewInfo.Enabled=true;
                        listViewMonitor.Enabled=true;
                        listViewData.Enabled = true;
                        buttonClear.Enabled = true;
                        comboBoxTask.Enabled = true;
                        comboBoxModule.Enabled = true;
                        textBoxRapidList.Enabled = true;
                        groupBoxData.Enabled = true;
                        groupBoxMonitor.Enabled = true;
                        groupBoxInfo.Enabled = true;
                        groupBoxPERS.Enabled = true;
                        buttonIO.Enabled = true;
                        ///////////////////////////////////////////////////////////
                        ///moniting
                        ////////////////////////////////////////////////////////////
                        this.ctl.OperatingModeChanged += new EventHandler<OperatingModeChangeEventArgs>(OperatingModeChanged);	//mode change event
                        this.ctl.StateChanged += new EventHandler<StateChangedEventArgs>(StateChanged);		                    //state change event
                        this.ctl.Rapid.ExecutionStatusChanged += new EventHandler<ExecutionStatusChangedEventArgs>(RapidExecutionStatusChanged);    //Rapid execution status change event
            

                    }
                }
                else
                {
                    MessageBox.Show("Unselected controller");

                }
            }
            catch(System.Exception ex)
            {
                MessageBox.Show("error：" + ex.Message);
            }
        }
        #endregion

        #region log on
        private void LogonController(ControllerInfo clrinfo)
        {
            if (ctl != null)
            {
                ctl.Logoff();
                ctl.Dispose();
                ctl = null;
            }
            ctl = ControllerFactory.CreateFrom(clrinfo);
            ctl.Logon(UserInfo.DefaultUser);            //default user
            
        }
        #endregion

        #region get rapid list
        private void GetRapid()
        {
            try
            {
                textBoxRapidList.Text = "";
                
                tasks = ctl.Rapid.GetTasks();   //get rapid list
                foreach (ABB.Robotics.Controllers.RapidDomain.Task t in tasks)
                {
                    textBoxRapidList.AppendText("Task: " + t.Name + "\n");
                    comboBoxTask.Items.Add(t.Name);
                    ABB.Robotics.Controllers.RapidDomain.Module[] modules = t.GetModules();
                    
                    foreach (ABB.Robotics.Controllers.RapidDomain.Module m in modules)
                    {
                        textBoxRapidList.AppendText("\t Module: " + m.Name + "\n");
                        comboBoxModule.Items.Add(m.Name);
                        Routine[] routines = m.GetRoutines();
                        foreach (Routine r in routines)
                        {
                            textBoxRapidList.AppendText("\t\t Routine: " + r.Name + "\n");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("get Rapid list error");
            }
            
        }
        #endregion
        #region get io and data
        private void GetIOAndData()
        {
            try
            {
                ListViewItem item;
                listViewInfo.Items.Clear();
                /////////////////////////////////////////////////////////////////
                ///some signals
                ////////////////////////////////////////////////////////////////
                IOFilterTypes sigFilterIn = IOFilterTypes.Digital | IOFilterTypes.Input;
                SignalCollection signalsIn = ctl.IOSystem.GetSignals(sigFilterIn);
                foreach (Signal signal in signalsIn)
                {
                    item = new ListViewItem(signal.Name);
                    item.SubItems.Add(signal.Type.ToString());
                    item.SubItems.Add(signal.Value.ToString());
                    listViewInfo.Items.Add(item);
                }

                IOFilterTypes sigFilterOut = IOFilterTypes.Digital | IOFilterTypes.Output;
                SignalCollection signalsOut = ctl.IOSystem.GetSignals(sigFilterOut);
                foreach (Signal signal in signalsOut)
                {
                    item = new ListViewItem(signal.Name);
                    item.SubItems.Add(signal.Type.ToString());
                    item.SubItems.Add(signal.Value.ToString());
                    listViewInfo.Items.Add(item);
                }

                sigFilterIn = IOFilterTypes.Analog | IOFilterTypes.Input;
                signalsIn = ctl.IOSystem.GetSignals(sigFilterIn);
                foreach (Signal signal in signalsIn)
                {
                    item = new ListViewItem(signal.Name);
                    item.SubItems.Add(signal.Type.ToString());
                    item.SubItems.Add(signal.Value.ToString());
                    listViewInfo.Items.Add(item);
                }

                sigFilterOut = IOFilterTypes.Analog | IOFilterTypes.Output;
                signalsOut = ctl.IOSystem.GetSignals(sigFilterOut);
                foreach (Signal signal in signalsOut)
                {
                    item = new ListViewItem(signal.Name);
                    item.SubItems.Add(signal.Type.ToString());
                    item.SubItems.Add(signal.Value.ToString());
                    listViewInfo.Items.Add(item);
                }

                sigFilterIn = IOFilterTypes.Group | IOFilterTypes.Input;
                signalsIn = ctl.IOSystem.GetSignals(sigFilterIn);
                foreach (Signal signal in signalsIn)
                {
                    item = new ListViewItem(signal.Name);
                    item.SubItems.Add(signal.Type.ToString());
                    item.SubItems.Add(signal.Value.ToString());
                    listViewInfo.Items.Add(item);
                }

                sigFilterOut = IOFilterTypes.Group | IOFilterTypes.Output;
                signalsOut = ctl.IOSystem.GetSignals(sigFilterOut);
                foreach (Signal signal in signalsOut)
                {
                    item = new ListViewItem(signal.Name);
                    item.SubItems.Add(signal.Type.ToString());
                    item.SubItems.Add(signal.Value.ToString());
                    listViewInfo.Items.Add(item);
                }

                sigFilterIn = IOFilterTypes.System | IOFilterTypes.Input;
                signalsIn = ctl.IOSystem.GetSignals(sigFilterIn);
                foreach (Signal signal in signalsIn)
                {
                    item = new ListViewItem(signal.Name);
                    item.SubItems.Add(signal.Type.ToString());
                    item.SubItems.Add(signal.Value.ToString());
                    listViewInfo.Items.Add(item);
                }

                sigFilterOut = IOFilterTypes.System | IOFilterTypes.Output;
                signalsOut = ctl.IOSystem.GetSignals(sigFilterOut);
                foreach (Signal signal in signalsOut)
                {
                    item = new ListViewItem(signal.Name);
                    item.SubItems.Add(signal.Type.ToString());
                    item.SubItems.Add(signal.Value.ToString());
                    listViewInfo.Items.Add(item);
                }
            }
            catch
            {
                MessageBox.Show("get IO list error");
            }

            /////////////////////////////////////////////////////////////
            
        }
        #endregion
        #region input PERS var if you want to moniting
        private void buttonInput_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && comboBoxTask.Text.ToString() != "" && comboBoxModule.Text.ToString() != "")
            {
                ListViewItem item = new ListViewItem(textBoxName.Text);
                item.SubItems.Add("");
                listViewData.Items.Add(item);
                varList.Add(textBoxName.Text);
                
            }
            else
            {
                MessageBox.Show("select task,module,PERS");
            }
            
        }
        #endregion
        #region input IO signals if you want to moniting
        private void listViewInfo_DoubleClick(object sender, EventArgs e)
        {
            buttonIO.Enabled = true;
            groupBoxInfo.Visible = false;
            groupBoxMonitor.Visible = true;
            ListViewItem item = new ListViewItem(listViewInfo.SelectedItems[0].Text);
            item.SubItems.Add("");
            item.SubItems.Add(listViewInfo.SelectedItems[0].SubItems[1].Text);
            listViewMonitor.Items.Add(item);
            ioList.Add(listViewInfo.SelectedItems[0].Text);
        }
        #endregion

        #region starting
        private void buttonStart_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////////////////
            ///starting
            ///////////////////////////////////////////////////////////////
            
            Signal sig=null;
            
            if(ioList.Count!=0)
            {
                for(int i=0;i<ioList.Count;i++)
                {
                    
                    sig = ctl.IOSystem.GetSignal(ioList[i].ToString());
                    sig.Changed+=new EventHandler<SignalChangedEventArgs>(SignalChanged);
                }

            }
            
            
            taskName = comboBoxTask.Text.ToString();
            moduleName = comboBoxModule.Text.ToString();
            
            if(varList.Count!=0 && taskName!="" && moduleName!="")
            {
                try
                {
                    
                    for(int i=0;i<varList.Count;i++)
                    {
                        this.rd = this.ctl.Rapid.GetTask(taskName).GetModule(moduleName).GetRapidData(varList[i].ToString());
                        listViewData.Items[i].SubItems[1].Text = rd.Value.ToString();
                        this.rd.ValueChanged += new EventHandler<DataValueChangedEventArgs>(DataValueChanged);
                        this.rd.Subscribe(DataValueChanged, EventPriority.High);
                        this.rd.Unsubscribe(DataValueChanged);
                    }
                }
                catch
                {
                    MessageBox.Show("error，check task name,module name,PERS name");
                }
            }
            
            
            
        }
        #endregion

        #region moniting PERA data
        void DataValueChanged(object sender, DataValueChangedEventArgs e)
        {
            this.Invoke(new EventHandler<DataValueChangedEventArgs>(DataValueIsChanged), new Object[] { sender, e });
        }

        private void DataValueIsChanged(object sender, DataValueChangedEventArgs e)
        {
            /////////////////////////////////////////////////////////////////////////
            ///watching data value
            ////////////////////////////////////////////////////////////////////////
            try
            {
                for (int i = 0; i < varList.Count; i++)
                {

                    this.rd = this.ctl.Rapid.GetTask(taskName).GetModule(moduleName).GetRapidData(varList[i].ToString());

                    listViewData.Items[i].SubItems[1].Text = rd.Value.ToString();
                    

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            

        }
        #endregion

        #region moniting IO signals
        void SignalChanged(object sender, SignalChangedEventArgs e)
        {
            
            this.Invoke(new EventHandler<SignalChangedEventArgs>(SignalIsChanged), new Object[] { sender, e });
        }

        private void SignalIsChanged(object sender, SignalChangedEventArgs e)
        {
            
            for (int i = 0; i < ioList.Count; i++)
            {
                if(listViewMonitor.Items[i].Text==sender.ToString())
                    listViewMonitor.Items[i].SubItems[1].Text = e.NewSignalState.Value.ToString();
            }
            
        }
        #endregion


        #region Rapid execution status change event
        void RapidExecutionStatusChanged(object sender, ExecutionStatusChangedEventArgs e)
        {
            this.Invoke(new EventHandler<ExecutionStatusChangedEventArgs>(RapidExecStatusChanged), new object[] { this, e });
        }

        private void RapidExecStatusChanged(object sender, ExecutionStatusChangedEventArgs e)
        {
            
            labelExecStatus.Text = e.Status.ToString();
            if (labelExecStatus.Text == ExecutionStatus.Running.ToString())
            {
                labelExecStatus.BackColor=Color.Green;
                labelExecStatus.ForeColor = Color.White;
                ;
            }

            else if (labelExecStatus.Text == ExecutionStatus.Unknown.ToString())
            {
                labelExecStatus.BackColor = Color.Yellow;
                labelExecStatus.ForeColor = Color.White;
            }
            else
            {
                labelExecStatus.BackColor = Color.Red;
                labelExecStatus.ForeColor = Color.White;
            }
        }
        #endregion

        #region state change event
        void StateChanged(object sender,StateChangedEventArgs e)
        {
            this.Invoke(new EventHandler<StateChangedEventArgs>(StateIsChanged), new Object[] { this, e });
        }

        private void StateIsChanged(object sender,StateChangedEventArgs e)
        {
            labelStatus.Text = e.NewState.ToString();

            if(labelStatus.Text==ControllerState.MotorsOn.ToString())
            {
                labelStatus.BackColor=Color.Green;
                labelStatus.ForeColor = Color.White;
            }
            else
            {
                labelStatus.BackColor = Color.Red;
                labelStatus.ForeColor = Color.White;
            }
        }
        #endregion

        #region mode change event
        void OperatingModeChanged(object sender, OperatingModeChangeEventArgs e)
        {
            this.Invoke(new EventHandler<OperatingModeChangeEventArgs>(ModeIsChanged),new Object[] {this,e});
        }

        private void ModeIsChanged(object sender, OperatingModeChangeEventArgs e)
        {
            

            labelMode.Text = e.NewMode.ToString();
            if (labelMode.Text == ControllerOperatingMode.Auto.ToString())
            {
                labelMode.BackColor=Color.Green;
                labelMode.ForeColor = Color.White;

            }
            else if (labelMode.Text == ControllerOperatingMode.AutoChange.ToString())
            {
                labelMode.BackColor=Color.Cyan;
                labelMode.ForeColor = Color.White;
            }
            else if (labelMode.Text == ControllerOperatingMode.Init.ToString())
            {
                labelMode.BackColor = Color.Blue;
                labelMode.ForeColor = Color.White;
            }
            else if (labelMode.Text == ControllerOperatingMode.ManualFullSpeed.ToString())
            {
                labelMode.BackColor = Color.Orange;
                labelMode.ForeColor = Color.White;
            }
            else if (labelMode.Text == ControllerOperatingMode.ManualFullSpeedChange.ToString())
            {
                labelMode.BackColor = Color.YellowGreen;
                labelMode.ForeColor = Color.White;
            }
            else if (labelMode.Text == ControllerOperatingMode.ManualReducedSpeed.ToString())
            {
                labelMode.BackColor = Color.Yellow;
                labelMode.ForeColor = Color.White;
            }
            else
            {
                labelMode.BackColor = Color.Red;
                labelMode.ForeColor = Color.White;
            }
        }
        #endregion

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listViewMonitor.Items.Clear();
            listViewData.Items.Clear();
            varList.Clear();
            ioList.Clear();
        }

        private void listViewData_DoubleClick(object sender, EventArgs e)
        {
            RapidData rdt = null;
            string temp = "0";
            try
            {
                MessageBox.Show("Zero clearing?    accept in the flexpandent after click OK");
                rdt = this.ctl.Rapid.GetTask(taskName).GetModule(moduleName).GetRapidData(listViewData.SelectedItems[0].Text.ToString());
                Mastership mas = Mastership.Request(this.ctl.Rapid);
                //Change: controller is repaced by aController
                rdt.Value = ABB.Robotics.Controllers.RapidDomain.Num.Parse(temp);
                mas.Dispose();
                MessageBox.Show("zero clearing");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Type isn't Num. error: "+ex.ToString());
            }

            //Release mastership as soon as possible
            
        }

        private void labelExecStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if(ctl.OperatingMode == ControllerOperatingMode.Auto && ctl.State == ControllerState.MotorsOn)
                {
                    Mastership mc = Mastership.Request(this.ctl.Rapid);
                    if (labelExecStatus.Text == ExecutionStatus.Running.ToString())
                        {

                            //Perform operation

                            tasks[0].Stop();

                        }
                    else
                        {
                            StartResult a;
                            tasks[0].ResetProgramPointer();
                            a=tasks[0].Start();
                            

                        }
                    mc.Dispose();
                }
                else
                {
                    MessageBox.Show("Please turn to Auto mode and motor on");
                }
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Mastership is held by another client." + ex.Message);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Unexpected error occurred: " + ex.Message);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonIO_Click(object sender, EventArgs e)
        {
            groupBoxMonitor.Visible = false;
            groupBoxInfo.Visible = true;
            buttonIO.Enabled = false;
        }

    }
}

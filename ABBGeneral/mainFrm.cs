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

namespace ABBGeneral
{
    public partial class mainFrm : Form
    {
        #region 全局变量表
        static System.Threading.Mutex _mutex;   //一个互斥量，防止程序再次运行
        static ArrayList debugMess = null;
        static ArrayList varList = null;
        static ArrayList ioList = null;
        private string taskName ;
        private string moduleName;
        private NetworkScanner netScanner = null;   //ABB相关        
        private NetworkWatcher netWatcher = null;
        private ABB.Robotics.Controllers.RapidDomain.Task[] tasks = null;
        private Controller ctl = null;
        private RapidData rd = null;
        
        #endregion 
        public mainFrm()
        {
            InitializeComponent();
        }

        #region 窗体加载时动作
        private void mainForm_Load(object sender, EventArgs e)
        {
            debugMess = new ArrayList();
            varList = new ArrayList();
            ioList = new ArrayList();

            /////////////////////////////////////////////////////////////
            ///建立一个互斥量防止程序再次运行，同一时间只允许运行一个实例
            //////////////////////////////////////////////////////////////
           
                bool createNew;
                Attribute guid_attr = Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(GuidAttribute));
                string guid = ((GuidAttribute)guid_attr).Value;
                debugMess.Add("guid: " + guid);
                _mutex = new System.Threading.Mutex(true, guid, out createNew);
                if (false == createNew)
                {
                    MessageBox.Show("only a instance");
                    this.Close();
                }
                _mutex.ReleaseMutex();
           

            /////////////////////////////////////////////////////////////
            ///开启ABB网络监听并实例化一些部件
            ////////////////////////////////////////////////////////////
            netScanner = new NetworkScanner();      //实例化网络扫描器

            if(this.netWatcher !=null)          //实例化网络监听器
            {
                this.netWatcher.Dispose();      //若存在，则清除
                this.netWatcher = null;
            }
            this.netWatcher = new NetworkWatcher(netScanner.Controllers);       //监视网络中活动的控制器
            this.netWatcher.Found += new EventHandler<NetworkWatcherEventArgs>(HandleFoundEvent);   //当有新控制器找到，发生这个事件
            this.netWatcher.Lost += new EventHandler<NetworkWatcherEventArgs>(HandleLostEvent);     //当有控制器离线，发生这个事件
            this.netWatcher.EnableRaisingEvents = true;         //激活事件

            ///////////////////////////////////////////////////////////
            ///窗体绘制
            //////////////////////////////////////////////////////////
            int ledWidth = SystemInformation.VirtualScreen.Width;
            int ledHeight = SystemInformation.VirtualScreen.Height;
            this.MaximumSize=new Size(3*ledWidth/4,3*ledHeight/4);    //固定窗体
            this.MinimumSize=new Size(3*ledWidth/4,3*ledHeight/4);
            this.Top = (ledHeight - this.Height) / 2;
            this.Left = (ledWidth - this.Width) / 2;
            debugMess.Add("Width: " + this.MaximumSize.Width.ToString());
            debugMess.Add("Height: " + this.MaximumSize.Height.ToString());
            
            labelEnDebug.Top = this.ClientRectangle.Bottom - 15;
            labelEnDebug.Left = this.ClientRectangle.Right - 15;

            listViewController.Top = 12;
            listViewController.Left = listViewController.Top;
            listViewController.Width = this.ClientRectangle.Width - 2*listViewController.Left;
            listViewController.Height = this.ClientRectangle.Height / 3;
            int colWidth=listViewController.Width/7;
            for (int i = 0; i < 7;i++ )
                listViewController.Columns[i].Width = colWidth;

            groupBoxStatus.Top = listViewController.Bottom + listViewController.Left;
            groupBoxStatus.Left = listViewController.Left;
            groupBoxStatus.Width = listViewController.Width / 5;
            groupBoxStatus.Height = this.ClientRectangle.Bottom - listViewController.Bottom - 2 * listViewController.Top;
            groupBoxStatus.Enabled = false;

            pictureBoxMode.Size = new Size(groupBoxStatus.Width / 4, groupBoxStatus.Width / 4);
            pictureBoxMode.Top = groupBoxStatus.Height/5;
            pictureBoxMode.Left = groupBoxStatus.Width / 2;
            pictureBoxMode.Image = (Image)Properties.Resources.red;

            pictureBoxStatus.Size = pictureBoxMode.Size;
            pictureBoxStatus.Top = pictureBoxMode.Top * 2;
            pictureBoxStatus.Left = pictureBoxMode.Left;
            pictureBoxStatus.Image = (Image)Properties.Resources.red;

            pictureBoxExecStatus.Size = pictureBoxMode.Size;
            pictureBoxExecStatus.Top = pictureBoxMode.Top * 3;
            pictureBoxExecStatus.Left = pictureBoxMode.Left;
            pictureBoxExecStatus.Image = (Image)Properties.Resources.red;

            labelMode.Top = pictureBoxMode.Top-labelMode.Height;
            labelMode.Left = groupBoxStatus.Left/2;
            labelMode.Text = "N/A";

            labelStatus.Top = pictureBoxStatus.Top-labelStatus.Height;
            labelStatus.Left = groupBoxStatus.Left / 2;
            labelStatus.Text = "N/A";

            labelExecStatus.Top = pictureBoxExecStatus.Top-labelExecStatus.Height;
            labelExecStatus.Left = groupBoxStatus.Left / 2;
            labelExecStatus.Text = "N/A";

            groupBoxRapidList.Top = groupBoxStatus.Top;
            groupBoxRapidList.Left = groupBoxStatus.Right + groupBoxStatus.Left;
            groupBoxRapidList.Width = (this.ClientRectangle.Width - (5 * groupBoxStatus.Left + groupBoxStatus.Width)) / 3;
            groupBoxRapidList.Height = 4 * groupBoxStatus.Height / 5;
            groupBoxRapidList.Enabled = false;

            textBoxRapidList.Enabled = false;

            groupBoxInfo.Top = groupBoxStatus.Top;
            groupBoxInfo.Left = groupBoxRapidList.Right + groupBoxStatus.Left;
            groupBoxInfo.Width = groupBoxRapidList.Width;
            groupBoxInfo.Height = 4 * groupBoxStatus.Height / 5;
            for (int i = 0; i < 2; i++)
                listViewInfo.Columns[i].Width = listViewInfo.Width / 2 - 5;
            listViewInfo.Enabled = false;
            groupBoxInfo.Enabled = false;

            groupBoxMonitor.Top = groupBoxStatus.Top;
            groupBoxMonitor.Left = groupBoxInfo.Right + groupBoxStatus.Left;
            groupBoxMonitor.Width = groupBoxInfo.Width;
            groupBoxMonitor.Height = 2 * groupBoxStatus.Height / 5;
            for (int i = 0; i < 3; i++)
                listViewMonitor.Columns[i].Width = listViewMonitor.Width / 3 - 2;
            listViewMonitor.Enabled = false;
            groupBoxMonitor.Enabled = false;

            groupBoxData.Top = groupBoxMonitor.Bottom + groupBoxStatus.Left;
            groupBoxData.Left = groupBoxMonitor.Left;
            groupBoxData.Width = groupBoxInfo.Width;
            groupBoxData.Height = 2 * groupBoxStatus.Height / 5;
            for (int i = 0; i < 3; i++)
                listViewData.Columns[i].Width = listViewMonitor.Width / 3 - 2;
            listViewData.Enabled = false;
            groupBoxData.Enabled = false;

            groupBoxPERS.Top = groupBoxRapidList.Bottom + groupBoxStatus.Left;
            groupBoxPERS.Left = groupBoxRapidList.Left;
            groupBoxPERS.Width = groupBoxInfo.Right - groupBoxPERS.Left;
            groupBoxPERS.Height = groupBoxStatus.Bottom - groupBoxPERS.Top;
            groupBoxPERS.Enabled = false;

            comboBoxTask.Top = groupBoxStatus.Left;
            comboBoxTask.Left = groupBoxStatus.Left;
            comboBoxTask.Width = groupBoxRapidList.Width / 2 - 2*groupBoxStatus.Left / 2;
            comboBoxTask.Enabled = false;

            comboBoxModule.Top = comboBoxTask.Top;
            comboBoxModule.Left = comboBoxTask.Right + groupBoxStatus.Left;
            comboBoxModule.Width = comboBoxTask.Width;
            comboBoxModule.Enabled = false;

            textBoxName.Top = comboBoxTask.Top;
            textBoxName.Left = comboBoxModule.Right+groupBoxStatus.Left;
            textBoxName.Width = comboBoxTask.Width;
            textBoxName.Enabled = false;

            comboBoxType.Top = textBoxName.Top;
            comboBoxType.Left = textBoxName.Right + groupBoxStatus.Left;
            comboBoxType.Width = textBoxName.Width;
            comboBoxType.SelectedIndex = 0;
            comboBoxType.Enabled = false;

            buttonInput.Top = textBoxName.Bottom + groupBoxStatus.Left/3;
            buttonInput.Left = textBoxName.Left;
            buttonInput.Enabled = false;

            buttonClear.Size = buttonInput.Size;
            buttonClear.Top = buttonInput.Top;
            buttonClear.Left = comboBoxType.Left;
            buttonClear.Enabled = false;

            buttonStart.Size = new Size(groupBoxMonitor.Width, groupBoxMonitor.Height / 3);
            buttonStart.Top = groupBoxData.Bottom + groupBoxStatus.Left;
            buttonStart.Left = groupBoxMonitor.Left;
            buttonStart.Enabled = false;

           

            //////////////////////////////////////////////////////////
            ///开始行动，在网络上扫描控制器并添加到 listView里
            /////////////////////////////////////////////////////////
            ScanControllerToListView();
        }
        #endregion

        #region 把扫描到的控制器填入listView控件里
        private void ScanControllerToListView()
        {
            netScanner.Scan();
            ControllerInfoCollection controllers = netScanner.Controllers;

            /////////////////////////////////////////////////////////////////
            ///填表
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
                debugMess.Add("Tag: " + item.Tag);
            }
        }
        #endregion

        #region 寻找到新控制器事件
        void HandleFoundEvent(object sender,NetworkWatcherEventArgs e)
        {
            this.Invoke(new EventHandler<NetworkWatcherEventArgs>(AddControllerToListView), new Object[] { this, e });
            
        }
        private void AddControllerToListView(object sender,NetworkWatcherEventArgs e)
        {
            ScanControllerToListView();
        }
        #endregion

        #region 控制器离线事件
        void HandleLostEvent(object sender,NetworkWatcherEventArgs e)
        {
            this.Invoke(new EventHandler<NetworkWatcherEventArgs>(RemoveControllerToListView), new Object[] { this, e });
        }

        private void RemoveControllerToListView(object sender,NetworkWatcherEventArgs e)
        {
            ScanControllerToListView();
        }
        #endregion
        #region 激活彩蛋
        private void labelEnDebug_Click(object sender, EventArgs e)
        {
            string strDebugMess = "";
            foreach(Object obj in debugMess)
            {
                strDebugMess += obj.ToString()+"\n";
            }
            MessageBox.Show(strDebugMess);

        }
        #endregion

        #region 激活选中的控制器
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
                        LogonController(controllerInfo);    //登陆控制器
                        GetRapid();                         //取得Rapid列表
                        GetIOAndData();                     //取得IO或数据

                        groupBoxStatus.Enabled=true;
                        textBoxName.Enabled = true;
                        comboBoxType.Enabled = true;
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
                        groupBoxRapidList.Enabled = true;
                        groupBoxPERS.Enabled = true;

                        ///////////////////////////////////////////////////////////
                        ///开始各项监控事件
                        ////////////////////////////////////////////////////////////
                        this.ctl.OperatingModeChanged += new EventHandler<OperatingModeChangeEventArgs>(OperatingModeChanged);	//模式改变事件
                        this.ctl.StateChanged += new EventHandler<StateChangedEventArgs>(StateChanged);		                    //状态改变事件
                        this.ctl.Rapid.ExecutionStatusChanged += new EventHandler<ExecutionStatusChangedEventArgs>(RapidExecutionStatusChanged);    //Rapid执行状态改变事件
            

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

        #region 登陆ABB控制器
        private void LogonController(ControllerInfo clrinfo)
        {
            if (ctl != null)
            {
                ctl.Logoff();
                ctl.Dispose();
                ctl = null;
            }
            ctl = ControllerFactory.CreateFrom(clrinfo);
            ctl.Logon(UserInfo.DefaultUser);            //用默认用户登录控制器
            
        }
        #endregion

        #region 取得控制器里Rapid列表
        private void GetRapid()
        {
            try
            {
                textBoxRapidList.Text = "";
                
                tasks = ctl.Rapid.GetTasks();   //取得Rapid列表
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
        #region 获取IO信号以及数据列表
        private void GetIOAndData()
        {
            try
            {
                ListViewItem item;
                listViewInfo.Items.Clear();
                /////////////////////////////////////////////////////////////////
                ///各种输入输出信号
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
        #region 录入要监控的可变量
        private void buttonInput_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && comboBoxTask.Text.ToString() != "" && comboBoxModule.Text.ToString() != "")
            {
                ListViewItem item = new ListViewItem(textBoxName.Text);
                item.SubItems.Add("");
                item.SubItems.Add(comboBoxType.Text);
                listViewData.Items.Add(item);
                varList.Add(textBoxName.Text);
                
            }
            else
            {
                MessageBox.Show("select task,module,PERS");
            }
            
        }
        #endregion
        #region 录入要监控的IO信号
        private void listViewInfo_DoubleClick(object sender, EventArgs e)
        {

            ListViewItem item = new ListViewItem(listViewInfo.SelectedItems[0].Text);
            item.SubItems.Add("");
            item.SubItems.Add(listViewInfo.SelectedItems[0].SubItems[1].Text);
            listViewMonitor.Items.Add(item);
            ioList.Add(listViewInfo.SelectedItems[0].Text);
        }
        #endregion

        #region 监控事件的启动子程序
        private void buttonStart_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////////////////
            ///启动各项监控事件
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

        #region 数据监听事件
        void DataValueChanged(object sender, DataValueChangedEventArgs e)
        {
            this.Invoke(new EventHandler<DataValueChangedEventArgs>(DataValueIsChanged), new Object[] { sender, e });
        }

        private void DataValueIsChanged(object sender, DataValueChangedEventArgs e)
        {
            /////////////////////////////////////////////////////////////////////////
            ///若任意监控变量发生改变，则重新刷新列表
            ////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < varList.Count; i++)
            {
                this.rd = this.ctl.Rapid.GetTask(taskName).GetModule(moduleName).GetRapidData(varList[i].ToString());
                listViewData.Items[i].SubItems[1].Text = rd.Value.ToString();
            }
            

        }
        #endregion

        #region 输入输出监听事件
        void SignalChanged(object sender, SignalChangedEventArgs e)
        {
            
            this.Invoke(new EventHandler<SignalChangedEventArgs>(SignalIsChanged), new Object[] { sender, e });
        }

        private void SignalIsChanged(object sender, SignalChangedEventArgs e)
        {
            
            if (e.NewSignalState.Value == 1)
            {
                for (int i = 0; i < ioList.Count; i++)
                {
                    if (listViewMonitor.Items[i].Text == sender.ToString())
                        listViewMonitor.Items[i].SubItems[1].Text = "1";
                }
                  
            }
            else
            {
                for (int i = 0; i < ioList.Count; i++)
                {
                    if (listViewMonitor.Items[i].Text == sender.ToString())
                        listViewMonitor.Items[i].SubItems[1].Text = "0";
                }
            }
        }
        #endregion


        #region Rapid执行状态改变事件
        void RapidExecutionStatusChanged(object sender, ExecutionStatusChangedEventArgs e)
        {
            this.Invoke(new EventHandler<ExecutionStatusChangedEventArgs>(RapidExecStatusChanged), new object[] { this, e });
        }

        private void RapidExecStatusChanged(object sender, ExecutionStatusChangedEventArgs e)
        {
            labelExecStatus.Text = e.Status.ToString();
            if (labelExecStatus.Text == ExecutionStatus.Running.ToString())
            {
                pictureBoxExecStatus.Image = Properties.Resources.green;
                labelExecStatus.ForeColor = Color.Green;
            }

            else if (labelExecStatus.Text == ExecutionStatus.Unknown.ToString())
            {
                pictureBoxExecStatus.Image = Properties.Resources.yellow;
                labelExecStatus.ForeColor = Color.Yellow;
            }
            else
            {
                pictureBoxExecStatus.Image = Properties.Resources.red;
                labelExecStatus.ForeColor = Color.Red;
            }
        }
        #endregion

        #region 状态改变事件
        void StateChanged(object sender,StateChangedEventArgs e)
        {
            this.Invoke(new EventHandler<StateChangedEventArgs>(StateIsChanged), new Object[] { this, e });
        }

        private void StateIsChanged(object sender,StateChangedEventArgs e)
        {
            labelStatus.Text = e.NewState.ToString();

            if(labelStatus.Text==ControllerState.MotorsOn.ToString())
            {
                pictureBoxStatus.Image = Properties.Resources.green;
                labelStatus.ForeColor = Color.Green;
            }
            else
            {
                pictureBoxStatus.Image = Properties.Resources.red;
                labelStatus.ForeColor = Color.Red;
            }
        }
        #endregion

        #region 模式改变事件
        void OperatingModeChanged(object sender, OperatingModeChangeEventArgs e)
        {
            this.Invoke(new EventHandler<OperatingModeChangeEventArgs>(ModeIsChanged),new Object[] {this,e});
        }

        private void ModeIsChanged(object sender, OperatingModeChangeEventArgs e)
        {
            labelMode.Text = e.NewMode.ToString();
            if (labelMode.Text == ControllerOperatingMode.Auto.ToString())
            {
                pictureBoxMode.Image = Properties.Resources.green;
                labelMode.ForeColor = Color.Green;
            }
            else if (labelMode.Text == ControllerOperatingMode.AutoChange.ToString())
            {
                pictureBoxMode.Image = Properties.Resources.green;
                labelMode.ForeColor = Color.Cyan;
            }
            else if (labelMode.Text == ControllerOperatingMode.Init.ToString())
            {
                pictureBoxMode.Image = Properties.Resources.red;
                labelMode.ForeColor = Color.Blue;
            }
            else if (labelMode.Text == ControllerOperatingMode.ManualFullSpeed.ToString())
            {
                pictureBoxMode.Image = Properties.Resources.yellow;
                labelMode.ForeColor = Color.Orange;
            }
            else if (labelMode.Text == ControllerOperatingMode.ManualFullSpeedChange.ToString())
            {
                pictureBoxMode.Image = Properties.Resources.yellow;
                labelMode.ForeColor = Color.YellowGreen;
            }
            else if (labelMode.Text == ControllerOperatingMode.ManualReducedSpeed.ToString())
            {
                pictureBoxMode.Image = Properties.Resources.yellow;
                labelMode.ForeColor = Color.Yellow;
            }
            else
            {
                pictureBoxMode.Image = Properties.Resources.red;
                labelMode.ForeColor = Color.Red;
            }
        }
        #endregion

        private void buttonClear_Click(object sender, EventArgs e)
        {
            listViewMonitor.Items.Clear();
            listViewData.Items.Clear();
        }

        private void listViewData_DoubleClick(object sender, EventArgs e)
        {
            RapidData rdt = null;
            string temp = "0";
            if(listViewData.SelectedItems[0].SubItems[2].Text=="Num")
            {
                MessageBox.Show("Zero clearing?    accept in the flexpandent after click OK");
                rdt = this.ctl.Rapid.GetTask(taskName).GetModule(moduleName).GetRapidData(listViewData.SelectedItems[0].Text.ToString());
                Mastership mas = Mastership.Request(this.ctl.Rapid);
                //Change: controller is repaced by aController
                rdt.Value = ABB.Robotics.Controllers.RapidDomain.Num.Parse(temp);
                mas.Dispose();
                MessageBox.Show("zero clearing");
            }
            else
            {
                MessageBox.Show("Type isn't Num");
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
                            debugMess.Add(a.ToString());

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

     

       
    }
}

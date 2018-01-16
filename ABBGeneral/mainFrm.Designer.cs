namespace ABBGeneral
{
    partial class mainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrm));
            this.listViewController = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelExecStatus = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelMode = new System.Windows.Forms.Label();
            this.textBoxRapidList = new System.Windows.Forms.TextBox();
            this.listViewMonitor = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonInput = new System.Windows.Forms.Button();
            this.listViewData = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonClear = new System.Windows.Forms.Button();
            this.comboBoxTask = new System.Windows.Forms.ComboBox();
            this.comboBoxModule = new System.Windows.Forms.ComboBox();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.listViewInfo = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxMonitor = new System.Windows.Forms.GroupBox();
            this.groupBoxData = new System.Windows.Forms.GroupBox();
            this.groupBoxPERS = new System.Windows.Forms.GroupBox();
            this.panelLeftTop = new System.Windows.Forms.Panel();
            this.buttonIO = new System.Windows.Forms.Button();
            this.panelLeftBottom = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panelHide = new System.Windows.Forms.Panel();
            this.drawMap1 = new DrawMapClass.DrawMap();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxMonitor.SuspendLayout();
            this.groupBoxData.SuspendLayout();
            this.groupBoxPERS.SuspendLayout();
            this.panelLeftTop.SuspendLayout();
            this.panelLeftBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawMap1)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewController
            // 
            this.listViewController.BackgroundImageTiled = true;
            this.listViewController.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewController.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewController.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewController.FullRowSelect = true;
            this.listViewController.GridLines = true;
            this.listViewController.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewController.Location = new System.Drawing.Point(11, 250);
            this.listViewController.Margin = new System.Windows.Forms.Padding(2);
            this.listViewController.MultiSelect = false;
            this.listViewController.Name = "listViewController";
            this.listViewController.Size = new System.Drawing.Size(413, 155);
            this.listViewController.TabIndex = 2;
            this.listViewController.UseCompatibleStateImageBehavior = false;
            this.listViewController.View = System.Windows.Forms.View.Details;
            this.listViewController.DoubleClick += new System.EventHandler(this.listViewController_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP Address";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Availability";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Virtual";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "System Name";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "RobotWare Version";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Controller Name";
            // 
            // labelExecStatus
            // 
            this.labelExecStatus.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelExecStatus.Location = new System.Drawing.Point(189, 499);
            this.labelExecStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelExecStatus.Name = "labelExecStatus";
            this.labelExecStatus.Size = new System.Drawing.Size(88, 27);
            this.labelExecStatus.TabIndex = 7;
            this.labelExecStatus.Text = "label4";
            this.labelExecStatus.Click += new System.EventHandler(this.labelExecStatus_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStatus.Location = new System.Drawing.Point(189, 460);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(88, 19);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "label2";
            // 
            // labelMode
            // 
            this.labelMode.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMode.Location = new System.Drawing.Point(189, 420);
            this.labelMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(88, 21);
            this.labelMode.TabIndex = 4;
            this.labelMode.Text = "label1";
            // 
            // textBoxRapidList
            // 
            this.textBoxRapidList.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxRapidList.Location = new System.Drawing.Point(11, 417);
            this.textBoxRapidList.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxRapidList.Multiline = true;
            this.textBoxRapidList.Name = "textBoxRapidList";
            this.textBoxRapidList.ReadOnly = true;
            this.textBoxRapidList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxRapidList.Size = new System.Drawing.Size(146, 144);
            this.textBoxRapidList.TabIndex = 8;
            // 
            // listViewMonitor
            // 
            this.listViewMonitor.BackgroundImageTiled = true;
            this.listViewMonitor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.listViewMonitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMonitor.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewMonitor.FullRowSelect = true;
            this.listViewMonitor.GridLines = true;
            this.listViewMonitor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewMonitor.Location = new System.Drawing.Point(2, 26);
            this.listViewMonitor.Margin = new System.Windows.Forms.Padding(2);
            this.listViewMonitor.Name = "listViewMonitor";
            this.listViewMonitor.Size = new System.Drawing.Size(201, 134);
            this.listViewMonitor.TabIndex = 10;
            this.listViewMonitor.UseCompatibleStateImageBehavior = false;
            this.listViewMonitor.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Name";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Value";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Type";
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStart.Location = new System.Drawing.Point(290, 420);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(72, 33);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Start monitor";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(106, 28);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(76, 31);
            this.textBoxName.TabIndex = 12;
            // 
            // buttonInput
            // 
            this.buttonInput.Location = new System.Drawing.Point(113, 100);
            this.buttonInput.Margin = new System.Windows.Forms.Padding(2);
            this.buttonInput.Name = "buttonInput";
            this.buttonInput.Size = new System.Drawing.Size(74, 27);
            this.buttonInput.TabIndex = 14;
            this.buttonInput.Text = "Input";
            this.buttonInput.UseVisualStyleBackColor = true;
            this.buttonInput.Click += new System.EventHandler(this.buttonInput_Click);
            // 
            // listViewData
            // 
            this.listViewData.BackgroundImageTiled = true;
            this.listViewData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader14});
            this.listViewData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewData.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewData.FullRowSelect = true;
            this.listViewData.GridLines = true;
            this.listViewData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewData.Location = new System.Drawing.Point(2, 26);
            this.listViewData.Margin = new System.Windows.Forms.Padding(2);
            this.listViewData.Name = "listViewData";
            this.listViewData.Size = new System.Drawing.Size(231, 134);
            this.listViewData.TabIndex = 15;
            this.listViewData.UseCompatibleStateImageBehavior = false;
            this.listViewData.View = System.Windows.Forms.View.Details;
            this.listViewData.DoubleClick += new System.EventHandler(this.listViewData_DoubleClick);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Name";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Value";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(17, 24);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(74, 37);
            this.buttonClear.TabIndex = 16;
            this.buttonClear.Text = "Clear All";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // comboBoxTask
            // 
            this.comboBoxTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTask.FormattingEnabled = true;
            this.comboBoxTask.Location = new System.Drawing.Point(113, 65);
            this.comboBoxTask.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTask.Name = "comboBoxTask";
            this.comboBoxTask.Size = new System.Drawing.Size(92, 29);
            this.comboBoxTask.TabIndex = 17;
            // 
            // comboBoxModule
            // 
            this.comboBoxModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModule.FormattingEnabled = true;
            this.comboBoxModule.Location = new System.Drawing.Point(17, 98);
            this.comboBoxModule.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxModule.Name = "comboBoxModule";
            this.comboBoxModule.Size = new System.Drawing.Size(92, 29);
            this.comboBoxModule.TabIndex = 18;
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.listViewInfo);
            this.groupBoxInfo.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxInfo.Location = new System.Drawing.Point(14, -1);
            this.groupBoxInfo.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxInfo.Size = new System.Drawing.Size(176, 162);
            this.groupBoxInfo.TabIndex = 9;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Signals List";
            // 
            // listViewInfo
            // 
            this.listViewInfo.BackgroundImageTiled = true;
            this.listViewInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9});
            this.listViewInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewInfo.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewInfo.FullRowSelect = true;
            this.listViewInfo.GridLines = true;
            this.listViewInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewInfo.Location = new System.Drawing.Point(2, 26);
            this.listViewInfo.Margin = new System.Windows.Forms.Padding(2);
            this.listViewInfo.Name = "listViewInfo";
            this.listViewInfo.Size = new System.Drawing.Size(172, 134);
            this.listViewInfo.TabIndex = 9;
            this.listViewInfo.UseCompatibleStateImageBehavior = false;
            this.listViewInfo.View = System.Windows.Forms.View.Details;
            this.listViewInfo.DoubleClick += new System.EventHandler(this.listViewInfo_DoubleClick);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Name";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Type";
            // 
            // groupBoxMonitor
            // 
            this.groupBoxMonitor.Controls.Add(this.listViewMonitor);
            this.groupBoxMonitor.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxMonitor.Location = new System.Drawing.Point(208, 2);
            this.groupBoxMonitor.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxMonitor.Name = "groupBoxMonitor";
            this.groupBoxMonitor.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxMonitor.Size = new System.Drawing.Size(205, 162);
            this.groupBoxMonitor.TabIndex = 20;
            this.groupBoxMonitor.TabStop = false;
            this.groupBoxMonitor.Text = "Monitor Signals List";
            // 
            // groupBoxData
            // 
            this.groupBoxData.Controls.Add(this.listViewData);
            this.groupBoxData.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxData.Location = new System.Drawing.Point(303, 19);
            this.groupBoxData.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxData.Name = "groupBoxData";
            this.groupBoxData.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxData.Size = new System.Drawing.Size(235, 162);
            this.groupBoxData.TabIndex = 8;
            this.groupBoxData.TabStop = false;
            this.groupBoxData.Text = "Monitor PERS List";
            // 
            // groupBoxPERS
            // 
            this.groupBoxPERS.Controls.Add(this.buttonClear);
            this.groupBoxPERS.Controls.Add(this.textBoxName);
            this.groupBoxPERS.Controls.Add(this.comboBoxTask);
            this.groupBoxPERS.Controls.Add(this.comboBoxModule);
            this.groupBoxPERS.Controls.Add(this.buttonInput);
            this.groupBoxPERS.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBoxPERS.Location = new System.Drawing.Point(16, 14);
            this.groupBoxPERS.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxPERS.Name = "groupBoxPERS";
            this.groupBoxPERS.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxPERS.Size = new System.Drawing.Size(283, 167);
            this.groupBoxPERS.TabIndex = 16;
            this.groupBoxPERS.TabStop = false;
            this.groupBoxPERS.Text = "Input PERS Information";
            // 
            // panelLeftTop
            // 
            this.panelLeftTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftTop.Controls.Add(this.buttonIO);
            this.panelLeftTop.Controls.Add(this.groupBoxMonitor);
            this.panelLeftTop.Controls.Add(this.groupBoxInfo);
            this.panelLeftTop.Location = new System.Drawing.Point(460, 12);
            this.panelLeftTop.Name = "panelLeftTop";
            this.panelLeftTop.Size = new System.Drawing.Size(591, 182);
            this.panelLeftTop.TabIndex = 21;
            // 
            // buttonIO
            // 
            this.buttonIO.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonIO.Location = new System.Drawing.Point(440, 47);
            this.buttonIO.Margin = new System.Windows.Forms.Padding(2);
            this.buttonIO.Name = "buttonIO";
            this.buttonIO.Size = new System.Drawing.Size(72, 33);
            this.buttonIO.TabIndex = 25;
            this.buttonIO.Text = "Add Signals";
            this.buttonIO.UseVisualStyleBackColor = true;
            this.buttonIO.Click += new System.EventHandler(this.buttonIO_Click);
            // 
            // panelLeftBottom
            // 
            this.panelLeftBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftBottom.Controls.Add(this.groupBoxData);
            this.panelLeftBottom.Controls.Add(this.groupBoxPERS);
            this.panelLeftBottom.Location = new System.Drawing.Point(475, 200);
            this.panelLeftBottom.Name = "panelLeftBottom";
            this.panelLeftBottom.Size = new System.Drawing.Size(562, 205);
            this.panelLeftBottom.TabIndex = 22;
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonExit.Location = new System.Drawing.Point(290, 493);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(72, 32);
            this.buttonExit.TabIndex = 23;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panelHide
            // 
            this.panelHide.BackColor = System.Drawing.SystemColors.Control;
            this.panelHide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelHide.Location = new System.Drawing.Point(1, 4);
            this.panelHide.Name = "panelHide";
            this.panelHide.Size = new System.Drawing.Size(1130, 598);
            this.panelHide.TabIndex = 25;
            // 
            // drawMap1
            // 
            this.drawMap1.Location = new System.Drawing.Point(1, 4);
            this.drawMap1.Name = "drawMap1";
            this.drawMap1.Size = new System.Drawing.Size(453, 232);
            this.drawMap1.TabIndex = 24;
            this.drawMap1.TabStop = false;
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1353, 731);
            this.ControlBox = false;
            this.Controls.Add(this.panelHide);
            this.Controls.Add(this.drawMap1);
            this.Controls.Add(this.textBoxRapidList);
            this.Controls.Add(this.labelExecStatus);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.panelLeftBottom);
            this.Controls.Add(this.labelMode);
            this.Controls.Add(this.panelLeftTop);
            this.Controls.Add(this.listViewController);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABB General Monitor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxMonitor.ResumeLayout(false);
            this.groupBoxData.ResumeLayout(false);
            this.groupBoxPERS.ResumeLayout(false);
            this.groupBoxPERS.PerformLayout();
            this.panelLeftTop.ResumeLayout(false);
            this.panelLeftBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawMap1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewController;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Label labelExecStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.TextBox textBoxRapidList;
        private System.Windows.Forms.ListView listViewMonitor;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonInput;
        private System.Windows.Forms.ListView listViewData;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ComboBox comboBoxTask;
        private System.Windows.Forms.ComboBox comboBoxModule;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.GroupBox groupBoxMonitor;
        private System.Windows.Forms.GroupBox groupBoxData;
        private System.Windows.Forms.GroupBox groupBoxPERS;
        private System.Windows.Forms.ListView listViewInfo;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Panel panelLeftTop;
        private System.Windows.Forms.Panel panelLeftBottom;
        private System.Windows.Forms.Button buttonExit;
        private DrawMapClass.DrawMap drawMap1;
        private System.Windows.Forms.Button buttonIO;
        private System.Windows.Forms.Panel panelHide;
    }
}


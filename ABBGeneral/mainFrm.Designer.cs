﻿namespace ABBGeneral
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
            this.labelEnDebug = new System.Windows.Forms.Label();
            this.listViewController = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.labelExecStatus = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelMode = new System.Windows.Forms.Label();
            this.pictureBoxExecStatus = new System.Windows.Forms.PictureBox();
            this.pictureBoxStatus = new System.Windows.Forms.PictureBox();
            this.pictureBoxMode = new System.Windows.Forms.PictureBox();
            this.textBoxRapidList = new System.Windows.Forms.TextBox();
            this.listViewInfo = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewMonitor = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.buttonInput = new System.Windows.Forms.Button();
            this.listViewData = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonClear = new System.Windows.Forms.Button();
            this.comboBoxTask = new System.Windows.Forms.ComboBox();
            this.comboBoxModule = new System.Windows.Forms.ComboBox();
            this.groupBoxStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMode)).BeginInit();
            this.SuspendLayout();
            // 
            // labelEnDebug
            // 
            this.labelEnDebug.AutoSize = true;
            this.labelEnDebug.Location = new System.Drawing.Point(934, 476);
            this.labelEnDebug.Name = "labelEnDebug";
            this.labelEnDebug.Size = new System.Drawing.Size(15, 15);
            this.labelEnDebug.TabIndex = 1;
            this.labelEnDebug.Text = "o";
            this.labelEnDebug.Click += new System.EventHandler(this.labelEnDebug_Click);
            // 
            // listViewController
            // 
            this.listViewController.BackgroundImageTiled = true;
            this.listViewController.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewController.FullRowSelect = true;
            this.listViewController.GridLines = true;
            this.listViewController.Location = new System.Drawing.Point(12, 12);
            this.listViewController.Name = "listViewController";
            this.listViewController.Size = new System.Drawing.Size(692, 270);
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
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.labelExecStatus);
            this.groupBoxStatus.Controls.Add(this.labelStatus);
            this.groupBoxStatus.Controls.Add(this.labelMode);
            this.groupBoxStatus.Controls.Add(this.pictureBoxExecStatus);
            this.groupBoxStatus.Controls.Add(this.pictureBoxStatus);
            this.groupBoxStatus.Controls.Add(this.pictureBoxMode);
            this.groupBoxStatus.Location = new System.Drawing.Point(12, 298);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(200, 256);
            this.groupBoxStatus.TabIndex = 3;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "状态指示";
            // 
            // labelExecStatus
            // 
            this.labelExecStatus.AutoSize = true;
            this.labelExecStatus.Font = new System.Drawing.Font("宋体", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelExecStatus.Location = new System.Drawing.Point(6, 163);
            this.labelExecStatus.Name = "labelExecStatus";
            this.labelExecStatus.Size = new System.Drawing.Size(68, 17);
            this.labelExecStatus.TabIndex = 7;
            this.labelExecStatus.Text = "label4";
            this.labelExecStatus.Click += new System.EventHandler(this.labelExecStatus_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("宋体", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStatus.Location = new System.Drawing.Point(6, 77);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(68, 17);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "label2";
            // 
            // labelMode
            // 
            this.labelMode.AutoSize = true;
            this.labelMode.Font = new System.Drawing.Font("宋体", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelMode.Location = new System.Drawing.Point(6, 36);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(68, 17);
            this.labelMode.TabIndex = 4;
            this.labelMode.Text = "label1";
            // 
            // pictureBoxExecStatus
            // 
            this.pictureBoxExecStatus.Location = new System.Drawing.Point(56, 200);
            this.pictureBoxExecStatus.Name = "pictureBoxExecStatus";
            this.pictureBoxExecStatus.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxExecStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxExecStatus.TabIndex = 3;
            this.pictureBoxExecStatus.TabStop = false;
            // 
            // pictureBoxStatus
            // 
            this.pictureBoxStatus.Location = new System.Drawing.Point(56, 87);
            this.pictureBoxStatus.Name = "pictureBoxStatus";
            this.pictureBoxStatus.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStatus.TabIndex = 1;
            this.pictureBoxStatus.TabStop = false;
            // 
            // pictureBoxMode
            // 
            this.pictureBoxMode.Location = new System.Drawing.Point(56, 24);
            this.pictureBoxMode.Name = "pictureBoxMode";
            this.pictureBoxMode.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxMode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMode.TabIndex = 0;
            this.pictureBoxMode.TabStop = false;
            // 
            // textBoxRapidList
            // 
            this.textBoxRapidList.Location = new System.Drawing.Point(230, 298);
            this.textBoxRapidList.Multiline = true;
            this.textBoxRapidList.Name = "textBoxRapidList";
            this.textBoxRapidList.ReadOnly = true;
            this.textBoxRapidList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxRapidList.Size = new System.Drawing.Size(216, 256);
            this.textBoxRapidList.TabIndex = 8;
            // 
            // listViewInfo
            // 
            this.listViewInfo.BackgroundImageTiled = true;
            this.listViewInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9});
            this.listViewInfo.FullRowSelect = true;
            this.listViewInfo.GridLines = true;
            this.listViewInfo.Location = new System.Drawing.Point(615, 298);
            this.listViewInfo.Name = "listViewInfo";
            this.listViewInfo.Size = new System.Drawing.Size(313, 270);
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
            // listViewMonitor
            // 
            this.listViewMonitor.BackgroundImageTiled = true;
            this.listViewMonitor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.listViewMonitor.FullRowSelect = true;
            this.listViewMonitor.GridLines = true;
            this.listViewMonitor.Location = new System.Drawing.Point(474, 298);
            this.listViewMonitor.Name = "listViewMonitor";
            this.listViewMonitor.Size = new System.Drawing.Size(313, 270);
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
            this.buttonStart.Location = new System.Drawing.Point(666, 211);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(247, 81);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "双击左边列表添加欲监控的信号以及输入欲监控的变量名录入到变量表中（变量表里Num类型可清零，需要示教器确认），然后点我开始监控";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(733, 107);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 25);
            this.textBoxName.TabIndex = 12;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Num",
            "Bool"});
            this.comboBoxType.Location = new System.Drawing.Point(755, 138);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(121, 23);
            this.comboBoxType.TabIndex = 13;
            // 
            // buttonInput
            // 
            this.buttonInput.Location = new System.Drawing.Point(815, 167);
            this.buttonInput.Name = "buttonInput";
            this.buttonInput.Size = new System.Drawing.Size(98, 27);
            this.buttonInput.TabIndex = 14;
            this.buttonInput.Text = "录入";
            this.buttonInput.UseVisualStyleBackColor = true;
            this.buttonInput.Click += new System.EventHandler(this.buttonInput_Click);
            // 
            // listViewData
            // 
            this.listViewData.BackgroundImageTiled = true;
            this.listViewData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader14,
            this.columnHeader15});
            this.listViewData.FullRowSelect = true;
            this.listViewData.GridLines = true;
            this.listViewData.Location = new System.Drawing.Point(324, 204);
            this.listViewData.Name = "listViewData";
            this.listViewData.Size = new System.Drawing.Size(313, 270);
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
            // columnHeader15
            // 
            this.columnHeader15.Text = "Type";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(815, 50);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 16;
            this.buttonClear.Text = "全部清除";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // comboBoxTask
            // 
            this.comboBoxTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTask.FormattingEnabled = true;
            this.comboBoxTask.Location = new System.Drawing.Point(452, 385);
            this.comboBoxTask.Name = "comboBoxTask";
            this.comboBoxTask.Size = new System.Drawing.Size(121, 23);
            this.comboBoxTask.TabIndex = 17;
            // 
            // comboBoxModule
            // 
            this.comboBoxModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModule.FormattingEnabled = true;
            this.comboBoxModule.Location = new System.Drawing.Point(615, 385);
            this.comboBoxModule.Name = "comboBoxModule";
            this.comboBoxModule.Size = new System.Drawing.Size(121, 23);
            this.comboBoxModule.TabIndex = 18;
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ABBGeneral.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(961, 678);
            this.Controls.Add(this.comboBoxModule);
            this.Controls.Add(this.comboBoxTask);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.listViewData);
            this.Controls.Add(this.buttonInput);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listViewMonitor);
            this.Controls.Add(this.listViewInfo);
            this.Controls.Add(this.textBoxRapidList);
            this.Controls.Add(this.groupBoxStatus);
            this.Controls.Add(this.listViewController);
            this.Controls.Add(this.labelEnDebug);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABB General Manager";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExecStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEnDebug;
        private System.Windows.Forms.ListView listViewController;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.PictureBox pictureBoxExecStatus;
        private System.Windows.Forms.PictureBox pictureBoxStatus;
        private System.Windows.Forms.PictureBox pictureBoxMode;
        private System.Windows.Forms.Label labelExecStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.TextBox textBoxRapidList;
        private System.Windows.Forms.ListView listViewInfo;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ListView listViewMonitor;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonInput;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ListView listViewData;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.ComboBox comboBoxTask;
        private System.Windows.Forms.ComboBox comboBoxModule;
    }
}

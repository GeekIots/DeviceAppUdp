namespace DeviceApp
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button_send = new System.Windows.Forms.Button();
            this.button_ClearSend = new System.Windows.Forms.Button();
            this.textBox_ServerIP = new System.Windows.Forms.TextBox();
            this.textBox_ServerPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_UserID = new System.Windows.Forms.TextBox();
            this.textBox_SwitchLed = new System.Windows.Forms.TextBox();
            this.timer_Heart = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_closecmd = new System.Windows.Forms.TextBox();
            this.textBox_opencmd = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_StateLED = new System.Windows.Forms.Label();
            this.button_Connect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_DeviceId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_HeartCirle = new System.Windows.Forms.ComboBox();
            this.checkBox_Heart = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label_HeartLed = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.richTextBox_Msg = new System.Windows.Forms.RichTextBox();
            this.button_clearRes = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_SendStr = new System.Windows.Forms.TextBox();
            this.checkBox_ListenSwitch = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_CmdStr = new System.Windows.Forms.TextBox();
            this.button_CreatCmd = new System.Windows.Forms.Button();
            this.textBox_CmdDeviceID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_CmdType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_send
            // 
            this.button_send.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_send.Location = new System.Drawing.Point(375, 64);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(94, 31);
            this.button_send.TabIndex = 0;
            this.button_send.Text = "发送";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // button_ClearSend
            // 
            this.button_ClearSend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_ClearSend.Location = new System.Drawing.Point(376, 24);
            this.button_ClearSend.Name = "button_ClearSend";
            this.button_ClearSend.Size = new System.Drawing.Size(94, 34);
            this.button_ClearSend.TabIndex = 1;
            this.button_ClearSend.Text = "清空发送";
            this.button_ClearSend.UseVisualStyleBackColor = true;
            this.button_ClearSend.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_ServerIP
            // 
            this.textBox_ServerIP.Location = new System.Drawing.Point(99, 22);
            this.textBox_ServerIP.Name = "textBox_ServerIP";
            this.textBox_ServerIP.Size = new System.Drawing.Size(154, 26);
            this.textBox_ServerIP.TabIndex = 2;
            this.textBox_ServerIP.Text = "120.27.45.38";
            this.textBox_ServerIP.TextChanged += new System.EventHandler(this.textBox_ServerIP_TextChanged);
            // 
            // textBox_ServerPort
            // 
            this.textBox_ServerPort.Location = new System.Drawing.Point(99, 60);
            this.textBox_ServerPort.Name = "textBox_ServerPort";
            this.textBox_ServerPort.Size = new System.Drawing.Size(154, 26);
            this.textBox_ServerPort.TabIndex = 3;
            this.textBox_ServerPort.Text = "2525";
            this.textBox_ServerPort.TextChanged += new System.EventHandler(this.textBox_ServerPort_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "服务器IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "端    口:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "用 户 ID:";
            // 
            // textBox_UserID
            // 
            this.textBox_UserID.Location = new System.Drawing.Point(99, 60);
            this.textBox_UserID.Name = "textBox_UserID";
            this.textBox_UserID.Size = new System.Drawing.Size(154, 26);
            this.textBox_UserID.TabIndex = 6;
            this.textBox_UserID.Text = "1509639203636";
            this.textBox_UserID.TextChanged += new System.EventHandler(this.textBox_UserID_TextChanged);
            // 
            // textBox_SwitchLed
            // 
            this.textBox_SwitchLed.BackColor = System.Drawing.Color.LightGray;
            this.textBox_SwitchLed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_SwitchLed.Location = new System.Drawing.Point(198, 94);
            this.textBox_SwitchLed.Name = "textBox_SwitchLed";
            this.textBox_SwitchLed.ReadOnly = true;
            this.textBox_SwitchLed.Size = new System.Drawing.Size(52, 26);
            this.textBox_SwitchLed.TabIndex = 10;
            // 
            // timer_Heart
            // 
            this.timer_Heart.Interval = 10000;
            this.timer_Heart.Tick += new System.EventHandler(this.timer_Heart_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "关 指 令:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "开 指 令:";
            // 
            // textBox_closecmd
            // 
            this.textBox_closecmd.Location = new System.Drawing.Point(99, 59);
            this.textBox_closecmd.Name = "textBox_closecmd";
            this.textBox_closecmd.Size = new System.Drawing.Size(154, 26);
            this.textBox_closecmd.TabIndex = 19;
            this.textBox_closecmd.Text = "close";
            this.textBox_closecmd.TextChanged += new System.EventHandler(this.textBox_closecmd_TextChanged);
            // 
            // textBox_opencmd
            // 
            this.textBox_opencmd.Location = new System.Drawing.Point(99, 22);
            this.textBox_opencmd.Name = "textBox_opencmd";
            this.textBox_opencmd.Size = new System.Drawing.Size(154, 26);
            this.textBox_opencmd.TabIndex = 18;
            this.textBox_opencmd.Text = "open";
            this.textBox_opencmd.TextChanged += new System.EventHandler(this.textBox_opencmd_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_StateLED);
            this.groupBox1.Controls.Add(this.button_Connect);
            this.groupBox1.Controls.Add(this.textBox_ServerIP);
            this.groupBox1.Controls.Add(this.textBox_ServerPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 126);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网络设置";
            // 
            // label_StateLED
            // 
            this.label_StateLED.AutoSize = true;
            this.label_StateLED.BackColor = System.Drawing.SystemColors.Control;
            this.label_StateLED.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_StateLED.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label_StateLED.Location = new System.Drawing.Point(105, 96);
            this.label_StateLED.Name = "label_StateLED";
            this.label_StateLED.Size = new System.Drawing.Size(24, 16);
            this.label_StateLED.TabIndex = 28;
            this.label_StateLED.Text = "●";
            // 
            // button_Connect
            // 
            this.button_Connect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_Connect.Location = new System.Drawing.Point(6, 92);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(80, 25);
            this.button_Connect.TabIndex = 17;
            this.button_Connect.Text = "连接";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_DeviceId);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.comboBox_HeartCirle);
            this.groupBox2.Controls.Add(this.checkBox_Heart);
            this.groupBox2.Controls.Add(this.textBox_UserID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label_HeartLed);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox2.Location = new System.Drawing.Point(7, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 169);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "心跳配置";
            // 
            // textBox_DeviceId
            // 
            this.textBox_DeviceId.Location = new System.Drawing.Point(99, 98);
            this.textBox_DeviceId.Name = "textBox_DeviceId";
            this.textBox_DeviceId.Size = new System.Drawing.Size(154, 26);
            this.textBox_DeviceId.TabIndex = 21;
            this.textBox_DeviceId.Text = "1";
            this.textBox_DeviceId.TextChanged += new System.EventHandler(this.textBox_DeviceId_TextChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "设 备 ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "心跳周期:";
            // 
            // comboBox_HeartCirle
            // 
            this.comboBox_HeartCirle.FormattingEnabled = true;
            this.comboBox_HeartCirle.Items.AddRange(new object[] {
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50"});
            this.comboBox_HeartCirle.Location = new System.Drawing.Point(99, 23);
            this.comboBox_HeartCirle.Name = "comboBox_HeartCirle";
            this.comboBox_HeartCirle.Size = new System.Drawing.Size(154, 24);
            this.comboBox_HeartCirle.TabIndex = 19;
            this.comboBox_HeartCirle.Text = "15";
            this.comboBox_HeartCirle.SelectedIndexChanged += new System.EventHandler(this.comboBox_HeartCirle_SelectedIndexChanged);
            // 
            // checkBox_Heart
            // 
            this.checkBox_Heart.AutoSize = true;
            this.checkBox_Heart.Location = new System.Drawing.Point(99, 141);
            this.checkBox_Heart.Name = "checkBox_Heart";
            this.checkBox_Heart.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Heart.TabIndex = 17;
            this.checkBox_Heart.UseVisualStyleBackColor = true;
            this.checkBox_Heart.CheckStateChanged += new System.EventHandler(this.checkBox_Heart_CheckStateChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "自动心跳:";
            // 
            // label_HeartLed
            // 
            this.label_HeartLed.AutoSize = true;
            this.label_HeartLed.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_HeartLed.ForeColor = System.Drawing.Color.LightGray;
            this.label_HeartLed.Location = new System.Drawing.Point(120, 131);
            this.label_HeartLed.Name = "label_HeartLed";
            this.label_HeartLed.Size = new System.Drawing.Size(35, 31);
            this.label_HeartLed.TabIndex = 20;
            this.label_HeartLed.Text = "❤";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.richTextBox_Msg);
            this.groupBox4.Controls.Add(this.button_clearRes);
            this.groupBox4.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox4.Location = new System.Drawing.Point(273, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(476, 483);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "网络数据接收";
            // 
            // richTextBox_Msg
            // 
            this.richTextBox_Msg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_Msg.Font = new System.Drawing.Font("宋体", 16F);
            this.richTextBox_Msg.Location = new System.Drawing.Point(6, 22);
            this.richTextBox_Msg.Name = "richTextBox_Msg";
            this.richTextBox_Msg.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox_Msg.Size = new System.Drawing.Size(463, 421);
            this.richTextBox_Msg.TabIndex = 15;
            this.richTextBox_Msg.Text = "";
            // 
            // button_clearRes
            // 
            this.button_clearRes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_clearRes.Location = new System.Drawing.Point(375, 449);
            this.button_clearRes.Name = "button_clearRes";
            this.button_clearRes.Size = new System.Drawing.Size(94, 28);
            this.button_clearRes.TabIndex = 14;
            this.button_clearRes.Text = "清空接收";
            this.button_clearRes.UseVisualStyleBackColor = true;
            this.button_clearRes.Click += new System.EventHandler(this.button_clearRes_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button_ClearSend);
            this.groupBox5.Controls.Add(this.textBox_SendStr);
            this.groupBox5.Controls.Add(this.button_send);
            this.groupBox5.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox5.Location = new System.Drawing.Point(273, 495);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(476, 101);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "发送区";
            // 
            // textBox_SendStr
            // 
            this.textBox_SendStr.Location = new System.Drawing.Point(5, 24);
            this.textBox_SendStr.Multiline = true;
            this.textBox_SendStr.Name = "textBox_SendStr";
            this.textBox_SendStr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_SendStr.Size = new System.Drawing.Size(364, 71);
            this.textBox_SendStr.TabIndex = 13;
            // 
            // checkBox_ListenSwitch
            // 
            this.checkBox_ListenSwitch.AutoSize = true;
            this.checkBox_ListenSwitch.Location = new System.Drawing.Point(99, 99);
            this.checkBox_ListenSwitch.Name = "checkBox_ListenSwitch";
            this.checkBox_ListenSwitch.Size = new System.Drawing.Size(15, 14);
            this.checkBox_ListenSwitch.TabIndex = 18;
            this.checkBox_ListenSwitch.UseVisualStyleBackColor = true;
            this.checkBox_ListenSwitch.CheckStateChanged += new System.EventHandler(this.checkBox_ListenSwitch_CheckStateChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkBox_ListenSwitch);
            this.groupBox6.Controls.Add(this.textBox_SwitchLed);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.textBox_opencmd);
            this.groupBox6.Controls.Add(this.textBox_closecmd);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox6.Location = new System.Drawing.Point(7, 313);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(259, 127);
            this.groupBox6.TabIndex = 24;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "监听配置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "监    听:";
            // 
            // textBox_CmdStr
            // 
            this.textBox_CmdStr.Location = new System.Drawing.Point(99, 81);
            this.textBox_CmdStr.Name = "textBox_CmdStr";
            this.textBox_CmdStr.Size = new System.Drawing.Size(154, 26);
            this.textBox_CmdStr.TabIndex = 19;
            this.textBox_CmdStr.Text = "close";
            this.textBox_CmdStr.TextChanged += new System.EventHandler(this.textBox_CmdStr_TextChanged);
            // 
            // button_CreatCmd
            // 
            this.button_CreatCmd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_CreatCmd.Location = new System.Drawing.Point(6, 113);
            this.button_CreatCmd.Name = "button_CreatCmd";
            this.button_CreatCmd.Size = new System.Drawing.Size(244, 31);
            this.button_CreatCmd.TabIndex = 15;
            this.button_CreatCmd.Text = "生成指令";
            this.button_CreatCmd.UseVisualStyleBackColor = true;
            this.button_CreatCmd.Click += new System.EventHandler(this.button_CreatCmd_Click);
            // 
            // textBox_CmdDeviceID
            // 
            this.textBox_CmdDeviceID.Location = new System.Drawing.Point(99, 49);
            this.textBox_CmdDeviceID.Name = "textBox_CmdDeviceID";
            this.textBox_CmdDeviceID.Size = new System.Drawing.Size(154, 26);
            this.textBox_CmdDeviceID.TabIndex = 18;
            this.textBox_CmdDeviceID.Text = "15";
            this.textBox_CmdDeviceID.TextChanged += new System.EventHandler(this.textBox_CmdDeviceID_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 16);
            this.label13.TabIndex = 20;
            this.label13.Text = "指令内容:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 16);
            this.label12.TabIndex = 12;
            this.label12.Text = "设 备 ID:";
            // 
            // comboBox_CmdType
            // 
            this.comboBox_CmdType.FormattingEnabled = true;
            this.comboBox_CmdType.Items.AddRange(new object[] {
            "identity",
            "set",
            "get",
            "response",
            "upload"});
            this.comboBox_CmdType.Location = new System.Drawing.Point(99, 20);
            this.comboBox_CmdType.Name = "comboBox_CmdType";
            this.comboBox_CmdType.Size = new System.Drawing.Size(154, 24);
            this.comboBox_CmdType.TabIndex = 23;
            this.comboBox_CmdType.Text = "set";
            this.comboBox_CmdType.SelectedIndexChanged += new System.EventHandler(this.comboBox_CmdType_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 16);
            this.label15.TabIndex = 22;
            this.label15.Text = "指令类型:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.comboBox_CmdType);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.textBox_CmdDeviceID);
            this.groupBox3.Controls.Add(this.button_CreatCmd);
            this.groupBox3.Controls.Add(this.textBox_CmdStr);
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox3.Location = new System.Drawing.Point(7, 446);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 150);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "快速指令";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 599);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UDP调试助手-极客物联网 V1.0 ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Button button_ClearSend;
        private System.Windows.Forms.TextBox textBox_ServerIP;
        private System.Windows.Forms.TextBox textBox_ServerPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_UserID;
        private System.Windows.Forms.TextBox textBox_SwitchLed;
        private System.Windows.Forms.Timer timer_Heart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_closecmd;
        private System.Windows.Forms.TextBox textBox_opencmd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox_SendStr;
        private System.Windows.Forms.CheckBox checkBox_ListenSwitch;
        private System.Windows.Forms.CheckBox checkBox_Heart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_HeartCirle;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button_clearRes;
        private System.Windows.Forms.Label label_StateLED;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_HeartLed;
        private System.Windows.Forms.RichTextBox richTextBox_Msg;
        private System.Windows.Forms.TextBox textBox_CmdStr;
        private System.Windows.Forms.Button button_CreatCmd;
        private System.Windows.Forms.TextBox textBox_CmdDeviceID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_CmdType;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_DeviceId;
        private System.Windows.Forms.Label label6;
    }
}


using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Threading;
using System.Drawing;
using System.Text.RegularExpressions;

namespace DeviceApp
{
    public partial class Form1 : Form
    {
        #region 日志记录、支持其他线程访问 
        public delegate void LogAppendDelegate(Color color, string text);
        /// <summary> 
        /// 追加显示文本 
        /// </summary> 
        /// <param name="color">文本颜色</param> 
        /// <param name="text">显示文本</param> 
        public void LogAppend(Color color, string text)
        {
            //第一行不增加空格
            if (richTextBox_Msg.TextLength > 0)
            {
                richTextBox_Msg.AppendText("\n");
                richTextBox_Msg.SelectionColor = Color.LightGray;
                richTextBox_Msg.AppendText("---------------------------------\n");
            }

            //时间行
            richTextBox_Msg.SelectionColor = Color.Tomato;
            richTextBox_Msg.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "\n");
            //内容
            richTextBox_Msg.SelectionColor = color;
            richTextBox_Msg.AppendText(text+"\n");

            //滚动到最后一行
            richTextBox_Msg.SelectionStart = richTextBox_Msg.TextLength;
            richTextBox_Msg.ScrollToCaret();
        }
        /// <summary> 
        /// 显示错误日志 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogError(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBox_Msg.Invoke(la, Color.Red,   text);
        }
        /// <summary> 
        /// 显示警告信息 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogWarning(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBox_Msg.Invoke(la, Color.Violet,  text);
        }
        /// <summary> 
        /// 显示信息 
        /// </summary> 
        /// <param name="text"></param> 
        public void LogMessage(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBox_Msg.Invoke(la, Color.Black,  text);
        }
        #endregion

        byte[] bytes = new byte[1024];
        IPEndPoint ip;
        Socket server;
        Thread recThread;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 加载配置
            //网络配置
            string configStr;
            configStr = Ini.Read("网络配置", "IP");
            if (configStr != "null")
                textBox_ServerIP.Text = configStr;
            configStr = Ini.Read("网络配置", "Port");
            if (configStr != "null")
                textBox_ServerPort.Text = configStr;
            //心跳配置
            configStr = Ini.Read("心跳配置", "周期");
            if (configStr != "null")
                comboBox_HeartCirle.Text = configStr;
            configStr = Ini.Read("心跳配置", "用户ID");
            if (configStr != "null")
                textBox_UserID.Text = configStr;
            configStr = Ini.Read("心跳配置", "设备ID");
            if (configStr != "null")
                textBox_DeviceId.Text = configStr;

            //监听配置
            configStr = Ini.Read("监听配置", "开指令");
            if (configStr != "null")
                textBox_opencmd.Text = configStr;
            configStr = Ini.Read("监听配置", "关指令");
            if (configStr != "null")
                textBox_closecmd.Text = configStr;
            //快速指令
            configStr = Ini.Read("快速指令", "类型");
            if (configStr != "null")
                comboBox_CmdType.Text = configStr;
            configStr = Ini.Read("快速指令", "设备ID");
            if (configStr != "null")
                textBox_CmdDeviceID.Text = configStr;
            configStr = Ini.Read("快速指令", "内容");
            if (configStr != "null")
                textBox_CmdStr.Text = configStr;
            #endregion
        }

        //接收监听进程
        private void RecMothed()
        {
            try
            {
                string str = string.Empty;
                int recv = 0;
                IPEndPoint sender1 = new IPEndPoint(IPAddress.Any, 0);
                EndPoint Remote = (EndPoint)(sender1);
                server.Bind(Remote);
                while (true)
                {
                    Thread.Sleep(10);
                    byte[] byt = new byte[1000];
                    recv = server.ReceiveFrom(byt, ref Remote);
                    str = Encoding.GetEncoding("GB2312").GetString(byt, 0, byt.Length);
                    LogMessage(string.Format("接收:{0}\n{1}", Remote, str));
                    str = str.Replace("\0", "");
                    DeviceHelper dh;
                    dh = GetJson(str);

                    if (dh.type == "set")
                    {
                        //是否监听设备
                        if (checkBox_ListenSwitch.Checked)
                        {
                            //判断用户ID和设备ID
                            if (dh.userid == textBox_UserID.Text)
                            {
                                if (dh.deviceid == textBox_DeviceId.Text)
                                {
                                    //状态判断
                                    if (dh.state == textBox_opencmd.Text)
                                    {
                                        dh.state = "已经开了";
                                        textBox_SwitchLed.BackColor = Color.Green;
                                    }
                                    else
                                    if (dh.state == textBox_closecmd.Text)
                                    {
                                        dh.state = "已经关了";
                                        textBox_SwitchLed.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        dh.state = "指令不匹配";
                                    }
                                }
                                else
                                {
                                    dh.state = "设备未就绪";
                                }

                                dh.type = "response";
                                bytes = Encoding.GetEncoding("GB2312").GetBytes(SetJson(dh));
                                server.SendTo(bytes, ip);
                                LogMessage(string.Format("响应:{0}", SetJson(dh)));
                            }
                        }
                    }
                    else if (dh.type == "get")
                    {
                        //是否监听设备
                        if (checkBox_ListenSwitch.Checked)
                        {
                            //判断用户ID和设备ID
                            if (dh.userid == textBox_UserID.Text)
                            {
                                if (dh.deviceid == textBox_DeviceId.Text)
                                {
                                    //状态判断
                                    if (textBox_SwitchLed.BackColor==Color.Green)
                                    {
                                        dh.state = "开着呢";
                                    }
                                    else
                                    if (dh.state == textBox_closecmd.Text)
                                    {
                                        dh.state = "关着呢";
                                    }
                                }
                                else
                                {
                                    dh.state = "设备未就绪";
                                }

                                dh.type = "response";
                                bytes = Encoding.GetEncoding("GB2312").GetBytes(SetJson(dh));
                                server.SendTo(bytes, ip);
                                LogMessage(string.Format("响应:{0}", SetJson(dh)));
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 转对象到JSON字符串
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="deviceid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static string SetJson(string type, string userid, string deviceid, string state)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            DeviceHelper info = new DeviceHelper();
            info.type = type;
            info.userid = userid;
            info.deviceid = deviceid;
            info.state = state;
            //转为json字符串
            string dd = js.Serialize(info);
            return dd;
        }

        public static string SetJson(DeviceHelper info)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            //转为json字符串
            string dd = js.Serialize(info);
            return dd;
        }

        /// <summary>
        /// 转JSON字符串为对象
        /// </summary>
        /// <param name="src">json格式的字符串</param>
        /// <returns></returns>
        public static DeviceHelper GetJson(string src)
        {
            DeviceHelper inf;
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                inf = new DeviceHelper();
                inf = js.Deserialize<DeviceHelper>(src);
                return inf;
            }
            catch
            {
                inf = new DeviceHelper();
                return inf;
            }
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            //待发送内容
            string str = textBox_SendStr.Text;
            if (server == null)
            {
                LogError("请打开连接！");
                return;
            }

            if (str.Length == 0)
            {
                LogWarning("发送内容不能为空！");
                return;
            }
            //发送数据
            try
            {
                bytes = Encoding.GetEncoding("GB2312").GetBytes(str);
                server.SendTo(bytes, ip);
                LogMessage(string.Format("发送:{0}", str));
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
            {
                server.Close();
                server.Dispose();
            }

            if (recThread != null)
            {

                recThread.Abort();
            }
        }

        private void timer_Heart_Tick(object sender, EventArgs e)
        {
            //第一次设置10ms
            if (timer_Heart.Interval == 10)
            {
                timer_Heart.Interval = int.Parse(comboBox_HeartCirle.Text) * 1000;
            }
            try
            {
                DeviceHelper dh = new DeviceHelper();
                dh.type = "identity";
                dh.userid = textBox_UserID.Text;
                dh.deviceid = textBox_DeviceId.Text;
                dh.state = " ";
                string str = SetJson(dh);
                bytes = Encoding.GetEncoding("GB2312").GetBytes(str);
                server.SendTo(bytes, ip);
                LogMessage(string.Format("心跳包:{0}", str));

                label_HeartLed.ForeColor = Color.Red;
                Thread thh = new Thread(Heart);
                thh.Start();
                
            }
            catch (Exception ex)
            {
                LogError(ex.ToString());
            }
        }

        private void Heart()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                Thread.Sleep(200);
                label_HeartLed.ForeColor = Color.LightGray;
            }));
        }

        #region ip和port 有效性判断
        /// <summary>
        /// ip的有效性
        /// </summary>
        /// <param name="ip">IP</param>
        /// <returns></returns>
        public bool IP_YN(String ip)
        {
            bool YN = false;
            if (Regex.IsMatch(ip, "[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}"))
            {
                string[] ips = ip.Split('.');
                if (ips.Length == 4)
                    if (System.Int32.Parse(ips[0]) < 256 && System.Int32.Parse(ips[1]) < 256
                          && System.Int32.Parse(ips[2]) < 256 && System.Int32.Parse(ips[3]) < 256)
                    {
                        YN = true;
                    }
            }
            return YN;
        }
        /// <summary>
        /// port有效性
        /// </summary>
        /// <param name="port">端口</param>
        /// <returns></returns>
        public bool PORT_YN(String port)
        {
            bool YN = true;
            if (port.Length == 0)
            {
                YN = false;
            }
            else//没有非数字字符
            {
                for (int i = 0; i < port.Length; i++)
                    if (!char.IsNumber(port, i))
                        YN = false;
            }
            if (YN)//介于0-65535之间
            {
                if ((int.Parse(port) > 0) && (int.Parse(port) < 65535))
                {
                    YN = true;
                }
            }
            return YN;

        }
        #endregion

        #region 点击事件
        //连接按钮事件
        private void button4_Click(object sender, EventArgs e)
        {
            if (button_Connect.Text == "连接")
            {
                //判断IP有效性
                string ipStr = textBox_ServerIP.Text.Trim();
                if (!IP_YN(ipStr))
                {
                    LogError("IP不合法,请检查IP地址！");
                    return;
                }
                //判断Port有效性
                string portStr = textBox_ServerPort.Text.Trim();
                if (!PORT_YN(portStr))
                {
                    LogError("端口不合法,请检查端口配置！");
                    return;
                }

                //合法就继续执行
                button_Connect.Text = "断开";
                LogMessage("连接成功！");
                label_StateLED.ForeColor = Color.Red;
                bytes = new byte[1024];
                ip = new IPEndPoint(IPAddress.Parse(ipStr), int.Parse(portStr));
                server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                recThread = new Thread(RecMothed);
                recThread.Start();

                //////////////////
                textBox_ServerIP.ReadOnly = true;
                textBox_ServerPort.ReadOnly = true;
            }
            else
            {
                button_Connect.Text = "连接";
                LogMessage("已断开连接！");
                label_StateLED.ForeColor = Color.Black;
                recThread.Abort();
                server.Close();
                server.Dispose();
                server = null;
                //////////////////
                textBox_ServerIP.ReadOnly = false;
                textBox_ServerPort.ReadOnly = false;
                checkBox_Heart.Checked = false;
            }
        }

        //清空接收区
        private void button_clearRes_Click(object sender, EventArgs e)
        {
            richTextBox_Msg.Clear();
        }

        //清空发送区
        private void button2_Click(object sender, EventArgs e)
        {
            textBox_SendStr.Clear();
        }

        //勾选自动心跳
        private void checkBox_Heart_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_Heart.Checked)
            {
                //判断连接
                if (server == null)
                {
                    LogError("请打开连接！");
                    checkBox_Heart.Checked = false;
                    return;
                }
                //判断周期
                if (int.Parse(comboBox_HeartCirle.Text) < 5)
                {
                    LogError("心跳周期不能小于5秒！");
                    checkBox_Heart.Checked = false;
                    return;
                }

                //启动定时器
                timer_Heart.Interval = 10;
                timer_Heart.Start();
                comboBox_HeartCirle.Enabled = false;
                textBox_UserID.ReadOnly = true;
                textBox_DeviceId.ReadOnly = true;

                //开始监听
                checkBox_ListenSwitch.Checked = true;
            }
            else
            {
                //关闭定时器
                timer_Heart.Stop();
                textBox_DeviceId.ReadOnly = false;
                comboBox_HeartCirle.Enabled = true;
                textBox_UserID.ReadOnly = false;
            }
        }

        //心跳周期变化
        private void comboBox_HeartCirle_SelectedIndexChanged(object sender, EventArgs e)
        {
            //更新定时器频率
            timer_Heart.Interval = int.Parse(comboBox_HeartCirle.Text) * 1000;
            //存储配置
            Ini.Write("心跳配置", "周期", comboBox_HeartCirle.Text);
        }

        //用户id变化
        private void textBox_UserID_TextChanged(object sender, EventArgs e)
        {
            //存储配置
            Ini.Write("心跳配置", "用户ID", textBox_UserID.Text);
        }

        //设备id变化
        private void textBox_DeviceId_TextChanged_1(object sender, EventArgs e)
        {
            //存储配置
            Ini.Write("心跳配置", "设备ID", textBox_DeviceId.Text);
        }
        //服务器IP变化
        private void textBox_ServerIP_TextChanged(object sender, EventArgs e)
        {
            //判断IP有效性
            string ipStr = textBox_ServerIP.Text.Trim();
            if (IP_YN(ipStr))
            {
                //存储配置
                Ini.Write("网络配置", "IP", ipStr);
            }
        }

        //服务器端口变化
        private void textBox_ServerPort_TextChanged(object sender, EventArgs e)
        {
            //判断Port有效性
            string portStr = textBox_ServerPort.Text.Trim();
            if (PORT_YN(portStr))
            {
                //存储配置
                Ini.Write("网络配置", "Port", textBox_ServerPort.Text);
            }
        }

        //监听设备ID
        private void textBox_DeviceId_TextChanged(object sender, EventArgs e)
        {
            //存储配置
            Ini.Write("监听配置", "设备ID", textBox_DeviceId.Text);
        }

        //开指令变化
        private void textBox_opencmd_TextChanged(object sender, EventArgs e)
        {
            //存储配置
            Ini.Write("监听配置", "开指令", textBox_opencmd.Text);
        }
        //关指令变化
        private void textBox_closecmd_TextChanged(object sender, EventArgs e)
        {
            //存储配置
            Ini.Write("监听配置", "关指令", textBox_closecmd.Text);
        }
        //快速指令-类型
        private void comboBox_CmdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //存储配置
            Ini.Write("快速指令", "类型", comboBox_CmdType.Text);
        }
        //快速指令-设备ID
        private void textBox_CmdDeviceID_TextChanged(object sender, EventArgs e)
        {
            //存储配置
            Ini.Write("快速指令", "设备ID", textBox_CmdDeviceID.Text);
        }
        //快速指令-内容
        private void textBox_CmdStr_TextChanged(object sender, EventArgs e)
        {
            //存储配置
            Ini.Write("快速指令", "内容", textBox_CmdStr.Text);
        }

        //生成指令
        private void button_CreatCmd_Click(object sender, EventArgs e)
        {
            DeviceHelper dh = new DeviceHelper();
            dh.type = comboBox_CmdType.Text;
            dh.userid = textBox_UserID.Text.Trim();
            dh.deviceid = textBox_CmdDeviceID.Text.Trim();
            dh.state = textBox_CmdStr.Text;

            //用户id检查
            if (dh.userid.Length == 0)
            {
                LogWarning("用户ID不能为空,请检查心跳配置中用户ID！");
                return;
            }
            if (!Regex.IsMatch(dh.userid, "[0-9]{13}"))
            {
                LogWarning("用户ID不合法，用户ID由13位纯数字组成，请认真核对！");
                return;
            }
            //设备ID检查
            if (dh.deviceid.Length == 0)
            {
                LogWarning("设备ID不能为空,请检查！");
                return;
            }
            if (!Regex.IsMatch(dh.deviceid, "[0-9]{0,11}"))
            {
                LogWarning("设备ID不合法，设备ID由纯数字组成，请认真核对！");
                return;
            }
            //指令内容检查
            if (dh.state.Length == 0)
            {
                LogWarning("指令内容不能为空，请核对！");
                return;
            }

            textBox_SendStr.Text = SetJson(dh);
        }

        private void checkBox_ListenSwitch_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_ListenSwitch.Checked)
            {
                if (server == null)
                {
                    LogError("请打开连接！");
                    checkBox_ListenSwitch.Checked = false;
                    return;
                }

                string idStr = textBox_DeviceId.Text;
                //设备ID检查
                if (idStr.Length == 0)
                {
                    LogWarning("设备ID不能为空,请检查！");
                    checkBox_ListenSwitch.Checked = false;
                    return;
                }
                if (!Regex.IsMatch(idStr, "[0-9]{0,11}"))
                {
                    LogWarning("设备ID不合法，设备ID由纯数字组成，请认真核对！");
                    checkBox_ListenSwitch.Checked = false;
                    return;
                }

                textBox_opencmd.ReadOnly = true;
                textBox_closecmd.ReadOnly = true;
            }
            else
            {
                textBox_opencmd.ReadOnly = false;
                textBox_closecmd.ReadOnly = false;
            }
        }
        #endregion


    }

    /// <summary>
    /// 通信协议类
    /// </summary>
    public class DeviceHelper
    {
        public string type;//消息类型
        public string userid;//用户ID
        public string deviceid;//设备ID
        public string state;   //设备状态
    }
}

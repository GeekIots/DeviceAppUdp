using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Threading;
using System.Drawing;

namespace DeviceApp
{
    public partial class Form1 : Form
    {
        byte[] bytes = new byte[1024];
        IPEndPoint ip;
        Socket server;
        Thread recThread;
        int num = 0;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public void addText(string str)
        {
            textBox7.AppendText(str);     // 追加文本，并且使得光标定位到插入地方。
            textBox7.ScrollToCaret();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            //LED.BackColor = Color.Red;
        }


        private void RecMothed()
        {
            try
            {
                string str = string.Empty;
                int recv = 0;
                IPEndPoint sender1 = new IPEndPoint(IPAddress.Any, 0);
                EndPoint Remote = (EndPoint)(sender1);
                server.Bind(Remote);
                addText("已启动监听！\r\n\r\n");
                while (true)
                {
                    Thread.Sleep(10);
                    byte[] byt = new byte[1000];
                    recv = server.ReceiveFrom(byt, ref Remote);
                    addText(string.Format("Rec From:{0}\r\n", Remote));
                    str = Encoding.GetEncoding("GB2312").GetString(byt, 0, byt.Length);
                    addText("Msg:" + str + "\r\n\r\n");
                    str = str.Replace("\0", "");
                    DeviceHelper dh;
                    dh = GetJson(str);
                    if (dh.type == "set" || dh.type == "get")
                    {
                        textBox6.Text = dh.deviceid;
                        textBox5.Text = dh.state;
                    }
                    if (dh.type == "set")
                    {
                        num++;
                        //labelSet.Text = num.ToString();
                        //返回数据
                        if (dh.state == textBox_opencmd.Text)
                        {
                            dh.state = "灯已经开了";
                            //LED.BackColor = Color.Green;
                        }
                        else
                        if (dh.state == textBox_closecmd.Text)
                        {
                            dh.state = "灯已经关了";
                            //LED.BackColor = Color.Red;
                        }
                        else
                        {
                            dh.state = "已经响应指令：" + dh.state;
                        }
                        dh.type = "response";
                        bytes = Encoding.GetEncoding("GB2312").GetBytes(SetJson(dh));
                        server.SendTo(bytes, ip);
                        addText(string.Format("To Sever:{0}\r\n\r\n", SetJson(dh)));
                    }
                    else
                    if (dh.type == "get")
                    {
                        //返回数据
                        //if (LED.BackColor == Color.Green)
                        //{
                        //    dh.state = "客厅灯现在开着呢！";
                        //}
                        //else
                        //if (LED.BackColor == Color.Red)
                        //{
                        //    dh.state = "客厅灯现在关着呢！";
                        //}
                        dh.type = "response";
                        bytes = Encoding.GetEncoding("GB2312").GetBytes(SetJson(dh));
                        server.SendTo(bytes, ip);
                        addText(string.Format("To Sever:{0}\r\n\r\n", SetJson(dh)));
                    }
                }
            }
            catch
            {  }
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

        private void button1_Click(object sender, EventArgs e)
        {
            //发送数据
            try
            {
                DeviceHelper dh = new DeviceHelper();
               // dh.type = comboBox1.Text;
                dh.userid = textBox3.Text;
                dh.deviceid = textBox6.Text;
                dh.state = textBox5.Text;
                string str = SetJson(dh);
                bytes = Encoding.GetEncoding("GB2312").GetBytes(str);
                server.SendTo(bytes, ip);
                addText(string.Format("To Sever:{0}\r\n\r\n", str));
            }
            catch (Exception ex)
            {
                addText(ex.ToString() + "\r\n\r\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Text = string.Empty;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (button3.Text == "停止")
            //{
            //    server.Close();
            //    recThread.Abort();
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10000;
            try
            {
                DeviceHelper dh = new DeviceHelper();
                dh.type = "identity";
                dh.userid = textBox3.Text;
                dh.deviceid = "1";
                dh.state = "";
                string str = SetJson(dh);
                bytes = Encoding.GetEncoding("GB2312").GetBytes(str);
                server.SendTo(bytes, ip);
                addText(string.Format("To Sever:{0}\r\n\r\n", str));
            }
            catch (Exception ex)
            {
                addText(ex.ToString() + "\r\n\r\n");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (button3.Text == "启动")
            //{
            //    button3.Text = "停止";
            //    bytes = new byte[1024];
            //    ip = new IPEndPoint(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));
            //    server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //    recThread = new Thread(RecMothed);
            //    recThread.Start();
            //    button1.Enabled = true;
            //    timer1.Enabled = true;
            //    timer1.Interval = 200;
            //    timer1.Start();
            //}
            //else
            //{
            //    button3.Text = "启动";
            //    addText("已停止服务！\r\n\r\n");
            //    button1.Enabled = false;
            //    recThread.Abort();
            //    server.Close();
            //    server.Dispose();
            //    timer1.Stop();
            //}
        }
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

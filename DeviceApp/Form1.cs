using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Threading;
using System.Drawing;
<<<<<<< HEAD
using System.IO;
using AForge;
using AForge.Controls;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using MySql.Data.MySqlClient;
=======
>>>>>>> parent of c67c1ad... 1

namespace DeviceApp
{
    public partial class Form1 : Form
    {
        byte[] bytes = new byte[1024];
        IPEndPoint ip;
        Socket server;
        Thread recThread;
        Thread ThSendVideo;//视频传输线程

        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        public int selectedDeviceIndex = 0;
        //创建数据库连接对象
        MySqlConnection mysql = getMySqlCon();



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
            LED.BackColor = Color.Red;
        }

        //视频发送
        void SendVideo()
        {
            while (true)
            {
                Thread.Sleep(10);
                //更新图像
                if (cammer)//摄像头打开了
                {
                    //获取图像1280*720
                    Bitmap bit1 = videoSourcePlayer1.GetCurrentVideoFrame();
                    //缩放处理
                    Bitmap bit = ResizeImage(bit1, 320, 180);
                    //编码压缩
                    base64 = ToBase64(bit);
                    //释放资源
                    bit1.Dispose();
                    bit.Dispose();
                    //循环发送视频流数据
                    int i = 0;
                    while (base64.Length>0)
                    {
                        i++;
                        DeviceHelper dh = new DeviceHelper();
                        dh.type = "uploadpicture";
                        dh.userid = textBox3.Text;
                        dh.deviceid = i.ToString();//包序号

                        if (base64.Length >= 1300)
                        {
                            dh.state = base64.Substring(0, 1300);//数据
                            base64 = base64.Remove(0, 1300);
                        }
                        else
                        {
                            dh.state = base64;//数据
                            base64 = "";
                            dh.deviceid = "ok";
                        }
                        string str = SetJson(dh);
                        bytes = Encoding.GetEncoding("GB2312").GetBytes(str);
                        server.SendTo(bytes, ip);
                        addText(string.Format("To Sever:{0}\r\n\r\n", i.ToString()));
                        Thread.Sleep(30);
                    }


                    // videoupdata(base64);
                }
            }

        }
        string base64 = string.Empty;
        private void RecMothed()
        {
            string str = string.Empty;
            int recv = 0;
            int num = 0;
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
                    labelSet.Text = num.ToString();
                    //返回数据
                    if (dh.state == textBox_opencmd.Text)
                    {
                        dh.state = "灯已经开了";
                        LED.BackColor = Color.Green;
                    }
                    else
                    if (dh.state == textBox_closecmd.Text)
                    {
                        dh.state = "灯已经关了";
                        LED.BackColor = Color.Red;
                    }
                    else
                    {
                        dh.state = "已经响应指令："+ dh.state;
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
                    if (LED.BackColor == Color.Green)
                    {
                        dh.state = "客厅灯现在开着呢！";
                    }
                    else
                    if (LED.BackColor == Color.Red)
                    {
                        dh.state = "客厅灯现在关着呢！";
                    }
                    dh.type = "response";
                    bytes = Encoding.GetEncoding("GB2312").GetBytes(SetJson(dh));
                    server.SendTo(bytes, ip);
                    addText(string.Format("To Sever:{0}\r\n\r\n", SetJson(dh)));
                }
<<<<<<< HEAD
            }
        }

        ///
        /// Resize图片
        ///
        /// 原始Bitmap
        /// 新的宽度
        /// 新的高度
        /// 保留着，暂时未用
        /// 处理以后的图片
        public static Bitmap ResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }

        // ===============================
        ///
        /// 剪裁 -- 用GDI+
        ///
        /// 原始Bitmap
        /// 开始坐标X
        /// 开始坐标Y
        /// 宽度
        /// 高度
        /// 剪裁后的Bitmap
        public static Bitmap KiCut(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }
            int w = b.Width;
            int h = b.Height;
            if (StartX >= w || StartY >= h)
            {
                return null;
            }
            if (StartX + iWidth > w)
            {
                iWidth = w - StartX;
            }
            if (StartY + iHeight > h)
            {
                iHeight = h - StartY;
            }
            try
            {
                Bitmap bmpOut = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(bmpOut);
                g.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                g.Dispose();
                return bmpOut;
            }
            catch
            {
                return null;
=======
>>>>>>> parent of c67c1ad... 1
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

        private void button1_Click(object sender, EventArgs e)
        {
            //发送数据
            try
            {
                DeviceHelper dh = new DeviceHelper();
                dh.type = comboBox1.Text;
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
            if (button3.Text == "停止")
            {
                server.Close();
                recThread.Abort();
            }

            ThSendVideo.Abort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "启动")
            {
                button3.Text = "停止";
                bytes = new byte[1024];
                ip = new IPEndPoint(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));
                server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                recThread = new Thread(RecMothed);
                recThread.Start();
                button1.Enabled = true;
                //timer1.Enabled = true;
                //timer1.Interval = 200;
                //timer1.Start();

                ThSendVideo = new Thread(SendVideo);
                ThSendVideo.Start();
            }
            else
            {
                button3.Text = "启动";
                addText("已停止服务！\r\n\r\n");
                button1.Enabled = false;
                recThread.Abort();
                server.Close();
                server.Dispose();
                timer1.Stop();

                ThSendVideo.Abort();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10000;

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
<<<<<<< HEAD

        //图片转为base64编码的文本   
        private string ToBase64(Bitmap bmp)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                String strbaser64 = Convert.ToBase64String(arr);
                return strbaser64;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ImgToBase64String 转换失败 Exception:" + ex.Message);
                return "";
            }
        }

        //base64编码的文本转为图片  
        private void Base64StringToImage(string txtFileName)
        {
            try
            {
                FileStream ifs = new FileStream(txtFileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(ifs);

                String inputStr = sr.ReadToEnd();
                byte[] arr = Convert.FromBase64String(inputStr);
                MemoryStream ms = new MemoryStream(arr);
                Bitmap bmp = new Bitmap(ms);

                bmp.Save(txtFileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //bmp.Save(txtFileName + ".bmp", ImageFormat.Bmp);  
                //bmp.Save(txtFileName + ".gif", ImageFormat.Gif);  
                //bmp.Save(txtFileName + ".png", ImageFormat.Png);  
                ms.Close();
                sr.Close();
                ifs.Close();

                MessageBox.Show("转换成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Base64StringToImage 转换失败/nException：" + ex.Message);
            }
        }

        bool cammer = false;
        private void button4_Click(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            selectedDeviceIndex = 0;
            videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头。
            videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];
            videoSourcePlayer1.VideoSource = videoSource;
            // set NewFrame event handler
            videoSourcePlayer1.Start();
            cammer = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (videoSource == null)
                return;
            Bitmap bitmap = videoSourcePlayer1.GetCurrentVideoFrame();
            pictureBox1.Image = new Bitmap(bitmap);
            bitmap.Dispose();
        }



        /// <summary>
        /// 建立mysql数据库链接
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection getMySqlCon()
        {
            String mysqlStr = "Database=web;Data Source=120.27.45.38;User Id=root;Password=root;pooling=false;Connection Timeout = 1;CharSet=utf8;port=3306;";
            // String mySqlCon = ConfigurationManager.ConnectionStrings["MySqlCon"].ConnectionString;
            MySqlConnection mysql = new MySqlConnection(mysqlStr);
            return mysql;
        }
        /// <summary>
        /// 建立执行命令语句对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="mysql"></param>
        /// <returns></returns>
        public static MySqlCommand getSqlCommand(String sql, MySqlConnection mysql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
            //  MySqlCommand mySqlCommand = new MySqlCommand(sql);
            // mySqlCommand.Connection = mysql;
            return mySqlCommand;
        }
        /// <summary>
        /// 查询并获得结果集并遍历
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getResultset(MySqlCommand mySqlCommand)
        {
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                string rs = string.Empty;
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        rs += reader.GetInt32(0) + "  ";
                        for (int i = 1; i < reader.FieldCount; i++)
                            rs += reader.GetString(i) + "  ";
                        rs += "\r\n";
                    }
                }
                MessageBox.Show(rs);
            }
            catch (Exception)
            {

                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getInsert(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                MessageBox.Show(message);
                Console.WriteLine("插入数据失败了！" + message);
            }

        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getUpdate(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                String message = ex.Message;
                Console.WriteLine("修改数据失败了！" + message);
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getDel(MySqlCommand mySqlCommand)
        {
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                Console.WriteLine("删除数据失败了！" + message);
            }
        }

        //更新图像
        private void videoupdata(string base64)
        {
            try
            {
                //打开数据库
                mysql.Open();

                //修改sql
                String sqlUpdate = "update video set base64='" + base64 + "' where id = 0";
                MySqlCommand mySqlCommand = getSqlCommand(sqlUpdate, mysql);
                mySqlCommand.ExecuteNonQuery();

                //关闭
                mysql.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }

        }
=======
>>>>>>> parent of c67c1ad... 1
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

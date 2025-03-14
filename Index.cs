using HslCommunication.Instrument.Temperature;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using Asphalt;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asphalt
{
    /// <summary>
    /// 系统主窗体类，作为整个沥青生产控制系统的主界面和导航中心
    /// 负责管理系统的各个功能模块，如监控、报表、配方管理等
    /// 提供了界面导航、自适应布局和系统状态监控功能
    /// </summary>
    public partial class Index : Form
    {
        /// <summary>
        /// 窗体尺寸参数，用于自适应布局计算
        /// </summary>
        double x, y;         // 用于自适应
        
        /// <summary>
        /// 窗体最大化状态标记
        /// </summary>
        string bz = "最大化";
        
        /// <summary>
        /// 定时器，用于定期刷新系统状态
        /// </summary>
        private System.Threading.Timer timer = null;
        
        /// <summary>
        /// 监控界面实例，显示生产过程的实时状态
        /// </summary>
        public Monitor ui1 = null;
        
        /// <summary>
        /// 报表界面实例，用于生成和查看生产报表
        /// </summary>
        public Report ui2 = null;
        
        /// <summary>
        /// 配方管理界面实例，用于管理不同的生产配方
        /// </summary>
        public Formula ui3 = null;
        
        /// <summary>
        /// 参数范围设置界面实例，用于设定各项参数的正常范围
        /// </summary>
        public Range ui4 = null;
        
        /// <summary>
        /// 系统设置界面实例，用于配置系统参数
        /// </summary>
        public Setting ui5 = null;
        
        /// <summary>
        /// 生产曲线界面实例，用于查看生产参数的变化曲线
        /// </summary>
        public Curve ui6 = null;
        
        /// <summary>
        /// 重量校准界面实例，用于对称重系统进行校准
        /// </summary>
        public Weight ui7 = null;
        
        /// <summary>
        /// 电气控制界面实例，用于控制电气设备
        /// </summary>
        public Elec ui8 = null;
        
        /// <summary>
        /// 权限管理界面实例，用于管理用户权限
        /// </summary>
        public Permission ui10 = null;
        
        /// <summary>
        /// 延时设置界面实例，用于设置各个生产环节的延时参数
        /// </summary>
        public static Delays ui9 = null;
        
        /// <summary>
        /// 急停标志，true表示系统处于急停状态
        /// </summary>
        public static bool flag1 = false;       // 急停
        
        /// <summary>
        /// 系统开关标志，true表示系统已启动
        /// </summary>
        public static bool flag2 = false;       // 开关
        
        /// <summary>
        /// 操作模式标志，false表示手动模式，true表示自动模式
        /// </summary>
        public static bool flag3 = false;        // false手动，true自动
        
        /// <summary>
        /// 附加状态标志
        /// </summary>
        public static bool flag4 = false;
        
        /// <summary>
        /// 当前显示界面的ID，用于判断当前显示的是否为监控界面
        /// </summary>
        private int id;                         // 判断当前显示是否为监控界面
        
        /// <summary>
        /// 当前累计产量
        /// </summary>
        public static int curSum = 0;
        
        /// <summary>
        /// 设定累计产量
        /// </summary>
        public static int setSum = 0;

        /// <summary>
        /// 构造函数，初始化主窗体和各个功能模块
        /// </summary>
        public Index()
        {
            // 初始化窗体组件
            InitializeComponent();
            // 禁用跨线程调用检查，允许在非UI线程更新UI元素
            Control.CheckForIllegalCrossThreadCalls = false;
            // 设置导航栏停靠方式
            uiNavBar1.Dock = DockStyle.None;
            // 初始化显示界面ID为1(监控界面)
            id = 1;
            // 获取窗体初始尺寸，用于自适应布局计算
            x = this.Width;
            y = this.Height;
            
            // 初始化各个功能模块界面
            ui1 = new Monitor();
            ui2 = new Report();
            ui3 = new Formula();
            ui4 = new Range();
            ui5 = new Setting();
            ui6 = new Curve();
            ui7 = new Weight();
            ui8 = new Elec();
            ui9 = new Delays();
            ui10 = new Permission();
            
            // 将各个功能模块添加到主面板
            panel1.Controls.Add(ui1);
            panel1.Controls.Add(ui2);
            panel1.Controls.Add(ui3);
            panel1.Controls.Add(ui4);
            panel1.Controls.Add(ui5);
            panel1.Controls.Add(ui6);
            panel1.Controls.Add(ui7);
            panel1.Controls.Add(ui8);
            panel1.Controls.Add(ui9);
            ui10.TopLevel = false;      // ui10的父类为Form不同于其它界面的父类UserControl，不能直接Add
            ui10.Parent = panel1;
            ui10.Show();
            
            // 获取控件标签，用于自适应布局
            getTag(this);
            
            // 初始化定时器，定期刷新系统状态
            timer = new System.Threading.Timer(refresh, null, 0, Timeout.Infinite);
        }

        /// <summary>
        /// 定时刷新方法，用于更新系统状态和界面显示
        /// </summary>
        /// <param name="source">定时器回调参数</param>
        private void refresh(object source)
        {
            // 从PLC读取系统状态标志
            flag1 = (Plc.plc1.ReadByte("M10").Content & 4).Equals(4);
            flag2 = (Plc.plc1.ReadByte("M10").Content & 1).Equals(1);
            flag4 = (Plc.plc1.ReadByte("M9").Content & 16).Equals(16);
            autoFlag = !((Plc.plc1.ReadByte("M10").Content & 2).Equals(2));
            
            // 更新界面控件状态
            start.Image = flag2 ? global::Asphalt.Properties.Resources.绿色按钮3d : global::Asphalt.Properties.Resources.红色按钮3D;
            inStop.Image = flag1 ? global::Asphalt.Properties.Resources.绿色按钮3d : global::Asphalt.Properties.Resources.红色按钮3D;
            inStop.Image = flag4 ? global::Asphalt.Properties.Resources.绿色按钮3d : global::Asphalt.Properties.Resources.红色按钮3D;
            auto.SwitchStatus = autoFlag;
            
            // 设置下一次执行时间为200毫秒后
            timer.Change(200, Timeout.Infinite);
        }

        /// <summary>
        /// 获取控件标签方法，递归获取所有控件的尺寸和位置信息，用于自适应布局
        /// </summary>
        /// <param name="contr">要处理的控件</param>
        private void getTag(Control contr)
        {
            foreach (Control con in contr.Controls)
            {
                // 记录控件的宽度、高度、左边距、顶边距和字体大小
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                // 如果控件包含子控件，则递归处理
                if (con.Controls.Count > 0)
                {
                    getTag(con);
                }
            }
        }

        private void setTag(double xbl, double ybl, Control contr)
        {
            foreach (Control con in contr.Controls)
            {
                SetControlDoubleBuffer(this);
                SetControlDoubleBuffer(con);
                if (con.Tag != null)
                {
                    string[] myTag = con.Tag.ToString().Split(";");
                    if (myTag.Length > 0) con.Width = (int)Math.Round(double.Parse(myTag[0]) * xbl, 0);
                    if (myTag.Length > 1) con.Height = (int)Math.Round(double.Parse(myTag[1]) * ybl, 0);
                    if (myTag.Length > 2) con.Left = (int)Math.Round(double.Parse(myTag[2]) * xbl, 0);
                    if (myTag.Length > 3) con.Top = (int)Math.Round(double.Parse(myTag[3]) * ybl, 0);
                    if (myTag.Length > 4) con.Font = new Font(con.Font.Name, (int)Math.Round(double.Parse(myTag[4]) * ybl, 0));
                }
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(xbl, ybl, con);
                }
            }
        }

        public static void SetControlDoubleBuffer(Control cc)
        {
            // 双缓存防止最大化时图像闪烁
            cc.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance |
                         System.Reflection.BindingFlags.NonPublic).SetValue(cc, true, null);
        }

        private void max_click(object sender, EventArgs e)
        {

            if (bz == "最大化")
            {
                SetStyle(ControlStyles.UserPaint, true);
                SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景
                this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
                this.WindowState = FormWindowState.Maximized;
                double xbl = this.Width / x;
                double ybl = this.Height / y;
                setTag(xbl, ybl, this);
                ui1.changePage(true);
                uiNavBar1.NodeSize = new System.Drawing.Size((int)(130.0 / 1280 * Size.Width), (int)(45.0 / 760 * Size.Height));
                auto.Location = new Point((int)(1069 * xbl),(int)(7 * ybl));
                auto.Size = new Size((int)(68 * ybl), (int)(68 * ybl));
                auto.Font = new Font(auto.Font.FontFamily, 10);
                ui10.Maximize = 1;
                ui2.Maximize = 1;
                bz = "还原";
                pictureBox1.Image = global::Asphalt.Properties.Resources.还原;
            }
            else
            {
                double xbl = x / this.Width;  // 还原前的窗口宽度与当前窗口宽度的比例因子
                double ybl = y / this.Height; // 还原前的窗口高度与当前窗口高度的比例因子
                this.WindowState = FormWindowState.Normal;
                ui1.changePage(false);
                setTag(xbl, ybl, this);
                uiNavBar1.NodeSize = new System.Drawing.Size(130, 45);
                auto.Location = new Point(1069, 7);
                auto.Size = new Size(68, 68);
                auto.Font = new Font(auto.Font.FontFamily, 9);
                ui10.Maximize = 0;
                ui2.Maximize = 0;
                bz = "最大化";
                pictureBox1.Image = global::Asphalt.Properties.Resources.窗口最大化_操作_jurassic;
            }
        }

        private void index_Load(object sender, EventArgs e)
        {
            if (Limit.limit[0] >= 1)
            {
                ui1.BringToFront();
            }
            Splasher.Status = "初始化完毕............";
            Thread.Sleep(500);

            Splasher.Close();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void start_Click(object sender, EventArgs e)
        {
            if (Limit.limit[0] == 2)
            {
                if (!flag2)
                {
                    SumSetting sumSetting = new SumSetting();
                    if (sumSetting.ShowDialog() == DialogResult.OK)
                    {
                        curSum = 0;
                    }
                }
                else
                {
                    // 启动-->停止
                    // 置xxxxxx10
                    Plc.plc1.Write("M9", (byte)(Plc.plc1.ReadByte("M9").Content & 252 | 2));
                    Index.flag2 = false;
                }
                start.Image = flag2 ? global::Asphalt.Properties.Resources.绿色按钮3d : global::Asphalt.Properties.Resources.红色按钮3D;
            }
            else
            {
                MessageBox.Show("您没有权限使用此功能！");
            }
        }


        private void userLantern1_Load(object sender, EventArgs e)
        {

        }


        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }

        private void uiNavBar1_MenuItemClick(string itemText, int menuIndex, int pageIndex)
        {

            switch (itemText)
            {
                case "用户权限管理":
                    id = 10;
                    if (Limit.limit[1] >= 1)            // 账号具有查看及以上权限可打开
                    {

                        ui10.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("您没有权限使用此功能！");
                    }
                    break;
                case "系统参数设置":
                    id = 4;
                    if (Limit.limit[2] >= 1)
                    {
                        ui4.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("您没有权限使用此功能！");
                    }
                    break;
                case "参数设置":
                    id = 5;
                    if (Limit.limit[3] >= 1)
                    {
                        ui5.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("您没有权限使用此功能！");
                    }
                    break;
                case "配方设置":
                    id = 3;
                    if (Limit.limit[4] >= 1)
                    {
                        ui3.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("您没有权限使用此功能！");
                    }
                    break;
                case "温度曲线":
                    id = 6;
                    if (Limit.limit[6] >= 1)
                    {
                        ui6.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("您没有权限使用此功能！");
                    }
                    break;
                case "电流曲线":
                    id = 8;
                    if (Limit.limit[6] >= 1)
                    {
                        ui8.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("您没有权限使用此功能！");
                    }
                    break;
                case "重量曲线":
                    id = 7;
                    if (Limit.limit[6] >= 1)
                    {
                        ui7.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("您没有权限使用此功能！");
                    }
                    break;
                case "日报表":
                    id = 2;
                    if (Limit.limit[5] >= 1)
                    {
                        ui2.Flag = 1;
                        ui2.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("您没有权限使用此功能！");
                    }
                    break;
                case "周报表":
                    id = 2;
                    if (Limit.limit[5] >= 1)
                    {
                        ui2.Flag = 2;
                        ui2.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("您没有权限使用此功能！");
                    }
                    break;
                case "月报表":
                    id = 2;
                    if (Limit.limit[5] >= 1)
                    {
                        ui2.Flag = 3;
                        ui2.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("您没有权限使用此功能！");
                    }
                    break;
                case "年报表":
                    id = 2;
                    if (Limit.limit[5] >= 1)
                    {
                        ui2.Flag = 4;
                        ui2.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("您没有权限使用此功能！");
                    }
                    break;
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (Limit.limit[0] == 2)
            {
                // 急停状态M10.2
                if (flag1)
                {
                    // M9.2 急停：xxxxx0xx；或11111011
                    Plc.plc1.Write("M9", (byte)(Plc.plc1.ReadByte("M9").Content & 251));
                    flag1 = false;
                }
                else
                {
                    // M9.2 急停：xxxxx1xx；或00000100
                    Plc.plc1.Write("M9", (byte)(Plc.plc1.ReadByte("M9").Content | 4));
                    flag1 = true;
                }
                inStop.Image = flag1 ? global::Asphalt.Properties.Resources.绿色按钮3d : global::Asphalt.Properties.Resources.灰色按钮3d;
            }
            else
            {
                MessageBox.Show("您没有权限使用此功能！");
            }
        }

        public static bool autoFlag = false;
        private void auto_Click(object sender, EventArgs e)
        {
            if (Limit.limit[0] == 2)
            {
                // 控件是先变化的，所以此时true的时候是手动变自动了
                if (autoFlag)
                {
                    // 自动->手动
                    auto.SwitchStatus = false;
                    Plc.plc1.Write("M9", (byte)(Plc.plc1.ReadByte("M9").Content | 8));
                    autoFlag = false;
                }
                else
                {
                    // 手动->自动
                    auto.SwitchStatus = true;
                    Plc.plc1.Write("M9", (byte)(Plc.plc1.ReadByte("M9").Content & 247));
                    autoFlag = true;
                }
            }
            else
            {
                auto.SwitchStatus = true;
                MessageBox.Show("您没有权限使用此功能！");
            }
        }


        private void close_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("确定要退出吗?", "退出系统", messButton);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            if (id == 1)
            {
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("确定要重新登陆吗?", "注销系统", messButton);
                if (dr == DialogResult.OK)
                {
                    System.Windows.Forms.Application.Restart();
                }
            }
            else
            {
                id = 1;
                if (Limit.limit[0] >= 1)
                {
                    ui1.BringToFront();
                }
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void back_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(back, "返回");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            if (bz == "最大化")
                toolTip.SetToolTip(pictureBox1, "最大化");
            else
                toolTip.SetToolTip(pictureBox1, "还原");
        }

        private void min_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(min, "最小化");
        }

        private void close_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(close, "关闭");
        }

		private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

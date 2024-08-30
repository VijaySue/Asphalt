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
    public partial class Index : Form
    {
        double x, y;         // 用于自适应
        string bz = "最大化";
        private System.Threading.Timer timer = null;
        public Monitor ui1 = null;
        public Report ui2 = null;
        public Formula ui3 = null;
        public Range ui4 = null;
        public Setting ui5 = null;
        public Curve ui6 = null;
        public Weight ui7 = null;
        public Elec ui8 = null;
        public Permission ui10 = null;
        public static Delays ui9 = null;
        public static bool flag1 = false;       // 急停
        public static bool flag2 = false;       // 开关
        public static bool flag3 = false;        // false手动，true自动
        public static bool flag4 = false;
        private int id;                         // 判断当前显示是否为监控界面
        public static int curSum = 0;
        public static int setSum = 0;

        public Index()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            uiNavBar1.Dock = DockStyle.None;
            id = 1;
            x = this.Width;
            y = this.Height;
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
            getTag(this);
            timer = new System.Threading.Timer(refresh, null, 0, Timeout.Infinite);
        }

        private void refresh(object source)
        {
            flag1 = (Plc.plc1.ReadByte("M10").Content & 4).Equals(4);
            flag2 = (Plc.plc1.ReadByte("M10").Content & 1).Equals(1);
            flag4 = (Plc.plc1.ReadByte("M9").Content & 16).Equals(16);
            autoFlag = !((Plc.plc1.ReadByte("M10").Content & 2).Equals(2));
            start.Image = flag2 ? global::Asphalt.Properties.Resources.绿色按钮3d : global::Asphalt.Properties.Resources.红色按钮3D;
            inStop.Image = flag1 ? global::Asphalt.Properties.Resources.绿色按钮3d : global::Asphalt.Properties.Resources.红色按钮3D;
            inStop.Image = flag4 ? global::Asphalt.Properties.Resources.绿色按钮3d : global::Asphalt.Properties.Resources.红色按钮3D;
            auto.SwitchStatus = autoFlag;
            timer.Change(200, Timeout.Infinite);
        }

        private void getTag(Control contr)
        {
            foreach (Control con in contr.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asphalt
{
    public partial class SwitchElec : Form
    {
        string name = null;
        byte[] data = {1, 2, 4, 8, 16, 32, 64, 128};
        private Dictionary<string, (int, int, int)> dict = new Dictionary<string, (int, int, int)>()
        {
            {"胶粉左投料电机正转",  (2, 3, 5) },
            {"胶粉左投料电机反转",  (2, 3, 6) },
            {"胶粉分料电机正转",  (2, 4, 1) },
            {"胶粉分料电机反转",  (2, 4, 2) },
            {"胶粉右投料电机正转",  (3, 3, 2) },
            {"胶粉右投料电机反转",  (3, 3, 3) },
            {"SBS喂料电机正转", (1, 3, 4) },
            {"SBS喂料电机反转", (1, 5, 1) },
            {"T2喂料电机正转", (1, 3, 5) },
            {"T2喂料电机反转", (1, 5, 2) },
        };
        private bool flag;

        public SwitchElec(string name)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.label1.Text = name + "手动开关";
            this.name = name;
            int a = dict[name + "正转"].Item1, b = dict[name + "正转"].Item2, c = dict[name + "正转"].Item3;
            int x = dict[name + "反转"].Item2, y = dict[name + "反转"].Item3;
            if (a == 1)
            {
                if ((Plc.plc1.ReadByte("M" + b.ToString()).Content & data[c]) == 0 && (Plc.plc1.ReadByte("M" + x.ToString()).Content & data[y]) == 0) {
                    uiSwitch2.Active = false;
                }
                else if ((Plc.plc1.ReadByte("M" + b.ToString()).Content & data[c]) == data[c]) {
                    uiSwitch2.Active = true;
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;    
                }
                else { 
                    uiSwitch2.Active = true;
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }
            }
            else if (a == 2)
            {
                if ((Plc.plc2.ReadByte("M" + b.ToString()).Content & data[c]) == 0 && (Plc.plc2.ReadByte("M" + x.ToString()).Content & data[y]) == 0)
                {
                    uiSwitch2.Active = false;
                }
                else if ((Plc.plc2.ReadByte("M" + b.ToString()).Content & data[c]) == data[c])
                {
                    uiSwitch2.Active = true;
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else
                {
                    uiSwitch2.Active = true;
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }
            }
            else if (a == 3)
            {
                if ((Plc.plc3.ReadByte("M" + b.ToString()).Content & data[c]) == 0 && (Plc.plc3.ReadByte("M" + x.ToString()).Content & data[y]) == 0) {
                    uiSwitch2.Active = false;
                }
                else if ((Plc.plc3.ReadByte("M" + b.ToString()).Content & data[c]) == data[c]) {
                    uiSwitch2.Active = true;
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;    
                }
                else {
                    uiSwitch2.Active = true;
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }
            }
            flag = uiSwitch2.Active;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void switchElec_Load(object sender, EventArgs e)
        {

        }

        private void uiSwitch2_ValueChanged(object sender, bool value)
        {

        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            int a = dict[name + "正转"].Item1, b = dict[name + "正转"].Item2, c = dict[name + "正转"].Item3;
            int x = dict[name + "反转"].Item2, y = dict[name + "反转"].Item3;
            if (uiSwitch2.Active == false)      //开关为0,正反转地址的值全部复位
            {
                if (a == 1)
                {
                    Plc.plc1.Write("M" + b.ToString(), (byte)((Plc.plc1.ReadByte("M" + b.ToString()).Content) & (255 - data[c])));
                    Plc.plc1.Write("M" + x.ToString(), (byte)((Plc.plc1.ReadByte("M" + x.ToString()).Content) & (255 - data[y])));
                }
                else if (a == 2)
                {
                    Plc.plc2.Write("M" + b.ToString(), (byte)((Plc.plc2.ReadByte("M" + b.ToString()).Content) & (255 - data[c])));
                    Plc.plc2.Write("M" + x.ToString(), (byte)((Plc.plc2.ReadByte("M" + x.ToString()).Content) & (255 - data[y])));
                }
                else if (a == 3)
                {
                    Plc.plc3.Write("M" + b.ToString(), (byte)((Plc.plc3.ReadByte("M" + b.ToString()).Content) & (255 - data[c])));
                    Plc.plc3.Write("M" + x.ToString(), (byte)((Plc.plc3.ReadByte("M" + x.ToString()).Content) & (255 - data[y])));
                }
            }
            else
            {
                if (flag)
                {
                    MessageBox.Show("请勿重复设置，请先关闭后再次设置！");
                }
                if (radioButton1.Checked)
                {
                    if (a == 1)
                    {
                        Plc.plc1.Write("M" + b.ToString(), (byte)((Plc.plc1.ReadByte("M" + b.ToString()).Content) | data[c]));
                    }
                    else if (a == 2)
                    {
                        Plc.plc2.Write("M" + b.ToString(), (byte)((Plc.plc2.ReadByte("M" + b.ToString()).Content) | data[c]));
                    }
                    else if (a == 3)
                    {
                        Plc.plc3.Write("M" + b.ToString(), (byte)((Plc.plc3.ReadByte("M" + b.ToString()).Content) | data[c]));
                    }
                }
                else if ((radioButton2.Checked))
                {
                    if (a == 1)
                    {
                        Plc.plc1.Write("M" + x.ToString(), (byte)((Plc.plc1.ReadByte("M" + x.ToString()).Content) | data[y]));
                    }
                    else if (a == 2)
                    {
                        Plc.plc2.Write("M" + x.ToString(), (byte)((Plc.plc2.ReadByte("M" + x.ToString()).Content) | data[y]));
                    }
                    else if (a == 3)
                    {
                        Plc.plc3.Write("M" + x.ToString(), (byte)((Plc.plc3.ReadByte("M" + x.ToString()).Content) | data[y]));
                    }
                }
                else
                {
                    MessageBox.Show("请选择运行方式！");
                }
            }
            Close();
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void SwitchElec_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
    }
}

using Asphalt.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asphalt
{
    public partial class Manual : Form
    {
        string[] name = null;
        byte[] data = {1, 2, 4, 8, 16, 32, 64, 128};
        bool flag = false;
        private Dictionary<string, (int, int, int)> dict = new Dictionary<string, (int, int, int)>()
        {
            {"生产罐1燃烧器",  (2, 0, 0) },       //分别表示Plc编号，地址整数位，地址小数位
            {"生产罐2燃烧器",  (2, 0, 1) },
            {"生产罐3燃烧器",  (2, 0, 2) },
            {"生产罐4燃烧器",  (2, 0, 3) },
            {"生产罐5燃烧器",  (3, 3, 6) },
            {"生产罐6燃烧器",  (3, 3, 7) },
            {"生产罐7燃烧器",  (3, 4, 0) },
            {"生产罐8燃烧器",  (3, 0, 0) },
            {"生产罐1搅拌电机",  (2, 3, 1) },
            {"生产罐2搅拌电机",  (2, 3, 2) },
            {"生产罐3搅拌电机",  (2, 3, 3) },
            {"生产罐4搅拌电机",  (2, 3, 4) },
            {"生产罐5搅拌电机",  (3, 2, 6) },
            {"生产罐6搅拌电机",  (3, 2, 7) },
            {"生产罐7搅拌电机",  (3, 3, 0) },
            {"生产罐8搅拌电机",  (3, 3, 1) },
            {"胶粉提升电机",  (2, 4, 3) },
            {"胶粉喂料电机",  (2, 4, 4) },
            {"添加剂投料电机",  (3, 4, 1) },
            {"预混罐1搅拌电机", (1, 0, 0) },
            {"预混罐1搅拌电机油泵", (1, 0, 1) },
            {"预混罐2搅拌电机", (1, 0, 2) },
            {"预混罐2搅拌电机油泵", (1, 0, 3) },
            {"上料增压泵", (1, 0, 4) },
            {"喂料泵1", (1, 0, 6) },
            {"喂料泵2", (1, 0, 7) },
            {"喂料泵3", (1, 1, 0) },
            {"喂料泵4", (1, 1, 1) },
            {"出料一剪机油泵", (1, 1, 2) },
            {"周转罐搅拌电机油泵", (1, 1, 3) },
            {"二剪机油泵", (1, 1, 4) },
            {"成品泵", (1, 1, 5) },
            {"预混上料泵", (1, 3, 6) },
            {"基质沥青上料泵", (1, 3, 7) },
            {"预混一剪机", (1, 4, 0) },
            {"预混一剪机油泵", (1, 0, 5) },
            {"喂料电机", (1, 4, 1) },
            {"出料一剪机", (1, 4, 2) },
            {"周转罐搅拌电机", (1, 4, 3) },
            {"二剪喂料泵", (1, 4, 4) },
            {"二剪机", (1, 4, 5) },
            {"周转罐燃烧器", (1, 5, 3) },
            {"T4搅拌电机", (2, 3, 7) },
            {"T4投料电机", (3, 3, 4) }
        };


        public Manual(string[] name)
        {
            InitializeComponent();
            this.name = name;
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text = name[0] + "手动开关";
            int a = dict[name[0]].Item1, b = dict[name[0]].Item2, c = dict[name[0]].Item3;
            if (a == 1)
            {
                if ((Plc.plc1.ReadByte("M" + b.ToString()).Content & data[c]).Equals(data[c])) this.uiSwitch2.Active= true;
                else this.uiSwitch2.Active = false;
            }
            else if (a == 2) 
            {
                if ((Plc.plc2.ReadByte("M" + b.ToString()).Content & data[c]).Equals(data[c])) this.uiSwitch2.Active= true;
                else this.uiSwitch2.Active = false;
            } 
            else
            { 
                if ((Plc.plc3.ReadByte("M" + b.ToString()).Content & data[c]).Equals(data[c])) this.uiSwitch2.Active= true;
                else this.uiSwitch2.Active = false;
            }
            flag = uiSwitch2.Active;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (this.uiSwitch2.Active != flag)
            {
                foreach (string s in name)
                {
                    int a = dict[s].Item1, b = dict[s].Item2, c = dict[s].Item3;
                    if (a == 1)
                    {
                        Plc.plc1.Write("M" + b.ToString(), (byte)((Plc.plc1.ReadByte("M" + b.ToString()).Content) ^ data[c]));
                    }
                    else if (a == 2) 
                    {
                        Plc.plc2.Write("M" + b.ToString(), (byte)((Plc.plc2.ReadByte("M" + b.ToString()).Content) ^ data[c]));
                    } 
                    else
                    { 
                        Plc.plc3.Write("M" + b.ToString(), (byte)((Plc.plc3.ReadByte("M" + b.ToString()).Content) ^ data[c]));
                    }
                }
            }
            this.Close();
        }

        
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002; 

        private void Manual_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
    }
}

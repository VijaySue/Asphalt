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
    public partial class Production : Form
    {
        private int idx;
        private Dictionary<string, string> dict = new Dictionary<string, string>()
        {
            {"jfsdz1",  "VD300" },   
            {"jfsdz2",  "VD296" }, 
            {"jfsdz3",  "VD292" },
            {"jfsdz4",  "VD288" },
            {"jfsdz5",  "VD300" },
            {"jfsdz6",  "VD296" },
            {"jfsdz7",  "VD292" },
            {"jfsdz8",  "VD288" },
            {"jftql1", "VD364" },
            {"jftql2", "VD360" },
            {"jftql3", "VD356" },
            {"jftql4", "VD352" },
            {"jftql5", "VD364" },
            {"jftql6", "VD360" },
            {"jftql7", "VD356" },
            {"jftql8", "VD352" },
            {"zzgbys1", "VW1420" },
            {"zzgbys2", "VW1418" },
            {"zzgbys3", "VW1416" },
            {"zzgbys4", "VW1414" },
            {"zzgbys5", "VW1420" },
            {"zzgbys6", "VW1418" },
            {"zzgbys7", "VW1416" },
            {"zzgbys8", "VW1414" },
            {"zzys4",  "VW1412" },
            {"fzds4",  "VW1410" },
            {"zzys8",  "VW1412" },
            {"fzds8",  "VW1410" },
            {"csdqz1", "VB1623"},
            {"csdqz2", "VB1622"},
            {"csdqz3", "VB1621"},
            {"csdqz4", "VB1620"},
            {"csdqz5", "VB1623"},
            {"csdqz6", "VB1622"},
            {"csdqz7", "VB1621"},
            {"csdqz8", "VB1620"},
            {"cssdz1", "VB1619"},
            {"cssdz2", "VB1618"},
            {"cssdz3", "VB1617"},
            {"cssdz4", "VB1616"},
            {"cssdz5", "VB1619"},
            {"cssdz6", "VB1618"},
            {"cssdz7", "VB1617"},
            {"cssdz8", "VB1616"},
        };
        
        public Production(int idx)
        {
            this.idx = idx;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            label1.Text = "生产罐" + idx.ToString() + "加胶粉设置";
            if (idx != 4 && idx != 8)
            {
                label4.Visible = false;
                label5.Visible = false;
                zzys.Visible = false;
                fzds.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
            }
            if (idx <= 4)
            {
                jfsdz.Text = Plc.plc2.ReadFloat(dict["jfsdz" + idx.ToString()]).Content.ToString();
                jftql.Text = Plc.plc2.ReadFloat(dict["jftql" + idx.ToString()]).Content.ToString();
                zzgbys.Text = Plc.plc2.ReadInt16(dict["zzgbys" + idx.ToString()]).Content.ToString();
                cssdz.Text = Plc.plc2.ReadByte(dict["cssdz" + idx.ToString()]).Content.ToString();
                csdqz.Text = Plc.plc2.ReadByte(dict["csdqz" + idx.ToString()]).Content.ToString() + " /";
                if (idx == 4)
                {
                    zzys.Text = Plc.plc2.ReadInt16(dict["zzys" + idx.ToString()]).Content.ToString();
                    fzds.Text = Plc.plc2.ReadInt16(dict["fzds" + idx.ToString()]).Content.ToString();
                }
            }
            else if (idx > 4)
            {
                jfsdz.Text = Plc.plc3.ReadFloat(dict["jfsdz" + idx.ToString()]).Content.ToString();
                jftql.Text = Plc.plc3.ReadFloat(dict["jftql" + idx.ToString()]).Content.ToString();
                zzgbys.Text = Plc.plc3.ReadInt16(dict["zzgbys" + idx.ToString()]).Content.ToString();
                cssdz.Text = Plc.plc3.ReadByte(dict["cssdz" + idx.ToString()]).Content.ToString();
                csdqz.Text = Plc.plc3.ReadByte(dict["csdqz" + idx.ToString()]).Content.ToString() + " /";
                if (idx == 8)
                {
                    zzys.Text = Plc.plc3.ReadInt16(dict["zzys" + idx.ToString()]).Content.ToString();
                    fzds.Text = Plc.plc3.ReadInt16(dict["fzds" + idx.ToString()]).Content.ToString();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            if (idx <= 4)
            {
                Plc.plc2.Write(dict["jfsdz" + idx.ToString()], Convert.ToSingle(jfsdz.Text));
                Plc.plc2.Write(dict["jftql" + idx.ToString()], Convert.ToSingle(jftql.Text) + Monitor.weights[idx - 1]);
                Plc.plc2.Write(dict["zzgbys" + idx.ToString()], (short)(Convert.ToSingle(zzgbys.Text) * 10));
                Plc.plc2.Write(dict["cssdz" + idx.ToString()], (byte)Convert.ToSingle(cssdz.Text));
                Plc.plc2.Write("M6", Monitor.data[idx - 1]);
                if (idx == 4)
                {
                    Plc.plc2.Write(dict["zzys" + idx.ToString()], (short)(Convert.ToSingle(zzys.Text) * 10));
                    Plc.plc2.Write(dict["fzds" + idx.ToString()], (short)(Convert.ToSingle(fzds.Text) * 10));
                }
            }
            else if (idx > 4)
            {
                Plc.plc3.Write(dict["jfsdz" + idx.ToString()], Convert.ToSingle(jfsdz.Text));
                Plc.plc3.Write(dict["jftql" + idx.ToString()], Convert.ToSingle(jftql.Text) + Monitor.weights[idx - 1]);
                Plc.plc3.Write(dict["zzgbys" + idx.ToString()], (short)(Convert.ToSingle(zzgbys.Text) * 10));
                Plc.plc3.Write(dict["cssdz" + idx.ToString()], (byte)Convert.ToSingle(cssdz.Text));
                Plc.plc3.Write("M6", Monitor.data[idx - 5]);
                if (idx == 8)
                {
                    Plc.plc3.Write(dict["zzys" + idx.ToString()], (short)(Convert.ToSingle(zzys.Text) * 10));
                    Plc.plc3.Write(dict["fzds" + idx.ToString()], (short)(Convert.ToSingle(fzds.Text) * 10));
                }
            }

            this.Close();
        }

        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        private void Production_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
    }
}

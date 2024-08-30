using MySql.Data.MySqlClient;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Asphalt
{
    public partial class Formula : UserControl
    {
        private System.Threading.Timer timer;
        private Range myUI = new Range();
        public Formula()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            // 初始化时应从数据库读取存储的数据而不是PLC
            MySqlDataReader reader = Sql.executeReader("select * from formula where name = '预混罐1';");
            if (reader.Read())
            {
                yhlq1.Text = reader[2].ToString();
                yht21.Text = reader[5].ToString();
                yhsbs1.Text = reader[6].ToString();
            }
            reader.Close();
            reader = Sql.executeReader("select * from formula where name = '预混罐2';");
            if (reader.Read())
            {
                yhlq2.Text = reader[2].ToString();
                yht22.Text = reader[5].ToString();
                yhsbs2.Text = reader[6].ToString();
            }
            reader.Close();
            for (int i = 1; i <= 8; i++)
            {
                reader = Sql.executeReader("select * from formula where name = '生产罐" + i + "';");
                if (reader.Read())
                {
                    TextBox schl = (TextBox)this.Controls.Find("schl" + i.ToString(), true)[0];
                    schl.Text = reader[1].ToString();
                    TextBox sctjj = (TextBox)this.Controls.Find("sctjj" + i.ToString(), true)[0];
                    sctjj.Text = reader[3].ToString();
                    TextBox jfyc = (TextBox)this.Controls.Find("jfyc" + i.ToString(), true)[0];
                    jfyc.Text = reader[4].ToString();
                    TextBox sclq = (TextBox)this.Controls.Find("sclq" + i.ToString(), true)[0];
                    sclq.Text = reader[2].ToString();
                    TextBox t4 = (TextBox)this.Controls.Find("t4" + i.ToString(), true)[0];
                    t4.Text = reader[7].ToString();
                }
            }
            reader.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox73_TextChanged(object sender, EventArgs e)
        {

        }
        private void savePlc(object source)
        {
            Plc.plc1.Write("VD200", Convert.ToSingle(yhlq1.Text));
            Plc.plc1.Write("VD208", Convert.ToSingle(yht21.Text));
            Plc.plc1.Write("VD216", Convert.ToSingle(yhsbs1.Text));
            Plc.plc1.Write("VD204", Convert.ToSingle(yhlq2.Text));
            Plc.plc1.Write("VD212", Convert.ToSingle(yht22.Text));
            Plc.plc1.Write("VD220", Convert.ToSingle(yhsbs2.Text));

            Plc.plc2.Write("VD336", Convert.ToSingle(schl1.Text));
            Plc.plc2.Write("VD340", Convert.ToSingle(schl2.Text));
            Plc.plc2.Write("VD344", Convert.ToSingle(schl3.Text));
            Plc.plc2.Write("VD348", Convert.ToSingle(schl4.Text));
            Plc.plc3.Write("VD336", Convert.ToSingle(schl5.Text));
            Plc.plc3.Write("VD340", Convert.ToSingle(schl6.Text));
            Plc.plc3.Write("VD344", Convert.ToSingle(schl7.Text));
            Plc.plc3.Write("VD348", Convert.ToSingle(schl8.Text));

            Plc.plc2.Write("VD268", Convert.ToSingle(sclq1.Text));
            Plc.plc2.Write("VD264", Convert.ToSingle(sclq2.Text));
            Plc.plc2.Write("VD260", Convert.ToSingle(sclq3.Text));
            Plc.plc2.Write("VD256", Convert.ToSingle(sclq4.Text));
            Plc.plc3.Write("VD268", Convert.ToSingle(sclq5.Text));
            Plc.plc3.Write("VD264", Convert.ToSingle(sclq6.Text));
            Plc.plc3.Write("VD260", Convert.ToSingle(sclq7.Text));
            Plc.plc3.Write("VD256", Convert.ToSingle(sclq8.Text));

            Plc.plc2.Write("VD284", Convert.ToSingle(sctjj1.Text));
            Plc.plc2.Write("VD280", Convert.ToSingle(sctjj2.Text));
            Plc.plc2.Write("VD276", Convert.ToSingle(sctjj3.Text));
            Plc.plc2.Write("VD272", Convert.ToSingle(sctjj4.Text));
            Plc.plc3.Write("VD284", Convert.ToSingle(sctjj5.Text));
            Plc.plc3.Write("VD280", Convert.ToSingle(sctjj6.Text));
            Plc.plc3.Write("VD276", Convert.ToSingle(sctjj7.Text));
            Plc.plc3.Write("VD272", Convert.ToSingle(sctjj8.Text));

            Plc.plc2.Write("VD300", Convert.ToSingle(jfyc1.Text));
            Plc.plc2.Write("VD296", Convert.ToSingle(jfyc2.Text));
            Plc.plc2.Write("VD292", Convert.ToSingle(jfyc3.Text));
            Plc.plc2.Write("VD288", Convert.ToSingle(jfyc4.Text));
            Plc.plc3.Write("VD300", Convert.ToSingle(jfyc5.Text));
            Plc.plc3.Write("VD296", Convert.ToSingle(jfyc6.Text));
            Plc.plc3.Write("VD292", Convert.ToSingle(jfyc7.Text));
            Plc.plc3.Write("VD288", Convert.ToSingle(jfyc8.Text));
            
            Plc.plc2.Write("VD304", Convert.ToSingle(t44.Text));
            Plc.plc2.Write("VD308", Convert.ToSingle(t43.Text));
            Plc.plc2.Write("VD312", Convert.ToSingle(t42.Text));
            Plc.plc2.Write("VD316", Convert.ToSingle(t41.Text));
            Plc.plc3.Write("VD304", Convert.ToSingle(t48.Text));
            Plc.plc3.Write("VD308", Convert.ToSingle(t47.Text));
            Plc.plc3.Write("VD312", Convert.ToSingle(t46.Text));
            Plc.plc3.Write("VD316", Convert.ToSingle(t45.Text));

        }
        private void saveSql()
        {
            Sql.executeNonQuery(string.Format("update formula set asphalt = {0}, T2_weight = {1}, SBS_weight = {2} where name = '{3}';", yhlq1.Text.ToFloat(), yht21.Text.ToFloat(), yhsbs1.Text.ToFloat(), "预混罐1"));
            Sql.executeNonQuery(string.Format("update formula set asphalt = {0}, T2_weight = {1}, SBS_weight = {2} where name = '{3}';", yhlq2.Text.ToFloat(), yht22.Text.ToFloat(), yhsbs2.Text.ToFloat(), "预混罐2"));
            Sql.executeNonQuery(string.Format("update formula set mixing = {0}, asphalt = {1}, additive = {2},  gelatin = {3}, t4_weight = {4} where name = '{5}';", schl1.Text.ToFloat(), sclq1.Text.ToFloat(), sctjj1.Text.ToFloat(), jfyc1.Text.ToFloat(), t41.Text.ToFloat(), "生产罐1"));
            Sql.executeNonQuery(string.Format("update formula set mixing = {0}, asphalt = {1}, additive = {2},  gelatin = {3}, t4_weight = {4} where name = '{5}';", schl2.Text.ToFloat(), sclq2.Text.ToFloat(), sctjj2.Text.ToFloat(), jfyc2.Text.ToFloat(), t42.Text.ToFloat(), "生产罐2"));
            Sql.executeNonQuery(string.Format("update formula set mixing = {0}, asphalt = {1}, additive = {2},  gelatin = {3}, t4_weight = {4} where name = '{5}';", schl3.Text.ToFloat(), sclq3.Text.ToFloat(), sctjj3.Text.ToFloat(), jfyc3.Text.ToFloat(), t43.Text.ToFloat(), "生产罐3"));
            Sql.executeNonQuery(string.Format("update formula set mixing = {0}, asphalt = {1}, additive = {2},  gelatin = {3}, t4_weight = {4} where name = '{5}';", schl4.Text.ToFloat(), sclq4.Text.ToFloat(), sctjj4.Text.ToFloat(), jfyc4.Text.ToFloat(), t44.Text.ToFloat(), "生产罐4"));
            Sql.executeNonQuery(string.Format("update formula set mixing = {0}, asphalt = {1}, additive = {2},  gelatin = {3}, t4_weight = {4} where name = '{5}';", schl5.Text.ToFloat(), sclq5.Text.ToFloat(), sctjj5.Text.ToFloat(), jfyc5.Text.ToFloat(), t45.Text.ToFloat(), "生产罐5"));
            Sql.executeNonQuery(string.Format("update formula set mixing = {0}, asphalt = {1}, additive = {2},  gelatin = {3}, t4_weight = {4} where name = '{5}';", schl6.Text.ToFloat(), sclq6.Text.ToFloat(), sctjj6.Text.ToFloat(), jfyc6.Text.ToFloat(), t46.Text.ToFloat(), "生产罐6"));
            Sql.executeNonQuery(string.Format("update formula set mixing = {0}, asphalt = {1}, additive = {2},  gelatin = {3}, t4_weight = {4} where name = '{5}';", schl7.Text.ToFloat(), sclq7.Text.ToFloat(), sctjj7.Text.ToFloat(), jfyc7.Text.ToFloat(), t47.Text.ToFloat(), "生产罐7"));
            Sql.executeNonQuery(string.Format("update formula set mixing = {0}, asphalt = {1}, additive = {2},  gelatin = {3}, t4_weight = {4} where name = '{5}';", schl8.Text.ToFloat(), sclq8.Text.ToFloat(), sctjj8.Text.ToFloat(), jfyc8.Text.ToFloat(), t48.Text.ToFloat(), "生产罐8"));
        }
        private void uiSymbolButton26_Click(object sender, EventArgs e)
        {
            try
            {
                if (Limit.limit[4] == 2)
                {
                    saveSql();
                    timer = new System.Threading.Timer(savePlc, null, 0, Timeout.Infinite);
                    MessageBox.Show("保存成功！");
                }
                else
                {
                    MessageBox.Show("您没有权限使用此功能！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入错误，请重试:" + ex.ToString());
            }
        }

        private void label37_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox68_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox76_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox69_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox71_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox72_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox78_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox127_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox77_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox74_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox70_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Formula_Load(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }
    }
}

using MySql.Data.MySqlClient;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Asphalt
{
    public partial class Delays : UserControl
    {
        private System.Threading.Timer timer;

        public Range myUI = new Range();
        public Delays()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            // 初始化时应从数据库读取存储的数据而不是PLC
            MySqlDataReader reader = Sql.executeReader("select * from setting where name = '周转罐';");
            reader.Read();
            textBox6.Text = reader[18].ToString();
            reader.Close();

            for (int i = 1; i <= 8; i++)
            {
                reader = Sql.executeReader("select * from setting where name = '生产罐" + i + "';");
                if (reader.Read())
                {

                    TextBox scjfwd = (TextBox)this.Controls.Find("scjfwd" + i.ToString(), true)[0];
                    scjfwd.Text = reader[15].ToString();
                    TextBox t4 = (TextBox)this.Controls.Find("t4" + i.ToString(), true)[0];
                    t4.Text = reader[16].ToString();

                    TextBox t4syl = (TextBox)this.Controls.Find("t4syl" + i.ToString(), true)[0];
                    t4syl.Text = reader[17].ToString();
                    TextBox rsqdzl = (TextBox)this.Controls.Find("rsqdzl" + i.ToString(), true)[0];
                    rsqdzl.Text = reader[18].ToString();
                    TextBox tjjkgys = (TextBox)this.Controls.Find("tjjkgys" + i.ToString(), true)[0];
                    tjjkgys.Text = reader[19].ToString();
                    TextBox jfzxys = (TextBox)this.Controls.Find("jfzxys" + i.ToString(), true)[0];
                    jfzxys.Text = reader[20].ToString();
                    TextBox t4jbys = (TextBox)this.Controls.Find("t4jbys" + i.ToString(), true)[0];
                    t4jbys.Text = reader[21].ToString();
                    TextBox t4gb= (TextBox)this.Controls.Find("t4gb" + i.ToString(), true)[0];
                    t4gb.Text = reader[22].ToString();
                }
            }
            reader.Close();
            reader = Sql.executeReader("select * from delay ;");
            while (reader.Read())
            {
                if (reader[0].ToString() == "罐1-4沥青进口阀关闭延时")
                {
                    textBox72.Text = reader[1].ToString();
                }
                else if (reader[0].ToString() == "罐4胶粉投料反转定时")
                {
                    textBox71.Text = reader[1].ToString();
                }
                else if (reader[0].ToString() == "罐4胶粉投料正转延时")
                {
                    textBox70.Text = reader[1].ToString();
                }
                else if (reader[0].ToString() == "罐5-8沥青进口阀关闭延时")
                {
                    textBox5.Text = reader[1].ToString();
                }
                else if (reader[0].ToString() == "罐8胶粉投料反转定时")
                {
                    textBox4.Text = reader[1].ToString();
                }
                else if (reader[0].ToString() == "罐8胶粉投料正转延时")
                {
                    textBox3.Text = reader[1].ToString();
                }
                else if (reader[0].ToString() == "预混增压及上料停止延时")
                {
                    textBox76.Text = reader[1].ToString();
                }
                else if (reader[0].ToString() == "SBS喂料电机关闭延时")
                {
                    textBox77.Text = reader[1].ToString();
                }
                else if (reader[0].ToString() == "预混罐加完SBS延时")
                {
                    textBox78.Text = reader[1].ToString();
                }
                else if (reader[0].ToString() == "预混罐T2进口阀关闭延时")
                {
                    textBox127.Text = reader[1].ToString();
                }
                else if (reader[0].ToString() == "生产罐沥青进阀关闭延时")
                {
                    textBox128.Text = reader[1].ToString();
                }
                else if (reader[0].ToString() == "成品泵关闭延时")
                {
                    textBox75.Text = reader[1].ToString();
                }
                else if (reader[0].ToString() == "T4预混罐阀门关闭延时")
                {
                    t4gbys.Text = reader[1].ToString();
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
        public void savePlc(object source)
        {
            Plc.plc1.Write("VD4018", Convert.ToSingle(textBox6.Text));
            Plc.plc2.Write("VW1400",(short)(Convert.ToSingle(textBox72.Text) * 10));
            Plc.plc2.Write("VW1410",(short)(Convert.ToSingle(textBox71.Text) * 10));
            Plc.plc2.Write("VW1412",(short)(Convert.ToSingle(textBox70.Text) * 10));
            Plc.plc3.Write("VW1400",(short)(Convert.ToSingle(textBox5.Text) * 10));
            Plc.plc3.Write("VW1410",(short)(Convert.ToSingle(textBox4.Text) * 10));
            Plc.plc3.Write("VW1412",(short)(Convert.ToSingle(textBox3.Text) * 10));
            Plc.plc1.Write("VW1000",(short)(Convert.ToSingle(textBox76.Text) * 10));
            Plc.plc1.Write("VW1002",(short)(Convert.ToSingle(textBox77.Text) * 10));
            Plc.plc1.Write("VW1004",(short)(Convert.ToSingle(textBox78.Text) * 10));
            Plc.plc1.Write("VW1006",(short)(Convert.ToSingle(textBox127.Text) * 10));
            Plc.plc1.Write("VW1008",(short)(Convert.ToSingle(textBox128.Text) * 10));
            Plc.plc1.Write("VW1010",(short)(Convert.ToSingle(textBox75.Text) * 10));
            Plc.plc1.Write("VW1012",(short)(Convert.ToSingle(t4gbys.Text) * 10));
            Plc.plc2.Write("VD1612", Convert.ToSingle(scjfwd1.Text));
            Plc.plc2.Write("VD1608", Convert.ToSingle(scjfwd2.Text));
            Plc.plc2.Write("VD1604", Convert.ToSingle(scjfwd3.Text));
            Plc.plc2.Write("VD1600", Convert.ToSingle(scjfwd4.Text));

            Plc.plc2.Write("VD1636", Convert.ToSingle(t41.Text));
            Plc.plc2.Write("VD1632", Convert.ToSingle(t42.Text));
            Plc.plc2.Write("VD1628", Convert.ToSingle(t43.Text));
            Plc.plc2.Write("VD1624", Convert.ToSingle(t44.Text));
            Plc.plc2.Write("VD572", Convert.ToSingle(t4syl1.Text));
            Plc.plc2.Write("VD568", Convert.ToSingle(t4syl2.Text));
            Plc.plc2.Write("VD564", Convert.ToSingle(t4syl3.Text));
            Plc.plc2.Write("VD560", Convert.ToSingle(t4syl4.Text));
            Plc.plc2.Write("VD580", Convert.ToSingle(rsqdzl1.Text));
            Plc.plc2.Write("VD584", Convert.ToSingle(rsqdzl2.Text));
            Plc.plc2.Write("VD588", Convert.ToSingle(rsqdzl3.Text));
            Plc.plc2.Write("VD592", Convert.ToSingle(rsqdzl4.Text));
            Plc.plc2.Write("VW1408", (short)(Convert.ToSingle(tjjkgys1.Text) * 10));
            Plc.plc2.Write("VW1406", (short)(Convert.ToSingle(tjjkgys2.Text) * 10));
            Plc.plc2.Write("VW1402", (short)(Convert.ToSingle(tjjkgys3.Text) * 10));
            Plc.plc2.Write("VW1404", (short)(Convert.ToSingle(tjjkgys4.Text) * 10));
            Plc.plc2.Write("VW1420", (short)(Convert.ToSingle(jfzxys1.Text) * 10));
            Plc.plc2.Write("VD1418", (short)(Convert.ToSingle(jfzxys2.Text) * 10));
            Plc.plc2.Write("VD1416", (short)(Convert.ToSingle(jfzxys3.Text) * 10));
            Plc.plc2.Write("VD1414", (short)(Convert.ToSingle(jfzxys4.Text) * 10));
            Plc.plc2.Write("VW1432", (short)(Convert.ToSingle(t4jbys1.Text) * 10));
            Plc.plc2.Write("VW1430", (short)(Convert.ToSingle(t4jbys2.Text) * 10));
            Plc.plc2.Write("VW1428", (short)(Convert.ToSingle(t4jbys3.Text) * 10));
            Plc.plc2.Write("VW1426", (short)(Convert.ToSingle(t4jbys4.Text) * 10));
            Plc.plc2.Write("VW1442", (short)(Convert.ToSingle(t4gb1.Text) * 10));
            Plc.plc2.Write("VW1440", (short)(Convert.ToSingle(t4gb2.Text) * 10));
            Plc.plc2.Write("VW1438", (short)(Convert.ToSingle(t4gb3.Text) * 10));
            Plc.plc2.Write("VW1436", (short)(Convert.ToSingle(t4gb4.Text) * 10));

            Plc.plc3.Write("VD1612", Convert.ToSingle(scjfwd5.Text));
            Plc.plc3.Write("VD1608", Convert.ToSingle(scjfwd6.Text));
            Plc.plc3.Write("VD1604", Convert.ToSingle(scjfwd7.Text));
            Plc.plc3.Write("VD1600", Convert.ToSingle(scjfwd8.Text));

            Plc.plc3.Write("VD1636", Convert.ToSingle(t45.Text));
            Plc.plc3.Write("VD1632", Convert.ToSingle(t46.Text));
            Plc.plc3.Write("VD1628", Convert.ToSingle(t47.Text));
            Plc.plc3.Write("VD1624", Convert.ToSingle(t48.Text));
            Plc.plc3.Write("VD572", Convert.ToSingle(t4syl5.Text));
            Plc.plc3.Write("VD568", Convert.ToSingle(t4syl6.Text));
            Plc.plc3.Write("VD564", Convert.ToSingle(t4syl7.Text));
            Plc.plc3.Write("VD560", Convert.ToSingle(t4syl8.Text));
            Plc.plc3.Write("VD580", Convert.ToSingle(rsqdzl5.Text));
            Plc.plc3.Write("VD584", Convert.ToSingle(rsqdzl6.Text));
            Plc.plc3.Write("VD588", Convert.ToSingle(rsqdzl7.Text));
            Plc.plc3.Write("VD592", Convert.ToSingle(rsqdzl8.Text));
            Plc.plc3.Write("VW1408", (short)(Convert.ToSingle(tjjkgys5.Text) * 10));
            Plc.plc3.Write("VW1406", (short)(Convert.ToSingle(tjjkgys6.Text) * 10));
            Plc.plc3.Write("VW1402", (short)(Convert.ToSingle(tjjkgys7.Text) * 10));
            Plc.plc3.Write("VW1404", (short)(Convert.ToSingle(tjjkgys8.Text) * 10));
            Plc.plc3.Write("VW1420", (short)(Convert.ToSingle(jfzxys5.Text) * 10));
            Plc.plc3.Write("VD1418", (short)(Convert.ToSingle(jfzxys6.Text) * 10));
            Plc.plc3.Write("VD1416", (short)(Convert.ToSingle(jfzxys7.Text) * 10));
            Plc.plc3.Write("VD1414", (short)(Convert.ToSingle(jfzxys8.Text) * 10));
            Plc.plc3.Write("VW1432", (short)(Convert.ToSingle(t4jbys5.Text) * 10));
            Plc.plc3.Write("VW1430", (short)(Convert.ToSingle(t4jbys6.Text) * 10));
            Plc.plc3.Write("VW1428", (short)(Convert.ToSingle(t4jbys7.Text) * 10));
            Plc.plc3.Write("VW1426", (short)(Convert.ToSingle(t4jbys8.Text) * 10));
            Plc.plc3.Write("VW1442", (short)(Convert.ToSingle(t4gb5.Text) * 10));
            Plc.plc3.Write("VW1440", (short)(Convert.ToSingle(t4gb6.Text) * 10));
            Plc.plc3.Write("VW1438", (short)(Convert.ToSingle(t4gb7.Text) * 10));
            Plc.plc3.Write("VW1436", (short)(Convert.ToSingle(t4gb8.Text) * 10));
        }

        private void saveSql()
        {
                Sql.executeNonQuery(string.Format("update setting set crumb_temperature = {0}, T4_temperature = {1}, T4_tank_remain = {2}, burner_start_weight = {3}, additive_in_close_delay = {4}, crumb_foreward_close_delay = {5}, T4_stir_delay = {6}, T4_stop_delay = {7} where name = '{8}';", scjfwd1.Text.ToFloat(), t41.Text.ToFloat(), t4syl1.Text.ToFloat(), rsqdzl1.Text.ToFloat(), tjjkgys1.Text.ToFloat(), jfzxys1.Text.ToFloat(), t4jbys1.Text.ToFloat(), t4gb1.Text.ToFloat(), "生产罐1"));
                Sql.executeNonQuery(string.Format("update setting set crumb_temperature = {0}, T4_temperature = {1}, T4_tank_remain = {2}, burner_start_weight = {3}, additive_in_close_delay = {4}, crumb_foreward_close_delay = {5}, T4_stir_delay = {6}, T4_stop_delay = {7} where name = '{8}';", scjfwd2.Text.ToFloat(), t42.Text.ToFloat(), t4syl2.Text.ToFloat(), rsqdzl2.Text.ToFloat(), tjjkgys2.Text.ToFloat(), jfzxys2.Text.ToFloat(), t4jbys2.Text.ToFloat(), t4gb2.Text.ToFloat(), "生产罐2"));
                Sql.executeNonQuery(string.Format("update setting set crumb_temperature = {0}, T4_temperature = {1}, T4_tank_remain = {2}, burner_start_weight = {3}, additive_in_close_delay = {4}, crumb_foreward_close_delay = {5}, T4_stir_delay = {6}, T4_stop_delay = {7} where name = '{8}';", scjfwd3.Text.ToFloat(), t43.Text.ToFloat(), t4syl3.Text.ToFloat(), rsqdzl3.Text.ToFloat(), tjjkgys3.Text.ToFloat(), jfzxys3.Text.ToFloat(), t4jbys3.Text.ToFloat(), t4gb3.Text.ToFloat(), "生产罐3"));
                Sql.executeNonQuery(string.Format("update setting set crumb_temperature = {0}, T4_temperature = {1}, T4_tank_remain = {2}, burner_start_weight = {3}, additive_in_close_delay = {4}, crumb_foreward_close_delay = {5}, T4_stir_delay = {6}, T4_stop_delay = {7} where name = '{8}';", scjfwd4.Text.ToFloat(), t44.Text.ToFloat(), t4syl4.Text.ToFloat(), rsqdzl4.Text.ToFloat(), tjjkgys4.Text.ToFloat(), jfzxys4.Text.ToFloat(), t4jbys4.Text.ToFloat(), t4gb4.Text.ToFloat(), "生产罐4"));
                Sql.executeNonQuery(string.Format("update setting set crumb_temperature = {0}, T4_temperature = {1}, T4_tank_remain = {2}, burner_start_weight = {3}, additive_in_close_delay = {4}, crumb_foreward_close_delay = {5}, T4_stir_delay = {6}, T4_stop_delay = {7} where name = '{8}';", scjfwd5.Text.ToFloat(), t45.Text.ToFloat(), t4syl5.Text.ToFloat(), rsqdzl5.Text.ToFloat(), tjjkgys5.Text.ToFloat(), jfzxys5.Text.ToFloat(), t4jbys5.Text.ToFloat(), t4gb5.Text.ToFloat(), "生产罐5"));
                Sql.executeNonQuery(string.Format("update setting set crumb_temperature = {0}, T4_temperature = {1}, T4_tank_remain = {2}, burner_start_weight = {3}, additive_in_close_delay = {4}, crumb_foreward_close_delay = {5}, T4_stir_delay = {6}, T4_stop_delay = {7} where name = '{8}';", scjfwd6.Text.ToFloat(), t46.Text.ToFloat(), t4syl6.Text.ToFloat(), rsqdzl6.Text.ToFloat(), tjjkgys6.Text.ToFloat(), jfzxys6.Text.ToFloat(), t4jbys6.Text.ToFloat(), t4gb6.Text.ToFloat(), "生产罐6"));
                Sql.executeNonQuery(string.Format("update setting set crumb_temperature = {0}, T4_temperature = {1}, T4_tank_remain = {2}, burner_start_weight = {3}, additive_in_close_delay = {4}, crumb_foreward_close_delay = {5}, T4_stir_delay = {6}, T4_stop_delay = {7} where name = '{8}';", scjfwd7.Text.ToFloat(), t47.Text.ToFloat(), t4syl7.Text.ToFloat(), rsqdzl7.Text.ToFloat(), tjjkgys7.Text.ToFloat(), jfzxys7.Text.ToFloat(), t4jbys7.Text.ToFloat(), t4gb7.Text.ToFloat(), "生产罐7"));
                Sql.executeNonQuery(string.Format("update setting set crumb_temperature = {0}, T4_temperature = {1}, T4_tank_remain = {2}, burner_start_weight = {3}, additive_in_close_delay = {4}, crumb_foreward_close_delay = {5}, T4_stir_delay = {6}, T4_stop_delay = {7} where name = '{8}';", scjfwd8.Text.ToFloat(), t48.Text.ToFloat(), t4syl8.Text.ToFloat(), rsqdzl8.Text.ToFloat(), tjjkgys8.Text.ToFloat(), jfzxys8.Text.ToFloat(), t4jbys8.Text.ToFloat(), t4gb8.Text.ToFloat(), "生产罐8"));
                Sql.executeNonQuery(string.Format("update setting set burner_start_weight = {0} where name = '{1}';", textBox6.Text.ToFloat(), "周转罐"));
                Sql.executeNonQuery(string.Format("update delay set val = {0} where name = '{1}';", textBox72.Text.ToFloat(), "罐1-4沥青进口阀关闭延时"));
                Sql.executeNonQuery(string.Format("update delay set val = {0} where name = '{1}';", textBox71.Text.ToFloat(), "罐4胶粉投料反转定时"));
                Sql.executeNonQuery(string.Format("update delay set val = {0} where name = '{1}';", textBox70.Text.ToFloat(), "罐4胶粉投料正转延时"));
                Sql.executeNonQuery(string.Format("update delay set val = {0} where name = '{1}';", textBox5.Text.ToFloat(), "罐5-8沥青进口阀关闭延时"));
                Sql.executeNonQuery(string.Format("update delay set val = {0} where name = '{1}';", textBox4.Text.ToFloat(), "罐8胶粉投料反转定时"));
                Sql.executeNonQuery(string.Format("update delay set val = {0} where name = '{1}';", textBox3.Text.ToFloat(), "罐8胶粉投料正转延时"));
                Sql.executeNonQuery(string.Format("update delay set val = {0} where name = '{1}';", textBox76.Text.ToFloat(), "预混增压及上料停止延时"));
                Sql.executeNonQuery(string.Format("update delay set val = {0} where name = '{1}';", textBox77.Text.ToFloat(), "SBS喂料电机关闭延时"));
                Sql.executeNonQuery(string.Format("update delay set val = {0} where name = '{1}';", textBox78.Text.ToFloat(), "预混罐加完SBS延时"));
                Sql.executeNonQuery(string.Format("update delay set val = {0} where name = '{1}';", textBox127.Text.ToFloat(), "预混罐T2进口阀关闭延时"));
                Sql.executeNonQuery(string.Format("update delay set val = {0} where name = '{1}';", textBox128.Text.ToFloat(), "生产罐沥青进阀关闭延时"));
                Sql.executeNonQuery(string.Format("update delay set val = {0} where name = '{1}';", textBox75.Text.ToFloat(), "成品泵关闭延时"));
                Sql.executeNonQuery(string.Format("update delay set val = {0} where name = '{1}';", t4gbys.Text.ToFloat(), "T4预混罐阀门关闭延时"));
        }

        private void uiSymbolButton26_Click(object sender, EventArgs e)
        {
            try
            {
                if (Limit.limit[3] == 2)
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

		private void scjfwd1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}

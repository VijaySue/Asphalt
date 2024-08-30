using MySql.Data.MySqlClient;
using PCHMI;
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
using System.Timers;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Asphalt
{
    public partial class Range : UserControl
    {
        private System.Threading.Timer timer;

        public Range()
        {
            InitializeComponent();
            init();
        }
        private void init()
        {
            MySqlDataReader reader = Sql.executeReader("select * from setting;");
            while (reader.Read())
            {
                for (int i = 1; i <= 8; i++)
                {
                    if (reader[0].ToString() == ("生产罐" + i.ToString()))
                    {
                        TextBox max_weight = (TextBox)this.Controls.Find("max_weight_" + i.ToString(), true)[0];
                        max_weight.Text = reader[1].ToString();
                        TextBox min_weight = (TextBox)this.Controls.Find("min_weight_" + i.ToString(), true)[0];
                        min_weight.Text = reader[2].ToString();
                        TextBox max_temp = (TextBox)this.Controls.Find("max_temp_" + i.ToString(), true)[0];
                        max_temp.Text = reader[3].ToString();
                        TextBox min_temp = (TextBox)this.Controls.Find("min_temp_" + i.ToString(), true)[0];
                        min_temp.Text = reader[4].ToString();
                        TextBox maxWeight = (TextBox)this.Controls.Find("maxWeight" + i.ToString(), true)[0];
                        maxWeight.Text = reader[25].ToString();
                    }
                }
                if (reader[0].ToString() == "周转罐")
                {
                    max_weight_zz.Text = reader[1].ToString();
                    min_weight_zz.Text = reader[2].ToString();
                    max_temp_zz.Text = reader[3].ToString();
                    min_temp_zz.Text = reader[4].ToString();
                    maxWeightzz.Text = reader[25].ToString();
                }
                else if (reader[0].ToString() == "预混罐1")
                {   
                    max_weight_yh1.Text = reader[1].ToString();
                    min_weight_yh1.Text = reader[2].ToString();
                    max_temp_yh1.Text = reader[3].ToString();
                    min_temp_yh1.Text = reader[4].ToString();
                    max_elec_yh1.Text= reader[13].ToString();
                    min_elec_yh1.Text = reader[14].ToString();
                    maxWeightyh1.Text = reader[25].ToString();
                }
                else if (reader[0].ToString() == "预混罐2")
                {
                    max_weight_yh2.Text = reader[1].ToString();
                    min_weight_yh2.Text = reader[2].ToString();
                    max_temp_yh2.Text = reader[3].ToString();
                    min_temp_yh2.Text = reader[4].ToString();
                    max_elec_yh2.Text = reader[13].ToString();
                    min_elec_yh2.Text = reader[14].ToString();
                    maxWeightyh2.Text = reader[25].ToString();
                }
                else if (reader[0].ToString()== "SBS喂料")
                {
                    max_weight_sbs.Text = reader[1].ToString();
                    min_weight_sbs.Text= reader[2].ToString();
                }
                else if(reader[0].ToString() == "成品泵")
                {
                    max_elec_cp.Text= reader[13].ToString();
                    min_elec_cp.Text = reader[14].ToString();
                }
                else if(reader[0].ToString() == "T4预混罐")
                {
                    max_weight_t4.Text = reader[1].ToString();
                    min_weight_t4.Text = reader[2].ToString();
                }
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void temperature_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void label58_Click(object sender, EventArgs e)
        {

            this.Parent.Controls.Clear();
        }

        private void label39_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Clear();
        }


        private void uiSymbolButton26_Click(object sender, EventArgs e)
        {
            try
            {
                if (Limit.limit[2] == 2)
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
        private void saveSql()
        {
            Sql.executeNonQuery(string.Format("update setting set max_weight = {0}, min_weight = {1}, max_elec = {2}, min_elec = {3}, max_temp = {4}, min_temp = {5}, cur_max_weight = {6} where name = '{7}';", max_weight_yh1.Text.ToFloat(), min_weight_yh1.Text.ToFloat(), max_elec_yh1.Text.ToFloat(), min_elec_yh1.Text.ToFloat(),  max_temp_yh1.Text.ToFloat(), min_temp_yh1.Text.ToFloat(), maxWeightyh1.Text.ToFloat(), "预混罐1"));
            Sql.executeNonQuery(string.Format("update setting set max_weight = {0}, min_weight = {1}, max_elec = {2}, min_elec = {3}, max_temp = {4}, min_temp = {5}, cur_max_weight = {6} where name = '{7}';", max_weight_yh2.Text.ToFloat(), min_weight_yh2.Text.ToFloat(), max_elec_yh2.Text.ToFloat(), min_elec_yh2.Text.ToFloat(),  max_temp_yh2.Text.ToFloat(), min_temp_yh2.Text.ToFloat(), maxWeightyh2.Text.ToFloat(), "预混罐2"));
            Sql.executeNonQuery(string.Format("update setting set max_weight = {0}, min_weight = {1}, max_temp = {2}, min_temp = {3}, cur_max_weight = {4} where name = '{5}';", max_weight_zz.Text.ToFloat(), min_weight_zz.Text.ToFloat(), max_temp_zz.Text.ToFloat(), min_temp_zz.Text.ToFloat(), maxWeightzz.Text.ToFloat(), "周转罐"));
            Sql.executeNonQuery(string.Format("update setting set max_weight = {0}, min_weight = {1}, max_temp = {2}, min_temp = {3}, cur_max_weight = {4} where name = '{5}';", max_weight_1.Text.ToFloat(), min_weight_1.Text.ToFloat(), max_temp_1.Text.ToFloat(), min_temp_1.Text.ToFloat(), maxWeight1.Text.ToFloat(), "生产罐1"));
            Sql.executeNonQuery(string.Format("update setting set max_weight = {0}, min_weight = {1}, max_temp = {2}, min_temp = {3}, cur_max_weight = {4} where name = '{5}';", max_weight_2.Text.ToFloat(), min_weight_2.Text.ToFloat(), max_temp_2.Text.ToFloat(), min_temp_2.Text.ToFloat(), maxWeight2.Text.ToFloat(), "生产罐2"));
            Sql.executeNonQuery(string.Format("update setting set max_weight = {0}, min_weight = {1}, max_temp = {2}, min_temp = {3}, cur_max_weight = {4} where name = '{5}';", max_weight_3.Text.ToFloat(), min_weight_3.Text.ToFloat(), max_temp_3.Text.ToFloat(), min_temp_3.Text.ToFloat(), maxWeight3.Text.ToFloat(), "生产罐3"));
            Sql.executeNonQuery(string.Format("update setting set max_weight = {0}, min_weight = {1}, max_temp = {2}, min_temp = {3}, cur_max_weight = {4} where name = '{5}';", max_weight_4.Text.ToFloat(), min_weight_4.Text.ToFloat(), max_temp_4.Text.ToFloat(), min_temp_4.Text.ToFloat(), maxWeight4.Text.ToFloat(), "生产罐4"));
            Sql.executeNonQuery(string.Format("update setting set max_weight = {0}, min_weight = {1}, max_temp = {2}, min_temp = {3}, cur_max_weight = {4} where name = '{5}';", max_weight_5.Text.ToFloat(), min_weight_5.Text.ToFloat(), max_temp_5.Text.ToFloat(), min_temp_5.Text.ToFloat(), maxWeight5.Text.ToFloat(), "生产罐5"));
            Sql.executeNonQuery(string.Format("update setting set max_weight = {0}, min_weight = {1}, max_temp = {2}, min_temp = {3}, cur_max_weight = {4} where name = '{5}';", max_weight_6.Text.ToFloat(), min_weight_6.Text.ToFloat(), max_temp_6.Text.ToFloat(), min_temp_6.Text.ToFloat(), maxWeight6.Text.ToFloat(), "生产罐6"));
            Sql.executeNonQuery(string.Format("update setting set max_weight = {0}, min_weight = {1}, max_temp = {2}, min_temp = {3}, cur_max_weight = {4} where name = '{5}';", max_weight_7.Text.ToFloat(), min_weight_7.Text.ToFloat(), max_temp_7.Text.ToFloat(), min_temp_5.Text.ToFloat(), maxWeight7.Text.ToFloat(), "生产罐7"));
            Sql.executeNonQuery(string.Format("update setting set max_weight = {0}, min_weight = {1}, max_temp = {2}, min_temp = {3}, cur_max_weight = {4} where name = '{5}';", max_weight_8.Text.ToFloat(), min_weight_8.Text.ToFloat(), max_temp_8.Text.ToFloat(), min_temp_8.Text.ToFloat(), maxWeight8.Text.ToFloat(), "生产罐8"));
            Sql.executeNonQuery(string.Format("update setting set max_weight = {0}, min_weight = {1} where name = '{2}';", max_weight_sbs.Text.ToFloat(), min_weight_sbs.Text.ToFloat(), "SBS喂料"));
            Sql.executeNonQuery(string.Format("update setting set max_elec = {0}, min_elec = {1} where name = '{2}';", max_elec_cp.Text.ToFloat(), min_elec_cp.Text.ToFloat(), "成品泵"));
            Sql.executeNonQuery(string.Format("update setting set max_weight = {0}, min_weight = {1} where name = '{2}';", max_weight_t4.Text.ToFloat(), min_weight_t4.Text.ToFloat(), "T4预混罐"));
        }
        public void savePlc(object source)
        {
            Plc.plc1.Write("VD616", Convert.ToSingle(max_weight_yh1.Text));
            Plc.plc1.Write("VD644", Convert.ToSingle(min_weight_yh1.Text));
            Plc.plc1.Write("VD620", Convert.ToSingle(max_weight_yh2.Text));
            Plc.plc1.Write("VD648", Convert.ToSingle(min_weight_yh2.Text));
            Plc.plc1.Write("VD604", Convert.ToSingle(max_weight_zz.Text));
            Plc.plc1.Write("VD632", Convert.ToSingle(min_weight_zz.Text));
            Plc.plc2.Write("VD136", Convert.ToSingle(max_weight_1.Text));
            Plc.plc2.Write("VD172", Convert.ToSingle(min_weight_1.Text));
            Plc.plc2.Write("VD144", Convert.ToSingle(max_weight_2.Text));
            Plc.plc2.Write("VD180", Convert.ToSingle(min_weight_2.Text));
            Plc.plc2.Write("VD152", Convert.ToSingle(max_weight_3.Text));
            Plc.plc2.Write("VD188", Convert.ToSingle(min_weight_3.Text));
            Plc.plc2.Write("VD160", Convert.ToSingle(max_weight_4.Text));
            Plc.plc2.Write("VD196", Convert.ToSingle(min_weight_4.Text));
            Plc.plc3.Write("VD136", Convert.ToSingle(max_weight_5.Text));
            Plc.plc3.Write("VD172", Convert.ToSingle(min_weight_5.Text));
            Plc.plc3.Write("VD144", Convert.ToSingle(max_weight_6.Text));
            Plc.plc3.Write("VD180", Convert.ToSingle(min_weight_6.Text));
            Plc.plc3.Write("VD152", Convert.ToSingle(max_weight_7.Text));
            Plc.plc3.Write("VD188", Convert.ToSingle(min_weight_7.Text));
            Plc.plc3.Write("VD160", Convert.ToSingle(max_weight_8.Text));
            Plc.plc3.Write("VD196", Convert.ToSingle(min_weight_8.Text));
            Plc.plc1.Write("VD624", Convert.ToSingle(max_weight_sbs.Text));
            Plc.plc1.Write("VD652", Convert.ToSingle(min_weight_sbs.Text));
            Plc.plc1.Write("VD600", Convert.ToSingle(max_temp_zz.Text));
            Plc.plc1.Write("VD628", Convert.ToSingle(min_temp_zz.Text));
            Plc.plc2.Write("VD140", Convert.ToSingle(max_temp_1.Text));
            Plc.plc2.Write("VD176", Convert.ToSingle(min_temp_1.Text));
            Plc.plc2.Write("VD148", Convert.ToSingle(max_temp_2.Text));
            Plc.plc2.Write("VD184", Convert.ToSingle(min_temp_2.Text));
            Plc.plc2.Write("VD156", Convert.ToSingle(max_temp_3.Text));
            Plc.plc2.Write("VD192", Convert.ToSingle(min_temp_3.Text));
            Plc.plc2.Write("VD164", Convert.ToSingle(max_temp_4.Text));
            Plc.plc2.Write("VD200", Convert.ToSingle(min_temp_4.Text));
            Plc.plc3.Write("VD140", Convert.ToSingle(max_temp_5.Text));
            Plc.plc3.Write("VD176", Convert.ToSingle(min_temp_5.Text));
            Plc.plc3.Write("VD148", Convert.ToSingle(max_temp_6.Text));
            Plc.plc3.Write("VD184", Convert.ToSingle(min_temp_6.Text));
            Plc.plc3.Write("VD156", Convert.ToSingle(max_temp_7.Text));
            Plc.plc3.Write("VD192", Convert.ToSingle(min_temp_7.Text));
            Plc.plc3.Write("VD164", Convert.ToSingle(max_temp_8.Text));
            Plc.plc3.Write("VD200", Convert.ToSingle(min_temp_8.Text));
            Plc.plc1.Write("VD656", Convert.ToSingle(max_elec_yh1.Text));
            Plc.plc1.Write("VD660", Convert.ToSingle(min_elec_yh1.Text));
            Plc.plc1.Write("VD664", Convert.ToSingle(max_elec_yh2.Text));
            Plc.plc1.Write("VD668", Convert.ToSingle(min_elec_yh2.Text));
            Plc.plc1.Write("VD672", Convert.ToSingle(max_elec_cp.Text));
            Plc.plc1.Write("VD676", Convert.ToSingle(min_elec_cp.Text));
            Plc.plc3.Write("VD600", Convert.ToSingle(max_weight_t4.Text));
            Plc.plc3.Write("VD604", Convert.ToSingle(min_weight_t4.Text));

            Plc.plc2.Write("VD1312", Convert.ToSingle(maxWeight1.Text));
            Plc.plc2.Write("VD1308", Convert.ToSingle(maxWeight2.Text));
            Plc.plc2.Write("VD1304", Convert.ToSingle(maxWeight3.Text));
            Plc.plc2.Write("VD1300", Convert.ToSingle(maxWeight4.Text));
            Plc.plc3.Write("VD1312", Convert.ToSingle(maxWeight5.Text));
            Plc.plc3.Write("VD1308", Convert.ToSingle(maxWeight6.Text));
            Plc.plc3.Write("VD1304", Convert.ToSingle(maxWeight7.Text));
            Plc.plc3.Write("VD1300", Convert.ToSingle(maxWeight8.Text));

            Plc.plc1.Write("VD1300", Convert.ToSingle(maxWeightzz.Text));
            Plc.plc1.Write("VD1304", Convert.ToSingle(maxWeightyh1.Text));
            Plc.plc1.Write("VD1308", Convert.ToSingle(maxWeightyh2.Text));
        }

        private void min_weight_yh1_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_weight_yh2_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_weight_zz_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_weight_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_weight_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_weight_3_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_weight_4_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_weight_5_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_weight_6_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_weight_7_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_weight_8_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_weight_t4_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_weight_t4_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_weight_8_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_weight_7_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_weight_6_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_weight_5_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_weight_4_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_weight_3_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_weight_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_weight_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_weight_zz_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_weight_yh1_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_weight_yh2_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_temp_zz_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_temp_zz_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_temp_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_temp_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_temp_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_temp_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_temp_3_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_temp_3_TextChanged(object sender, EventArgs e)
        {

        }

        private void min_temp_4_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_temp_4_TextChanged(object sender, EventArgs e)
        {

        }

        private void max_temp_5_TextChanged(object sender, EventArgs e)
        {

        }

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}
	}
}

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

namespace Asphalt
{
    public partial class Setting : UserControl
    {
        private System.Threading.Timer timer;

        public Setting()
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
                        TextBox cur_max_temp = (TextBox)this.Controls.Find("cur_max_temp_" + i.ToString(), true)[0];
                        cur_max_temp.Text = reader[7].ToString();
                        TextBox cur_min_temp = (TextBox)this.Controls.Find("cur_min_temp_" + i.ToString(), true)[0];
                        cur_min_temp.Text = reader[8].ToString();
                        TextBox cur_min_weight = (TextBox)this.Controls.Find("cur_min_weight_" + i.ToString(), true)[0];
                        cur_min_weight.Text = reader[11].ToString();
                        TextBox frequency = (TextBox)this.Controls.Find("frequency_" + i.ToString(), true)[0];
                        frequency.Text = reader[12].ToString();

                    }
                }
                if (reader[0].ToString() == "周转罐")
                {
                    cur_max_temp_zz.Text = reader[7].ToString();
                    cur_min_temp_zz.Text = reader[8].ToString();
                    cur_min_weight_zz.Text = reader[11].ToString();
                    frequency_zz.Text= reader[12].ToString();
                    zzyjsx.Text = reader[5].ToString();
                }
                else if (reader[0].ToString() == "预混罐1")
                {
                    cur_min_weight_yh1.Text = reader[11].ToString();

                }
                else if (reader[0].ToString() == "预混罐2")
                {
                    cur_min_weight_yh2.Text = reader[11].ToString();
                }
                else if (reader[0].ToString() == "SBS喂料")
                {
                    frequency_sbs.Text= reader[12].ToString();
                }
                else if (reader[0].ToString() == "T2喂料")
                {
                    frequency_t2.Text = reader[12].ToString();
                }
                else if (reader[0].ToString() == "二剪喂料泵")
                {

                    frequency_ejwl.Text = reader[12].ToString();
                }
            
                else if (reader[0].ToString() == "二剪机")
                {
                    frequency_clej.Text = reader[12].ToString();

                }
                else if (reader[0].ToString() == "出料一剪机")
                {
                    frequency_clyj.Text = reader[12].ToString();

                }
                else if (reader[0].ToString() == "喂料泵")
                {
                    frequency_wlb.Text = reader[12].ToString();

                }
                else if (reader[0].ToString() == "基质沥青上料泵")
                {
                    frequency_jclq.Text = reader[12].ToString();

                }
                else if (reader[0].ToString() == "添加剂投料")
                {
                    frequency_tjj.Text = reader[12].ToString();

                }
                else if (reader[0].ToString() == "胶粉喂料")
                {
                    frequency_jf.Text = reader[12].ToString();

                }
                else if (reader[0].ToString() == "预混上料泵")
                {
                    frequency_yhs.Text = reader[12].ToString();

                }
                else if (reader[0].ToString() == "预混一剪")
                {
                    frequency_yhyj.Text = reader[12].ToString();
                }
                else if (reader[0].ToString() == "T4预混罐")
                {
                    frequency_t4.Text = reader[12].ToString();
                    t4czsdz.Text = reader[23].ToString();
                    t4czxxsdz.Text = reader[24].ToString();
                }
            }

        }
        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label57_Click(object sender, EventArgs e)
        {

        }
        public void savePlc(object source)
        {
                Plc.plc2.Write("VD208", Convert.ToSingle(cur_max_temp_1.Text));
                Plc.plc2.Write("VD224", Convert.ToSingle(cur_min_temp_1.Text));
                Plc.plc2.Write("VD212", Convert.ToSingle(cur_max_temp_2.Text));
                Plc.plc2.Write("VD228", Convert.ToSingle(cur_min_temp_2.Text));
                Plc.plc2.Write("VD216", Convert.ToSingle(cur_max_temp_3.Text));
                Plc.plc2.Write("VD232", Convert.ToSingle(cur_min_temp_3.Text));
                Plc.plc2.Write("VD650", Convert.ToSingle(cur_max_temp_4.Text));
                Plc.plc2.Write("VD236", Convert.ToSingle(cur_min_temp_4.Text));
                Plc.plc3.Write("VD208", Convert.ToSingle(cur_max_temp_5.Text));
                Plc.plc3.Write("VD224", Convert.ToSingle(cur_min_temp_5.Text));
                Plc.plc3.Write("VD212", Convert.ToSingle(cur_max_temp_6.Text));
                Plc.plc3.Write("VD228", Convert.ToSingle(cur_min_temp_6.Text));
                Plc.plc3.Write("VD216", Convert.ToSingle(cur_max_temp_7.Text));
                Plc.plc3.Write("VD232", Convert.ToSingle(cur_min_temp_7.Text));
                Plc.plc3.Write("VD650", Convert.ToSingle(cur_max_temp_8.Text));
                Plc.plc3.Write("VD236", Convert.ToSingle(cur_min_temp_8.Text));
                Plc.plc1.Write("VD4010", Convert.ToSingle(cur_max_temp_zz.Text));
                Plc.plc1.Write("VD4014", Convert.ToSingle(cur_min_temp_zz.Text));
                Plc.plc2.Write("VD252", Convert.ToSingle(cur_min_weight_1.Text));
                Plc.plc2.Write("VD248", Convert.ToSingle(cur_min_weight_2.Text));
                Plc.plc2.Write("VD244", Convert.ToSingle(cur_min_weight_3.Text));
                Plc.plc2.Write("VD240", Convert.ToSingle(cur_min_weight_4.Text));
                Plc.plc3.Write("VD252", Convert.ToSingle(cur_min_weight_5.Text));
                Plc.plc3.Write("VD248", Convert.ToSingle(cur_min_weight_6.Text));
                Plc.plc3.Write("VD244", Convert.ToSingle(cur_min_weight_7.Text));
                Plc.plc3.Write("VD240", Convert.ToSingle(cur_min_weight_8.Text));
                Plc.plc1.Write("VD228", Convert.ToSingle(cur_min_weight_zz.Text));
                Plc.plc1.Write("VD232", Convert.ToSingle(cur_min_weight_yh1.Text));
                Plc.plc1.Write("VD236", Convert.ToSingle(cur_min_weight_yh2.Text));
                Plc.plc1.Write("VD240", Convert.ToSingle(t4czsdz.Text));
                Plc.plc1.Write("VD244", Convert.ToSingle(t4czxxsdz.Text));
                Plc.plc1.Write("VW1100", (short)(Convert.ToSingle(frequency_sbs.Text) * 200));
                Plc.plc1.Write("VW1102", (short)(Convert.ToSingle(frequency_t2.Text) * 200));
                Plc.plc1.Write("VW1112", (short)(Convert.ToSingle(frequency_clyj.Text) * 100));
                Plc.plc1.Write("VW1118", (short)(Convert.ToSingle(frequency_clej.Text) * 100));
                Plc.plc1.Write("VW1106", (short)(Convert.ToSingle(frequency_jclq.Text) * 200));
                Plc.plc1.Write("VW1110", (short)(Convert.ToSingle(frequency_wlb.Text) * 200));
                Plc.plc1.Write("VW1108", (short)(Convert.ToSingle(frequency_yhyj.Text) * 100));
                Plc.plc1.Write("VW1116", (short)(Convert.ToSingle(frequency_ejwl.Text) * 200));
                Plc.plc1.Write("VW1104", (short)(Convert.ToSingle(frequency_yhs.Text) * 200));
                Plc.plc2.Write("VW1208", (short)(Convert.ToSingle(frequency_jf.Text) * 200));
                Plc.plc3.Write("VW1208", (short)(Convert.ToSingle(frequency_tjj.Text) * 200));
                Plc.plc1.Write("VW1114", (short)(Convert.ToSingle(frequency_zz.Text) * 200));
                Plc.plc2.Write("VW1200", (short)(Convert.ToSingle(frequency_1.Text) * 200));
                Plc.plc2.Write("VW1202", (short)(Convert.ToSingle(frequency_2.Text) * 200));
                Plc.plc2.Write("VW1204", (short)(Convert.ToSingle(frequency_3.Text) * 200));
                Plc.plc2.Write("VW1206", (short)(Convert.ToSingle(frequency_4.Text) * 200));
                Plc.plc3.Write("VW1200", (short)(Convert.ToSingle(frequency_5.Text) * 200));
                Plc.plc3.Write("VW1202", (short)(Convert.ToSingle(frequency_6.Text) * 200));
                Plc.plc3.Write("VW1204", (short)(Convert.ToSingle(frequency_7.Text) * 200));
                Plc.plc3.Write("VW1206", (short)(Convert.ToSingle(frequency_8.Text) * 200));
                Plc.plc2.Write("VW1250", (short)(Convert.ToSingle(frequency_t4.Text) * 200));
                Plc.plc1.Write("VD800", Convert.ToSingle(zzyjsx.Text));
        }
        private void saveSql()
        {
                Sql.executeNonQuery(string.Format("update setting set cur_max_temp = {0}, cur_min_temp = {1}, cur_min_weight = {2}, frequency = {3} where name = '{4}';", cur_max_temp_1.Text.ToFloat(), cur_min_temp_1.Text.ToFloat(), cur_min_weight_1.Text.ToFloat(), frequency_1.Text.ToFloat(), "生产罐1"));
                Sql.executeNonQuery(string.Format("update setting set cur_max_temp = {0}, cur_min_temp = {1}, cur_min_weight = {2}, frequency = {3} where name = '{4}';", cur_max_temp_2.Text.ToFloat(), cur_min_temp_2.Text.ToFloat(), cur_min_weight_2.Text.ToFloat(), frequency_2.Text.ToFloat(), "生产罐2"));
                Sql.executeNonQuery(string.Format("update setting set cur_max_temp = {0}, cur_min_temp = {1}, cur_min_weight = {2}, frequency = {3} where name = '{4}';", cur_max_temp_3.Text.ToFloat(), cur_min_temp_3.Text.ToFloat(), cur_min_weight_3.Text.ToFloat(), frequency_3.Text.ToFloat(), "生产罐3"));
                Sql.executeNonQuery(string.Format("update setting set cur_max_temp = {0}, cur_min_temp = {1}, cur_min_weight = {2}, frequency = {3} where name = '{4}';", cur_max_temp_4.Text.ToFloat(), cur_min_temp_4.Text.ToFloat(), cur_min_weight_4.Text.ToFloat(), frequency_4.Text.ToFloat(), "生产罐4"));
                Sql.executeNonQuery(string.Format("update setting set cur_max_temp = {0}, cur_min_temp = {1}, cur_min_weight = {2}, frequency = {3} where name = '{4}';", cur_max_temp_5.Text.ToFloat(), cur_min_temp_5.Text.ToFloat(), cur_min_weight_5.Text.ToFloat(), frequency_5.Text.ToFloat(), "生产罐5"));
                Sql.executeNonQuery(string.Format("update setting set cur_max_temp = {0}, cur_min_temp = {1}, cur_min_weight = {2}, frequency = {3} where name = '{4}';", cur_max_temp_6.Text.ToFloat(), cur_min_temp_6.Text.ToFloat(), cur_min_weight_6.Text.ToFloat(), frequency_6.Text.ToFloat(), "生产罐6"));
                Sql.executeNonQuery(string.Format("update setting set cur_max_temp = {0}, cur_min_temp = {1}, cur_min_weight = {2}, frequency = {3} where name = '{4}';", cur_max_temp_7.Text.ToFloat(), cur_min_temp_7.Text.ToFloat(), cur_min_weight_7.Text.ToFloat(), frequency_7.Text.ToFloat(), "生产罐7"));
                Sql.executeNonQuery(string.Format("update setting set cur_max_temp = {0}, cur_min_temp = {1}, cur_min_weight = {2}, frequency = {3} where name = '{4}';", cur_max_temp_8.Text.ToFloat(), cur_min_temp_8.Text.ToFloat(), cur_min_weight_8.Text.ToFloat(), frequency_8.Text.ToFloat(), "生产罐8"));
                Sql.executeNonQuery(string.Format("update setting set cur_max_temp = {0}, cur_min_temp = {1}, cur_min_weight = {2}, frequency = {3}, max_height = {4} where name = '{5}';", cur_max_temp_zz.Text.ToFloat(), cur_min_temp_zz.Text.ToFloat(), cur_min_weight_zz.Text.ToFloat(), frequency_zz.Text.ToFloat(), zzyjsx.Text.ToFloat(), "周转罐"));
                Sql.executeNonQuery(string.Format("update setting set cur_min_weight = {0} where name = '{1}';", cur_min_weight_yh1.Text.ToFloat(), "预混罐1"));
                Sql.executeNonQuery(string.Format("update setting set cur_min_weight = {0} where name = '{1}';", cur_min_weight_yh2.Text.ToFloat(), "预混罐2"));
                Sql.executeNonQuery(string.Format("update setting set frequency = {0} where name = '{1}';", frequency_sbs.Text.ToFloat(), "SBS喂料"));
                Sql.executeNonQuery(string.Format("update setting set frequency = {0} where name = '{1}';", frequency_t2.Text.ToFloat(), "T2喂料"));
                Sql.executeNonQuery(string.Format("update setting set frequency = {0} where name = '{1}';", frequency_clyj.Text.ToFloat(), "出料一剪机"));
                Sql.executeNonQuery(string.Format("update setting set frequency = {0} where name = '{1}';", frequency_clej.Text.ToFloat(), "二剪机"));
                Sql.executeNonQuery(string.Format("update setting set frequency = {0} where name = '{1}';", frequency_jclq.Text.ToFloat(), "基质沥青上料泵"));
                Sql.executeNonQuery(string.Format("update setting set frequency = {0} where name = '{1}';", frequency_wlb.Text.ToFloat(), "喂料泵"));
                Sql.executeNonQuery(string.Format("update setting set frequency = {0} where name = '{1}';", frequency_yhyj.Text.ToFloat(), "预混一剪"));
                Sql.executeNonQuery(string.Format("update setting set frequency = {0} where name = '{1}';", frequency_ejwl.Text.ToFloat(), "二剪喂料泵"));
                Sql.executeNonQuery(string.Format("update setting set frequency = {0} where name = '{1}';", frequency_yhs.Text.ToFloat(), "预混上料泵"));
                Sql.executeNonQuery(string.Format("update setting set frequency = {0} where name = '{1}';", frequency_jf.Text.ToFloat(), "胶粉喂料"));
                Sql.executeNonQuery(string.Format("update setting set frequency = {0} where name = '{1}';", frequency_tjj.Text.ToFloat(), "添加剂投料"));
                Sql.executeNonQuery(string.Format("update setting set frequency = {0}, T4_set_weight = {1}, T4_min_set_weight = {2} where name = '{3}';", frequency_t4.Text.ToFloat(), t4czsdz.Text.ToFloat(), t4czxxsdz.Text.ToFloat(), "T4预混罐"));
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

        private void textBox0_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Add(Index.ui9);
            Index.ui9.BringToFront();
            Index.ui9.Show();
        }

        private void frequency_sbs_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_t2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_clej_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_clyj_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_jclq_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_wlb_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_yhyj_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_ejwl_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_yhs_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_jf_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_tjj_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_t4_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_5_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_6_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_7_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_8_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_4_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_3_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frequency_zz_TextChanged(object sender, EventArgs e)
        {

        }

        private void cur_min_weight_yh2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cur_min_weight_yh1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cur_min_weight_zz_TextChanged(object sender, EventArgs e)
        {

        }

        private void cur_min_weight_8_TextChanged(object sender, EventArgs e)
        {

        }

        private void cur_min_weight_7_TextChanged(object sender, EventArgs e)
        {

        }

        private void cur_min_weight_6_TextChanged(object sender, EventArgs e)
        {

        }

        private void cur_min_weight_5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}

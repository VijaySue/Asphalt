using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using PCHMI;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Asphalt
{
    public partial class Elec : UserControl
    {
        public Elec()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            DateTime dt = new DateTime(2020, 10, 4);

            UILineOption option = new UILineOption();
            option.ToolTip.Visible = true;
            option.Title = new UITitle();
            option.Title.Text = "电流曲线";

            option.XAxisType = UIAxisType.DateTime;

            var series = option.AddSeries(new UILineSeries("Line1"));
            series.Add(dt.AddHours(0), 1.2);
            series.Add(dt.AddHours(1), 2.2);
            series.Add(dt.AddHours(2), 3.2);
            series.Add(dt.AddHours(3), 4.2);
            series.Add(dt.AddHours(4), 3.2);
            series.Add(dt.AddHours(5), 2.2);
            series.Symbol = UILinePointSymbol.Square;
            series.SymbolSize = 4;
            series.SymbolLineWidth = 2;
            series.SymbolColor = Color.Red;
            series.ShowLine = !cbPoints.Checked;
            //数据点显示小数位数
            series.YAxisDecimalPlaces = 2;
            series.Smooth = true;

            series = option.AddSeries(new UILineSeries("Line2", Color.Lime));
            series.Add(dt.AddHours(3), 3.3);
            series.Add(dt.AddHours(4), 2.3);
            series.Add(dt.AddHours(5), 2.3);
            series.Add(dt.AddHours(6), 1.3);
            series.Add(dt.AddHours(7), 2.3);
            series.Add(dt.AddHours(8), 4.3);
            series.Symbol = UILinePointSymbol.Star;
            series.SymbolSize = 4;
            series.SymbolLineWidth = 2;
            series.ShowLine = !cbPoints.Checked;
            //数据点显示小数位数
            series.YAxisDecimalPlaces = 1;
            series.Smooth = true;

            /* option.GreaterWarningArea = new UILineWarningArea(3.5);
             option.LessWarningArea = new UILineWarningArea(2.2, Color.Gold);

             option.YAxisScaleLines.Add(new UIScaleLine("上限", 3.5, Color.Red));
             option.YAxisScaleLines.Add(new UIScaleLine("下限", 2.2, Color.Gold));
            */
            option.XAxis.Name = "日期";
            option.YAxis.Name = "数值";
            //X轴坐标轴显示格式化
            option.XAxis.AxisLabel.DateTimeFormat = "yyyy-MM-dd HH:mm";

            //Y轴坐标轴显示小数位数
            option.YAxis.AxisLabel.DecimalPlaces = 1;

            /* option.XAxisScaleLines.Add(new UIScaleLine(dt.AddHours(3).DateTimeString(), dt.AddHours(3), Color.Red));
             option.XAxisScaleLines.Add(new UIScaleLine(dt.AddHours(6).DateTimeString(), dt.AddHours(6), Color.Red));*/

            //设置X轴显示范围
            option.XAxis.SetRange(dt, dt.AddHours(8));
            LineChart.SetOption(option);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void uiImageButton1_Click(object sender, EventArgs e)
        {
            LineChart.ChartStyleType = UIChartStyleType.Default;
        }

        private void uiImageButton2_Click(object sender, EventArgs e)
        {
            LineChart.ChartStyleType = UIChartStyleType.Plain;
        }

        private void uiImageButton3_Click(object sender, EventArgs e)
        {
            LineChart.ChartStyleType = UIChartStyleType.Dark;

        }
        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            
            UILineOption option = new UILineOption();
            option.ToolTip.Visible = true;
            option.Title = new UITitle();
            option.Title.Text = "电流曲线";
            var series = option.AddSeries(new UILineSeries("Line1"));

            //设置曲线显示最大点数，超过后自动清理
            series.SetMaxCount(50);
            startdatetime = DateTime.Now;
            //坐标轴显示小数位数
            //option.XAxis.AxisLabel.DecimalPlaces = 1;
            option.XAxisType = UIAxisType.DateTime;
            option.XAxis.AxisLabel.DateTimeFormat = "HH:mm:ss";
            option.YAxis.AxisLabel.DecimalPlaces = 1;

            LineChart.SetOption(option);
            timer2.Start();
        }
        DateTime startdatetime = DateTime.Now;
        Random random = new Random();

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            if (this.nodename == "")
            {
                LineChart.Option.AddData("Line1", datetime, random.NextDouble() * 10);//没有选中罐
            }
            else
            {
                //来自于plc
                Console.Write(this.nodename);
                switch (this.nodename)
                {
                    case "周转罐":
                        LineChart.Option.AddData("Line1", datetime, Convert.ToDouble(Plc.plc1.ReadFloat("VD104")));
                        break;
                    case "生产罐1":
                        LineChart.Option.AddData("Line1", datetime, Convert.ToDouble(Plc.plc2.ReadFloat("VD104")));
                        break;
                    case "生产罐2":
                        LineChart.Option.AddData("Line1", datetime, Convert.ToDouble(Plc.plc2.ReadFloat("VD112")));
                        break;
                    case "生产罐3":
                        LineChart.Option.AddData("Line1", datetime, Convert.ToDouble(Plc.plc2.ReadFloat("VD120")));
                        break;
                    case "生产罐4":
                        LineChart.Option.AddData("Line1", datetime, Convert.ToDouble(Plc.plc2.ReadFloat("VD128")));
                        break;
                    case "生产罐5":
                        LineChart.Option.AddData("Line1", datetime, Convert.ToDouble(Plc.plc3.ReadFloat("VD104")));
                        break;
                    case "生产罐6":
                        LineChart.Option.AddData("Line1", datetime, Convert.ToDouble(Plc.plc3.ReadFloat("VD112")));
                        break;
                    case "生产罐7":
                        LineChart.Option.AddData("Line1", datetime, Convert.ToDouble(Plc.plc3.ReadFloat("VD120")));
                        break;
                    case "生产罐8":
                        LineChart.Option.AddData("Line1", datetime, Convert.ToDouble(Plc.plc3.ReadFloat("VD128")));
                        break;

                }

            }

            TimeSpan timeSpan = startdatetime.Subtract(datetime).Duration();
            // MessageBox.Show(timeSpan.ToString());
            int sec = timeSpan.Seconds; if (sec > 5)
            {
                LineChart.Option.XAxis.SetRange(datetime.AddSeconds(-20), datetime.AddSeconds(1));
            }
            LineChart.Option.XAxis.AxisLabel.DateTimeFormat = "HH:mm:ss";
            LineChart.Refresh();
        }

      

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            DateTime time = dateTimePicker1.Value;
            string sql =  string.Format("select * from electrical where date(datetime) = date('{0}') order by name asc, batch asc;", time.ToString("yyyy-MM-dd"));
            MySqlDataReader reader = Sql.executeReader(sql);
            if (reader.HasRows)
            {

                List<string> names = new List<string>();
                List<DateTime> times = new List<DateTime>();
                List<float> temperatures = new List<float>();
                List<int> batchs = new List<int>();
                while (reader.Read())
                {
                    names.Add(reader.GetString(1));

                    times.Add(reader.GetDateTime(0));
                    temperatures.Add(reader.GetFloat(2));
                    batchs.Add(reader.GetInt16(3));
                }
                string[] nameArray = names.ToArray();
                //根据查找的结果，动态生成左边菜单
                string[] gnames = new string[23] { "生产罐1", "生产罐2", "生产罐3", "生产罐4",
                    "生产罐5", "生产罐6", "生产罐7", "生产罐8", "周转罐","预混罐1","预混罐2", 
                    "胶粉喂料" ,    "添加剂投料" ,  "SBS喂料", "T2喂料" ,"出料一剪机","二剪机",
                    "成品泵","二剪喂料","基质沥青上料泵","喂料泵","预混上料泵","预混一剪机"
                };
                uiNavMenuEx1.Nodes.Clear();
                for (int i = 0; i < 23; i++)
                {

                    if (nameArray.Contains(gnames[i]))
                    {
                        TreeNode newNode1 = uiNavMenuEx1.Nodes.Add(gnames[i]);
                        List<int> batchArray = new List<int>();
                        for (int j = 0; j < nameArray.Length; j++)
                        {
                            if (!batchArray.Contains(batchs[j]) && nameArray[j].Equals(gnames[i]))
                            {
                                batchArray.Add(batchs[j]);
                                newNode1.Nodes.Add("第" + batchs[j].ToString() + "班次");
                            }

                        }
                    }
                }
                reader.Close();

            }
            else
            {
                // MessageBox.Show("查询结果为空");
                reader.Close();
            }



        }
        string nodename = "";

        private void uiNavMenuEx1_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            // MessageBox.Show(node.Parent.Text + node.Text);
            
           try
            {
                if (node.Parent == null) return;
                string name = node.Parent.Text;
                nodename = name;
                string result = System.Text.RegularExpressions.Regex.Replace(node.Text, @"[^0-9]+", "");
                int batch = int.Parse(result);
                DateTime time = dateTimePicker1.Value;
                string sql =  string.Format("select * from electrical where name= '{0}' and batch= {1} and date(datetime) = date('{2}') order by name asc, batch asc;", name, batch, time.ToString("yyyy-MM-dd"));
                MySqlDataReader reader = Sql.executeReader(sql);
                //显示图表
                timer2.Stop();
                UILineOption option = new UILineOption();
                option.ToolTip.Visible = true;
                option.Title = new UITitle();
                option.Title.Text = "电流曲线";


                option.XAxisType = UIAxisType.DateTime;

                var series = option.AddSeries(new UILineSeries("Line1"));
                string starttime = "";
                string endtime = "";
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (starttime == "")
                        {
                            starttime = reader.GetDateTime(0).ToString();
                        }
                        series.Add(reader.GetDateTime(0), reader.GetFloat(2));
                        endtime = reader.GetDateTime(0).ToString();
                        //option.XAxisScaleLines.Add(new UIScaleLine(reader.GetDateTime(0).TimeString(), reader.GetDateTime(0), Color.Red));
                        //option.YAxisScaleLines.Add(new UIScaleLine(reader.GetFloat(2).ToString(), reader.GetFloat(2), Color.Green));
                        //MessageBox.Show(reader.GetString(1));
                    }
                    series.Symbol = UILinePointSymbol.Star;
                    series.SymbolSize = 4;
                    series.SymbolLineWidth = 2;
                    series.SymbolColor = Color.Red;
                    series.ShowLine = !cbPoints.Checked;
                    //数据点显示小数位数
                    series.YAxisDecimalPlaces = 2;
                    series.Smooth = true;

                }
                //X轴坐标轴显示格式化
                option.XAxis.AxisLabel.DateTimeFormat = "HH:mm:ss";
                // option.YAxis.Data.Add();
                //Y轴坐标轴显示小数位数
                option.YAxis.AxisLabel.DecimalPlaces = 1;
                option.YAxis.Scale = true;
                //设置x轴的范围
                // float tempMin = LineChart.Option.Series["Line1"].YData.Min();
                //  float tempMax = LineChart.Option.Series["Line1"].YData.Max();
                //option.XAxis.SetRange(starttime.ToDateTime(),endtime.ToDateTime());


                sql = "select * from setting where name='" + name + "' ;";
                reader = Sql.executeReader(sql);
                if (reader.Read())
                {
                    //MessageBox.Show(reader.GetFloat(7).ToString());
                    //设置Y轴的范围
                    //   option.YAxis.SetRange(reader.GetFloat(8), reader.GetFloat(7));
                    // option.YAxisScaleLines.Add(new UIScaleLine() { Color = Color.Red, Name = "上限", Value = reader.GetFloat(7) });
                    //  option.YAxisScaleLines.Add(new UIScaleLine() { Color = Color.Gold, Name = "下限", Value = reader.GetFloat(8) });

                }
                series.ShowLine = !cbPoints.Checked;
                LineChart.SetOption(option);
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }


        private void LineChart_Click(object sender, EventArgs e)
        {

        }

        private void cbPoints_CheckedChanged(object sender, EventArgs e)
        {
            UILineOption option = LineChart.Option;
            if (option != null)
            {

                LineChart.Option.Series["Line1"].ShowLine = !cbPoints.Checked;
                // LineChart.Option.Series["Line1"].ShowLine = !cbPoints.Checked;
                LineChart.SetOption(option);
            }
        }

    }
}

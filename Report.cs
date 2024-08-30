using MySql.Data.MySqlClient;
using PCHMI;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media.Media3D;
using System.Windows.Media;
using System.Security.Cryptography;
using System.Collections;
using System.Drawing.Text;
using System.Data.SqlClient;

namespace Asphalt
{
    public partial class Report : UserControl
    {

        //用于报表打印
        private int flag = 1;    // 1日报表 2周报表 3月报表 4年报表
        private int maximize = -1;    // 最大化标志
        DataTable dt = null;
        DataTable dt2 = null;
        int lq_total = 0;
        int jf_total = 0;
        int tjj_total = 0;
        int t4_total = 0;
        int totalWeight = 0;
        MySqlDataReader reader = null;
        int Men_width = 0;
        int scr_width1 = 0;
        int scr_width2 = 0;
        int scr_left = 0;

        public Report()
        {
            InitializeComponent();
            // SunnyUI封装的加列函数，也可以和原生的一样，从Columns里面添加列

            dt = new DataTable();
            dt2 = new DataTable();

            // 入料
            string sql = "select * from feeding where date(datetime) = date(now()) order by name asc, batch asc;";
            dt.Columns.Add(new System.Data.DataColumn("名称"));
            dt.Columns.Add(new System.Data.DataColumn("材料"));
            dt.Columns.Add(new System.Data.DataColumn("重量"));
            dt.Columns.Add(new System.Data.DataColumn("日期时间"));
            dt.Columns.Add(new System.Data.DataColumn("班次"));
            showDataView(sql);

            // 出料
            sql = "select * from discharge where date(datetime) = date(now()) order by name asc, batch asc;";
            dt2.Columns.Add(new System.Data.DataColumn("名称"));
            dt2.Columns.Add(new System.Data.DataColumn("重量"));
            dt2.Columns.Add(new System.Data.DataColumn("日期时间"));
            dt2.Columns.Add(new System.Data.DataColumn("班次"));
            showDataView2(sql);

            Men_width = uiNavMenuEx1.Width;
            scr_width1 = uiDataGridView1.Width;
            scr_width2 = uiDataGridView2.Width;
            scr_left = uiDataGridView2.Left;

            Maximize = 0;
        }

        private void sizeChanged()
        {
            uiPagination1.PageSize = (uiDataGridView1.Height - uiDataGridView1.ColumnHeadersHeight)  / uiDataGridView1.RowTemplate.Height;
            uiPagination2.PageSize = (uiDataGridView2.Height - uiDataGridView2.ColumnHeadersHeight)  / uiDataGridView2.RowTemplate.Height;
            if (maximize == 1)
            {
                if (uiDataGridView1.Columns.Count > 0)
                {
                    uiDataGridView1.Columns[0].Width = (int)(uiDataGridView1.Width * 0.12);
                    uiDataGridView1.Columns[1].Width = (int)(uiDataGridView1.Width * 0.12);
                    uiDataGridView1.Columns[2].Width = (int)(uiDataGridView1.Width * 0.18);
                    uiDataGridView1.Columns[3].Width = (int)(uiDataGridView1.Width * 0.35);
                    uiDataGridView1.Columns[4].Width = (int)(uiDataGridView1.Width * 0.12);
                }
                if (uiDataGridView2.Columns.Count > 0)
                {
                    uiDataGridView2.Columns[0].Width = (int)(uiDataGridView2.Width * 0.14);
                    uiDataGridView2.Columns[1].Width = (int)(uiDataGridView2.Width * 0.20);
                    uiDataGridView2.Columns[2].Width = (int)(uiDataGridView2.Width * 0.40);
                    uiDataGridView2.Columns[3].Width = (int)(uiDataGridView2.Width * 0.14);
                }
            }
            else
            {
                if (uiDataGridView1.Columns.Count > 0)
                {
                    uiDataGridView1.Columns[0].Width = 70;
                    uiDataGridView1.Columns[1].Width = 60;
                    uiDataGridView1.Columns[2].Width = 81;
                    uiDataGridView1.Columns[3].Width = 170;
                    uiDataGridView1.Columns[4].Width = 50;
                }
                if (uiDataGridView2.Columns.Count > 0)
                {
                    uiDataGridView2.Columns[0].Width = 80;
                    uiDataGridView2.Columns[1].Width = 100;
                    uiDataGridView2.Columns[2].Width = 180;
                    uiDataGridView2.Columns[3].Width = 70;
                }
            }
        }

        public int Flag
        {
            get { return flag; }
            set
            {
                flag = value;
                flagChange();
            }
        }

        public int Maximize
        {
            get { return maximize; }
            set
            {
                maximize = value;
                sizeChanged();            }
        }

        private void flagChange()
        {
            if (flag == 1)
            {
                weekLabel.Text = "";
                datePicker.Value = DateTime.Now;
                label1.Text = "选择日期";
                yearPicker.Visible = false;
                monthPicker.Visible = false;
                datePicker.Visible = true;
                weekPicker.Visible = false;
            }
            else if (flag == 2)
            {
                weekLabel.Text = "";
                weekPicker.Value = DateTime.Now;
                label1.Text = "选择周";
                yearPicker.Visible = false;
                monthPicker.Visible = false;
                datePicker.Visible = false;
                weekPicker.Visible = true;
            }
            else if (flag == 3)
            {
                weekLabel.Text = "";
                monthPicker.Value = DateTime.Now;
                label1.Text = "选择月份";
                yearPicker.Visible = false;
                monthPicker.Visible = true;
                datePicker.Visible = false;
                weekPicker.Visible = false;
            }
            else if (flag == 4)
            {
                weekLabel.Text = "";
                yearPicker.Value = DateTime.Now;
                label1.Text = "选择年份";
                yearPicker.Visible = true;
                monthPicker.Visible = false;
                datePicker.Visible = false;
                weekPicker.Visible = false;
            }
            else
            {
                MessageBox.Show("系统发生错误，操作失败!");
            }
        }

        public void showDataView2(string sql)
        {
            dt2.Clear();
            reader = Sql.executeReader(sql);
            totalWeight = 0;
            while (reader.Read())
            {
                totalWeight += reader.GetInt16(2);
                DataRow dr = dt2.NewRow();
                dr[0] = Convert.ToString(reader[1].ToString());
                dr[1] = Convert.ToString(reader[2].ToString());
                dr[2] = reader.GetDateTime(0).ToString("yyyy-MM-dd HH:mm:ss");
                dr[3] = Convert.ToString(reader[3].ToString());
                dt2.Rows.Add(dr);
            }
            reader.Close();
            label3.Text = string.Format("合计:{0}", totalWeight);
            //设置分页控件总数
            uiPagination2.TotalCount = dt2.Rows.Count;


            //设置统计绑定的表格
            uiDataGridView2.DataSource = null;
            uiDataGridView2.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            uiDataGridView2.DataSource = dt2;
            sizeChanged();
            setDataGridView2();
            uiDataGridView2.Refresh();
        }

        public void showDataView(string sql)
        {
            dt.Clear();
            reader = Sql.executeReader(sql);

            lq_total = jf_total = tjj_total = t4_total = totalWeight = 0;
            while (reader.Read())
            {
                try
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = Convert.ToString(reader[1].ToString());
                    dr[1] = Convert.ToString(reader[4].ToString());
                    dr[2] = Convert.ToString(reader[2].ToString());
                    dr[3] = reader.GetDateTime(0).ToString("yyyy-MM-dd HH:mm:ss");
                    dr[4] = Convert.ToString(reader[3].ToString());
                    dt.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                switch (reader[4].ToString())
                {
                    case "沥青":
                        lq_total += reader.GetInt16(2);
                        break;
                    case "添加剂":
                        tjj_total += reader.GetInt16(2);
                        break;
                    case "胶粉":
                        jf_total += reader.GetInt16(2);
                        break;
                    case "T4":
                        t4_total += reader.GetInt16(2);
                        break;
                }
                totalWeight += reader.GetInt16(2);
            }
            reader.Close();
            label2.Text = String.Format("合计:{0} 沥青:{1} 胶粉:{2} 添加剂:{3} T4:{4}", totalWeight, lq_total, jf_total, tjj_total, t4_total);

            //设置分页控件总数
            uiPagination1.TotalCount = dt.Rows.Count;


            uiDataGridView1.SelectIndexChange += uiDataGridView1_SelectIndexChange;

            //设置统计绑定的表格
            uiDataGridView1.DataSource = null;
            uiDataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            uiDataGridView1.DataSource = dt;
            sizeChanged();
            setDataGridView();
            uiDataGridView1.Refresh();
        }
        public void setDataGridView()
        {

            int count = uiDataGridView1.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                uiDataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            uiDataGridView1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;

        }
        public void setDataGridView2()
        {

            int count = uiDataGridView2.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                uiDataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            uiDataGridView2.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;

        }
        private void uiDataGridView1_SelectIndexChange(object sender, int index)
        {

        }

        private void uiPagination1_Click(object sender, EventArgs e)
        {

        }

        private void uiPagination1_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            //未连接数据库，通过模拟数据来实现
            //一般通过ORM的分页去取数据来填充
            //pageIndex：第几页，和界面对应，从1开始，取数据可能要用pageIndex - 1
            //count：单页数据量，也就是PageSize值
            DataTable data = new DataTable();
            data.Columns.Add(new System.Data.DataColumn("名称"));
            data.Columns.Add(new System.Data.DataColumn("材料"));
            data.Columns.Add(new System.Data.DataColumn("重量"));
            data.Columns.Add(new System.Data.DataColumn("日期时间"));
            data.Columns.Add(new System.Data.DataColumn("班次"));
            for (int i = (pageIndex - 1) * count; i < (pageIndex - 1) * count + count; i++)
            {
                if (i >= dt.Rows.Count) continue;
                DataRow dr = data.NewRow();
                dr.ItemArray = dt.Rows[i].ItemArray;
                data.Rows.Add(dr);
            }
            uiDataGridView1.DataSource = data;
        }

        private void uiPagination2_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            //未连接数据库，通过模拟数据来实现
            //一般通过ORM的分页去取数据来填充
            //pageIndex：第几页，和界面对应，从1开始，取数据可能要用pageIndex - 1
            //count：单页数据量，也就是PageSize值
            DataTable data = new DataTable();
            data.Columns.Add(new System.Data.DataColumn("名称"));
            data.Columns.Add(new System.Data.DataColumn("重量"));
            data.Columns.Add(new System.Data.DataColumn("日期时间"));
            data.Columns.Add(new System.Data.DataColumn("班次"));
            for (int i = (pageIndex - 1) * count; i < (pageIndex - 1) * count + count; i++)
            {
                if (i >= dt2.Rows.Count) continue;
                DataRow dr = data.NewRow();
                dr.ItemArray = dt2.Rows[i].ItemArray;
                data.Rows.Add(dr);
            }
            uiDataGridView2.DataSource = data;
        }

        private Hashtable hash = new Hashtable();

        private void addNode(MySqlDataReader reader)
        {
            if (reader.HasRows)
            {
                List<string> names = new List<string>();

                List<int> batchs = new List<int>();

                while (reader.Read())
                {
                    names.Add(reader.GetString(1));

                    batchs.Add(reader.GetInt16(3));
                }
                string[] nameArray = names.ToArray();
                //根据查找的结果，动态生成左边菜单
                string[] gnames = new string[11] { "生产罐1", "生产罐2", "生产罐3", "生产罐4",
                    "生产罐5", "生产罐6", "生产罐7", "生产罐8", "周转罐","预混罐1","预混罐2" };
                for (int i = 0; i < 11; i++)
                {
                    if (nameArray.Contains(gnames[i]) && !hash.Contains(gnames[i]))
                    {
                        hash.Add(gnames[i], i);
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
        }


        int batch = 0;

        private void uiNavMenuEx1_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            if (node.Parent == null) return;

            string name = node.Parent.Text;
            string result = System.Text.RegularExpressions.Regex.Replace(node.Text, @"[^0-9]+", "");
            batch = int.Parse(result);
            DateTime time = DateTime.Now;
            if (flag == 1) 
                time = datePicker.Value;
            else if (flag == 2)
                time = weekPicker.Value;
            else if (flag == 3)
                time = monthPicker.Value;
            else if (flag == 4)
                time = yearPicker.Value;

            string sql = "";

            // 入料
            if (flag == 1)
                sql = string.Format("select * from feeding where name = '{0}' and batch = {1} and date(datetime) = date('{2}') order by name asc, batch asc;", name, batch, time.ToString("yyyy-MM-dd"));
            else if (flag == 2)
                sql = string.Format("select * from feeding where name = '{0}' and batch = {1} and year(datetime) = year('{2}') and week(datetime, 1) = week('{3}', 1)  order by name asc, batch asc;", name, batch, time.ToString("yyyy-MM-dd"), time.ToString("yyyy-MM-dd"));
            else if (flag == 3)
                sql = string.Format("select * from feeding where name = '{0}' and batch = {1} and year(datetime) = year('{2}') and month(datetime) = month('{3}') order by name asc, batch asc;", name, batch, time.ToString("yyyy-MM-dd"), time.ToString("yyyy-MM-dd"));
            else if (flag == 4)               
                sql = string.Format("select * from feeding where name = '{0}' and batch = {1} and year(datetime) = year('{2}') order by name asc, batch asc;", name, batch, time.ToString("yyyy-MM-dd"));
            showDataView(sql);

            // 出料
            if (flag == 1)
                sql = string.Format("select * from discharge where name = '{0}' and batch = {1} and date(datetime) = date('{2}') order by name asc, batch asc;", name, batch, time.ToString("yyyy-MM-dd"));
            else if (flag == 2)
                sql = string.Format("select * from discharge where name = '{0}' and batch = {1} and year(datetime) = year('{2}') and week(datetime, 1) = week('{3}', 1)  order by name asc, batch asc;", name, batch, time.ToString("yyyy-MM-dd"), time.ToString("yyyy-MM-dd"));
            else if (flag == 3)
                sql = string.Format("select * from discharge where name = '{0}' and batch = {1} and year(datetime) = year('{2}') and month(datetime) = month('{3}') order by name asc, batch asc;", name, batch, time.ToString("yyyy-MM-dd"), time.ToString("yyyy-MM-dd"));
            else if (flag == 4)
                sql = string.Format("select * from discharge where name = '{0}' and batch = {1} and year(datetime) = year('{2}') order by name asc, batch asc;", name, batch, time.ToString("yyyy-MM-dd"));
            showDataView2(sql);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
        /// <summary>
        /// 将dgv列表数据转换为datatable数据
        /// </summary>
        /// <param name="dgv">当前dgv列表对象</param>
        /// <returns>datatable对象</returns>
        private static DataTable GetDgvToTable(UIDataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                System.Data.DataColumn dc = new System.Data.DataColumn(dgv.Columns[count].Name.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        //定义全局变量count，储存当前打印的行数
        int count = 0;
        //定义一个方法，接收一个DataTable类型参数及PrintDocument的PrintPage事件传入的参数e以方便操作

        private void PrintTable(string title, DataTable dt, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //取得对应的Graphics对象
            Graphics g = e.Graphics;
            //获得相关页面X坐标、Y坐标、打印区域宽度、长度
            int x = e.PageSettings.Margins.Left;
            int y = e.PageSettings.Margins.Top;
            int width = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Left - e.PageSettings.Margins.Right;
            int height = e.PageSettings.PaperSize.Height - e.PageSettings.Margins.Top - e.PageSettings.Margins.Bottom;
            //MessageBox.Show(e.PageSettings.Margins.Bottom.ToString());
            //定义打印字体
            Font font = new Font("宋体", 15);
            //rowCount是除去打印过的行数后剩下的行数
            int rowCount = dt.Rows.Count - count;

            //打印标题
            g.DrawString(title, new Font("隶书", 24), System.Drawing.Brushes.Black, x + (dt.Columns.Count) / 2 * 100, y);
            y = y + (int)new Font("隶书", 24).GetHeight() + 10;
            //打印日期和批次
            DateTime time = datePicker.Value;
            g.DrawString("日期：" + time.ToString("yyyy-MM-dd"), new Font("楷体", 15), System.Drawing.Brushes.Black, x + (dt.Columns.Count - 2) * 100, y);
            if (batch != 0)
            {
                g.DrawString("班次：" + batch.ToString(), new Font("楷体", 15), System.Drawing.Brushes.Black, x + (dt.Columns.Count) * 100, y);

            }
            y = y + (int)new Font("楷体", 15).GetHeight();
            //maxPageRow是当前设置下该页面可以打印的最大行数
            int maxPageRow = (height - (int)new Font("隶书", 24).GetHeight() - 10 - (int)new Font("楷体", 15).GetHeight()) / (int)font.GetHeight();
            //因为是表格，先画一条水平直线
            g.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black, 1), new Point(x, y), new Point(x + (dt.Columns.Count) * 100 + 100, y));
            //再画出表格各列的列标题

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string head = dt.Columns[i].ColumnName;
                if ((title == "进料登记表" && i == 4) || (title == "出料登记表" && i == 3))
                {
                    g.DrawString(head, font, System.Drawing.Brushes.Black, x + i * 100 + 100, y);
                }
                else
                {
                    g.DrawString(head, font, System.Drawing.Brushes.Black, x + i * 100, y);
                }
            }
            //画完标题，再画一条直线
            g.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black, 1), new Point(x, y + (int)font.GetHeight()), new Point(x + (dt.Columns.Count) * 100 + 100, y + (int)font.GetHeight()));
            //判断，如果剩下的行数小于可打印的最大行数，则执行下列代码
            if (maxPageRow >= rowCount)
            {
                //当前行数小于Table内总行数时，循环
                while (count < dt.Rows.Count)
                {
                    //内循环打印Table内行数据
                    int columnCount = 0;
                    while (columnCount < dt.Columns.Count)
                    {
                        string temp = dt.Rows[count][columnCount].ToString();
                        //打印每个单元格内的数据
                        if ((title == "进料登记表" && columnCount == 4) || (title == "出料登记表" && columnCount == 3))
                        {
                            g.DrawString(temp, font, System.Drawing.Brushes.Black, x + columnCount * 100 + 100, y + (count % maxPageRow) * (int)font.GetHeight() + (int)font.GetHeight());

                        }
                        else
                        {
                            g.DrawString(temp, font, System.Drawing.Brushes.Black, x + columnCount * 100, y + (count % maxPageRow) * (int)font.GetHeight() + (int)font.GetHeight());
                        }
                        //打印完一行后，继续打印一条直线
                        g.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black, 1), new Point(x, y + (count % maxPageRow) * (int)font.GetHeight() + 2 * (int)font.GetHeight()), new Point(x + (dt.Columns.Count) * 100 + 100, y + (count % maxPageRow) * (int)font.GetHeight() + 2 * (int)font.GetHeight()));
                        columnCount++;
                    }
                    count++;

                }
                /* 
                */
                //所有数据打印完毕后，打印垂直直线
                x = e.PageSettings.Margins.Left;

                for (int i = 0; i <= dt.Columns.Count + 1; i++)
                {
                    if ((title == "进料登记表" && i == 4) || (title == "出料登记表" && i == 3))
                    {
                        g.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black), new Point(x + i * 100 + 100, y), new Point(x + i * 100 + 100, y + rowCount * (int)font.GetHeight() + (int)font.GetHeight()));

                    }
                    else
                    {
                        g.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black), new Point(x + i * 100, y), new Point(x + i * 100, y + rowCount * (int)font.GetHeight() + (int)font.GetHeight()));

                    }
                }
                //打印总的用量结果
                string[] total = new string[] { "沥青:" + lq_total + "Kg ", "添加剂:" + tjj_total + "Kg ", "胶粉:" + jf_total + "Kg ", "T4:" + t4_total + "Kg ", "合计：" + totalWeight + "Kg" };
                y = y + (count % maxPageRow) * (int)font.GetHeight() + 2 * (int)font.GetHeight();
                g.DrawString(total[0], new Font("楷体", 15), System.Drawing.Brushes.Black, x, y);
                g.DrawString(total[1], new Font("楷体", 15), System.Drawing.Brushes.Black, x + 150, y);
                g.DrawString(total[2], new Font("楷体", 15), System.Drawing.Brushes.Black, x + 300, y);
                g.DrawString(total[3], new Font("楷体", 15), System.Drawing.Brushes.Black, x + 450, y);

                y = y + (int)new Font("楷体", 15).GetHeight();
                g.DrawString(total[4], new Font("楷体", 15), System.Drawing.Brushes.Black, x, y);
            }
            //判断，如果剩下的行数大于可打印的最大行数，则执行下列代码
            else
            {
                do
                {
                    //与上面类似，注意下面while的条件
                    int columnCount = 0;
                    while (columnCount < dt.Columns.Count)
                    {
                        string temp = dt.Rows[count][columnCount].ToString();
                        //打印每个单元格
                        if (((title == "进料登记表" && columnCount == 4) || (title == "出料登记表" && columnCount == 3)))
                        {
                            g.DrawString(temp, font, System.Drawing.Brushes.Black, x + columnCount * 100 + 100, y + (count % maxPageRow) * (int)font.GetHeight() + (int)font.GetHeight());

                        }
                        else
                        {
                            g.DrawString(temp, font, System.Drawing.Brushes.Black, x + columnCount * 100, y + (count % maxPageRow) * (int)font.GetHeight() + (int)font.GetHeight());

                        }
                        //打印水平直线
                        g.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black, 1), new Point(x, y + (count % maxPageRow) * (int)font.GetHeight() + 2 * (int)font.GetHeight()), new Point(x + (dt.Columns.Count) * 100 + 100, y + (count % maxPageRow) * (int)font.GetHeight() + 2 * (int)font.GetHeight()));
                        columnCount++;
                    }
                    count++;
                } while ((count % maxPageRow > 0));
                //打印垂直直线
                for (int i = 0; i <= dt.Columns.Count + 1; i++)
                {
                    if ((title == "进料登记表" && i == 4) || (title == "出料登记表" && i == 3))
                    {
                        g.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black), new Point(x + i * 100 + 100, y), new Point(x + i * 100 + 100, y + maxPageRow * (int)font.GetHeight() + (int)font.GetHeight()));
                    }
                    else
                    {
                        g.DrawLine(new System.Drawing.Pen(System.Drawing.Brushes.Black), new Point(x + i * 100, y), new Point(x + i * 100, y + maxPageRow * (int)font.GetHeight() + (int)font.GetHeight()));
                    }
                }
            }
            //指定HasMorePages值，如果页面最大行数小于剩下的行数，则返回true（还有），否则返回false
            if (maxPageRow < rowCount)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
                count = 0;
            }
        }
        private void Report_Load(object sender, EventArgs e)
        {

        }

        private void uiSymbolButton26_Click(object sender, EventArgs e)
        {
            if (Limit.limit[5] == 2)
            {
                try
                {
                    printDialog1.ShowDialog();
                    pageSetupDialog1.Document = this.printDocument3;
                    pageSetupDialog1.ShowDialog();
                    printPreviewDialog1.Document = this.printDocument3;
                    printPreviewDialog1.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("未检测到打印机!");
                }
            }
            else
            {
                MessageBox.Show("您没有权限使用此功能！");
            }
        }

        private void uiDataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.Programmatic)
            {
                string columnBindingName = dgv.Columns[e.ColumnIndex].DataPropertyName;
                switch (dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection)
                {
                    case System.Windows.Forms.SortOrder.None:
                    case System.Windows.Forms.SortOrder.Ascending:
                        CustomSort(columnBindingName, "desc");
                        dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
                        break;
                    case System.Windows.Forms.SortOrder.Descending:
                        CustomSort(columnBindingName, "asc");
                        dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                        break;
                }
            }
        }
        private void CustomSort(string columnBindingName, string sortMode)
        {
            DataTable dt = this.uiDataGridView1.DataSource as DataTable;
            DataView dv = dt.DefaultView;
            dv.Sort = columnBindingName + " " + sortMode;
            this.uiDataGridView1.DataSource = dv.ToTable();
            this.uiDataGridView1.Refresh();
        }

        private void CustomSort2(string columnBindingName, string sortMode)
        {
            DataTable dt = this.uiDataGridView2.DataSource as DataTable;
            DataView dv = dt.DefaultView;
            dv.Sort = columnBindingName + " " + sortMode;
            this.uiDataGridView2.DataSource = dv.ToTable();
            this.uiDataGridView2.Refresh();
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataTable dt1 = GetDgvToTable(uiDataGridView2);
            PrintTable("出料登记表", dt1, e);
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            if (Limit.limit[5] == 2)
            {
                try
                {
                    printDialog1.ShowDialog();
                    printPreviewDialog1.Document = this.printDocument2;
                    printPreviewDialog1.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("未检测到打印机!");
                }
            }
            else
            {
                MessageBox.Show("您没有权限使用此功能！");
            }
        }

        private void printDocument3_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DataTable dt1 = GetDgvToTable(uiDataGridView1);
            PrintTable("进料登记表", dt1, e);
        }

        private void uiSplitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (uiNavMenuEx1.Width == 0)
            {
                uiSymbolButton1.Left = uiSymbolButton1.Left + (Men_width / 2);

            }
            else if (uiNavMenuEx1.Width == Men_width)
            {
                uiSymbolButton1.Left = uiSymbolButton1.Left - (Men_width / 2);

            }
            uiSymbolButton26.Left = uiDataGridView1.Right - uiSymbolButton26.Width;

        }

        private void uiPagination1_Click_1(object sender, EventArgs e)
        {

        }

        private void datePicker_ValueChanged(object sender, DateTime value)
        {
            uiNavMenuEx1.Nodes.Clear();
            hash.Clear();
            DateTime time = datePicker.Value;

            string sql = string.Format("select * from feeding where date(datetime) = date('{0}') order by datetime desc;", time.ToString("yyyy-MM-dd"));
            showDataView(sql);
            batch = 0;
            addNode(Sql.executeReader(sql));

            sql = string.Format("select * from discharge where date(datetime) = date('{0}') order by datetime desc;", time.ToString("yyyy-MM-dd"));
            showDataView2(sql);
            addNode(Sql.executeReader(sql));
        }

        private void monthPicker_ValueChanged(object sender, DateTime value)
        {
            uiNavMenuEx1.Nodes.Clear();
            hash.Clear();
            DateTime time = monthPicker.Value;

            string sql = string.Format("select * from feeding where year(datetime) = year('{0}') and month(datetime) = month('{1}') order by datetime desc;", time.ToString("yyyy-MM-dd"), time.ToString("yyyy-MM-dd"));
            showDataView(sql);
            batch = 0;
            addNode(Sql.executeReader(sql));

            sql = string.Format("select * from discharge where year(datetime) = year('{0}') and month(datetime) = month('{1}') order by datetime desc;", time.ToString("yyyy-MM-dd"), time.ToString("yyyy-MM-dd"));
            showDataView2(sql);
            addNode(Sql.executeReader(sql));
        }

        private void yearPicker_ValueChanged(object sender, DateTime value)
        {
            uiNavMenuEx1.Nodes.Clear();
            hash.Clear();
            DateTime time = yearPicker.Value;

            string sql = string.Format("select * from feeding where year(datetime) = year('{0}') order by datetime desc;", time.ToString("yyyy-MM-dd"));
            showDataView(sql);
            batch = 0;
            addNode(Sql.executeReader(sql));

            sql = string.Format("select * from discharge where year(datetime) = year('{0}') order by datetime desc;", time.ToString("yyyy-MM-dd"));
            showDataView2(sql);
            addNode(Sql.executeReader(sql));
        }

        private void weekPicker_ValueChanged(object sender, DateTime value)
        {
            uiNavMenuEx1.Nodes.Clear();
            hash.Clear();
            DateTime time = weekPicker.Value;
            int dayOfWeek = -1 * (int)time.Date.DayOfWeek;
            // Sunday = 0,Monday = 1,Tuesday = 2,Wednesday = 3,Thursday = 4,Friday = 5,Saturday = 6,
            DateTime weekStartTime = time.AddDays(dayOfWeek + 1);  // 取本周一
            if (dayOfWeek == 0) //如果今天是周日，则开始时间是上周一
            {
                weekStartTime = weekStartTime.AddDays(-7);
            }
            DateTime weekEndTime = weekStartTime.AddDays(6);   // 本周周末
            weekLabel.Text = weekStartTime.ToString("yyyy'年'MM'月'dd'日'") + "至" + weekEndTime.ToString("yyyy'年'MM'月'dd'日'");

            string sql = string.Format("select * from feeding where year(datetime) = year('{0}') and week(datetime, 1) = week('{1}', 1) order by datetime desc;", time.ToString("yyyy-MM-dd"), time.ToString("yyyy-MM-dd"));
            showDataView(sql);
            batch = 0;
            addNode(Sql.executeReader(sql));

            sql = string.Format("select * from discharge where year(datetime) = year('{0}') and week(datetime) = week('{1}', 1) order by datetime desc;", time.ToString("yyyy-MM-dd"), time.ToString("yyyy-MM-dd"));
            showDataView2(sql);
            addNode(Sql.executeReader(sql));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void uiDataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.Programmatic)
            {
                string columnBindingName = dgv.Columns[e.ColumnIndex].DataPropertyName;
                switch (dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection)
                {
                    case System.Windows.Forms.SortOrder.None:
                    case System.Windows.Forms.SortOrder.Ascending:
                        CustomSort2(columnBindingName, "desc");
                        dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
                        break;
                    case System.Windows.Forms.SortOrder.Descending:
                        CustomSort2(columnBindingName, "asc");
                        dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                        break;
                }
            }
        }
    }
}

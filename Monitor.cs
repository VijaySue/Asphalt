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
using System.Web.UI;
using System.Windows;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using MessageBox = System.Windows.Forms.MessageBox;
using static System.Windows.Forms.Timer;
using System.Diagnostics.Eventing.Reader;
using System.IO.Pipelines;
using System.Xml.Linq;
using System.Collections;
using MySql.Data.MySqlClient;
using Point = System.Drawing.Point;
using Org.BouncyCastle.Tls;
using System.Diagnostics;
using Microsoft.VisualBasic;
using HslCommunication;

namespace Asphalt
{
    public partial class Monitor : UserControl
    {
        private System.Threading.Timer timer1 = null;
        private System.Threading.Timer timer2 = null;
        private System.Threading.Timer timer14 = null;
        private System.Threading.Timer timer15 = null;
        private System.Threading.Timer timer4 = null;
        private System.Threading.Timer timer5 = null;
        private System.Threading.Timer timer6 = null;
        private System.Threading.Timer timer7 = null;
        private System.Threading.Timer timer8 = null;
        private System.Threading.Timer timer9 = null;
        private System.Threading.Timer timer10 = null;
        private System.Threading.Timer timer11 = null;
        private System.Threading.Timer timer12 = null;
        private System.Windows.Forms.Timer timerone = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer timertwo = new System.Windows.Forms.Timer();
        Manual manual = null;
        Production production = null;
        SwitchElec swichElec = null;
        public static readonly byte[] data = { 1, 2, 4, 8, 16, 32, 64, 128 };
        private readonly Dictionary<string, (int, int, int)> dict = new Dictionary<string, (int, int, int)>()
        {
            {"生产罐1沥青进口阀",  (2, 0, 4) },
            {"生产罐2沥青进口阀",  (2, 0, 5) },
            {"生产罐3沥青进口阀",  (2, 0, 6) },
            {"生产罐4沥青进口阀",  (2, 0, 7) },
            {"生产罐5沥青进口阀",  (3, 0, 1) },
            {"生产罐6沥青进口阀",  (3, 0, 2) },
            {"生产罐7沥青进口阀",  (3, 0, 3) },
            {"生产罐8沥青进口阀",  (3, 0, 4) },
            {"生产罐1添加剂进口阀",  (2, 1, 0) },
            {"生产罐2添加剂进口阀",  (2, 1, 1) },
            {"生产罐3添加剂进口阀",  (2, 1, 2) },
            {"生产罐4添加剂进口阀",  (2, 1, 3) },
            {"生产罐5添加剂进口阀",  (3, 0, 5) },
            {"生产罐6添加剂进口阀",  (3, 0, 6) },
            {"生产罐7添加剂进口阀",  (3, 0, 7) },
            {"生产罐8添加剂进口阀",  (3, 1, 0) },
            {"生产罐1胶粉进口阀",  (2, 1, 4) },
            {"生产罐2胶粉进口阀",  (2, 1, 5) },
            {"生产罐3胶粉进口阀",  (2, 1, 6) },
            {"生产罐4胶粉进口阀",  (2, 1, 7) },
            {"生产罐5胶粉进口阀",  (3, 1, 1) },
            {"生产罐6胶粉进口阀",  (3, 1, 2) },
            {"生产罐7胶粉进口阀",  (3, 1, 3) },
            {"生产罐8胶粉进口阀",  (3, 1, 4) },
            {"生产罐1T4进口阀",  (2, 2, 0) },
            {"生产罐2T4进口阀",  (2, 2, 1) },
            {"生产罐3T4进口阀",  (2, 2, 2) },
            {"生产罐4T4进口阀",  (2, 2, 3) },
            {"生产罐5T4进口阀",  (3, 1, 5) },
            {"生产罐6T4进口阀",  (3, 1, 6) },
            {"生产罐7T4进口阀",  (3, 1, 7) },
            {"生产罐8T4进口阀",  (3, 2, 0) },
            {"生产罐1出口阀",  (2, 2, 4) },
            {"生产罐2出口阀",  (2, 2, 5) },
            {"生产罐3出口阀",  (2, 2, 6) },
            {"生产罐4出口阀",  (2, 2, 7) },
            {"生产罐5出口阀",  (3, 2, 1) },
            {"生产罐6出口阀",  (3, 2, 2) },
            {"生产罐7出口阀",  (3, 2, 3) },
            {"生产罐8出口阀",  (3, 2, 4) },
            {"左料斗出口阀",  (2, 3, 0) },
            {"右料斗出口阀",  (3, 2, 5) },
            {"SBS料斗阀", (1, 1, 6) },
            {"T2进口阀1", (1, 2, 0) },
            {"T2进口阀2", (1, 2, 1) },
            {"沥青进口阀1", (1, 2, 2) },
            {"沥青进口阀2", (1, 2, 3) },
            {"预混罐出料阀1", (1, 2, 4) },
            {"预混罐出料阀2", (1, 2, 5) },
            {"沥青上料阀", (1, 2, 6) },
            {"一剪机旁路阀", (1, 2, 7) },
            {"二剪机支路进口阀", (1, 3, 0) },
            {"周转物料出口阀", (1, 3, 1) },
            {"装车阀1", (1, 3, 2) },
            {"装车阀2", (1, 3, 3) },
            {"T4沥青进口阀", (2, 4, 0) },
            {"SBS进口阀1", (1, 1, 7) },
            {"SBS进口阀2", (1, 5, 4) },
            {"预混上料阀", (1, 5, 5) }
        };

        public Monitor()
        {
            InitializeComponent();
            timertwo.Tick += timertwo_Tick;

            timer1 = new System.Threading.Timer(refresh1, null, 0, Timeout.Infinite);
            timer14 = new System.Threading.Timer(refresh14, null, 0, Timeout.Infinite);
            timer15 = new System.Threading.Timer(refresh15, null, 0, Timeout.Infinite);
            timer4 = new System.Threading.Timer(refresh4, null, 0, Timeout.Infinite);
            timer7 = new System.Threading.Timer(refresh7, null, 0, Timeout.Infinite);
            timer9 = new System.Threading.Timer(refresh9, null, 0, Timeout.Infinite);
            timer5 = new System.Threading.Timer(refresh5, null, 0, Timeout.Infinite);
            timer8 = new System.Threading.Timer(refresh8, null, 0, Timeout.Infinite);
            timer6 = new System.Threading.Timer(refresh6, null, 0, Timeout.Infinite);
            timer2 = new System.Threading.Timer(saveSql, null, 60000, Timeout.Infinite);
            timer10 = new System.Threading.Timer(refresh10, null, 0, Timeout.Infinite);
            timer11 = new System.Threading.Timer(refresh12, null, 0, Timeout.Infinite);
            timer12 = new System.Threading.Timer(refresh11, null, 0, Timeout.Infinite);
            timer3.Start();
        }

        public void changePage(bool flag)
        {
            if (flag)
            {
                foreach (var valve in Controls)
                {
                    if (valve is UIValve)
                    {
                        UIValve v = (UIValve)valve;
                        v.Location = new Point(v.Location.X + 7, v.Location.Y);
                        v.Size = new System.Drawing.Size(46, v.Size.Height);
                    }
                }
            }
            else
            {
                foreach (var valve in Controls)
                {
                    if (valve is UIValve)
                    {
                        UIValve v = (UIValve)valve;
                        v.Location = new Point(v.Location.X - 7, v.Location.Y);
                        v.Size = new System.Drawing.Size(69, v.Size.Height);
                    }
                }
            }
        }
        OperateResult<float[]> fresult1;
        OperateResult<float[]> fresult2;
        OperateResult<float[]> fresult3;
        OperateResult<Int16[]> i16result1;
        OperateResult<Int16[]> i16result2;
        OperateResult<Int16[]> i16result3;

        private void saveSql(object source)     //定时存储数据
        {
            //称重
            Sql.executeNonQuery(string.Format("insert into weight values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "周转罐", zzcz.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into weight values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐1", cz1.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into weight values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐2", cz2.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into weight values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐3", cz3.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into weight values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐4", cz4.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into weight values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐5", cz5.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into weight values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐6", cz6.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into weight values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐7", cz7.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into weight values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐8", cz8.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into weight values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "预混罐1", yhcz1.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into weight values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "预混罐2", yhcz2.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            //温度
            Sql.executeNonQuery(string.Format("insert into temperature values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "周转罐", zzwd.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into temperature values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐1", wd1.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into temperature values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐2", wd2.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into temperature values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐3", wd3.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into temperature values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐4", wd4.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into temperature values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐5", wd5.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into temperature values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐6", wd6.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into temperature values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐7", wd7.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into temperature values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "生产罐8", wd8.Text.ToFloat(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            //电机电流
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "SBS喂料电机", i16result1.Content[50].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "T2喂料电机", i16result1.Content[51].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "出料一剪机", i16result1.Content[56].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "二剪机", i16result1.Content[59].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "二剪喂料泵", i16result1.Content[58].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "基质沥青上料泵", i16result1.Content[53].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "喂料泵", i16result1.Content[55].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "预混上料泵", i16result1.Content[52].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "预混一剪机", i16result1.Content[54].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "周转罐搅拌电机", i16result1.Content[57].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "罐1搅拌电机",i16result2.Content[55].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "罐2搅拌电机", i16result2.Content[56].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "罐3搅拌电机", i16result2.Content[57].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "罐4搅拌电机", i16result2.Content[58].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "胶粉喂料电机", i16result2.Content[59].ToString(),(DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "罐5搅拌电机", i16result3.Content[55].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "罐6搅拌电机", i16result3.Content[56].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "罐7搅拌电机", i16result3.Content[57].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "罐8搅拌电机", i16result3.Content[58].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "添加剂投料电机", i16result3.Content[59].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));
            Sql.executeNonQuery(string.Format("insert into electrical values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "T4投料电机", i16result2.Content[77].ToString(), (DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1))));  

            timer2.Change(60000, Timeout.Infinite);
        }

        static public int[] weights = new int[8];

        private void refresh1(object source)     //定时更新数据
        {
            fresult1 = Plc.plc1.ReadFloat("VD100", 20);
            fresult2 = Plc.plc2.ReadFloat("VD100", 20);
            fresult3 = Plc.plc3.ReadFloat("VD100", 20);

            zzcz.Text = ((int)fresult1.Content[2]).ToString();   //周转罐称重
            cz1.Text = (weights[0] = (int)fresult2.Content[0]).ToString();   //搅拌罐1称重
            cz2.Text = (weights[1] = (int)fresult2.Content[2]).ToString();   //搅拌罐2称重
            cz3.Text = (weights[2] = (int)fresult2.Content[4]).ToString();   //搅拌罐3称重
            cz4.Text = (weights[3] = (int)fresult2.Content[6]).ToString();   //搅拌罐4称重
            cz5.Text = (weights[4] = (int)fresult3.Content[0]).ToString();   //搅拌罐5称重
            cz6.Text = (weights[5] = (int)fresult3.Content[2]).ToString();   //搅拌罐6称重
            cz7.Text = (weights[6] = (int)fresult3.Content[4]).ToString();   //搅拌罐7称重
            cz8.Text = (weights[7] = (int)fresult3.Content[6]).ToString();   //搅拌罐8称重
            yhcz1.Text = ((int)fresult1.Content[7]).ToString();   //预混罐1称重
            yhcz2.Text = ((int)fresult1.Content[8]).ToString();   //预混罐2称重
            sbscz.Text = ((int)fresult1.Content[9]).ToString();   //SBS称重
            label4.Text = Convert.ToInt32(Plc.plc3.ReadFloat("VD608").Content).ToString();   //T4预混罐称重
            zzwd.Text = ((int)fresult1.Content[1]).ToString();   //周转罐温度
            wd1.Text = ((int)fresult2.Content[1]).ToString();   //搅拌罐1温度
            wd2.Text = ((int)fresult2.Content[3]).ToString();   //搅拌罐2温度
            wd3.Text = ((int)fresult2.Content[5]).ToString();   //搅拌罐3温度
            wd4.Text = ((int)fresult2.Content[7]).ToString();   //搅拌罐4温度
            wd5.Text = ((int)fresult3.Content[1]).ToString();   //搅拌罐5温度
            wd6.Text = ((int)fresult3.Content[3]).ToString();   //搅拌罐6温度
            wd7.Text = ((int)fresult3.Content[5]).ToString();   //搅拌罐7温度
            wd8.Text = ((int)fresult3.Content[7]).ToString();   //搅拌罐8温度

            timer1.Change(0, Timeout.Infinite);
        }

        bool fflag = false;

        private void refresh14(object source)
        {
            while (fflag) Thread.Sleep(3000);
            i16result1 = Plc.plc1.ReadInt16("VW1100", 150);
            i16result2 = Plc.plc2.ReadInt16("VW1100", 150);
            i16result3 = Plc.plc3.ReadInt16("VW1100", 150);
            // 频率，电流显示
            ejwlbfre.Text = (i16result1.Content[88] / 100.0).ToString() + "Hz";
            ejwlbele.Text = (i16result1.Content[58] / 10.0).ToString() + "A";
            ejjfre.Text = (i16result1.Content[89] / 100.0).ToString() + "Hz";
            ejjele.Text = (i16result1.Content[59] / 10.0).ToString() + "A";
            clyjfre.Text = (i16result1.Content[86] / 100.0).ToString() + "Hz";
            clyjele.Text = (i16result1.Content[56] / 10.0).ToString() + "A";
            t4fre.Text = (i16result3.Content[76] / 100.0).ToString() + "Hz";
            t4ele.Text = (i16result3.Content[77] / 10.0).ToString() + "A";
            jffre.Text =  (i16result2.Content[74] / 100.0).ToString() + "Hz";
            jfele.Text = (i16result2.Content[59] / 10.0).ToString() + "A";
            zzfre.Text = (i16result1.Content[87] / 100.0).ToString() + "Hz";
            zzele.Text = (i16result1.Content[57] / 10.0).ToString() + "A";
            tjjfre.Text = (i16result3.Content[74] / 100.0).ToString() + "Hz";
            tjjele.Text = (i16result3.Content[59] / 10.0).ToString() + "A";
            sbsfre.Text = (i16result1.Content[80] / 100.0).ToString() + "Hz";
            sbsele.Text = (i16result1.Content[50] / 10.0).ToString() + "A";
            t2fre.Text = (i16result1.Content[81] / 100.0).ToString() + "Hz";
            t2ele.Text = (i16result1.Content[51] / 10.0).ToString() + "A";
            yhslbfre.Text = (i16result1.Content[82] / 100.0).ToString() + "Hz";
            yhslbele.Text = (i16result1.Content[52] / 10.0).ToString() + "A";
            yhyjfre.Text = (i16result1.Content[84] / 100.0).ToString() + "Hz";
            yhyjele.Text = (i16result1.Content[54] / 10.0).ToString() + "A";
            jzlqfre.Text = (i16result1.Content[83] / 100.0).ToString() + "Hz";
            jzlqele.Text = (i16result1.Content[53] / 10.0).ToString() + "A";
            sc1fre.Text = (i16result2.Content[70] / 100.0).ToString() + "Hz";
            sc1ele.Text = (i16result2.Content[55] / 10.0).ToString() + "A";
            sc2fre.Text = (i16result2.Content[71] / 100.0).ToString() + "Hz";
            sc2ele.Text = (i16result2.Content[56] / 10.0).ToString() + "A";
            sc3fre.Text = (i16result2.Content[72] / 100.0).ToString() + "Hz";
            sc3ele.Text = (i16result2.Content[57] / 10.0).ToString() + "A";
            sc4fre.Text = (i16result2.Content[73] / 100.0).ToString() + "Hz";
            sc4ele.Text = (i16result2.Content[58] / 10.0).ToString() + "A";
            sc5fre.Text = (i16result3.Content[70] / 100.0).ToString() + "Hz";
            sc5ele.Text = (i16result3.Content[55] / 10.0).ToString() + "A";
            sc6fre.Text = (i16result3.Content[71] / 100.0).ToString() + "Hz";
            sc6ele.Text = (i16result3.Content[56] / 10.0).ToString() + "A";
            sc7fre.Text = (i16result3.Content[72] / 100.0).ToString() + "Hz";
            sc7ele.Text = (i16result3.Content[57] / 10.0).ToString() + "A";
            sc8fre.Text = (i16result3.Content[73] / 100.0).ToString() + "Hz";
            sc8ele.Text = (i16result3.Content[58] / 10.0).ToString() + "A";
            wlbfre.Text = (i16result1.Content[85] / 100.0).ToString() + "Hz";
            wlbele.Text = (i16result1.Content[55] / 10.0).ToString() + "A";


            timer14.Change(0, Timeout.Infinite);
        }

        private void refresh15(object source)
        {
            if ((Plc.plc1.ReadByte("VB5001").Content & 1).Equals(1))
            {
                if (jlFlag1 == false)
                {
                    jlFlag1 = true;
                    MessageBox.Show("预混罐1加料完成！");
                    label1.Visible = true;
                }
            }
            else
            {
                jlFlag1 = false;
                label1.Visible = false;
            }
            if ((Plc.plc1.ReadByte("VB5001").Content & 2).Equals(2))
            {
                if (jlFlag2 == false)
                {
                    jlFlag2 = true;
                    MessageBox.Show("预混罐2加料完成！");
                    label1.Visible = true;
                }
            }
            else
            {
                jlFlag2 = false;
                label2.Visible = false;
            }

            timer15.Change(0, Timeout.Infinite);
        }


        private void refresh4(object source)
        {

            //控制阀下面的管道
            uiPipe_lq1.Active = lq1.Active;
            uiPipe_lq2.Active = lq2.Active;
            uiPipe_lq3.Active = lq3.Active;
            uiPipe_lq4.Active = lq4.Active;
            uiPipe_lq5.Active = lq5.Active;
            uiPipe_lq6.Active = lq6.Active;
            uiPipe_lq7.Active = lq7.Active;
            uiPipe_lq8.Active = lq8.Active;
            uiPipe_lq9.Active = lq9.Active;
            uiPipe_lq10.Active = lq10.Active;

            //控制阀下面的管道  
            uiPipe_tjj1.Active = tjj1.Active;
            uiPipe_tjj2.Active = tjj2.Active;
            uiPipe_tjj3.Active = tjj3.Active;
            uiPipe_tjj4.Active = tjj4.Active;
            uiPipe_tjj5.Active = tjj5.Active;
            uiPipe_tjj6.Active = tjj6.Active;
            uiPipe_tjj7.Active = tjj7.Active;
            uiPipe_tjj8.Active = tjj8.Active;

            //控制阀下面的管道  
            uiPipe_t41.Active = t41.Active;
            uiPipe_t42.Active = t42.Active;
            uiPipe_t43.Active = t43.Active;
            uiPipe_t44.Active = t44.Active;
            uiPipe_t45.Active = t45.Active;
            uiPipe_t46.Active = t46.Active;
            uiPipe_t47.Active = t47.Active;
            uiPipe_t48.Active = t48.Active;

            //控制阀下面的管道  
            uiPipe_jf1.Active = jf1.Active;
            uiPipe_jf2.Active = jf2.Active;
            uiPipe_jf3.Active = jf3.Active;
            uiPipe_jf4.Active = jf4.Active;
            uiPipe_jf5.Active = jf5.Active;
            uiPipe_jf6.Active = jf6.Active;
            uiPipe_jf7.Active = jf7.Active;
            uiPipe_jf8.Active = jf8.Active;
            uiPipe_cl1_1.Active = cl1.Active;
            uiPipe_cl2_1.Active = cl2.Active;
            uiPipe4.Active = uiPipe5.Active = t4lq.Active;
            uiPipe_lqs6.Active = uiPipe_lqs5.Active = uiPipe_lqs4.Active = lqs.Active;
            uiPipe_cl1_2.Active = uiPipe_cl1_1.Active || uiPipe_cl2_1.Active;
            uiPipe_cl3_1.Active = cl3.Active;
            uiPipe_cl4_1.Active = cl4.Active;
            uiPipe_cl3_2.Active = uiPipe_cl3_1.Active || uiPipe_cl4_1.Active;
            uiPipe_cl5_1.Active = cl5.Active;
            uiPipe_cl6_1.Active = cl6.Active;
            uiPipe_cl5_2.Active = uiPipe_cl5_1.Active || uiPipe_cl6_1.Active;
            uiPipe_cl7_1.Active = cl7.Active;
            uiPipe_cl8_1.Active = cl8.Active;
            uiPipe_cl7_2.Active = uiPipe_cl7_1.Active || uiPipe_cl8_1.Active;
            uiPipe_t2_1.Active = t21.Active;
            uiPipe_t2_2.Active = t22.Active;
            uiPipe_sbs_cl_1.Active = uiPipe_sbs_cl_2.Active = uiPipe_sbs_cl_3.Active = sbs.Active;
            uiPipe_hl1.Active = hl1.Active;
            uiPipe_hl2.Active = hl2.Active;
            uiPipe_hl.Active = hl1.Active || hl2.Active;
            uiPipe_yj_1.Active = uiPipe_yj_2.Active = uiPipe_yj_3.Active = uiPipe_yj_4.Active = uiPipe_yj_5.Active = yjfm.Active;
            uiPipe_ej_1.Active = ejfm.Active;
            uiPipe_clz_1.Active = clz.Active;
            uiPipe_zc1.Active = zc1.Active;
            uiPipe_zc2.Active = zc2.Active;
            uiPipe_sbs_fl_3.Active = sbsj1.Active;
            uiPipe_sbs_fl_1.Active = sbsj2.Active;

            // 其他管道
            uiPipe_dj_t2_1.Active = uiPipe_dj_t2_2.Active = uiPipe_dj_t2_3.Active = (Plc.plc1.ReadByte("Q17").Content & 2).Equals(2) || (Plc.plc1.ReadByte("Q17").Content & 4).Equals(4) ? true : false;
            uiPipe_tjj_1.Active = uiPipe_tjj_2.Active = uiPipe_tjj_3.Active = uiPipe_tjj_4.Active = uiPipe_tjj_5.Active = uiPipe_tjj_6.Active = uiPipe_tjj_7.Active = uiPipe_tjj_8.Active = uiPipe_tjj_s1.Active = (Plc.plc3.ReadByte("Q0").Content & 2).Equals(2) ? true : false;
            uiPipe1.Active = uiPipe2.Active = (Plc.plc2.ReadByte("Q13").Content & 32).Equals(32) || (Plc.plc2.ReadByte("Q13").Content & 64).Equals(64) ? true : false;
            uiPipe_jf_z_s.Active = uiPipe_jf_z_1.Active = uiPipe_jf_z_2.Active = uiPipe_jf_z_3.Active = uiPipe_jf_z_4.Active = (Plc.plc2.ReadByte("Q13").Content & 2).Equals(2) || (Plc.plc2.ReadByte("Q13").Content & 4).Equals(4) ? true : false;
            uiPipe_jf_y_s.Active = uiPipe_jf_y_5.Active = uiPipe_jf_y_6.Active = uiPipe_jf_y_7.Active = uiPipe_jf_y_8.Active = (Plc.plc3.ReadByte("Q13").Content & 2).Equals(2) || (Plc.plc3.ReadByte("Q13").Content & 4).Equals(4) ? true : false;
            uiPipe_clz_2.Active = uiPipe_clz_3.Active = uiPipe_clz_4.Active = uiPipe_clz_5.Active = (Plc.plc1.ReadByte("Q0").Content & 1).Equals(1) ? true : false;
            uiPipe_clz_6.Active = uiPipe_clz_7.Active = uiPipe_clz_8.Active = (Plc.plc1.ReadByte("Q12").Content & 8).Equals(8) ? true : false;
            uiPipe_lqs_1.Active = uiPipe_lqs1.Active = uiPipe_lqs2.Active = uiPipe_lqs3.Active = (Plc.plc1.ReadByte("Q17").Content & 16).Equals(16) ? true : false;
            uiPipe_lqs4.Active = (Plc.plc1.ReadByte("Q9").Content & 1).Equals(1) ? true : false;
            uiPipe_lqs5.Active = (Plc.plc1.ReadByte("Q13").Content & 64).Equals(64) ? true : false;
            uiPipe_hl_1.Active = uiPipe_hl_2.Active = uiPipe_hl_3.Active = uiPipe_hl_4.Active = uiPipe_hl_5.Active = (Plc.plc1.ReadByte("Q17").Content & 128).Equals(128) ? true : false;
            
            zc1.ValveColor = zc1.Active ? Color.Green : Color.Red;
            zc2.ValveColor = zc2.Active ? Color.Green : Color.Red;
            clz.ValveColor = clz.Active ? Color.Green : Color.Red;
            yjfm.ValveColor = yjfm.Active ? Color.Green : Color.Red;
            ejfm.ValveColor = ejfm.Active ? Color.Green : Color.Red;
            t4lq.ValveColor = t4lq.Active ? Color.Green : Color.Red;
            sbs.ValveColor = sbs.Active ? Color.Green : Color.Red;
            sbsj1.ValveColor = sbsj1.Active ? Color.Green : Color.Red;
            sbsj2.ValveColor = sbsj2.Active ? Color.Green : Color.Red;
            t41.ValveColor = t41.Active ? Color.Green : Color.Red;
            t42.ValveColor = t42.Active ? Color.Green : Color.Red;
            t43.ValveColor = t43.Active ? Color.Green : Color.Red;
            t44.ValveColor = t44.Active ? Color.Green : Color.Red;
            t45.ValveColor = t45.Active ? Color.Green : Color.Red;
            t46.ValveColor = t46.Active ? Color.Green : Color.Red;
            t47.ValveColor = t47.Active ? Color.Green : Color.Red;
            t48.ValveColor = t48.Active ? Color.Green : Color.Red;
            jf1.ValveColor = jf1.Active ? Color.Green : Color.Red;
            jf2.ValveColor = jf2.Active ? Color.Green : Color.Red;
            jf3.ValveColor = jf3.Active ? Color.Green : Color.Red;
            jf4.ValveColor = jf4.Active ? Color.Green : Color.Red;
            jf5.ValveColor = jf5.Active ? Color.Green : Color.Red;
            jf6.ValveColor = jf6.Active ? Color.Green : Color.Red;
            jf7.ValveColor = jf7.Active ? Color.Green : Color.Red;
            jf8.ValveColor = jf8.Active ? Color.Green : Color.Red;
            tjj1.ValveColor = tjj1.Active ? Color.Green : Color.Red;
            tjj2.ValveColor = tjj2.Active ? Color.Green : Color.Red;
            tjj3.ValveColor = tjj3.Active ? Color.Green : Color.Red;
            tjj4.ValveColor = tjj4.Active ? Color.Green : Color.Red;
            tjj5.ValveColor = tjj5.Active ? Color.Green : Color.Red;           

            tjj6.ValveColor = tjj6.Active ? Color.Green : Color.Red;
            tjj7.ValveColor = tjj7.Active ? Color.Green : Color.Red;
            tjj8.ValveColor = tjj8.Active ? Color.Green : Color.Red;
            lq1.ValveColor = lq1.Active ? Color.Green : Color.Red;
            lq2.ValveColor = lq2.Active ? Color.Green : Color.Red;
            lq3.ValveColor = lq3.Active ? Color.Green : Color.Red;
            lq4.ValveColor = lq4.Active ? Color.Green : Color.Red;
            lq5.ValveColor = lq5.Active ? Color.Green : Color.Red;
            lq6.ValveColor = lq6.Active ? Color.Green : Color.Red;
            lq7.ValveColor = lq7.Active ? Color.Green : Color.Red;
            lq8.ValveColor = lq8.Active ? Color.Green : Color.Red;
            cl1.ValveColor = cl1.Active ? Color.Green : Color.Red;
            cl2.ValveColor = cl2.Active ? Color.Green : Color.Red;
            cl3.ValveColor = cl3.Active ? Color.Green : Color.Red;
            cl4.ValveColor = cl4.Active ? Color.Green : Color.Red;
            cl5.ValveColor = cl5.Active ? Color.Green : Color.Red;
            cl6.ValveColor = cl6.Active ? Color.Green : Color.Red;
            cl7.ValveColor = cl7.Active ? Color.Green : Color.Red;
            cl8.ValveColor = cl8.Active ? Color.Green : Color.Red;
            lqs.ValveColor = lqs.Active ? Color.Green : Color.Red;
            lq9.ValveColor = lq9.Active ? Color.Green : Color.Red;
            lq10.ValveColor = lq10.Active ? Color.Green : Color.Red;
            t21.ValveColor = t21.Active ? Color.Green : Color.Red;
            t22.ValveColor = t22.Active ? Color.Green : Color.Red;
            hl1.ValveColor = hl1.Active ? Color.Green : Color.Red;
            hl2.ValveColor = hl2.Active ? Color.Green : Color.Red;
            yhsl.ValveColor = yhsl.Active ? Color.Green : Color.Red;

            uiLight1.OnColor = zc2.Active ? Color.Green : Color.Red;    //装车指示灯
            uiLight3.OnColor = zc1.Active ? Color.Green : Color.Red;
            pictureBox203.Image = zc1.Active ? global::Asphalt.Properties.Resources.货车 : global::Asphalt.Properties.Resources.货车2;
            pictureBox204.Image = zc2.Active ? global::Asphalt.Properties.Resources.货车 : global::Asphalt.Properties.Resources.货车2;
            uiLight1.OnColor = zc2.Active ? Color.Green : Color.Red;    //装车指示灯
            uiLight3.OnColor = zc1.Active ? Color.Green : Color.Red;
            pictureBox203.Image = zc1.Active ? global::Asphalt.Properties.Resources.货车 : global::Asphalt.Properties.Resources.货车2;
            pictureBox204.Image = zc2.Active ? global::Asphalt.Properties.Resources.货车 : global::Asphalt.Properties.Resources.货车2;

            buttonE.BackColor = ((Plc.plc1.ReadByte("M20").Content) & 1) == 1 ? Color.Green : Color.Red;

            timer4.Change(0, Timeout.Infinite);
        }

        private void refresh5(object source)
        {   
            byte q16 = Plc.plc1.ReadByte("Q16").Content;
            // 车位
            if ((q16 & 4).Equals(4))
            {
                uiLight3.OnColor = Color.Green;
            }
            else
            {
                uiLight3.OnColor = Color.Red;
            }
            if ((q16 & 8).Equals(8))
            {
                uiLight1.OnColor = Color.Green;
            }
            else
            {
                uiLight1.OnColor = Color.Red;
            }

            byte q17 = Plc.plc1.ReadByte("Q17").Content;
            // 电机正反转
            if ((q17 & 2).Equals(2))
            {
                t2wldj.Image = global::Asphalt.Properties.Resources.绿色电机;
            }
            else if ((q17 & 4).Equals(4))
            {
                t2wldj.Image = global::Asphalt.Properties.Resources.黄色电机;
            }
            else
            {
                t2wldj.Image = global::Asphalt.Properties.Resources.灰色电机;
            }
            if ((q16 & 128).Equals(128))
            {
                sbswldj.Image = global::Asphalt.Properties.Resources.绿色电机;
            }
            else if ((q17 & 1).Equals(1))
            {
                sbswldj.Image = global::Asphalt.Properties.Resources.黄色电机;
            }
            else
            {
                sbswldj.Image = global::Asphalt.Properties.Resources.灰色电机;
            }
            byte i21 = Plc.plc2.ReadByte("I1").Content, q213 = Plc.plc2.ReadByte("Q13").Content;
            if ((i21 & 64).Equals(64))
            {
                jfztldj.Image = global::Asphalt.Properties.Resources.红色电机;
            }
            else if ((q213 & 2).Equals(2))
            {
                jfztldj.Image = global::Asphalt.Properties.Resources.绿色电机;
            }
            else if ((q213 & 4).Equals(4))
            {
                jfztldj.Image = global::Asphalt.Properties.Resources.黄色电机;
            }
            else
            {
                jfztldj.Image = global::Asphalt.Properties.Resources.灰色电机;
            }
            byte q31 = Plc.plc3.ReadByte("I1").Content;
            byte q313 = Plc.plc3.ReadByte("Q13").Content;
            if ((q31 & 64).Equals(64))
            {
                jfytldj.Image = global::Asphalt.Properties.Resources.红色电机;
            }
            else if ((q313 & 2).Equals(2))
            {
                jfytldj.Image = global::Asphalt.Properties.Resources.绿色电机;
            }
            else if ((q313 & 4).Equals(4))
            {
                jfytldj.Image = global::Asphalt.Properties.Resources.黄色电机;
            }
            else
            {
                jfytldj.Image = global::Asphalt.Properties.Resources.灰色电机;
            }
            if ((i21 & 128).Equals(128))
            {
                fldj.Image = global::Asphalt.Properties.Resources.红色电机;
            }
            else if ((q213 & 32).Equals(32))
            {
                fldj.Image = global::Asphalt.Properties.Resources.绿色电机;
            }
            else if ((q213 & 64).Equals(64))
            {
                fldj.Image = global::Asphalt.Properties.Resources.黄色电机;
            }
            else
            {
                fldj.Image = global::Asphalt.Properties.Resources.灰色电机;
            }

            if ((Plc.plc1.ReadByte("M20").Content & 1) == 1)
            {
                buttonE.BackColor = Color.Green;
            }
            else
            {
                buttonE.BackColor = Color.Red;
            }

            timer5.Change(0, Timeout.Infinite);
        }

        private void refresh6(object source)
        {
            byte i10 = Plc.plc1.ReadByte("I0").Content, i22 = Plc.plc2.ReadByte("I2").Content, q212 = Plc.plc2.ReadByte("Q12").Content,q213 = Plc.plc2.ReadByte("Q13").Content;
            byte q20 = Plc.plc2.ReadByte("Q0").Content, q30 = Plc.plc3.ReadByte("Q0").Content, q312 = Plc.plc3.ReadByte("Q12").Content, q10 = Plc.plc1.ReadByte("Q0").Content;
            byte q117 = Plc.plc1.ReadByte("Q17").Content, q313 = Plc.plc3.ReadByte("Q13").Content;
            yhdj1.Image = (i10 & 8).Equals(8) ? global::Asphalt.Properties.Resources.红色电机 : (Plc.plc1.ReadByte("Q8").Content & 1).Equals(1) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            yhdj2.Image = (i10 & 16).Equals(16) ? global::Asphalt.Properties.Resources.红色电机 : (Plc.plc1.ReadByte("Q8").Content & 16).Equals(16) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            jfwldj.Image = (q20 & 16).Equals(16) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            jftsdj.Image = (Plc.plc2.ReadByte("I2").Content & 1).Equals(1) ? global::Asphalt.Properties.Resources.红色电机 : (q213 & 128).Equals(128) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            dj1.Image = (q212 & 32).Equals(32) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            dj2.Image = (q212 & 64).Equals(64) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            dj3.Image = (q212 & 128).Equals(128) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            dj4.Image = (q213 & 1).Equals(1) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            tjjtldj.Image = (q30 & 2).Equals(2) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            dj5.Image = (q312 & 32).Equals(32) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            dj6.Image = (q312 & 64).Equals(64) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            dj7.Image = (q312 & 128).Equals(128) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            dj8.Image = (q313 & 1).Equals(1) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            djz.Image = (q117 & 128).Equals(128) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            t4jb.Image = (Plc.plc2.ReadByte("I0").Content & 32).Equals(32) ? global::Asphalt.Properties.Resources.红色电机 : (q213 & 8).Equals(8) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            t4tl.Image = (Plc.plc3.ReadByte("I0").Content & 32).Equals(32) ? global::Asphalt.Properties.Resources.红色电机 : (q313 & 8).Equals(8) ? global::Asphalt.Properties.Resources.绿色电机 : global::Asphalt.Properties.Resources.灰色电机;
            yhyj.Image = (q117 & 32).Equals(32) ? global::Asphalt.Properties.Resources.二剪_绿 : global::Asphalt.Properties.Resources.二剪;
            yjj.Image = (q10 & 4).Equals(4) ? global::Asphalt.Properties.Resources.二剪_绿 : global::Asphalt.Properties.Resources.二剪;
            ejj.Image = (q10 & 2).Equals(2) ? global::Asphalt.Properties.Resources.二剪_绿 : global::Asphalt.Properties.Resources.二剪;

            timer6.Change(0, Timeout.Infinite);
        }

        private void refresh7(object source)
        {

            //各种阀的状态
            //沥青进口阀
            byte i28 = Plc.plc2.ReadByte("I8").Content, i38 = Plc.plc3.ReadByte("I8").Content;
            lq1.Active = (i28 & 1).Equals(1) ? true : false;//罐1沥青进口阀手动打开
            lq2.Active = (i28 & 2).Equals(2) ? true : false;//罐2沥青进口阀手动打开           
            lq3.Active = (i28 & 4).Equals(4) ? true : false;//罐3沥青进口阀手动打开
            lq4.Active = (i28 & 8).Equals(8) ? true : false;//罐4沥青进口阀手动打开
            lq5.Active = (i38 & 1).Equals(1) ? true : false;//罐5沥青进口阀手动打开
            lq6.Active = (i38 & 2).Equals(2) ? true : false;//罐6沥青进口阀手动打开
            lq7.Active = (i38 & 4).Equals(4) ? true : false;//罐7沥青进口阀手动打开
            lq8.Active = (i38 & 8).Equals(8) ? true : false;//罐8沥青进口阀手动打开
            
            //添加剂进口阀
            tjj1.Active = (i28 & 16).Equals(16) ? true : false;//罐1添加剂进口阀手动打开
            tjj2.Active = (i28 & 32).Equals(32) ? true : false;//罐2添加剂进口阀手动打开
            tjj3.Active = (i28 & 64).Equals(64) ? true : false;//罐3添加剂进口阀手动打开
            tjj4.Active = (i28 & 128).Equals(128) ? true : false;//罐4添加剂进口阀手动打开
            tjj5.Active = (i38 & 16).Equals(16) ? true : false;//罐5添加剂进口阀手动打开
            tjj6.Active = (i38 & 32).Equals(32) ? true : false;//罐6添加剂进口阀手动打开
            tjj7.Active = (i38 & 64).Equals(64) ? true : false;//罐7添加剂进口阀手动打开
            tjj8.Active = (i38 & 128).Equals(128) ? true : false;//罐8添加剂进口阀手动打开

            lq9.Active = (Plc.plc1.ReadByte("I8").Content & 4).Equals(4) ? true : false;//预混罐1沥青进口阀手动打开
            lq10.Active = (Plc.plc1.ReadByte("I1").Content & 8).Equals(8) ? true : false; //预混罐2沥青进口阀手动打开

            timer7.Change(0, Timeout.Infinite);
        }

        private bool[] errorFlag = new bool[10];

        bool jlFlag1, jlFlag2;

        private void refresh8(object source)
        {
            byte i20 = Plc.plc2.ReadByte("I0").Content, i21 = Plc.plc2.ReadByte("I1").Content, i30 = Plc.plc3.ReadByte("I0").Content, i31 = Plc.plc3.ReadByte("I1").Content;
            byte q20 = Plc.plc2.ReadByte("Q0").Content, q30 = Plc.plc3.ReadByte("Q0").Content;

            //燃烧器
            bool a = (i20 & 64).Equals(64), b = (i20 & 128).Equals(128);
            if (a || b) {
                hm1.Image = global::Asphalt.Properties.Resources.火苗_红;
                if (errorFlag[1] == false)
                {
                    if (a) MessageBox.Show("生产罐1燃烧器1故障，请检查错误");
                    if (b) MessageBox.Show("生产罐1燃烧器2故障，请检查错误");
                }
                errorFlag[1] = true;
            } 
            else
            {
                errorFlag[1] = false;
                hm1.Image = (q20 & 1).Equals(1) ?  global::Asphalt.Properties.Resources.火苗_黄 : global::Asphalt.Properties.Resources.火苗_灰;
            }

            a = (i21 & 1).Equals(1);
            b = (i21 & 2).Equals(2);
            if (a || b) {
                hm2.Image = global::Asphalt.Properties.Resources.火苗_红;
                if (errorFlag[2] == false)
                {
                    if (a) MessageBox.Show("生产罐2燃烧器1故障，请检查错误");
                    if (b) MessageBox.Show("生产罐2燃烧器2故障，请检查错误");
                }
                errorFlag[2] = true;
            }
            else
            {
                errorFlag[2] = false;
                hm2.Image = (q20 & 2).Equals(2) ? global::Asphalt.Properties.Resources.火苗_黄 : global::Asphalt.Properties.Resources.火苗_灰;
            }

            a = (i21 & 4).Equals(4);
            b = (i21 & 8).Equals(8);
            if (a || b) {
                hm3.Image = global::Asphalt.Properties.Resources.火苗_红;
                if (errorFlag[3] == false)
                {
                    if (a) MessageBox.Show("生产罐2燃烧器1故障，请检查错误");
                    if (b) MessageBox.Show("生产罐2燃烧器2故障，请检查错误");
                }
                errorFlag[3] = true;
            }
            else
            {
                errorFlag[3] = false;
                hm3.Image = (q20 & 4).Equals(4) ? global::Asphalt.Properties.Resources.火苗_黄 : global::Asphalt.Properties.Resources.火苗_灰;
            }

            a = (i21 & 16).Equals(16);
            b = (i21 & 32).Equals(32);
            if (a || b) {
                hm4.Image = global::Asphalt.Properties.Resources.火苗_红;
                if (errorFlag[4] == false)
                {
                    if (a) MessageBox.Show("生产罐4燃烧器1故障，请检查错误");
                    if (b) MessageBox.Show("生产罐4燃烧器2故障，请检查错误");
                }
                errorFlag[4] = true;
            }
            else
            {
                errorFlag[4] = false;
                hm4.Image = (q20 & 8).Equals(8) ? global::Asphalt.Properties.Resources.火苗_黄 : global::Asphalt.Properties.Resources.火苗_灰;
            }

            a = (i30 & 64).Equals(64);
            b = (i30 & 128).Equals(128);
            if (a || b) {
                hm5.Image = global::Asphalt.Properties.Resources.火苗_红;
                if (errorFlag[5] == false)
                {
                    if (a) MessageBox.Show("生产罐5燃烧器1故障，请检查错误");
                    if (b) MessageBox.Show("生产罐5燃烧器2故障，请检查错误");
                }
                errorFlag[5] = true;
            }
            else
            {
                hm5.Image = (Plc.plc3.ReadByte("Q13").Content & 32).Equals(32) ? global::Asphalt.Properties.Resources.火苗_黄 : global::Asphalt.Properties.Resources.火苗_灰;
            }

            a = (i31 & 1).Equals(1);
            b = (i31 & 2).Equals(2);
            if (a || b) {
                hm6.Image = global::Asphalt.Properties.Resources.火苗_红;
                if (errorFlag[6] == false)
                {
                    if (a) MessageBox.Show("生产罐6燃烧器1故障，请检查错误");
                    if (b) MessageBox.Show("生产罐6燃烧器2故障，请检查错误");
                }
                errorFlag[6] = true;
            }
            else
            {
                hm6.Image =(Plc.plc3.ReadByte("Q13").Content & 64).Equals(64) ? global::Asphalt.Properties.Resources.火苗_黄 : global::Asphalt.Properties.Resources.火苗_灰;
            }

            a = (i31 & 4).Equals(4);
            b = (i31 & 8).Equals(8);
            if (a || b) {
                hm7.Image = global::Asphalt.Properties.Resources.火苗_红;
                if (errorFlag[7] == false)
                {
                    if (a) MessageBox.Show("生产罐7燃烧器1故障，请检查错误");
                    if (b) MessageBox.Show("生产罐7燃烧器2故障，请检查错误");
                }
                errorFlag[7] = true;
            }
            else
            {
                hm7.Image = (Plc.plc3.ReadByte("Q13").Content & 128).Equals(128) ? global::Asphalt.Properties.Resources.火苗_黄 : global::Asphalt.Properties.Resources.火苗_灰;
            }
            
            a = (i31 & 16).Equals(16);
            b = (i31 & 32).Equals(32);
            if (a || b) {
                hm8.Image = global::Asphalt.Properties.Resources.火苗_红;
                if (errorFlag[8] == false)
                {
                    if (a) MessageBox.Show("生产罐8燃烧器1故障，请检查错误");
                    if (b) MessageBox.Show("生产罐8燃烧器2故障，请检查错误");
                }
                errorFlag[8] = true;
            }
            else
            {
                hm8.Image = (q30 & 1).Equals(1) ? global::Asphalt.Properties.Resources.火苗_黄 : global::Asphalt.Properties.Resources.火苗_灰;
            }

            a = (Plc.plc1.ReadByte("I8").Content & 8).Equals(8);
            b = (Plc.plc1.ReadByte("I8").Content & 16).Equals(16);
            if (a || b) {
                hm8.Image = global::Asphalt.Properties.Resources.火苗_红;
                if (errorFlag[9] == false)
                {
                    if (a) MessageBox.Show("周转罐燃烧器1故障，请检查错误");
                    if (b) MessageBox.Show("周转罐燃烧器2故障，请检查错误");
                }
                errorFlag[9] = true;
            }
            else
            {
                hm9.Image = (Plc.plc1.ReadByte("Q0").Content & 8).Equals(8) ? global::Asphalt.Properties.Resources.火苗_黄 : global::Asphalt.Properties.Resources.火苗_灰;
            }

            timer8.Change(0, Timeout.Infinite);
        }

        private void refresh9(object source)
        {
            byte i29 = Plc.plc2.ReadByte("I9").Content, i39 = Plc.plc3.ReadByte("I9").Content, i20 = Plc.plc2.ReadByte("I0").Content, i30 = Plc.plc3.ReadByte("I0").Content;
            // 加胶粉进口阀
            jf1.Active = (i29 & 1).Equals(1) ? true : false;//罐1加胶粉进口阀手动打开
            jf2.Active = (i29 & 2).Equals(2) ? true : false;//罐2加胶粉进口阀手动打开
            jf3.Active = (i29 & 4).Equals(4) ? true : false;//罐3加胶粉进口阀手动打开
            jf4.Active = (i29 & 8).Equals(8) ? true : false;//罐4加胶粉进口阀手动打开
            jf5.Active = (i39 & 1).Equals(1) ? true : false;//罐5加胶粉进口手动打开
            jf6.Active = (i39 & 2).Equals(2) ? true : false;//罐6加胶粉进口阀手动打开
            jf7.Active = (i39 & 4).Equals(4) ? true : false;//罐7加胶粉进口阀手动打开
            jf8.Active = (i39 & 8).Equals(8) ? true : false;//罐8加胶粉进口阀手动打开

            // 出口阀
            cl1.Active = (i20 & 1).Equals(1) ? true : false;//罐1出口阀手动打开
            cl2.Active = (i20 & 2).Equals(2) ? true : false;//罐2出口阀手动打开
            cl3.Active = (i20 & 4).Equals(4) ? true : false;//罐3出口阀手动打开
            cl4.Active = (i20 & 8).Equals(8) ? true : false;//罐4出口阀手动打开
            cl5.Active = (i30 & 1).Equals(1) ? true : false;//罐5出口阀手动打开
            cl6.Active = (i30 & 2).Equals(2) ? true : false;//罐6出口阀手动打开
            cl7.Active = (i30 & 4).Equals(4) ? true : false;//罐7出口阀手动打开
            cl8.Active = (i30 & 8).Equals(8) ? true : false;//罐8出口阀手动打开
            
            timer9.Change(0, Timeout.Infinite);
        }

        private void refresh11(object source)
        {
            byte i11 = Plc.plc1.ReadByte("I1").Content, i18 = Plc.plc1.ReadByte("I8").Content;
            // 其他阀门
            sbsj1.Active = (i11 & 1).Equals(1) ? true : false;//SBS进口阀1
            sbsj2.Active = (i18 & 128).Equals(128) ? true : false;//SBS进口阀2
            yhsl.Active = (Plc.plc1.ReadByte("I9").Content & 1).Equals(1) ? true : false;//预混上料阀
            t4lq.Active = (Plc.plc2.ReadByte("I0").Content & 16).Equals(16) ? true : false;//T4沥青进口阀
            t21.Active = (i11 & 2).Equals(2) ? true : false;//T2预混罐1
            t22.Active = (i11 & 4).Equals(4) ? true : false;//T2预混罐2
            hl1.Active = (i11 & 16).Equals(16) ? true : false;//预混罐出料1
            hl2.Active = (i11 & 32).Equals(32) ? true : false;//预混罐出料2
            sbs.Active = (Plc.plc1.ReadByte("I0").Content & 128).Equals(128) ? true : false;//SBS料斗阀
            lqs.Active = (i11 & 64).Equals(64) ? true : false;//沥青上料阀
            zc1.Active = (i18 & 1).Equals(1) ? true : false;//装车阀1
            zc2.Active = (i18 & 2).Equals(2) ? true : false;//装车阀2
            clz.Active = (Plc.plc1.ReadByte("I2").Content & 2).Equals(2) ? true : false;//周转罐出料阀
            ejfm.Active = (Plc.plc1.ReadByte("I2").Content & 1).Equals(1) ? true : false;//二剪进口阀
            yjfm.Active = (i11 & 128).Equals(128) ? true : false;//一剪旁通阀

            timer11.Change(0, Timeout.Infinite);
        }

        private void refresh12(object source)
        {
            byte i29 = Plc.plc2.ReadByte("I9").Content, i39 = Plc.plc3.ReadByte("I9").Content;
            t41.Active = (i29 & 16).Equals(16) ? true : false;//罐1T4进口阀手动打开
            t42.Active = (i29 & 32).Equals(32) ? true : false;//罐2T4进口阀手动打开
            t43.Active = (i29 & 64).Equals(64) ? true : false;//罐3T4进口阀手动打开
            t44.Active = (i29 & 128).Equals(128) ? true : false;//罐4T4进口阀手动打开
            t45.Active = (i39 & 16).Equals(16) ? true : false;//罐5T4进口阀手动打开
            t46.Active = (i39 & 32).Equals(32) ? true : false;//罐6T4进口阀手动打开
            t47.Active = (i39 & 64).Equals(64) ? true : false;//罐7T4进口阀手动打开
            t48.Active = (i39 & 128).Equals(128) ? true : false;//罐8T4进口阀手动打开

            //泵
            pictureBox25.Image = Plc.plc1.ReadInt16("VW1256").Content != 0 ? global::Asphalt.Properties.Resources.喂料泵 : (Plc.plc1.ReadByte("Q0").Content & 1).Equals(1) ? global::Asphalt.Properties.Resources.喂料泵_绿 : global::Asphalt.Properties.Resources.喂料泵_灰;
            pictureBox24.Image = (Plc.plc1.ReadByte("I0").Content & 32).Equals(32) ? global::Asphalt.Properties.Resources.喂料泵_下 : (Plc.plc1.ReadByte("Q9").Content & 1).Equals(1) ? global::Asphalt.Properties.Resources.喂料泵_下_绿 : global::Asphalt.Properties.Resources.喂料泵_下_灰;
            pictureBox177.Image = Plc.plc1.ReadInt16("VW1250").Content != 0 ? global::Asphalt.Properties.Resources.喂料泵 : (Plc.plc1.ReadByte("Q9").Content & 16).Equals(16) ? global::Asphalt.Properties.Resources.喂料泵_绿 : global::Asphalt.Properties.Resources.喂料泵_灰;
            pictureBox170.Image = Plc.plc1.ReadInt16("VW1250").Content != 0 ? global::Asphalt.Properties.Resources.喂料泵 : (Plc.plc1.ReadByte("Q9").Content & 32).Equals(32) ? global::Asphalt.Properties.Resources.喂料泵_绿 : global::Asphalt.Properties.Resources.喂料泵_灰;
            pictureBox92.Image = Plc.plc1.ReadInt16("VW1250").Content != 0 ? global::Asphalt.Properties.Resources.喂料泵 : (Plc.plc1.ReadByte("Q9").Content & 64).Equals(64) ? global::Asphalt.Properties.Resources.喂料泵_绿 : global::Asphalt.Properties.Resources.喂料泵_灰;
            pictureBox165.Image = Plc.plc1.ReadInt16("VW1250").Content != 0 ? global::Asphalt.Properties.Resources.喂料泵 : (Plc.plc1.ReadByte("Q9").Content & 128).Equals(128) ? global::Asphalt.Properties.Resources.喂料泵_绿 : global::Asphalt.Properties.Resources.喂料泵_灰;
            pictureBox26.Image = (Plc.plc1.ReadByte("I0").Content & 64).Equals(64) ? global::Asphalt.Properties.Resources.喂料泵_下 : (Plc.plc1.ReadByte("Q12").Content & 8).Equals(8) ? global::Asphalt.Properties.Resources.喂料泵_下_绿 : global::Asphalt.Properties.Resources.喂料泵_下_灰;
            pictureBox27.Image = Plc.plc1.ReadInt16("VW1246").Content != 0 ? global::Asphalt.Properties.Resources.喂料泵 : (Plc.plc1.ReadByte("Q17").Content & 16).Equals(16) ? global::Asphalt.Properties.Resources.喂料泵_绿 : global::Asphalt.Properties.Resources.喂料泵_灰;
            yhb.Image = Plc.plc1.ReadInt16("VW1244").Content != 0 ? global::Asphalt.Properties.Resources.喂料泵 : (Plc.plc1.ReadByte("Q17").Content & 8).Equals(8) ? global::Asphalt.Properties.Resources.喂料泵_绿 : global::Asphalt.Properties.Resources.喂料泵_灰;

            timer12.Change(0, Timeout.Infinite);
        }

        private void refresh10(object source)
        {
            //故障检测
            if (judgeError("SBS喂料电机变频器", Plc.plc1.ReadInt16("VW1240").Content)) return; //直接返回，不再重启定时器，取消刷新
            if (judgeError("T2喂料电机变频器", Plc.plc1.ReadInt16("VW1242").Content)) return;
            if (judgeError("出料一剪机变频器", Plc.plc1.ReadInt16("VW1252").Content)) return;
            if (judgeError("二剪机变频器", Plc.plc1.ReadInt16("VW1258").Content)) return;
            if (judgeError("二剪喂料泵变频器", Plc.plc1.ReadInt16("VW1256").Content)) return;
            if (judgeError("基质沥青上料泵变频器", Plc.plc1.ReadInt16("VW1246").Content)) return;
            if (judgeError("喂料泵变频器", Plc.plc1.ReadInt16("VW1250").Content)) return;
            if (judgeError("预混上料泵变频器", Plc.plc1.ReadInt16("VW1244").Content)) return;
            if (judgeError("预混一剪机变频器", Plc.plc1.ReadInt16("VW1248").Content)) return;
            if (judgeError("预混一剪机变频器", Plc.plc1.ReadInt16("VW1248").Content)) return;
            if (judgeError("周转罐搅拌电机变频器", Plc.plc1.ReadInt16("VW1254").Content)) return;
            if (judgeError("周转罐搅拌电机变频器", Plc.plc1.ReadInt16("VW1254").Content)) return;
            if (judgeError("罐1搅拌电机", Plc.plc2.ReadInt16("VW1230").Content)) return;
            if (judgeError("罐2搅拌电机", Plc.plc2.ReadInt16("VW1232").Content)) return;
            if (judgeError("罐3搅拌电机", Plc.plc2.ReadInt16("VW1234").Content)) return;
            if (judgeError("罐4搅拌电机", Plc.plc2.ReadInt16("VW1236").Content)) return;
            if (judgeError("胶粉喂料电机", Plc.plc2.ReadInt16("VW1238").Content)) return;
            if (judgeError("罐5搅拌电机", Plc.plc3.ReadInt16("VW1230").Content)) return;
            if (judgeError("罐6搅拌电机", Plc.plc3.ReadInt16("VW1232").Content)) return;
            if (judgeError("罐7搅拌电机", Plc.plc3.ReadInt16("VW1234").Content)) return;
            if (judgeError("罐8搅拌电机", Plc.plc3.ReadInt16("VW1236").Content)) return;
            if (judgeError("添加剂投料电机", Plc.plc3.ReadInt16("VW1238").Content)) return;
            if (judgeError("T4投料电机", Plc.plc3.ReadInt16("VW1256").Content)) return;

            timer10.Change(0, Timeout.Infinite);
        }

        private bool judgeError(string name, Int16 x)       //故障查表判断
        {
            bool flag = true;
            switch (x)
            {
                case 0x00:      //无故障
                    flag = false;
                    break;
                case 0x01:
                    MessageBox.Show("故障：" + name + "逆变单元U相保护(UC1),请修复后重新打开程序");
                    break;
                case 0x02:
                    MessageBox.Show("故障：" + name + "逆变单元V相保护(UC2),请修复后重新打开程序");
                    break;
                case 0x03:
                    MessageBox.Show("故障：" + name + "逆变单元W相保护(UC3),请修复后重新打开程序");
                    break;
                case 0x04:
                    MessageBox.Show("故障：" + name + "加速过电流(OC1),请修复后重新打开程序");
                    break;
                case 0x05:
                    MessageBox.Show("故障：" + name + "减速过电流(OC2),请修复后重新打开程序");
                    break;
                case 0x06:
                    MessageBox.Show("故障：" + name + "恒速过电流(OC3),请修复后重新打开程序");
                    break;
                case 0x07:
                    MessageBox.Show("故障：" + name + "加速过电压(OU1),请修复后重新打开程序");
                    break;
                case 0x08:
                    MessageBox.Show("故障：" + name + "减速过电压(OU2),请修复后重新打开程序");
                    break;
                case 0x09:
                    MessageBox.Show("故障：" + name + "恒速过电压(OU3),请修复后重新打开程序");
                    break;
                case 0x0A:
                    MessageBox.Show("故障：" + name + "母线欠压故障(LU),请修复后重新打开程序");
                    break;
                case 0x0B:
                    MessageBox.Show("故障：" + name + "电机过载(OL1),请修复后重新打开程序");
                    break;
                case 0x0C:
                    MessageBox.Show("故障：" + name + "变频器过载(OL2),请修复后重新打开程序");
                    break;
                case 0x0D:
                    MessageBox.Show("故障：" + name + "输入侧缺相(LI),请修复后重新打开程序");
                    break;
                case 0x0E:
                    MessageBox.Show("故障：" + name + "输出侧缺相(LO),请修复后重新打开程序");
                    break;
                case 0x0F:
                    MessageBox.Show("故障：" + name + "整流模块过热故障(OH1),请修复后重新打开程序");
                    break;
                case 0x10:
                    MessageBox.Show("故障：" + name + "逆变模块过热故障(OH2),请修复后重新打开程序");
                    break;
                case 0x11:
                    MessageBox.Show("故障：" + name + "外部故障(EF),请修复后重新打开程序");
                    break;
                case 0x12:
                    MessageBox.Show("故障：" + name + "通讯故障(CE),请修复后重新打开程序");
                    break;
                case 0x13:
                    MessageBox.Show("故障：" + name + "电流检测故障(IE),请修复后重新打开程序");
                    break;
                case 0x14:
                    MessageBox.Show("故障：" + name + "电机自学习故障(TE),请修复后重新打开程序");
                    break;
                case 0x15:
                    MessageBox.Show("故障：" + name + "EEPROM操作故障(EEP),请修复后重新打开程序");
                    break;
                case 0x16:
                    MessageBox.Show("故障：" + name + "PID反馈断线故障(PIDE),请修复后重新打开程序");
                    break;
                default:
                    MessageBox.Show("故障：" + name + "未知错误,请修复后重新打开程序");
                    break;
            }
            return flag;
        }

        private Hashtable ht = new Hashtable();

        private readonly Dictionary<string, (int, int, int)> readDict = new Dictionary<string, (int, int, int)>()
        {
            {"生产罐1沥青进口阀",  (2, 8, 0) },
            {"生产罐2沥青进口阀",  (2, 8, 1) },
            {"生产罐3沥青进口阀",  (2, 8, 2) },
            {"生产罐4沥青进口阀",  (2, 8, 3) },
            {"生产罐5沥青进口阀",  (3, 8, 0) },
            {"生产罐6沥青进口阀",  (3, 8, 1) },
            {"生产罐7沥青进口阀",  (3, 8, 2) },
            {"生产罐8沥青进口阀",  (3, 8, 3) },
            {"生产罐1添加剂进口阀",  (2, 8, 4) },
            {"生产罐2添加剂进口阀",  (2, 8, 5) },
            {"生产罐3添加剂进口阀",  (2, 8, 6) },
            {"生产罐4添加剂进口阀",  (2, 8, 7) },
            {"生产罐5添加剂进口阀",  (3, 8, 4) },
            {"生产罐6添加剂进口阀",  (3, 8, 5) },
            {"生产罐7添加剂进口阀",  (3, 8, 6) },
            {"生产罐8添加剂进口阀",  (3, 8, 7) },
            {"生产罐1胶粉进口阀",  (2, 9, 0) },
            {"生产罐2胶粉进口阀",  (2, 9, 1) },
            {"生产罐3胶粉进口阀",  (2, 9, 2) },
            {"生产罐4胶粉进口阀",  (2, 9, 3) },
            {"生产罐5胶粉进口阀",  (3, 9, 0) },
            {"生产罐6胶粉进口阀",  (3, 9, 1) },
            {"生产罐7胶粉进口阀",  (3, 9, 2) },
            {"生产罐8胶粉进口阀",  (3, 9, 3) },
            {"生产罐1T4进口阀",  (2, 9, 4) },
            {"生产罐2T4进口阀",  (2, 9, 5) },
            {"生产罐3T4进口阀",  (2, 9, 6) },
            {"生产罐4T4进口阀",  (2, 9, 7) },
            {"生产罐5T4进口阀",  (3, 9, 4) },
            {"生产罐6T4进口阀",  (3, 9, 5) },
            {"生产罐7T4进口阀",  (3, 9, 6) },
            {"生产罐8T4进口阀",  (3, 9, 7) },
            {"生产罐1出口阀",  (2, 0, 0) },
            {"生产罐2出口阀",  (2, 0, 1) },
            {"生产罐3出口阀",  (2, 0, 2) },
            {"生产罐4出口阀",  (2, 0, 3) },
            {"生产罐5出口阀",  (3, 0, 0) },
            {"生产罐6出口阀",  (3, 0, 1) },
            {"生产罐7出口阀",  (3, 0, 2) },
            {"生产罐8出口阀",  (3, 0, 3) },
            {"左料斗出口阀",  (2, 3, 0) },
            {"右料斗出口阀",  (3, 2, 5) },
            {"SBS料斗阀", (1, 1, 0) },
            {"T2进口阀1", (1, 1, 1) },
            {"T2进口阀2", (1, 1, 2) },
            {"沥青进口阀1", (1, 8, 2) },
            {"沥青进口阀2", (1, 1, 3) },
            {"预混罐出料阀1", (1, 1, 4) },
            {"预混罐出料阀2", (1, 1, 5) },
            {"沥青上料阀", (1, 2, 6) },
            {"一剪机旁路阀", (1, 1, 7) },
            {"二剪机支路进口阀", (1, 2, 0) },
            {"周转物料出口阀", (1, 2, 1) },
            {"装车阀1", (1, 8, 0) },
            {"装车阀2", (1, 8, 1) },
            {"T4沥青进口阀", (2, 0, 4) },
            {"SBS进口阀1", (1, 1, 0) },
            {"SBS进口阀2", (1, 8, 7) },
            {"预混上料阀", (1, 1, 6) }
        };

        private void switchOver(object sender, string name)
        {
            UIValve valve = (UIValve)sender;
            bool active = valve.Active;
            string value = valve.Active ? "打开" : "关闭";
            string mes = name + "当前状态为：“" + value + "”,您确定切换开关吗？";
            DialogResult result = MessageBox.Show(mes, "开关阀门切换", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                if (!ht.Contains(valve.Name)) ht.Add(valve.Name, 1);
                int a = dict[name].Item1, b = dict[name].Item2, c = dict[name].Item3;
                if (a == 1)
                {
                    Plc.plc1.Write("M" + b.ToString(), (byte)(Plc.plc1.ReadByte("M" + b.ToString()).Content ^ data[c]));
                }
                else if (a == 2)
                {
                    Plc.plc2.Write("M" + b.ToString(), (byte)(Plc.plc2.ReadByte("M" + b.ToString()).Content ^ data[c]));
                }
                else
                {
                    Plc.plc3.Write("M" + b.ToString(), (byte)(Plc.plc3.ReadByte("M" + b.ToString()).Content ^ data[c]));
                }

                valve.Active = !active;

                int e = readDict[name].Item1, f = readDict[name].Item2, g = readDict[name].Item3;
                if (e == 1)
                {
                    valve.Active = (Plc.plc1.ReadByte("I" + f.ToString()).Content & data[g]).Equals(data[g]);
                }
                else if (e == 2)
                {
                    valve.Active = (Plc.plc2.ReadByte("I" + f.ToString()).Content & data[g]).Equals(data[g]);
                }
                else
                {
                    valve.Active = (Plc.plc3.ReadByte("I" + f.ToString()).Content & data[g]).Equals(data[g]);
                }
                valve.ValveColor = valve.Active ? Color.Green : Color.Red;

                return;
            }

            else
            {
                valve.Active = !active;
            }
        }

        // 罐名，重量，阀门开关，材料名
        private void gateChanged(object sender, string name, double weight, string material = null)
        {
            UIValve valve = (UIValve)sender;
            if (Index.flag3 || !ht.Contains(valve.Name)) return;        // 自动状态

            int gate = valve.Active ? 1 : 0;
            MySqlDataReader reader = Sql.executeReader("select * from gate where name = '" + name + "';");
            reader.Read();

            if (ht.Contains(valve.Name)) ht.Remove(valve.Name);
            if (reader[2].ToString() == gate.ToString()) return;       // 防止软件异常重启后出现错误

            if (gate == 1)  // 开阀门，保存数据
            {
                Sql.executeNonQuery(string.Format("update gate set weight = {0}, flag = 1 where name = '{1}';", weight, name));
            }
            else  // 关阀门
            {
                double changedWeight = Math.Abs(weight - reader[1].ToString().ToDouble());
                if ((int)changedWeight > 0)
                {
                    if (material != null)      // 入料
                    {
                        Sql.executeNonQuery(string.Format("insert into feeding values('{0}', '{1}', {2}, {3}, '{4}');", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), name, changedWeight, DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1), material));
                        if (name != "预混罐1" && name != "预混罐2" && name != "周转罐")
                        {
                            Index.curSum += (int)changedWeight;
                            if (Index.curSum >= Index.setSum && Index.flag2)
                            {
                                Plc.plc1.Write("M9", (byte)(Plc.plc1.ReadByte("M9").Content | 8));
                                Index.autoFlag = false;
                                // 启动->停止
                                Plc.plc1.Write("M9", (byte)(Plc.plc1.ReadByte("M9").Content & 252 | 2));
                                Index.flag2 = false;
                            }
                        }
                    }
                    else  // 出料
                    {
                        Sql.executeNonQuery(string.Format("insert into discharge values('{0}', '{1}', {2}, {3});", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), name, changedWeight, DateTime.Now.Hour >= 16 ? 3 : (DateTime.Now.Hour >= 8 ? 2 : 1)));
                    }
                }

                Sql.executeNonQuery(string.Format("update gate set weight = {0}, flag = 0 where name = '{1}';", weight, name));
            }
            reader.Close();
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐6搅拌电机" });
                manual.Show();
            }
        }
        private void timer3_Tick(object sender, System.EventArgs e)
        {
            foreach (var pipe in this.GetControls<UIPipe>())
            {
                pipe.Invalidate();
            }
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        private void hm4_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐4燃烧器" });
                manual.Show();
            }
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐2搅拌电机" });
                manual.Show();
            }
        }

        private void hm1_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐1燃烧器" });
                manual.Show();
            }
        }

        private void hm2_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐2燃烧器" });
                manual.Show();
            }
        }

        private void hm3_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐3燃烧器" });
                manual.Show();
            }
        }

        private void hm5_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐5燃烧器" });
                manual.Show();
            }
        }

        private void hm6_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐6燃烧器" });
                manual.Show();
            }
        }

        private void hm7_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐7燃烧器" });
                manual.Show();
            }
        }

        private void hm8_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐8燃烧器" });
                manual.Show();
            }
        }

        private void dj1_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐1搅拌电机" });
                manual.Show();
            }
        }

        private void dj3_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐3搅拌电机" });
                manual.Show();
            }
        }

        private void dj4_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐4搅拌电机" });
                manual.Show();
            }
        }

        private void dj5_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐5搅拌电机" });
                manual.Show();
            }
        }

        private void dj7_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐7搅拌电机" });
                manual.Show();
            }
        }

        private void dj8_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "生产罐8搅拌电机" });
                manual.Show();
            }
        }


        private void jftsdj_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "胶粉提升电机" });
                manual.Show();
            }
        }

        private void jfwldj_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "胶粉喂料电机" });
                manual.Show();
            }
        }



        private void tjjtldj_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "添加剂投料电机" });
                manual.Show();
            }
        }

        private void yhdj1_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "预混罐1搅拌电机", "预混罐1搅拌电机油泵" });
                manual.Show();
            }
        }

        private void yhdj2_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "预混罐2搅拌电机", "预混罐2搅拌电机油泵" });
                manual.Show();
            }
        }


        private void pictureBox177_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "喂料泵1" });
                manual.Show();
            }
        }

        private void uiPipe_jf1_Click(object sender, EventArgs e)
        {

        }

        private void t41_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐1T4进口阀");
        }

        private void jf1_ActiveChanged_1(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐1胶粉进口阀");
        }

        private void tjj1_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐1添加剂进口阀");
        }

        private void hm9_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "周转罐燃烧器" });
                manual.Show();
            }
        }

        private void djz_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "周转罐搅拌电机", "周转罐搅拌电机油泵" });
                manual.Show();
            }
        }

        private void jfztldj_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                swichElec = new SwitchElec("胶粉左投料电机");
                swichElec.Show();
            }
        }


        private void fldj_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                swichElec = new SwitchElec("胶粉分料电机");
                swichElec.Show();
            }
        }

        private void jfytldj_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                swichElec = new SwitchElec("胶粉右投料电机");
                swichElec.Show();
            }
        }

        private void yhb_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "预混上料泵" });
                manual.Show();
            }
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "上料增压泵" });
                manual.Show();
            }
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "成品泵" });
                manual.Show();
            }
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "二剪喂料泵" });
                manual.Show();
            }
        }

        private void pictureBox170_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "喂料泵2" });
                manual.Show();
            }
        }

        private void pictureBox92_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "喂料泵3" });
                manual.Show();
            }
        }

        private void pictureBox165_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "喂料泵4" });
                manual.Show();
            }
        }

        private void yhyj_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "预混一剪机", "预混一剪机油泵" });
                manual.Show();
            }
        }

        private void yjj_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "出料一剪机", "出料一剪机油泵" });
                manual.Show();
            }
        }

        private void sbswldj_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                swichElec = new SwitchElec("SBS喂料电机");
                swichElec.Show();
            }
        }

        private void t2wldj_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                swichElec = new SwitchElec("T2喂料电机");
                swichElec.Show();
            }
            else
            {
                UIValve valve = (UIValve)sender;
                valve.Active = !valve.Active;
            }
        }


        private void ejj_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "二剪机" });
                manual.Show();
            }
        }

        private void t4tl_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "T4投料电机" });
                manual.Show();
            }
        }


        private void lq1_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐1沥青进口阀");
        }

        private void lq2_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐2沥青进口阀");
        }

        private void lq3_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐3沥青进口阀");
        }

        private void lq4_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐4沥青进口阀");
        }

        private void lq5_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐5沥青进口阀");
        }

        private void lq6_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐6沥青进口阀");
        }

        private void lq7_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐7沥青进口阀");
        }

        private void lq8_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐8沥青进口阀");
        }

        private void tjj2_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐2添加剂进口阀");
        }

        private void tjj3_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐3添加剂进口阀");
        }

        private void tjj4_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐4添加剂进口阀");
        }

        private void tjj5_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐5添加剂进口阀");
        }

        private void tjj6_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐6添加剂进口阀");
        }

        private void tjj7_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐7添加剂进口阀");
        }

        private void tjj8_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐8添加剂进口阀");
        }

        private void jf2_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐2胶粉进口阀");
        }

        private void jf3_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐3胶粉进口阀");
        }

        private void jf4_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐4胶粉进口阀");
        }

        private void jf5_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐5胶粉进口阀");
        }

        private void jf6_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐6胶粉进口阀");
        }

        private void jf7_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐7胶粉进口阀");
        }

        private void jf8_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐8胶粉进口阀");
        }

        private void t42_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐2T4进口阀");
        }

        private void t43_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐3T4进口阀");
        }

        private void t44_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐4T4进口阀");
        }

        private void t45_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐5T4进口阀");
        }

        private void t46_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐6T4进口阀");
        }

        private void t47_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐7T4进口阀");
        }

        private void t48_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐8T4进口阀");
        }


        private void sbs_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "SBS料斗阀");
        }


        private void lqs_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "沥青上料阀");
        }

        private void lq9_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "沥青进口阀1");
        }

        private void lq10_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "沥青进口阀2");
        }

        private void t21_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "T2进口阀1");
        }

        private void t22_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "T2进口阀2");
        }

        private void clz_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "周转物料出口阀");
        }

        private void zc1_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "装车阀1");
        }

        private void zc2_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "装车阀2");
        }

        private void yjfm_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "一剪机旁路阀");
        }

        private void ejfm_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "二剪机支路进口阀");
        }

        private void cl1_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐1出口阀");
        }

        private void cl2_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐2出口阀");
        }

        private void cl3_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐3出口阀");
        }

        private void cl4_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐4出口阀");
        }

        private void cl5_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐5出口阀");
        }

        private void cl6_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐6出口阀");
        }

        private void cl7_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐7出口阀");
        }

        private void cl8_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "生产罐8出口阀");
        }

        private void hl1_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "预混罐出料阀1");
        }

        private void hl2_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "预混罐出料阀2");
        }


        private void pictureBox27_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                manual = new Manual(new string[] { "基质沥青上料泵" });
                manual.Show();
            }
        }

        private void lq1_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐1", Plc.plc2.ReadFloat("VD100").Content, "沥青");
        }

        private void lq2_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐2", Plc.plc2.ReadFloat("VD108").Content, "沥青");
        }

        private void lq3_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐3", Plc.plc2.ReadFloat("VD116").Content, "沥青");
        }

        private void lq4_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐4", Plc.plc2.ReadFloat("VD124").Content, "沥青");
        }

        private void lq5_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐5", Plc.plc3.ReadFloat("VD100").Content, "沥青");
        }

        private void lq6_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐6", Plc.plc3.ReadFloat("VD108").Content, "沥青");
        }

        private void lq7_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐7", Plc.plc3.ReadFloat("VD116").Content, "沥青");
        }

        private void lq8_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐8", Plc.plc3.ReadFloat("VD124").Content, "沥青");
        }

        private void lq9_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "预混罐1", Plc.plc1.ReadFloat("VD128").Content, "沥青");
        }

        private void lq10_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "预混罐2", Plc.plc1.ReadFloat("VD132").Content, "沥青");
        }

        private void tjj1_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐1", Plc.plc2.ReadFloat("VD100").Content, "添加剂");
        }

        private void tjj2_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐2", Plc.plc2.ReadFloat("VD108").Content, "添加剂");
        }

        private void tjj3_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐3", Plc.plc2.ReadFloat("VD116").Content, "添加剂");
        }

        private void tjj4_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐4", Plc.plc2.ReadFloat("VD124").Content, "添加剂");
        }

        private void tjj5_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐5", Plc.plc3.ReadFloat("VD100").Content, "添加剂");
        }

        private void tjj6_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐6", Plc.plc3.ReadFloat("VD108").Content, "添加剂");
        }

        private void tjj7_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐7", Plc.plc3.ReadFloat("VD116").Content, "添加剂");
        }

        private void tjj8_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐8", Plc.plc3.ReadFloat("VD124").Content, "添加剂");
        }
        private void jf1_ActiveChanged(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐1", Plc.plc2.ReadFloat("VD100").Content, "胶粉");
        }

        private void jf2_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐2", Plc.plc2.ReadFloat("VD108").Content, "胶粉");
        }

        private void jf3_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐3", Plc.plc2.ReadFloat("VD116").Content, "胶粉");
        }

        private void jf4_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐4", Plc.plc2.ReadFloat("VD124").Content, "胶粉");
        }

        private void jf5_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐5", Plc.plc3.ReadFloat("VD100").Content, "胶粉");
        }

        private void jf6_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐6", Plc.plc3.ReadFloat("VD108").Content, "胶粉");
        }

        private void jf7_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐7", Plc.plc3.ReadFloat("VD116").Content, "胶粉");
        }

        private void jf8_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐8", Plc.plc3.ReadFloat("VD124").Content, "胶粉");
        }

        private void t41_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐1", Plc.plc2.ReadFloat("VD100").Content, "T4");
        }

        private void t42_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐2", Plc.plc2.ReadFloat("VD108").Content, "T4");
        }

        private void t43_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐3", Plc.plc2.ReadFloat("VD116").Content, "T4");
        }

        private void t44_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐4", Plc.plc2.ReadFloat("VD124").Content, "T4");
        }

        private void t45_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐5", Plc.plc3.ReadFloat("VD100").Content, "T4");    
        }

        private void t46_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐6", Plc.plc3.ReadFloat("VD108").Content, "T4");
        }

        private void t47_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐7", Plc.plc3.ReadFloat("VD116").Content, "T4");
        }

        private void t48_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐8", Plc.plc3.ReadFloat("VD124").Content, "T4");
        }

        private void cl1_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐1", Plc.plc2.ReadFloat("VD100").Content);
        }

        private void cl2_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐2", Plc.plc2.ReadFloat("VD108").Content);
        }

        private void cl3_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐3", Plc.plc2.ReadFloat("VD116").Content);
        }

        private void cl4_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐4", Plc.plc2.ReadFloat("VD124").Content);
        }

        private void cl5_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐5", Plc.plc3.ReadFloat("VD100").Content);
        }

        private void cl6_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐6", Plc.plc3.ReadFloat("VD108").Content);
        }

        private void cl7_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐7", Plc.plc3.ReadFloat("VD116").Content);
        }

        private void cl8_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "生产罐8", Plc.plc3.ReadFloat("VD124").Content);
        }

        private void hl1_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "预混罐1", Plc.plc1.ReadFloat("VD128").Content);
        }

        private void hl2_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "预混罐2", Plc.plc1.ReadFloat("VD132").Content);
        }

        private void clz_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "周转罐", Plc.plc1.ReadFloat("VD108").Content);
        }

        private void t21_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "预混罐1", Plc.plc1.ReadFloat("VD128").Content, "T2");
        }
        
        private void t22_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "预混罐2", Plc.plc1.ReadFloat("VD132").Content, "T2");
        }

        private void sbs_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "预混罐1", Plc.plc1.ReadFloat("VD136").Content, "SBS");
        }


        private void zc1_ActiveChanged_1(object sender, EventArgs e)
        {

        }

        private void zc2_ActiveChanged_1(object sender, EventArgs e)
        {
            
        }

        private void yjfm_ActiveChanged_1(object sender, EventArgs e)
        {

        }

        private void ejfm_ActiveChanged_1(object sender, EventArgs e)
        {

        }

        private void zldc_ActiveChanged_1(object sender, EventArgs e)
        {

        }

        private void uiPipe_cl8_1_Click(object sender, EventArgs e)
        {

        }

        private void t4lq_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "T4沥青进口阀");
        }

        private void t4lq_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "T4预混罐", Plc.plc2.ReadFloat("VD132").Content, "T4");
        }

        private void sbsj1_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "SBS进口阀1");
        }

        private void sbsj2_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "SBS进口阀2");
        }

        private void sbsj1_ActiveChanged_1(object sender, EventArgs e)
        {
             gateChanged(sender, "预混罐1", Plc.plc1.ReadFloat("VD128").Content);
        }

        private void sbsj2_ActiveChanged_1(object sender, EventArgs e)
        {
             gateChanged(sender, "预混罐2", Plc.plc1.ReadFloat("VD132").Content);
        }

        private void yhsl_ActiveChanged(object sender, EventArgs e)
        {
            switchOver(sender, "预混上料阀");
        }

        private void yhsl_ActiveChanged_1(object sender, EventArgs e)
        {
            gateChanged(sender, "预混罐2", Plc.plc1.ReadFloat("VD132").Content);
        }

        private void t4jb_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)

                manual = new Manual(new string[] { "T4搅拌电机" });
                manual.Show();
        }

        private void jbg1_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                production = new Production(1);
                production.Show();
            }
        }

        private void jbg2_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                production = new Production(2);
                production.Show();
            }
        }

        private void jbg3_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                production = new Production(3);
                production.Show();
            }
        }

        private void jbg4_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                production = new Production(4);
                production.Show();
            }
        }

        private void jbg5_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                production = new Production(5);
                production.Show();
            }
        }

        private void jbg6_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                production = new Production(6);
                production.Show();
            }
        }

        private void jbg7_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                production = new Production(7);
                production.Show();
            }
        }

        private void jbg8_Click(object sender, EventArgs e)
        {
            if (!Index.flag3)
            {
                production = new Production(8);
                production.Show();
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {
            
        }

        private void button_MouseDown()
        {
            fflag = true;
            timerone = new System.Windows.Forms.Timer();
            timertwo.Interval = 500;
            timertwo.Enabled = true;
        }

        private void timertwo_Tick(object sender, EventArgs e)
        {
            fflag = true;
            timerone.Interval = 100;
            timerone.Enabled = true;
            timertwo.Enabled = false;
        }

        private void button_MouseUp()
        {
            fflag = false;
            timertwo.Enabled = false;
            timerone.Enabled = false;
        }

        private float getDigit(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'H')
                {
                    str = str.Substring(0, i);
                    break;
                }
            }
            return float.Parse(str);
        }


        private void button46_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sbsfre.Text = getDigit(sbsfre.Text) + 1 + "Hz";
            };
            sbsfre.Text = getDigit(sbsfre.Text) + 1 + "Hz";
        }

        private void button46_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(sbsfre.Text) > 50) sbsfre.Text = "50Hz";
            if (getDigit(sbsfre.Text) < 0) sbsfre.Text = "0Hz";
            button_MouseUp();
            Plc.plc1.Write("VW1100", (short)(getDigit(sbsfre.Text) * 200));
        }

        private void button45_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sbsfre.Text = getDigit(sbsfre.Text) - 1 + "Hz";
            };
            sbsfre.Text = getDigit(sbsfre.Text) - 1 + "Hz";
        }

        private void button40_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                t2fre.Text = getDigit(t2fre.Text) + 1 + "Hz";
            };
            t2fre.Text = getDigit(t2fre.Text) + 1 + "Hz";
        }
        private void button40_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(t2fre.Text) > 50) t2fre.Text = "50Hz";
            if (getDigit(t2fre.Text) < 0) t2fre.Text = "0Hz";
            button_MouseUp();
            Plc.plc1.Write("VW1102", (short)(getDigit(t2fre.Text) * 200));
        }

        private void button39_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                t2fre.Text = getDigit(t2fre.Text) - 1 + "Hz";
            };
            t2fre.Text = getDigit(t2fre.Text) - 1 + "Hz";
        }

        private void button28_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                yhslbfre.Text = getDigit(yhslbfre.Text) + 1 + "Hz";
            };
            yhslbfre.Text = getDigit(yhslbfre.Text) + 1 + "Hz";
        }

        private void button28_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(yhslbfre.Text) > 50) yhslbfre.Text = "50Hz";
            if (getDigit(yhslbfre.Text) < 0) yhslbfre.Text = "0Hz";
            button_MouseUp();
            Plc.plc1.Write("VW1104", (short)(getDigit(yhslbfre.Text) * 200));
        }

        private void button27_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                yhslbfre.Text = getDigit(yhslbfre.Text) - 1 + "Hz";
            };
            yhslbfre.Text = getDigit(yhslbfre.Text) - 1 + "Hz";
        }


        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                yhyjfre.Text = getDigit(yhyjfre.Text) + 1 + "Hz";
            };
            yhyjfre.Text = getDigit(yhyjfre.Text) + 1 + "Hz";
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(yhyjfre.Text) > 100) yhyjfre.Text = "100Hz";
            if (getDigit(yhyjfre.Text) < 0) yhyjfre.Text = "0Hz";
            button_MouseUp();
            Plc.plc1.Write("VW1108", (short)(getDigit(yhyjfre.Text) * 100));
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                yhyjfre.Text = getDigit(yhyjfre.Text) - 1 + "Hz";
            };
            yhyjfre.Text = getDigit(yhyjfre.Text) - 1 + "Hz";
        }


        private void button30_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                jzlqfre.Text = getDigit(jzlqfre.Text) + 1 + "Hz";
            };
            jzlqfre.Text = getDigit(jzlqfre.Text) + 1 + "Hz";
        }

        private void button30_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(jzlqfre.Text) > 50) jzlqfre.Text = "50Hz";
            if (getDigit(jzlqfre.Text) < 0) jzlqfre.Text = "0Hz";
            button_MouseUp();
            Plc.plc1.Write("VW1106", (short)(getDigit(jzlqfre.Text) * 200));
        }

        private void button29_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                jzlqfre.Text = getDigit(jzlqfre.Text) - 1 + "Hz";
            };
            jzlqfre.Text = getDigit(jzlqfre.Text) - 1 + "Hz";
        }

        private void button42_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                tjjfre.Text = getDigit(tjjfre.Text) + 1 + "Hz";
            };
            tjjfre.Text = getDigit(tjjfre.Text) + 1 + "Hz";
        }

        private void button42_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(tjjfre.Text) > 50) tjjfre.Text = "50Hz";
            if (getDigit(tjjfre.Text) < 0) tjjfre.Text = "0Hz";
            button_MouseUp();
            Plc.plc3.Write("VW1208", (short)(getDigit(tjjfre.Text) * 200));
        }

        private void button41_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                tjjfre.Text = getDigit(tjjfre.Text) - 1 + "Hz";
            };
            tjjfre.Text = getDigit(tjjfre.Text) - 1 + "Hz";
        }

        private void button32_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                jffre.Text = getDigit(jffre.Text) + 1 + "Hz";
            };
            jffre.Text = getDigit(jffre.Text) + 1 + "Hz";
        }

        private void button32_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(jffre.Text) > 50) sbsfre.Text = "50Hz";
            if (getDigit(jffre.Text) < 0) sbsfre.Text = "0Hz";
            button_MouseUp();
            Plc.plc2.Write("VW1208", (short)(getDigit(jffre.Text) * 200));
        }

        private void button31_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                jffre.Text = getDigit(jffre.Text) - 1 + "Hz";
            };
            jffre.Text = getDigit(jffre.Text) - 1 + "Hz";
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                t4fre.Text = getDigit(t4fre.Text) + 1 + "Hz";
            };
            t4fre.Text = getDigit(t4fre.Text) + 1 + "Hz";
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(t4fre.Text) > 50) t4fre.Text = "50Hz";
            if (getDigit(t4fre.Text) < 0) t4fre.Text = "0Hz";
            button_MouseUp();
            Plc.plc3.Write("VW1250", (short)(getDigit(t4fre.Text) * 200));
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                t4fre.Text = getDigit(t4fre.Text) - 1 + "Hz";
            };
            t4fre.Text = getDigit(t4fre.Text) - 1 + "Hz";
        }

        private void button34_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                ejwlbfre.Text = getDigit(ejwlbfre.Text) + 1 + "Hz";
            };
            ejwlbfre.Text = getDigit(ejwlbfre.Text) + 1 + "Hz";
        }

        private void button34_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(ejwlbfre.Text) > 50) ejwlbfre.Text = "50Hz";
            if (getDigit(ejwlbfre.Text) < 0) ejwlbfre.Text = "0Hz";
            button_MouseUp();
            Plc.plc1.Write("VW1116", (short)(getDigit(ejwlbfre.Text) * 200));
        }

        private void button33_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                ejwlbfre.Text = getDigit(ejwlbfre.Text) - 1 + "Hz";
            };
            ejwlbfre.Text = getDigit(ejwlbfre.Text) - 1 + "Hz";
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                clyjfre.Text = getDigit(clyjfre.Text) + 1 + "Hz";
            };
            clyjfre.Text = getDigit(clyjfre.Text) + 1 + "Hz";
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(clyjfre.Text) > 100) clyjfre.Text = "100Hz";
            if (getDigit(clyjfre.Text) < 0) clyjfre.Text = "0Hz";
            button_MouseUp();
            Plc.plc1.Write("VW1112", (short)(getDigit(clyjfre.Text) * 100));
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                clyjfre.Text = getDigit(clyjfre.Text) - 1 + "Hz";
            };
            clyjfre.Text = getDigit(clyjfre.Text) - 1 + "Hz";
        }

        private void button10_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                zzfre.Text = getDigit(zzfre.Text) + 1 + "Hz";
            };
            zzfre.Text = getDigit(zzfre.Text) + 1 + "Hz";
        }

        private void button10_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(zzfre.Text) > 50) zzfre.Text = "50Hz";
            if (getDigit(zzfre.Text) < 0) zzfre.Text = "0Hz";
            button_MouseUp();
            Plc.plc1.Write("VW1114", (short)(getDigit(zzfre.Text) * 200));
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                zzfre.Text = getDigit(zzfre.Text) - 1 + "Hz";
            };
            zzfre.Text = getDigit(zzfre.Text) - 1 + "Hz";
        }

        private void button12_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc1fre.Text = getDigit(sc1fre.Text) + 1 + "Hz";
            };
            sc1fre.Text = getDigit(sc1fre.Text) + 1 + "Hz";
        }

        private void button12_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(sc1fre.Text) > 50) sc1fre.Text = "50Hz";
            if (getDigit(sc1fre.Text) < 0) sc1fre.Text = "0Hz";
            button_MouseUp();
            Plc.plc2.Write("VW1200", (short)(getDigit(sc1fre.Text) * 200));
        }

        private void button11_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc1fre.Text = getDigit(sc1fre.Text) - 1 + "Hz";
            };
            sc1fre.Text = getDigit(sc1fre.Text) - 1 + "Hz";
        }

        private void button14_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc2fre.Text = getDigit(sc2fre.Text) + 1 + "Hz";
            };
            sc2fre.Text = getDigit(sc2fre.Text) + 1 + "Hz";
        }

        private void button14_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(sc2fre.Text) > 50) sc2fre.Text = "50Hz";
            if (getDigit(sc2fre.Text) < 0) sc2fre.Text = "0Hz";
            button_MouseUp();
            Plc.plc2.Write("VW1202", (short)(getDigit(sc2fre.Text) * 200));
        }

        private void button13_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc2fre.Text = getDigit(sc2fre.Text) - 1 + "Hz";
            };
            sc2fre.Text = getDigit(sc2fre.Text) - 1 + "Hz";
        }

        private void button16_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc3fre.Text = getDigit(sc3fre.Text) + 1 + "Hz";
            };
            sc3fre.Text = getDigit(sc3fre.Text) + 1 + "Hz";
        }

        private void button16_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(sc3fre.Text) > 50) sc3fre.Text = "50Hz";
            if (getDigit(sc3fre.Text) < 0) sc3fre.Text = "0Hz";
            button_MouseUp();
            Plc.plc2.Write("VW1204", (short)(getDigit(sc3fre.Text) * 200));
        }

        private void button15_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc3fre.Text = getDigit(sc3fre.Text) - 1 + "Hz";
            };
            sc3fre.Text = getDigit(sc3fre.Text) - 1 + "Hz";
        }

        private void button18_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc4fre.Text = getDigit(sc4fre.Text) + 1 + "Hz";
            };
            sc4fre.Text = getDigit(sc4fre.Text) + 1 + "Hz";
        }

        private void button18_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(sc4fre.Text) > 50) sc4fre.Text = "50Hz";
            if (getDigit(sc4fre.Text) < 0) sc4fre.Text = "0Hz";
            button_MouseUp();
            Plc.plc2.Write("VW1206", (short)(getDigit(sc4fre.Text) * 200));
        }

        private void button17_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc4fre.Text = getDigit(sc4fre.Text) - 1 + "Hz";
            };
            sc4fre.Text = getDigit(sc4fre.Text) - 1 + "Hz";
        }

        private void button20_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc5fre.Text = getDigit(sc5fre.Text) + 1 + "Hz";
            };
            sc5fre.Text = getDigit(sc5fre.Text) + 1 + "Hz";
        }

        private void button20_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(sc5fre.Text) > 50) sc5fre.Text = "50Hz";
            if (getDigit(sc5fre.Text) < 0) sc5fre.Text = "0Hz";
            button_MouseUp();
            Plc.plc3.Write("VW1200", (short)(getDigit(sc5fre.Text) * 200));
        }

        private void button19_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc5fre.Text = getDigit(sc5fre.Text) - 1 + "Hz";
            };
            sc5fre.Text = getDigit(sc5fre.Text) - 1 + "Hz";
        }

        private void button22_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc6fre.Text = getDigit(sc6fre.Text) + 1 + "Hz";
            };
            sc6fre.Text = getDigit(sc6fre.Text) + 1 + "Hz";
        }

        private void button22_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(sc6fre.Text) > 50) sc6fre.Text = "50Hz";
            if (getDigit(sc6fre.Text) < 0) sc6fre.Text = "0Hz";
            button_MouseUp();
            Plc.plc3.Write("VW1202", (short)(getDigit(sc6fre.Text) * 200));
        }

        private void button21_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc6fre.Text = getDigit(sc6fre.Text) - 1 + "Hz";
            };
            sc6fre.Text = getDigit(sc6fre.Text) - 1 + "Hz";
        }

        private void button24_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc7fre.Text = getDigit(sc7fre.Text) + 1 + "Hz";
            };
            sc7fre.Text = getDigit(sc7fre.Text) + 1 + "Hz";
        }

        private void button24_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(sc7fre.Text) > 50) sc7fre.Text = "50Hz";
            if (getDigit(sc7fre.Text) < 0) sc7fre.Text = "0Hz";
            button_MouseUp();
            Plc.plc3.Write("VW1204", (short)(getDigit(sc7fre.Text) * 200));
        }

        private void button23_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc7fre.Text = getDigit(sc7fre.Text) - 1 + "Hz";
            };
            sc7fre.Text = getDigit(sc7fre.Text) - 1 + "Hz";
        }

        private void button26_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc8fre.Text = getDigit(sc8fre.Text) + 1 + "Hz";
            };
            sc8fre.Text = getDigit(sc8fre.Text) + 1 + "Hz";
        }

        private void button26_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(sc8fre.Text) > 50) sc8fre.Text = "50Hz";
            if (getDigit(sc8fre.Text) < 0) sc8fre.Text = "0Hz";
            button_MouseUp();
            Plc.plc3.Write("VW1206", (short)(getDigit(sc8fre.Text) * 200));
        }

        private void button25_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                sc8fre.Text = getDigit(sc8fre.Text) - 1 + "Hz";
            };
            sc8fre.Text = getDigit(sc8fre.Text) - 1 + "Hz";
        }

        private void button36_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                wlbfre.Text = getDigit(wlbfre.Text) + 1 + "Hz";
            };
            wlbfre.Text = getDigit(wlbfre.Text) + 1 + "Hz";
        }

        private void button36_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(wlbfre.Text) > 50) wlbfre.Text = "50Hz";
            if (getDigit(wlbfre.Text) < 0) wlbfre.Text = "0Hz";
            button_MouseUp();
            Plc.plc1.Write("VW1110", (short)(getDigit(wlbfre.Text) * 200));
        }

        private void button35_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                wlbfre.Text = getDigit(wlbfre.Text) - 1 + "Hz";
            };
            wlbfre.Text = getDigit(wlbfre.Text) - 1 + "Hz";
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                ejjfre.Text = getDigit(ejjfre.Text) + 1 + "Hz";
            };
            ejjfre.Text = getDigit(ejjfre.Text) + 1 + "Hz";
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (getDigit(ejjfre.Text) > 100) ejjfre.Text = "100Hz";
            if (getDigit(ejjfre.Text) < 0) ejjfre.Text = "0Hz";
            button_MouseUp();
            Plc.plc1.Write("VW1118", (short)(getDigit(ejjfre.Text) * 100));
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                ejjfre.Text = getDigit(ejjfre.Text) - 1 + "Hz";
            };
            ejjfre.Text = getDigit(ejjfre.Text) - 1 + "Hz";
        }

		private void button7_MouseDown(object sender, MouseEventArgs e)
		{
            button_MouseDown();
            timerone.Tick += (s, ev) => { 
                t4fre.Text = getDigit(t4fre.Text) - 1 + "Hz";
            };
            t4fre.Text = getDigit(t4fre.Text) - 1 + "Hz";
		}

		private void buttonE_Click(object sender, EventArgs e)
		{
            if ((Plc.plc1.ReadByte("M20").Content & 1) == 1)
            {
                Plc.plc1.Write("M20", (byte)0);
                buttonE.BackColor = Color.Red;
            }
            else
            {
                Plc.plc1.Write("M20", (byte)1);
                buttonE.BackColor = Color.Green;
            }
		}
	}
}
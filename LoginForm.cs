using MySql.Data.MySqlClient;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asphalt
{
    public partial class LoginForm : Form
    {
        float x, y = 0;         // 用于自适应
        public LoginForm()
        {
         
            InitializeComponent();
            getTag(this);
            x = this.ClientSize.Width;
            y = this.ClientSize.Height;
            Console.WriteLine("原始大小：" + x.ToString());
            Console.WriteLine(y.ToString()); 
            PasswordText.PasswordChar = '*';
        }

        void getTag(Control contr)
        {
            foreach (Control con in contr.Controls)
            {

                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Name == "panel1" || con.Name == "pictureBox2")
                {
                    Console.WriteLine(con.Tag);
                }
                
                if (con.Controls.Count > 0)
                {
                    getTag(con);
                }
            }
        }
        void setTag(float xbl, float ybl, Control contr)
        {
            foreach (Control con in contr.Controls)
            {
                if (con.Tag != null)
                {
                    string[] myTag = con.Tag.ToString().Split(";");
                                 
                    con.Width = Convert.ToInt32(Convert.ToSingle(myTag[0]) * xbl);
                    con.Height = Convert.ToInt32(Convert.ToSingle(myTag[1]) * ybl);
                    con.Left = Convert.ToInt32(Convert.ToSingle(myTag[2]) * xbl);
                    con.Top = Convert.ToInt32(Convert.ToSingle(myTag[3]) * ybl);
                    con.Font = new Font(con.Font.Name, Convert.ToInt32(Convert.ToSingle(myTag[4]) * ybl));
                    
                    }
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Name == "panel1" || con.Name== "pictureBox2")
                {

                }
                if (con.Controls.Count > 0)
                {
                    setTag(xbl, ybl, con);
                }
               

            }
        }
        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = Sql.executeReader("select * from users where id = '" + UserText.Text.ToString() + "';");
            if (reader.Read())
            {
                if (reader[1].ToString() == PasswordText.Text.ToString())
                {
                    Limit temp = new Limit(UserText.Text.ToString());
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误，请重新输入");
                }
            }
            else
            {
                MessageBox.Show("用户名不存在，请重新输入");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;     // 不占用任务栏
            this.WindowState = FormWindowState.Maximized;       // 最大化窗口
            Console.WriteLine(this.ClientSize.Width.ToString());
            Console.WriteLine(this.ClientSize.Height.ToString());
            float xbl = this.Width / x;
            float ybl = this.Height / y;
            Console.WriteLine(xbl.ToString());
            Console.WriteLine(this.Height.ToString());
            setTag(xbl, ybl, this);
        }

        private void PasswordText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                enter.Focus();
                uiSymbolButton1_Click(this, new EventArgs());
            }
        }

        private void PasswordText_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

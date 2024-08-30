using Google.Protobuf.WellKnownTypes;
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
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Asphalt
{
    public partial class Permission : Form
    {
        public int maximize = -1;
        List<Users> users = new List<Users>();
        public Permission()
        {
            InitializeComponent();
            uiDataGridView1.AddColumn("用户名", "用户名");
            uiDataGridView1.AddColumn("密码", "密码");
            uiDataGridView1.AddColumn("角色", "角色");
            Refreshs();
        }
        public void Refreshs()
        {
            uiComboBox1.Items.Clear();
            cbRole.Items.Clear();
            MySqlDataReader reader = Sql.executeReader("select * from permission;");
            while (reader.Read())
            {
                cbRole.Items.Add(reader[0]);
                uiComboBox1.Items.Add(reader[0]);
            }
            reader.Close();
            users.Clear();
            string sql = "select * from users;";
            reader = Sql.executeReader(sql);
            while (reader.Read())
            {
                Users user = new Users();
                user.用户名 = reader[0].ToString();
                user.密码 = reader[1].ToString();
                user.角色 = reader[2].ToString();
                users.Add(user);
            }
            //设置分页控件总数
            uiPagination1.TotalCount = users.Count;
            uiDataGridView1.SelectIndexChange += uiDataGridView1_SelectIndexChange;
            uiDataGridView1.DataSource = null;
            uiDataGridView1.DataSource = users;
            sizeChanged();
            uiDataGridView1.Refresh();
        }

         public int Maximize
        {
            get { return maximize; }
            set
            {
                maximize = value;
                sizeChanged();            }
        }

        public void sizeChanged()
        {
            uiPagination1.PageSize = (uiDataGridView1.Height - uiDataGridView1.ColumnHeadersHeight)  / uiDataGridView1.RowTemplate.Height;
            if (maximize == 1)
            {
                if (uiDataGridView1.Columns.Count > 0)
                {
                    for (int i = 0; i < uiDataGridView1.Columns.Count; i++)
                    {
                        uiDataGridView1.Columns[i].Width =  (uiDataGridView1.Width - 82) / 3;
                    }
                }
            }
            else
            {
                if (uiDataGridView1.Columns.Count > 0)
                {
                    for (int i = 0; i < uiDataGridView1.Columns.Count; i++)
                    {
                        uiDataGridView1.Columns[i].Width = 144;
                    }
                }
            }
        }

        private void uiPagination1_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            //未连接数据库，通过模拟数据来实现
            //一般通过ORM的分页去取数据来填充
            //pageIndex：第几页，和界面对应，从1开始，取数据可能要用pageIndex - 1
            //count：单页数据量，也就是PageSize值
            List<Users> data = new List<Users>();
            for (int i = (pageIndex - 1) * count; i < (pageIndex - 1) * count + count; i++)
            {
                if (i >= users.Count) continue;
                data.Add(users[i]);
            }          
            uiDataGridView1.DataSource = data;
        }

        private void uiDataGridView1_SelectIndexChange(object sender, int index)
        {
            edtName.Text = uiDataGridView1.Rows[index].Cells[0].Value.ToString();
            edtPasswd.Text = uiDataGridView1.Rows[index].Cells[1].Value.ToString();
            cbRole.Text = uiDataGridView1.Rows[index].Cells[2].Value.ToString();
        }

        private void permission_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void uiSymbolButton3_Click(object sender, EventArgs e)
        {
            if (Limit.limit[1] == 2)
            {
                string name = edtName.Text.ToString(), pw = edtPasswd.Text.ToString();
                if (edtName.Text.ToString() == "" || edtPasswd.Text.ToString() == "")
                {
                    MessageBox.Show("用户名或密码禁止为空！");
                    return;
                }
                if (cbRole.Text.ToString() == "")
                {
                    MessageBox.Show("请选择角色");
                    return;
                }
                for (int i = 0; i < name.Length; ++i)
                {
                    if (name[i] == ' ')
                    {
                        MessageBox.Show("禁止输入空格!");
                        return;
                    }
                }
                for (int i = 0; i < pw.Length; ++i)
                {
                    if (pw[i] == ' ')
                    {
                        MessageBox.Show("禁止输入空格!");
                        return;
                    }
                }
                MySqlDataReader reader = Sql.executeReader("select * from users where id = '" + name + "';");
                if (reader.Read())
                {
                    Sql.executeNonQuery("update users set pw='" + pw + "', part='" + cbRole.Text.ToString() + "'  where id='" + name + "';");
                    MessageBox.Show("修改用户信息成功！");
                }
                else
                {
                    Sql.executeNonQuery("insert into users values('" + name + "','" + pw + "','" + cbRole.Text.ToString() + "');");
                    MessageBox.Show("添加用户信息成功！");
                }
                Refreshs();
            }
            else
            {
                MessageBox.Show("您没有权限使用此功能！");
            }
        }

        private void uiSymbolButton2_Click(object sender, EventArgs e)
        {
            if (Limit.limit[1] == 2)
            {
                DialogResult result = MessageBox.Show("确定要删除用户" + this.edtName.Text + "?", "删除用户", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    Sql.executeNonQuery("delete from users where id='" + edtName.Text.ToString() + "';");
                    MessageBox.Show("删除用户信息成功！");
                }
                Refreshs();
            }
            else
            {
                MessageBox.Show("您没有权限使用此功能！");
            }

        }

        private void uiComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            if (Limit.limit[1] == 2)
            {
                string part = uiComboBox1.Text.ToString();
                if (part == "")
                {
                    MessageBox.Show("角色禁止为空！");
                    return;
                }
                for (int i = 0; i < part.Length; ++i)
                {
                    if (part[i] == ' ')
                    {
                        MessageBox.Show("禁止输入空格!");
                        return;
                    }
                }
                MySqlDataReader reader = Sql.executeReader("select * from permission where part = '" + part + "';");
                if (reader.Read())
                {
                    MessageBox.Show("修改角色权限成功！");
                }
                else
                {
                    Sql.executeNonQuery(string.Format("insert into permission(part) values('{0}');", part));
                    MessageBox.Show("添加角色权限成功！");
                }
                for (int i = 0; i < 7; ++i)         //2表示可以操作，1表示可以查看，0表示无权限
                {
                    if (checkedListBox2.GetItemChecked(i))
                    {
                        Sql.executeNonQuery(string.Format("update permission set val{0} = 2 where part = '{1}';", i + 1, part));
                    }
                    else if (checkedListBox1.GetItemChecked(i))
                    {
                        Sql.executeNonQuery(string.Format("update permission set val{0} = 1 where part = '{1}';", i + 1, part));
                    }
                    else
                    {
                        Sql.executeNonQuery(string.Format("update permission set val{0} = 0 where part = '{1}';", i + 1, part));
                    }
                }
                reader.Close();
                Refreshs();
            }
            else
            {
                MessageBox.Show("您没有权限使用此功能！");
            }
        }

        private void uiSymbolButton4_Click(object sender, EventArgs e)
        {
            if (Limit.limit[1] == 2)
            {
                DialogResult result = MessageBox.Show("确定要删除角色" + uiComboBox1.Text.ToString() + "?", "删除角色", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {

                    Sql.executeNonQuery("delete from permission where part='" + uiComboBox1.Text.ToString() + "';");
                    MessageBox.Show("删除角色信息成功！");
                }
                Refreshs();
            }
            else
            {
                MessageBox.Show("您没有权限使用此功能！");
            }
        }
        private void uiComboBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; ++i)
            {
                checkedListBox2.SetItemChecked(i, false);  
                checkedListBox1.SetItemChecked(i, false);
            }
            MySqlDataReader reader = Sql.executeReader("select * from permission where part = '" + uiComboBox1.Text.ToString() + "';");
            if (reader.Read())
            {
                for (int i = 0; i < 7; ++i)
                {
                    if (reader[i + 1].ToString() == "2")
                    {
                        checkedListBox2.SetItemChecked(i, true);
                    }
                    else if (reader[i + 1].ToString() == "1")
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }
            reader.Close();
        }

		private void uiPanel2_Click(object sender, EventArgs e)
		{

		}

		private void edtName_TextChanged(object sender, EventArgs e)
		{

		}

		private void edtPasswd_TextChanged(object sender, EventArgs e)
		{

		}

		private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void uiLabel4_Click(object sender, EventArgs e)
		{

		}

		private void uiLabel3_Click(object sender, EventArgs e)
		{

		}

		private void uiLabel2_Click(object sender, EventArgs e)
		{

		}
	}
	public class Users
    {
        public string 用户名 { get; set; }

        public string 密码 { get; set; }

        public string 角色 { get; set; }
    }
}

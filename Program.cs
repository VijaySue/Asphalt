using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asphalt
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        public static void Main()
        {
            try
            {
                string connectionString = "server=127.0.0.1;persist security info=yes;userid=root;pwd=root;";
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    MySqlCommand checkDBExistsCmd = new MySqlCommand($"select schema_name from information_schema.schemata where schema_name = 'asphalt';", conn);
                    using (var reader = checkDBExistsCmd.ExecuteReader())
                    {
                        bool dbExists = reader.Read() && reader.GetString(0).Equals("asphalt", StringComparison.OrdinalIgnoreCase);
                        reader.Close();

                        if (!dbExists)
                        {
                            MySqlCommand createDBCmd = new MySqlCommand("create database if not exists asphalt;", conn);
                            createDBCmd.ExecuteNonQuery();
                    
                            MySqlCommand useDBCmd = new MySqlCommand("use asphalt;", conn);
                            useDBCmd.ExecuteNonQuery();

                            string sqlScript = File.ReadAllText("./asphalt.sql");
                            MySqlCommand initDBCmd = new MySqlCommand(sqlScript, conn);
                            initDBCmd.ExecuteNonQuery();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            start();
        }


        public static void start()
        {
            LoginForm formLogin = new LoginForm();
            if (formLogin.ShowDialog() == DialogResult.OK)
            {
                Splasher.Show(typeof(FrmSplash));

                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                Index myIndex = new Index();
                Application.Run(myIndex);
            }
        }
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs ex)
        {
            string message = string.Format("{0}\r\n操作发生错误，您须要退出系统么？", ex.Exception.Message);
            if (DialogResult.Yes == MessageBox.Show(message, "系统错误", MessageBoxButtons.YesNo))
            {
                Application.Exit();
            }
        }
    }
}
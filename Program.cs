using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asphalt
{
    /// <summary>
    /// 程序入口类，负责初始化数据库、处理异常和启动应用程序
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// 负责检查和初始化数据库，设置应用程序样式，并启动登录流程
        /// </summary>
        public static void Main()
        {
            try
            {
                // 设置数据库连接字符串 - 连接到MySQL服务器
                string connectionString = "server=127.0.0.1;persist security info=yes;userid=root;pwd=root;";
                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // 检查asphalt数据库是否存在
                    MySqlCommand checkDBExistsCmd = new MySqlCommand($"select schema_name from information_schema.schemata where schema_name = 'asphalt';", conn);
                    using (var reader = checkDBExistsCmd.ExecuteReader())
                    {
                        bool dbExists = reader.Read() && reader.GetString(0).Equals("asphalt", StringComparison.OrdinalIgnoreCase);
                        reader.Close();

                        // 如果数据库不存在，则创建并初始化数据库
                        if (!dbExists)
                        {
                            // 创建asphalt数据库
                            MySqlCommand createDBCmd = new MySqlCommand("create database if not exists asphalt;", conn);
                            createDBCmd.ExecuteNonQuery();
                    
                            // 使用asphalt数据库
                            MySqlCommand useDBCmd = new MySqlCommand("use asphalt;", conn);
                            useDBCmd.ExecuteNonQuery();

                            // 从SQL脚本文件导入初始数据
                            string sqlScript = File.ReadAllText("./asphalt.sql");
                            MySqlCommand initDBCmd = new MySqlCommand(sqlScript, conn);
                            initDBCmd.ExecuteNonQuery();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // 显示初始化过程中的错误信息
                MessageBox.Show(ex.Message);
            }
            
            // 启用应用程序的视觉样式
            Application.EnableVisualStyles();
            // 设置文本渲染的兼容性
            Application.SetCompatibleTextRenderingDefault(false);
            // 启动应用程序的登录流程
            start();
        }

        /// <summary>
        /// 启动登录流程并初始化主应用程序
        /// 显示登录窗口，若登录成功则启动启动画面和主窗体
        /// </summary>
        public static void start()
        {
            // 创建并显示登录窗口
            LoginForm formLogin = new LoginForm();
            if (formLogin.ShowDialog() == DialogResult.OK)
            {
                // 显示启动画面
                Splasher.Show(typeof(FrmSplash));

                // 设置全局异常处理器
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                // 创建并运行主窗体
                Index myIndex = new Index();
                Application.Run(myIndex);
            }
        }

        /// <summary>
        /// 全局线程异常处理方法
        /// 当应用程序中发生未处理的异常时，提示用户并询问是否退出
        /// </summary>
        /// <param name="sender">事件源</param>
        /// <param name="ex">包含异常信息的事件参数</param>
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
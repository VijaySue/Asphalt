using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Asphalt
{
    /// <summary>
    /// 数据库操作类，提供对MySQL数据库的连接和操作方法
    /// 采用单例模式设计，避免重复创建数据库连接实例
    /// </summary>
    internal class Sql
    {
        /// <summary>
        /// 数据库连接对象，用于执行查询操作
        /// </summary>
        private static MySqlConnection conn = null;
        
        /// <summary>
        /// 数据库读取器，用于查询结果的读取
        /// </summary>
        private static MySqlDataReader reader = null;
        
        /// <summary>
        /// 私有构造函数，防止外部实例化
        /// </summary>
        private Sql() { }
       
        /// <summary>
        /// 执行SQL查询并返回数据读取器
        /// 该方法用于执行查询操作，如SELECT语句
        /// </summary>
        /// <param name="sql">要执行的SQL查询语句</param>
        /// <returns>返回MySqlDataReader对象的引用，用于读取查询结果</returns>
        public static ref MySqlDataReader executeReader(string sql)
        {
            // 如果连接对象为空，则创建新连接
            if (conn == null)
            {
                conn = new MySqlConnection("server=127.0.0.1;port=3306;user=root;password=root;database=asphalt;");
            }
            
            try
            {
                // 如果连接已关闭，则打开连接
                if (conn.State == ConnectionState.Closed) 
                {
                    conn.Open();
                } 
                else
                {
                    // 如果连接处于其他状态，则重新连接
                    conn.Close();
                    conn.Open();
                }
            }
            catch (MySqlException ex)
            {
                // 显示连接错误信息
                MessageBox.Show(ex.ToString());
            }
            
            // 创建命令并执行查询
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                reader = cmd.ExecuteReader();
            }
            return ref reader;
        }

        /// <summary>
        /// 用于线程安全的数据库操作的锁对象
        /// </summary>
        private static object _connectionLock = new object();
        
        /// <summary>
        /// 用于执行非查询操作的数据库连接对象
        /// </summary>
        private static MySqlConnection _conn;

        /// <summary>
        /// 执行SQL非查询命令，如INSERT、UPDATE、DELETE等
        /// 该方法线程安全，使用锁确保多线程环境下的数据一致性
        /// </summary>
        /// <param name="sql">要执行的SQL非查询命令</param>
        /// <returns>受影响的行数</returns>
        public static int executeNonQuery(string sql)
        {
            int rowsAffected = 0;
    
            // 使用锁确保线程安全
            lock (_connectionLock)
            {
                // 如果连接不存在或已关闭，则创建并打开新连接
                if (_conn == null || _conn.State != ConnectionState.Open)
                {
                    _conn = new MySqlConnection("server=127.0.0.1;port=3306;user=root;password=root;database=asphalt;");
                    _conn.Open();
                }

                // 执行命令并返回受影响的行数
                using (var cmd = new MySqlCommand(sql, _conn))
                {
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
    }
}

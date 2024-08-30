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
    internal class Sql
    {
        private static MySqlConnection conn = null;
        private static MySqlDataReader reader = null;
        private Sql() { }
       
        public static ref MySqlDataReader executeReader(string sql)
        {
            if (conn == null)
            {
                conn = new MySqlConnection("server=127.0.0.1;port=3306;user=root;password=root;database=asphalt;");
            }
            try
            {
                if (conn.State == ConnectionState.Closed) 
                {
                    conn.Open();
                } 
                else
                {
                    conn.Close();
                    conn.Open();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                reader = cmd.ExecuteReader();
            }
            return ref reader;
        }

        private static object _connectionLock = new object();
        private static MySqlConnection _conn;


        public static int executeNonQuery(string sql)
        {
            int rowsAffected = 0;
    
            lock (_connectionLock)
            {
                if (_conn == null || _conn.State != ConnectionState.Open)
                {
                    _conn = new MySqlConnection("server=127.0.0.1;port=3306;user=root;password=root;database=asphalt;");
                    _conn.Open();
                }

                using (var cmd = new MySqlCommand(sql, _conn))
                {
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }
    }
}

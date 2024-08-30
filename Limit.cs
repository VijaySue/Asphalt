using MySql.Data.MySqlClient;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Asphalt
{

    internal class Limit
    {
        public static int[] limit = null;           // 2表示可以操作，1表示可以查看，0表示无权限
        public Limit(string id)
        {
            limit = new int[7];   // 分别对应：监控管理，用户权限管理，系统参数设置，运行参数设置，运行配方设置，历史数据报表，历史数据曲线  
            MySqlDataReader reader = Sql.executeReader("select part from users where id = '" + id + "';");
            reader.Read();
            string part = reader[0].ToString();
            reader.Close();
            reader = Sql.executeReader("select * from permission where part = '" + part + "';");
            reader.Read();
            for (int i = 0; i < 7; ++i)
            {
                limit[i] = reader[i + 1].ToString().ToInt();
            }
            reader.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using MySql.Data.MySqlClient;

namespace GameServer.Tool
{
    class ConnHelper
    {
        private const string CONNECTIONSTR = "datasource=127.0.0.1;port=3306;database=test007;user=root;password=123456";

        private MySqlConnection mConnetion;

        public static MySqlConnection Connect()
        {
            mConnetion = new MySqlConnection(CONNECTIONSTR);
            try
            {
                mConnetion.Open();
                return mConnetion;
            }
            catch (Exception e)
            {
                Console.WriteLine("链接数据库时出现异常：" + e);
                return null;
            }
            

        }

        public static void CloseConnection(MySqlConnection conn)
        {
            if (conn != null)
                conn.Close();
            else
                Console.WriteLine("MySqlConnection 不能为空");
        }
    }
}

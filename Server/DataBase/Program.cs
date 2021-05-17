using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "DataBase=test007;datasource=127.0.0.1;port=3306;user=root;password=123456";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            #region 查询
            //MySqlCommand query = new MySqlCommand("select * from user", conn);
            //MySqlDataReader reader = query.ExecuteReader();
            //while (reader.Read())
            //{
            //    string username = reader.GetString("username");
            //    string password = reader.GetString("password");
            //    Console.WriteLine(username + " " + password);
            //}
            #endregion

            #region 插入
            // string username = "cwer"; string password = "lcker;delete from user;";
            //// 方式一 ， 租聘字符串易导致恶意SQL语句注入
            //MySqlCommand cmd = new MySqlCommand("insert into user set username = '" + username + "',password='" + password + "';", conn);

            //// 方式二，使用参数解决恶意语句注入
            //MySqlCommand cmd = new MySqlCommand("insert into user set username = @un, password=@pwd", conn);

            // cmd.Parameters.AddWithValue("un", username);
            // cmd.Parameters.AddWithValue("pwd", password);

            // cmd.ExecuteNonQuery();
            #endregion

            #region 删除 更新
            // 操作过程类似插入，使用参数方式
            #endregion



            conn.Close();
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TechBlog
{
    public class ConnectDatabase
    {
        public SqlConnection connect;
        public SqlDataAdapter dataAdapter;
        public SqlCommand command;
        public SqlCommandBuilder commandBuilder;

        public ConnectDatabase()
        {
            string connectString = "Data Source=DESKTOP-VE79BNO\\VANHIEP;Initial Catalog=TechBlog;Integrated Security=True";
            connect = new SqlConnection();
            connect.ConnectionString = connectString;
        }

        public DataTable GetData(string sql)
        {
            try
            {
                connect.Open();
                dataAdapter = new SqlDataAdapter(sql, connect);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                connect.Close();
                return dt;
            } catch (Exception ex) { }
            return null;
        }

        public bool SetData(string sql)
        {
            try
            {
                connect.Open();
                command = new SqlCommand(sql, connect);
                command.ExecuteNonQuery();
                connect.Close();
                return true;
            } catch (Exception ex) { }
            return false;
        }
    }
}
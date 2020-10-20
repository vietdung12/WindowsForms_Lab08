using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace WindowsForms_Lab08
{
    class Database
    {
        SqlConnection sqlConn;
        SqlDataAdapter da;
  

        public Database()
        {
            string strCnn = "Data Source=VD\\SQLEXPRESS; Database=QLthuvien; Integrated Security = True";
            sqlConn = new SqlConnection(strCnn);
        }

        public DataTable Execute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, sqlConn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        public void ExecuteNonQuery(string strSQL)
        {
            SqlCommand sqlcmd = new SqlCommand(strSQL, sqlConn);
            sqlConn.Open(); 
            sqlcmd.ExecuteNonQuery();
            sqlConn.Close();
        }


    }
}

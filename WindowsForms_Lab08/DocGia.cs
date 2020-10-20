using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WindowsForms_Lab08
{
    class DocGia
    {
        Database db;
        public DocGia()
        {
            db = new Database();
        }
        public DataTable LayTenDG()
        {
            string strSQL = "Select * from DOCGIA";
            DataTable dt = db.Execute(strSQL);
            return dt;
        }
    }
}

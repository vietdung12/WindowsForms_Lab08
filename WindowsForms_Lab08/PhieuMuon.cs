using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsForms_Lab08
{
    class PhieuMuon
    {
        Database db;
        public PhieuMuon()
        {
            db = new Database();
        }

        public DataTable LayDSPM()
        {
            string strSQL = "Select * From PHIEUMUONSACH N, DOCGIA B Where N.MaDocGia = B.MaDocGia";
            DataTable dt = db.Execute(strSQL);
            return dt;
        }

        

        public void Them(string ngaymuon, string index_bc)

        {
            string sql = string.Format("Insert Into PhieuMuonSach Values({0},{1})", ngaymuon, index_bc);
            db.ExecuteNonQuery(sql);
        }

        public void CapNhat(string index_mpm, string ngaymuon, string index_bc)
        {
                 
            string str = string.Format("Update PHIEUMUONSACH set Ngaymuon = '{0}', MaDocGia = {1} where MAPHIEUMUON = {2}", ngaymuon, index_bc, index_mpm);
            db.ExecuteNonQuery(str);
        }

        public void Xoa(string MaPhieuMuon)
        {
            string sql = "Delete from PHIEUMUONSACH where MaPhieuMuon = " + MaPhieuMuon;
            db.ExecuteNonQuery(sql);
        }
    }
}

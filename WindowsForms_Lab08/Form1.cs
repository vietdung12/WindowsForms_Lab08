using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.IO;

namespace WindowsForms_Lab08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /* 
         SqlConnection sqlConn; 
         SqlDataAdapter da;
         DataSet ds;
         
         void KetnoiCSDL() 
         {
             string connStr = "Data source=PC11\\ADMINSQL; database=QLTHUVIEN; Integrated Security = True";
             sqlConn = new SqlConnection(connStr);
             sqlConn.Open();
         }

         DataTable layDanhSachNhanVien()
         {
             string sql = "Select * from NhanVien";
             da = new SqlDataAdapter(sql, sqlConn);
             DataSet ds = new DataSet();
             da.Fill(ds);
             return ds.Tables[0];
         }

         void LoadListview()
         {
             lsvNhanVien.Items.Clear();
             DataTable dt = new DataTable();
             dt = layDanhSachNhanVien();
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 ListViewItem lvi = lsvNhanVien.Items.Add(dt.Rows[i]["Hotennhanvien"].ToString());       
                 lvi.SubItems.Add(dt.Rows[i][2].ToString()); 
                 lvi.SubItems.Add(dt.Rows[i][4].ToString());
                 lvi.SubItems.Add(dt.Rows[i][3].ToString());
             }

         }

         private void Form1_Load(object sender, EventArgs e)
         {
             KetnoiCSDL();
             LoadListview();
         }

         private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (lsvNhanVien.SelectedItems.Count > 0)
             {
                 txtHoTen.Text = lsvNhanVien.SelectedItems[0].SubItems[0].Text;
                 dtpNgaySinh.Text = lsvNhanVien.SelectedItems[0].SubItems[1].Text;
                 txtDienThoai.Text = lsvNhanVien.SelectedItems[0].SubItems[2].Text;
                 txtDiaChi.Text = lsvNhanVien.SelectedItems[0].SubItems[3].Text;
             }
         }

         void setnull()
         {
             txtHoTen.Text = "";
             dtpNgaySinh.Text = DateTime.Now.ToShortDateString();
             txtDienThoai.Text = "";
             txtDiaChi.Text = "";
             txtHoTen.Focus();
         }

         private void Btn_Them_Click(object sender, EventArgs e)
         {
             if (txtHoTen.Text != "")
             {
                 ListViewItem lvi = new ListViewItem();
                 lvi = lsvNhanVien.Items.Add(txtHoTen.Text);
                 lvi.SubItems.Add(dtpNgaySinh.Value.ToShortDateString());
                 lvi.SubItems.Add(txtDienThoai.Text);
                 lvi.SubItems.Add(txtDiaChi.Text);
                 setnull();
             }
             else
             {
                 MessageBox.Show("Not Allow Leave The Name Blank");
             }
         }

         private void Btn_Xoa_Click(object sender, EventArgs e)
         {
             if (lsvNhanVien.SelectedItems.Count > 0)
             {
                 lsvNhanVien.Items.Remove(lsvNhanVien.SelectedItems[0]);
             }
             else
                 MessageBox.Show("No Information To Delete");
         }

         private void Btn_Sua_Click(object sender, EventArgs e)
         {
             if (lsvNhanVien.SelectedItems.Count > 0)
             {
                 lsvNhanVien.SelectedItems[0].SubItems[0].Text = txtHoTen.Text;
                 lsvNhanVien.SelectedItems[0].SubItems[1].Text = dtpNgaySinh.Value.ToShortDateString();
                 lsvNhanVien.SelectedItems[0].SubItems[2].Text = txtDienThoai.Text;
                 lsvNhanVien.SelectedItems[0].SubItems[3].Text = txtDiaChi.Text;
                 setnull();
             }
             else
                 MessageBox.Show("No Information To Edit");
         }

         private void Btn_Thoat_Click(object sender, EventArgs e)
         {
             if (MessageBox.Show("--Are You Really Exit?--", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 this.Close();
         }
         */
        Nhanvien nv = new Nhanvien();

        void HienthiNhanvien()
        {
            DataTable dt = new DataTable();
            dt = nv.LayDSNhanvien();
            lsvNhanVien.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvNhanVien.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
                lvi.SubItems.Add(dt.Rows[i][3].ToString());
                lvi.SubItems.Add(dt.Rows[i][4].ToString());
                lvi.SubItems.Add(dt.Rows[i][5].ToString());
            }
        }
        void HienthiBangcap()
        {
            DataTable dt = nv.LayBangcap();
            cboBangCap.DataSource = dt;
            cboBangCap.DisplayMember = "TenBangcap";
            cboBangCap.ValueMember = "MaBangcap";
        }
        void setNull()
        {
            txtHoTen.Text = "";
            dtpNgaySinh.Text = DateTime.Now.ToShortDateString();
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
        }

        void setButton(bool val)
        {
            Btn_Them.Enabled = val;
            Btn_Xoa.Enabled = val;
            Btn_Sua.Enabled = val;
            Btn_Thoat.Enabled = val;
            btnLuu.Enabled = !val;
            btnHuy.Enabled = !val;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            setNull();
            HienthiBangcap();
            HienthiNhanvien();
        }

        private void lsvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedItems.Count > 0)
            {
                txtHoTen.Text = lsvNhanVien.SelectedItems[0].SubItems[1].Text;
                dtpNgaySinh.Text = lsvNhanVien.SelectedItems[0].SubItems[2].Text;
                txtDiaChi.Text = lsvNhanVien.SelectedItems[0].SubItems[3].Text;
                txtDienThoai.Text = lsvNhanVien.SelectedItems[0].SubItems[4].Text;
                cboBangCap.SelectedIndex = cboBangCap.FindString(lsvNhanVien.SelectedItems[0].SubItems[5].Text);
            }
        }

        bool themmoi = true;

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            themmoi = true;
            setButton(false);
            setNull();
            txtHoTen.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ngay = String.Format("{0:MM/dd/yyyy}", dtpNgaySinh.Value);
            string hoten = txtHoTen.Text;
            string diachi = txtDiaChi.Text;
            string dienthoai = txtDienThoai.Text;
            string index_bc = cboBangCap.SelectedValue.ToString();

            if (themmoi)
            {
                nv.ThemNhanVien(hoten,ngay,diachi,dienthoai,index_bc);

                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                nv.CapNhatNhanVien(lsvNhanVien.SelectedItems[0].SubItems[0].Text,txtHoTen.Text, ngay, txtDiaChi.Text, txtDienThoai.Text, cboBangCap.SelectedValue.ToString());
                MessageBox.Show("Cập nhật thành công");
            }

            HienthiNhanvien();
            setNull();
        }

        private void Btn_Sua_Click(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButton(false);
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cập nhật");
        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            if (lsvNhanVien.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không ? ", "Xóa bằng cấp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    nv.XoaNhanVien(lsvNhanVien.SelectedItems[0].SubItems[0].Text);
                    lsvNhanVien.Items.RemoveAt(lsvNhanVien.SelectedIndices[0]);
                    setNull();
                }
            }
            else
                MessageBox.Show("Bạn phải chọn mẩu tin cần xóa");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            setButton(true);
        }

        private void Btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("--Are You Really Exit?--", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
    }


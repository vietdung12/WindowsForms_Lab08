using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_Lab08
{
    public partial class FrmPhieuMuon : Form
    {
        public FrmPhieuMuon()
        {
            InitializeComponent();
        }
        PhieuMuon pm = new PhieuMuon();
        DocGia dg = new DocGia();
        void HienthiPM()
        {
            DataTable dt = new DataTable();
            dt = pm.LayDSPM();
            lsvPM.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = lsvPM.Items.Add(dt.Rows[i][0].ToString());
                lvi.SubItems.Add(dt.Rows[i][1].ToString());
                lvi.SubItems.Add(dt.Rows[i][2].ToString());
            }
        }

        void HienthiTenDG()
        {
            DataTable dt = dg.LayTenDG();
            cboMaDG.DataSource = dt;
            cboMaDG.DisplayMember = "MaDocGia";
            cboMaDG.ValueMember = "HoTenDocGia";
         }
         
        private void FrmPhieuMuon_Load(object sender, EventArgs e)
        {
            setNull();
            HienthiPM();
            HienthiTenDG();
            txtTenDG.Text = cboMaDG.SelectedValue.ToString();
        }

        void setNull()
        {
            txtTenDG.Text = "";
            dtpNgayM.Text = DateTime.Now.ToShortDateString();
            txtMaPM.Text = "";           
        }

        void setButton(bool val)
        {
            Btn_Them.Enabled = val;
            Btn_Xoa.Enabled = val;
            Btn_Sua.Enabled = val;
            Btn_Thoat.Enabled = val;
            btn_Luu.Enabled = !val;
            btn_Huy.Enabled = !val;
        }

        private void lsvPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPM.SelectedItems.Count > 0)
            {
                txtMaPM.Text = lsvPM.SelectedItems[0].SubItems[0].Text;
                dtpNgayM.Text = lsvPM.SelectedItems[0].SubItems[1].Text;                
                cboMaDG.SelectedIndex = cboMaDG.FindString(lsvPM.SelectedItems[0].SubItems[2].Text);              
            }
        }

        bool themmoi = true;
       

        private void Btn_Them_Click_1(object sender, EventArgs e)
        {
            themmoi = true;
            setButton(false);
            setNull();
        }

        private void Btn_Xoa_Click_1(object sender, EventArgs e)
        {
            if (lsvPM.SelectedIndices.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc xóa không ? ", "Xóa bằng cấp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    pm.Xoa(lsvPM.SelectedItems[0].SubItems[0].Text);
                    lsvPM.Items.RemoveAt(lsvPM.SelectedIndices[0]);
                    setNull();
                }
            }
            else
                MessageBox.Show("Bạn phải chọn mẩu tin cần xóa");
        }

        private void Btn_Sua_Click_1(object sender, EventArgs e)
        {
            if (lsvPM.SelectedIndices.Count > 0)
            {
                themmoi = false;
                setButton(false);
            }
            else
                MessageBox.Show("Bạn phải chọn mẫu tin cập nhật");
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            string ngay = String.Format("{0:MM/dd/yyyy}", dtpNgayM.Value);
            //string ma = txtMaPM.Text;
            string index_dg = cboMaDG.Text;
            if (themmoi == true)
            {
                pm.Them(ngay, index_dg);

                MessageBox.Show("Thêm mới thành công");
            }
            else
            {
                pm.CapNhat(lsvPM.SelectedItems[0].SubItems[0].Text, ngay, cboMaDG.Text);
                MessageBox.Show("Cập nhật thành công");
            }
            HienthiPM();
            setNull();
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            setButton(true);
        }

        private void Btn_Thoat_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("--Are You Really Exit?--", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void txtTenDG_TextChanged(object sender, EventArgs e)
        {
            txtTenDG.Text = cboMaDG.SelectedValue.ToString();
        }
    }
    }


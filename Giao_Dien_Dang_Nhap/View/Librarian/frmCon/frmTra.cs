using Giao_Dien_Dang_Nhap.Classes;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giao_Dien_Dang_Nhap.View.Librarian.frmCon
{
    public partial class frmTra : Form
    {
        CommonFunction commonFunction = new CommonFunction();
        Connection connection = new Connection();
        public frmTra()
        {
            InitializeComponent();
            DataTable dtMaPhieuTra = connection.DataReader("Select * from tPhieuTra");
            DataTable dtTinhTrang = connection.DataReader("select * from tTaiLieu");
            commonFunction.FillComboBox(cboMaPhieuTra, dtMaPhieuTra, "MaPhieuTra", "MaPhieuTra");
            commonFunction.FillComboBox(cboTinhTrang, dtTinhTrang, "MaTaiLieu", "MaTaiLieu");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNoCancel); //Gets users input by showing the message box
            if (result == DialogResult.Yes) //Creates the yes function
            {
                this.Close();
            }
        }
        private void hienChiTiet(bool hien)
        {
            txtMaPhieuTra.Enabled = hien;
            txtMaTaiLieu.Enabled = hien;
            txtTenTaiLieu.Enabled = hien;
            txtMaSV.Enabled = hien;
            dtpNgayTra.Enabled = hien;
            cboTinhTrang.Enabled = hien;
            txtSLMuon.Enabled = hien;
            txtGhiChu.Enabled = hien; 
        }

        private void btnDuyetDSTra_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sinh vien da tra tai lieu");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dtPhieuTra = connection.DataReader("select * from tPhieuTra where MaPhieuTra='" + cboMaPhieuTra.Text + "'");
            
            txtMaPhieuTra.Text = cboMaPhieuTra.Text;
            txtMaTaiLieu.Text = dtPhieuTra.Rows[0]["MaTailieu"].ToString();
            txtTenTaiLieu.Text = dtPhieuTra.Rows[0]["TenTailieu"].ToString();
            txtMaSV.Text = dtPhieuTra.Rows[0]["MaSV"].ToString();
            dtpNgayTra.Text = dtPhieuTra.Rows[0]["NgayTra"].ToString();
            cboTinhTrang.SelectedValue = dtPhieuTra.Rows[0]["MaNhanVien"];
            txtSLMuon.Text = dtPhieuTra.Rows[0]["SLMuon"].ToString();
            txtGhiChu.Text = dtPhieuTra.Rows[0]["GhiChu"].ToString();
        }

        private void dgvKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhieuTra.Text = dgvKetQua.CurrentRow.Cells[0].Value.ToString();
            txtMaTaiLieu.Text = dgvKetQua.CurrentRow.Cells[1].Value.ToString();
            txtTenTaiLieu.Text = dgvKetQua.CurrentRow.Cells[2].Value.ToString();
            txtMaSV.Text = dgvKetQua.CurrentRow.Cells[3].Value.ToString();
            dtpNgayTra.Text = dgvKetQua.CurrentRow.Cells[4].Value.ToString();
            cboTinhTrang.SelectedValue = dgvKetQua.CurrentRow.Cells[5].Value.ToString();
            txtSLMuon.Text = dgvKetQua.CurrentRow.Cells[6].Value.ToString();
            txtGhiChu.Text = dgvKetQua.CurrentRow.Cells[7].Value.ToString();
        }
    }
}

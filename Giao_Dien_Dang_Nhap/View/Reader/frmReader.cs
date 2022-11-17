using Giao_Dien_Dang_Nhap.Main;
using Giao_Dien_Dang_Nhap.View.Reader.frmConReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Giao_Dien_Dang_Nhap.View.Reader
{
    public partial class frmReader : Form
    {
        Classes.Connection data = new Classes.Connection();
        public string ten;
        public frmReader(string tk)
        {
            this.ten = tk;
           
            InitializeComponent();
        }
        public frmReader()
        {
            InitializeComponent();
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void frmReader_Load(object sender, EventArgs e)
        {
            label1.Parent = guna2PictureBox2;
            label1.BackColor = Color.Transparent;
            user.Text= this.ten;
         
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmGopY frmGopY = new frmGopY();
            frmGopY.MdiParent = this;
            frmGopY.Show();
            frmGopY.Dock = DockStyle.Fill;
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            frmReSachTKhao frmSTK = new frmReSachTKhao();
            frmSTK.MdiParent = this;
            frmSTK.Show();
            frmSTK.Dock = DockStyle.Fill;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmReAllDocument frmReSearch = new frmReAllDocument(); 
            frmReSearch.MdiParent = this;
            frmReSearch.Show();
            frmReSearch.Dock = DockStyle.Fill;
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            frmReResearch1 frmReResearch1 = new frmReResearch1();
            frmReResearch1.MdiParent = this;
            frmReResearch1.Show();
            frmReResearch1.Dock = DockStyle.Fill;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            frmReGiaoTrinh frmReGiaoTrinh = new frmReGiaoTrinh();
            frmReGiaoTrinh.MdiParent = this;
            frmReGiaoTrinh.Show();
            frmReGiaoTrinh.Dock = DockStyle.Fill;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string ma;
            DataTable msv = data.DataReader("select * from tAccount where Username = '" + this.ten + "'");
            if (msv.Rows.Count > 0)
            {
                ma = msv.Rows[0]["MSV"].ToString();
                this.ten = ma;
            }
            string st = "select tChiTietPhieuMuon.MaPhieuMuon, tTaiLieu.MaTaiLieu,TenTaiLieu,TenTacGia,NamXB,tChiTietPhieuMuon.SoLuongTaiLieu,NgayMuon" +
                " from tChiTietPhieuMuon inner join tPhieuMuon on tChiTietPhieuMuon.MaPhieuMuon = tPhieuMuon.MaPhieuMuon" +
                " join tTaiLieu on tTaiLieu.MaTaiLieu = tChiTietPhieuMuon.MaTaiLieu" +
                " join tSinhVien on tSinhVien.MSV = tPhieuMuon.MSV" +
                " where tPhieuMuon.MSV = '" + this.ten + "'";
            string sinhvien = "select * from tSinhVien where MSV = '" + this.ten + "'";
            frmReSachMuon frmReSachMuon = new frmReSachMuon(st, sinhvien);
            frmReSachMuon.MdiParent = this;
            frmReSachMuon.Show();
            frmReSachMuon.Dock = DockStyle.Fill;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            frmMainStudent frmMain = new frmMainStudent();
            this.Hide();
            frmMain.ShowDialog();
            this.Close();
        }
    }
}

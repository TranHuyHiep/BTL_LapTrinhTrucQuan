using Giao_Dien_Dang_Nhap.Main;
using Giao_Dien_Dang_Nhap.View.Librarian;
using Giao_Dien_Dang_Nhap.View.Librarian.frmCon;
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

namespace Giao_Dien_Dang_Nhap
{
    public partial class frmLibrarian : Form
    {
        public frmLibrarian()
        {
            InitializeComponent();
        }
        
        private void frmLibrarian_Load(object sender, EventArgs e)
        {
            label1.Parent = guna2PictureBox2;
            label1.BackColor = Color.Transparent;

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            frmTailieu frmTailieu = new frmTailieu();
            frmTailieu.MdiParent = this;
            frmTailieu.Show();
            frmTailieu.Dock = DockStyle.Fill;
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            frmDocGia frmDocGia = new frmDocGia();
            frmDocGia.MdiParent = this;
            frmDocGia.Show();
            frmDocGia.Dock = DockStyle.Fill;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            frmMuon frmMuon = new frmMuon();
            frmMuon.MdiParent = this;
            frmMuon.Show();
            frmMuon.Dock = DockStyle.Fill;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            frmTra frmTra = new frmTra();
            frmTra.MdiParent = this;
            frmTra.Show();
            frmTra.Dock = DockStyle.Fill;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            frmViPham frmViPham = new frmViPham();
            frmViPham.MdiParent = this;
            frmViPham.Show();
            frmViPham.Dock = DockStyle.Fill;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            this.Hide();
            frmMain.ShowDialog();
            this.Close();
        }
    }
}

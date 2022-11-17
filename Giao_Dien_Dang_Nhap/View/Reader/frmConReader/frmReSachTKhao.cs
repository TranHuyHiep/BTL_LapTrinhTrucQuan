using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giao_Dien_Dang_Nhap.View.Reader.frmConReader
{
    public partial class frmReSachTKhao : Form
    {
        public frmReSachTKhao()
        {
            InitializeComponent();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNoCancel); //Gets users input by showing the message box
            if (result == DialogResult.Yes) //Creates the yes function
            {
                this.Close();
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string st;
            if (textBox1.Text.Trim() == "" && textBox2.Text.Trim() == "" && textBox3.Text.Trim() == "")
                st = "select MaTaiLieu, TenTaiLieu, TenTacGia,NamXB,SoLuong,SoTrang,TenTheLoai,TenNXB" +
                    " from tTheLoai inner join tTaiLieu on tTaiLieu.MaTheLoai = tTheLoai.MaTheLoai" +
                    " join tNhaXuatBan on tNhaXuatBan.MaNXB = tTaiLieu.MaNXB" +
                    " where TenTheLoai = N'Tài liệu tham khảo'";
            else
                st = "select MaTaiLieu, TenTaiLieu, TenTacGia,NamXB,SoLuong,SoTrang,TenTheLoai,TenNXB" +
                    " from tTheLoai inner join tTaiLieu on tTaiLieu.MaTheLoai = tTheLoai.MaTheLoai" +
                    " join tNhaXuatBan on tNhaXuatBan.MaNXB = tTaiLieu.MaNXB " +
                    "                       where (TenTaiLieu = N'"+textBox2.Text+"'  or TenTacGia = N'"+ textBox3.Text+"' or NamXB='"+textBox1.Text+"') and TenTheLoai = N'Tài liệu tham khảo'";
            frmReResult frmReResult = new frmReResult(st);
            frmReResult.ShowDialog();
        }
    }
}

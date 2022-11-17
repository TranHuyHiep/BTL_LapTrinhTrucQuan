using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Giao_Dien_Dang_Nhap
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        Classes.Connection data = new Classes.Connection();
        private void label1_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
            this.Close();
        }
        public bool CheckMK(string a)
        {
            return Regex.IsMatch(a, "^[a-zA-Z0-9]{6,24}$");
        }
        public bool CheckEmail(string b)
        {
            return Regex.IsMatch(b, "^[a-z0-9][-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$");
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string msv = txtMaSV.Text;
            string hoten = txtHoTen.Text;
            string email = txtEmail.Text;
            string matkhau = txtMatKhau.Text;
            if (!CheckEmail(email))
            {
                MessageBox.Show("Vui lòng nhập email tồn tại!");
                return;
            }
            DataTable dttk = data.DataReader("Select  *  From  tAccount  Where  Username  ='" + msv + "'");
            if (dttk.Rows.Count > 0)
            {
                MessageBox.Show(txtMaSV, "Mã sinh viên này đã đăng ký, vui lòng kiểm tra lại!", "Thông báo");
                return;
            }
            data.DataChange("INSERT INTO dbo.tSinhVien(MSV,HoTen,Lop,Khoa,SDT,Email)VALUES(N'" + msv + "','" + hoten + "', Null, Null,Null, '" + email + "' )");
            data.DataChange("INSERT  INTO  tAccount(Username, Password, Email,ID,MSV,MaThuThu) VALUES(N'" + msv + "',N'" + matkhau + "',N'" + email + "',1,'" + msv + "',null)");
            MessageBox.Show("Đăng ký thành công");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmLogin().Visible = true;
            this.Visible = false;
        }
    }
}

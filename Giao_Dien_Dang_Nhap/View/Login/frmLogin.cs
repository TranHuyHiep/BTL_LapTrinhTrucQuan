using Giao_Dien_Dang_Nhap.Main;
using Giao_Dien_Dang_Nhap.View.Reader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giao_Dien_Dang_Nhap
{
    public partial class frmLogin : Form
    {
        Classes.Connection data = new Classes.Connection();

        public frmLogin()
        {
            InitializeComponent();
        }
        public string b()
        {
            return guna2TextBox1.Text;
        }

        private void ResetAllData()
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            frmMainStudent.studentName = "";
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string tk = guna2TextBox1.Text;
            string mk = guna2TextBox2.Text;
            // DataTable taikhoan = data.DataReader("select * from tAccount");
            if (tk.Trim() == "") { MessageBox.Show("Vui lòng nhập tên tài khoản!", "Tài khoản trống"); }
            else if (mk.Trim() == "") { MessageBox.Show("Vui lòng nhập mật khẩu!", "Mật khẩu trống"); }
            else
            {
                DataTable taikhoan = data.DataReader("select * from tAccount where Username = N'" + tk + "' and Password =N'" + mk + "'");
                if (taikhoan.Rows.Count > 0)
                {
                    if (int.Parse(taikhoan.Rows[0]["ID"].ToString()) == 1)
                    {
                        frmMainStudent mainStudent = new frmMainStudent(tk);
                        mainStudent.ShowDialog();
                        
                    }
                    if (int.Parse(taikhoan.Rows[0]["ID"].ToString()) == 0)
                    {
                        frmMain fmain = new frmMain();
                        fmain.ShowDialog();
                    }
                    ResetAllData();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu bạn nhập không đúng!", "Lỗi đăng nhập");
                }

            }

        }
        private void label2_Click(object sender, EventArgs e)
        {
            new frmForgetPassword().Visible = true;
            this.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            new frmRegister().Visible = true;
            this.Visible = false;
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch1.Checked == true)
            {
                guna2TextBox2.PasswordChar = '\0';
            }
            else
            {
                guna2TextBox2.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmForgetPassword().Visible = true;
            this.Visible = false;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNoCancel); //Gets users input by showing the message box
            if (result == DialogResult.Yes) //Creates the yes function
            {
                this.Close();
            }
        }
    }
}

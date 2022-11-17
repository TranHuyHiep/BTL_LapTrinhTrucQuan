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
    public partial class frmForgetPassword : Form
    {
        Classes.Connection data = new Classes.Connection();
        public frmForgetPassword()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string email = txtemail.Text;
            if (email.Trim() == "") { MessageBox.Show("Vui lòng nhập email!"); }
            else
            {
                DataTable dt = data.DataReader("select Username, Password,tAccount.Email,tAccount.ID,tAccount.MSV,SDT from tAccount inner join tSinhVien on tSinhVien.MSV = tAccount.MSV where tAccount.Email = '" + email + "'");
                if (dt.Rows.Count > 0)
                {
                    string mk = dt.Rows[0]["Password"].ToString();
                    MessageBox.Show("PassWord : " + mk);
                }
                else
                {
                    MessageBox.Show("Email hoặc Số điện thoại không đúng");
                }
            }
        }

        private void lblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmLogin().Visible = true;
            this.Visible = false;
        }

    }
}

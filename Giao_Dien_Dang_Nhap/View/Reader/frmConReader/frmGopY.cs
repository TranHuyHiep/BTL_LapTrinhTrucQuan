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
    public partial class frmGopY : Form
    {
        public frmGopY()
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
            if(textBox1.Text.Trim()=="" || textBox2.Text.Trim()=="" || textBox5.Text.Trim()=="")
            {
                MessageBox.Show("Yêu cầu nhập những phần không được bỏ trống!");
                return;
            }
            else
            {
                MessageBox.Show("Hệ thống quản lý thư viện TRường Đại Học GTVT rất cảm ơn về sự góp ý của bạn");
            }
        }
    }
}

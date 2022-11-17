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
    public partial class frmReAllDocument : Form
    {
        public frmReAllDocument()
        {
            InitializeComponent();
        }

    

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát?", "Thoát tìm tài liệu", MessageBoxButtons.YesNoCancel); //Gets users input by showing the message box
            if (result == DialogResult.Yes) //Creates the yes function
            {
                this.Close();
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            string st = "select * from tTaiLieu";
            frmReResult frmReResult = new frmReResult(st);
            frmReResult.ShowDialog();
        }
    }
}

using Giao_Dien_Dang_Nhap.View.Reader;
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

namespace Giao_Dien_Dang_Nhap.Main
{

    public partial class frmMainStudent : Form
    {
        public static string studentName;
        public frmMainStudent(string t)
        {
            studentName = t;
            InitializeComponent();
           
        }
        public frmMainStudent()
        {
            InitializeComponent();
        }
        public string masv()
        {
            return studentName;
        }
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReader reader = new frmReader(studentName);
            this.Hide();
            reader.ShowDialog();
            this.Close();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReAllDocument reResearch1 = new frmReAllDocument();
            reResearch1.ShowDialog();

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNoCancel); //Gets users input by showing the message box
            if (result == DialogResult.Yes) //Creates the yes function
            {
                this.Close();
            }
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.utc.edu.vn/");
        }
    }
}

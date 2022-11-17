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
    public partial class frmReResult : Form
    {
        Classes.Connection data = new Classes.Connection();
        public string mtl, tentl, tentg, nxb, solg, sotrang, tentloai, tennxb,msv,mv;
        Main.frmMainStudent mainStudent = new Main.frmMainStudent();
        frmLogin frm= new frmLogin();
        private void frmReResult_Load(object sender, EventArgs e)
        {
            
        }

        public frmReResult(string st)
        {
            InitializeComponent();
            DataTable dt = data.DataReader(st);
            dataGridView1.DataSource = dt;
        }
        public frmReResult()
        {
            //this.msv = st;
            InitializeComponent();
            
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát?", "Thoát mượn tài liệu", MessageBoxButtons.YesNoCancel); //Gets users input by showing the message box
            if (result == DialogResult.Yes) //Creates the yes function
            {
                this.Close();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn mượn tài liệu này không?", "Bạn muốn mượn?", MessageBoxButtons.YesNoCancel); //Gets users input by showing the message box

            if (result == DialogResult.Yes) //Creates the yes function
            {
                msv = mainStudent.masv();
                DataTable ms = data.DataReader("select * from tAccount where Username = '" + this.msv + "'");
                if (ms.Rows.Count > 0)
                {
                    mv = ms.Rows[0]["MSV"].ToString();
                    DataTable dttk = data.DataReader("Select  *  From  tPhieuMuon  Where  MaPhieuMuon  ='PM" + mv + "'");
                    if (dttk.Rows.Count > 0)
                    {
                        data.DataChange("INSERT INTO dbo.tChiTietPhieuMuon(SoLuongTaiLieu,MaPhieuMuon,MaTaiLieu)VALUES( 1, N'PM" + mv + "', N'" + mtl + "')");
                    }
                    else
                    {
                        data.DataChange("INSERT INTO dbo.tPhieuMuon(MaPhieuMuon,NgayMuon,MSV,MaThuThu)VALUES( N'PM" + mv + "',GETDATE(),N'" + mv + "',N'TT01') ");
                        data.DataChange("INSERT INTO dbo.tChiTietPhieuMuon(SoLuongTaiLieu,MaPhieuMuon,MaTaiLieu)VALUES( 1, N'PM" + mv + "', N'" + mtl + "')");
                    }
                }
                MessageBox.Show("Mượn thành công!", "Thông báo");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mtl = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tentl = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tentg = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            nxb = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            solg = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            sotrang = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tentloai = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            tennxb = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            guna2Button2.Enabled = true;
            
        }

       
    }
}

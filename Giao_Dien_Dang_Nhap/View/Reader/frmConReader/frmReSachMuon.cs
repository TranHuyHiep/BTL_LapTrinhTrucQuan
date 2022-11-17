using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Giao_Dien_Dang_Nhap.View.Reader.frmConReader
{
    public partial class frmReSachMuon : Form
    {
        Classes.Connection data = new Classes.Connection();
        public string t,sv;
        string mapm, matl, tentl, tentg, namxb, soltl, nm;
        int sosach, soluong;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DataTable bsv = data.DataReader(this.sv);
            Excel.Application exapp = new Excel.Application();
            Excel.Workbook exbook = exapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exsheet = (Excel.Worksheet)exbook.Worksheets[1];
            Excel.Range exrange = (Excel.Range)exsheet.Cells[1, 1];
            exrange.Font.Size = 15;
            exrange.Font.Bold = true;
            exrange.Font.Color = Color.Red;
            exrange.Value = "Trường Đại học Giao thông vận tải";

            Excel.Range dc = (Excel.Range)exsheet.Cells[2, 1];
            exrange.Font.Size = 15;
            // exrange.Font.Bold = true;
            //exrange.Font.Color = Color.Blue;
            dc.Value = " Số 3 Cầu Giấy Hà Nội";

            exsheet.Range["E1"].Value = "Trung tâm Thông tin - Thư viện ";
            exrange.Range["E1"].Font.Size = 15;
            exrange.Range["E1"].Font.Bold = true;

            exsheet.Range["D4"].Font.Size = 15;
            //exsheet.Range["C4:E4"].Merge(true);
            exsheet.Range["D4"].Font.Bold = true;
            //exsheet.Range["D4"].Font.Color = Color.Red;
            exsheet.Range["D4"].Value = "Danh Sách Mượn";

            //DataTable ten2 = data.DataReader(ten);
            DateTime date = DateTime.Now;
            exsheet.Range["A5:A8"].Font.Size = 12;
            exsheet.Range["A5:A8"].Font.Bold = true;
            exsheet.Range["A6"].Value = "Sinh viên: ";
            exsheet.Range["B6"].Value = bsv.Rows[0]["HoTen"].ToString();
            exsheet.Range["A7"].Value = "Mã sinh viên: ";
            exsheet.Range["B7"].Value = bsv.Rows[0]["MSV"].ToString();
            exsheet.Range["A8"].Value = "Ngày In: ";
            exsheet.Range["B8"].Value = date.Day + "-" + date.Month + "-" + date.Year;

            exsheet.Range["A10:G10"].Font.Size = 10;
            exsheet.Range["A10:G10"].Font.Bold = true;
            exsheet.Range["A10:G10"].ColumnWidth = 15;
            exsheet.Range["A10"].Value = "STT";
            exsheet.Range["B10"].Value = "Mã phiếu mượn";
            exsheet.Range["C10"].Value = "Mã sách";
            exsheet.Range["D10"].ColumnWidth = 25;
            exsheet.Range["D10"].Value = "Tên sách";
            exsheet.Range["E10"].ColumnWidth = 25;
            exsheet.Range["E10"].Value = "Tác giả";
            exsheet.Range["F10"].Value = "Năm xuất bản";
            exsheet.Range["G10"].Value = "Số Lượng";

            int dong = 11;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                exsheet.Range["A" + (dong + i).ToString()].Value = (i + 1).ToString();
                exsheet.Range["B" + (dong + i).ToString()].Value = dataGridView1.Rows[i].Cells[0].Value.ToString();
                exsheet.Range["C" + (dong + i).ToString()].Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                exsheet.Range["D" + (dong + i).ToString()].Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                exsheet.Range["E" + (dong + i).ToString()].Value = dataGridView1.Rows[i].Cells[3].Value.ToString();
                exsheet.Range["F" + (dong + i).ToString()].Value = dataGridView1.Rows[i].Cells[4].Value.ToString();
                exsheet.Range["G" + (dong + i).ToString()].Value = dataGridView1.Rows[i].Cells[5].Value.ToString();
                //exsheet.Range["G" + (dong + i).ToString()].Value = dataGridView1.Rows[i].Cells[7].Value.ToString();
            }

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                //dem = soluong;
                soluong = soluong + int.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            }
            sosach = dataGridView1.Rows.Count;

            exsheet.Range["F" + (dong + sosach).ToString()].Value = "Tổng số lượng ";
            exsheet.Range["G" + (dong + sosach).ToString()].Value = soluong;
            exsheet.Range["F" + (dong + sosach + 1).ToString()].Value = "Tổng số sách ";
            exsheet.Range["G" + (dong + sosach + 1).ToString()].Value = sosach - 1;
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excl 97-2002 Workbook|*.xls|Execl Workbook|*.xlsx|All Files|*.*";
            save.FilterIndex = 2;
            if (save.ShowDialog() == DialogResult.OK)
            {
                exbook.SaveAs(save.FileName.ToLower());
            }
            exapp.Quit();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Có hay không",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    data.DataReader("delete tChiTietPhieuMuon where MaTaiLieu='" + matl + "'");
                    frmReSachMuon_Load(sender, e);
                }
                catch
                {
                    MessageBox.Show("Bạn không được xóa vì nó liên quan đến các hóa đơn.");
                }
        }

        public frmReSachMuon()
        {
            InitializeComponent();

        }
        public frmReSachMuon(string st)
        {
            this.t = st;
            InitializeComponent();

        }
        public frmReSachMuon(string st, string sinhvien)
        {
            InitializeComponent();
            this.t = st;
            this.sv = sinhvien;
            //this.ten = ten;
        }
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void frmReSachMuon_Load(object sender, EventArgs e)
        {
            DataTable dt = data.DataReader(this.t);
            dataGridView1.DataSource=dt;
            guna2Button1.Enabled = false;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mapm = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            matl = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tentl=dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tentg=dataGridView1.CurrentRow.Cells[3].Value.ToString();
            namxb=dataGridView1.CurrentRow.Cells[4].Value.ToString();
            soltl=dataGridView1.CurrentRow.Cells[5].Value.ToString();
            nm=dataGridView1.CurrentRow.Cells[6].Value.ToString();
            guna2Button1.Enabled = true;
        }
    }
}

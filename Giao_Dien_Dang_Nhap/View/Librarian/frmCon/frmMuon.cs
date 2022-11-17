using Giao_Dien_Dang_Nhap.Classes;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giao_Dien_Dang_Nhap.View.Librarian.frmCon
{
    public partial class frmMuon : Form
    {
        CommonFunction commonFunction = new CommonFunction();
        Connection connection = new Connection();
        string truyVanTatCa = "SELECT tphieumuon.maphieumuon as \"Mã phiếu mượn\"\r\n\t  ,MSV as \"Mã sinh viên\"\r\n      ,tentailieu as \"Tên tài liệu\"\r\n\t  ,[SoLuongTaiLieu] as \"Số lượng\"\r\n\t  ,ngaymuon as \"Ngày mượn\"\r\nfrom tchitietphieumuon join ttailieu on tchitietphieumuon.matailieu = ttailieu.matailieu\r\n\tjoin tphieumuon on tphieumuon.maphieumuon = tchitietphieumuon.maphieumuon\r\n";
        public frmMuon()
        {
            InitializeComponent();
            DataTable dtTinhTrang = connection.DataReader("select * from tTaiLieu");
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNoCancel); //Gets users input by showing the message box
            if (result == DialogResult.Yes) //Creates the yes function
            {
                this.Close();
            }
        }
        private void hienChiTiet(bool hien)
        {
            txtMaphieumuon.Enabled = hien;
            txtMataiLieu.Enabled = hien;
            txtMaSV.Enabled = hien;
            dtpNgayMuon.Enabled = hien;
            txtSLMuon.Enabled = hien;
         
            //Ẩn hiện 2 nút Lưu và Hủy
            btnLuu.Enabled = hien;
            btnHuy.Enabled = hien;
        }
        private void XoaTrangChiTiet()
        {
            txtMaphieumuon.Text = "";
            txtMataiLieu.Text = "";
            txtMaSV.Text = "";
            dtpNgayMuon.Text = "";
            txtSLMuon.Text = "";
          
            btnLuu.Enabled = false;
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn lưu thông tin hiện tại không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                XoaTrangChiTiet();
                hienChiTiet(true);
            }
            return;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            string sql = "";
            DateTime dtNgayMuon;
            if (txtMaphieumuon.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập mã phiếu mượn");
                return;
            }
            if (txtMataiLieu.Text.Trim() == "")
            {
                MessageBox.Show("chua co thong tin tai lieu");
                return;
            }
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("chua nhap thong tin sinh vien");
                return;
            }
            if (txtSLMuon.Text.Trim() == "")
            {
                MessageBox.Show("ban chua nhap so luong");
                txtSLMuon.Focus();
                return;
            }
            dtNgayMuon = Convert.ToDateTime(dtpNgayMuon.Value.ToLongDateString());
            DataTable dataTable = connection.DataReader("select * from tblHDBan where MaPhieuMuon='" + txtMaphieumuon.Text + "'");
            // INSERTR TO SQL
            sql = "INSERT  INTO  tPhieuMuon VALUES(";
            sql += "N'" + txtMaphieumuon.Text + "'" +
                    ",N'" + txtMataiLieu.Text + "'" +
                    ",'" + txtMaSV.Text + "'" +
                    ",'" + dtpNgayMuon.Text + "'" +
                    ",'" + txtSLMuon.Text + "')";

        
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            /*Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            Excel.Range exRange = (Excel.Range)exSheet.Cells[1, 1];
            exRange.Font.Size = 15;
            exRange.Font.Bold = true;
            exRange.Font.Color = Color.Blue;
            exRange.Value = "THƯ VIỆN";

            Excel.Range dc = (Excel.Range)exSheet.Cells[2, 1];
            dc.Font.Size = 15;
            dc.Font.Color = Color.Blue;

            dc.Value = "ĐẠI HỌC GIAO THÔNG VẬN TẢI";
            //In chu hoa don ban
            Excel.Range title = (Excel.Range)exSheet.Cells[4, 3];
            exRange.Range["D4"].Font.Size = 20;
            exRange.Range["D4"].Font.Bold = true;
            exRange.Range["D4"].Font.Color = Color.Navy;
            exRange.Range["D4"].Value = "Danh Sách Phiếu Mượn";
          
          
            //In dong tieu de
            exSheet.Range["A6:G6"].Font.Size = 12;
            exSheet.Range["A6:G6"].Font.Bold = true;
            exSheet.Range["A6"].Value = "STT";
            exSheet.Range["B6"].Value = "Ma Phieu Muon";
            exSheet.Range["C6"].Value = "Ma Tai Lieu";
            exSheet.Range["D6"].Value = "Ten Tai Lieu";
            exSheet.Range["E6"].Value = "Ma SV";
            exSheet.Range["F6"].Value = "Ngay Muon";
            exSheet.Range["G6"].Value = "Tinh Trang";
            exSheet.Range["H6"].Value = "So Luong";
            exSheet.Range["I6"].Value = "Ghi Chu";
            //In danh sach cac chi tiet
            int dong = 11;
            for (int i = 0; i < dgvKetQua.Rows.Count - 1; i++)
            {
                exSheet.Range["A" + (dong + i).ToString()].Value = (i + 1).ToString();
                exSheet.Range["B" + (dong + i).ToString()].Value = dgvKetQua.Rows[i].Cells[0].Value.ToString();
                exSheet.Range["C" + (dong + i).ToString()].Value = dgvKetQua.Rows[i].Cells[1].Value.ToString();
                exSheet.Range["D" + (dong + i).ToString()].Value = dgvKetQua.Rows[i].Cells[2].Value.ToString();
                exSheet.Range["E" + (dong + i).ToString()].Value = dgvKetQua.Rows[i].Cells[3].Value.ToString();
                exSheet.Range["F" + (dong + i).ToString()].Value = dgvKetQua.Rows[i].Cells[4].Value.ToString();
                exSheet.Range["G" + (dong + i).ToString()].Value = dgvKetQua.Rows[i].Cells[1].Value.ToString();
                exSheet.Range["H" + (dong + i).ToString()].Value = dgvKetQua.Rows[i].Cells[2].Value.ToString();
                exSheet.Range["I" + (dong + i).ToString()].Value = dgvKetQua.Rows[i].Cells[3].Value.ToString();

            }

            dong = dong + dgvKetQua.Rows.Count;
        
            

            exBook.Activate();
            //Luu file
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel 97-2002 WorkBook|*.xls|Excel Workbook|*.xlsx|All Files|*.*";
            save.FilterIndex = 2;

            if (save.ShowDialog() == DialogResult.OK)
            {
                exBook.SaveAs(save.FileName.ToLower());
            }
            exApp.Quit();*/

        }

        private void btnDuyetDS_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã duyệt thành công!!");
        }

        private void guna2GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void dgvKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaphieumuon.Text = dgvKetQua.CurrentRow.Cells[0].Value.ToString();
            txtMataiLieu.Text = dgvKetQua.CurrentRow.Cells[1].Value.ToString();
            txtMaSV.Text = dgvKetQua.CurrentRow.Cells[2].Value.ToString();
            dtpNgayMuon.CustomFormat = dgvKetQua.CurrentRow.Cells[4].Value.ToString();
            txtSLMuon.Text = dgvKetQua.CurrentRow.Cells[3].Value.ToString();
        }
        void LoadData()
        {
            DataTable dgvKQua = connection.DataReader(truyVanTatCa);
            dgvKetQua.DataSource = dgvKQua;
        }
        private void frmMuon_Load(object sender, EventArgs e)
        {
            // load dữ liệu
            dgvKetQua.DataSource = connection.DataReader(truyVanTatCa);

            // ẩn nút sửa, xóa
            btnGiaHan.Enabled = false;
            // ẩn groupbox chi tiết
            hienChiTiet(false);
        }
    }
}

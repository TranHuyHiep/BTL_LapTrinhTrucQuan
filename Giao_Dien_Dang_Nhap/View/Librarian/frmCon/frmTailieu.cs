using Giao_Dien_Dang_Nhap.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Giao_Dien_Dang_Nhap.View.Librarian
{
    public partial class frmTailieu : Form
    {
        CommonFunction commonFunction = new CommonFunction();
        Connection connection = new Connection();
        string truyVanTatCa = "SELECT TOP (1000) [MaTaiLieu] as \"Mã tài liệu\"\r\n      ,[TenTaiLieu] as \"Tên tài liệu\"\r\n      ,[TenTacGia] as \"Tên tác giả\"\r\n      ,[NamXB] as \"Năm xuất bản\"\r\n      ,[GiaBia] as \"Giá bìa\"\r\n      ,[SoLuong] as \"Số lượng\"\r\n      ,[SoTrang] as \"Số trang\" \r\n      ,[MaTheLoai] as \"Mã thể loại\"\r\n      ,[MaNXB] as \"Năm xuất bản\"\r\n  FROM tTaiLieu";
        public frmTailieu()
        {
            InitializeComponent();
            DataTable dtNXB = connection.DataReader("Select * from tNhaXuatBan");
            DataTable dtTheLoai = connection.DataReader("select * from tTheLoai");
            commonFunction.FillComboBox(cbNXB, dtNXB, "TenNXB", "MaNXB");
            commonFunction.FillComboBox(cbTheLoai, dtTheLoai, "TenTheLoai", "MaTheLoai");
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
            txtMaTaiLieu.Enabled = hien;
            txtTenTaiLieu.Enabled=hien;
            txtTenTacGia.Enabled = hien;
            txtNamXB.Enabled = hien;
            txtGiaBia.Enabled = hien;
            txtSoLuong.Enabled = hien;
            txtSoTrang.Enabled = hien;
            cbTheLoai.Enabled = hien;
            cbNXB.Enabled = hien;
            //Ẩn hiện 2 nút Lưu và Hủy
            btnLuu.Enabled = hien;
            btnHuy.Enabled = hien;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "THÊM MẶT HÀNG";
            XoaTrangChiTiet();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            hienChiTiet(true);
            
        }

        private void XoaTrangChiTiet()
        {
            txtMaTaiLieu.Text = "";
            txtTenTaiLieu.Text = "";
            txtTenTacGia.Text = "";
            txtNamXB.Text = "";
            txtGiaBia.Text = "";
            txtSoLuong.Text = "";
            txtSoTrang.Text = "";
            cbTheLoai.Text = "";
            cbNXB.Text = "";
            btnLuu.Enabled = false;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            // thiết lập các nút như ban đầu
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            // xóa trang chi tiết
            XoaTrangChiTiet();
            // cấm nhập vào
            hienChiTiet(false);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn chắc chắn chứ?", "Lưu", MessageBoxButtons.YesNoCancel); //Gets users input by showing the message box
            if (result == DialogResult.Yes) //Creates the yes function
            {
                string sql = "";
                // sử dụng control ErrorProvider để hiển thị lỗi
                // Kiểm tra để trống không
                if (txtMaTaiLieu.Text.Trim() == "")
                {
                    errorMaTaiLieu.SetError(txtMaTaiLieu, "Bạn không thể để trống mã tài liệu!");
                    return;
                }
                errorMaTaiLieu.Clear();
                // Nếu nút thêm enable thì thực hiện thêm mới
                if (btnThem.Enabled == true)
                {
                    // kiểm tra xem mã tài liệu đã tồn tại chưa để tránh việc insert mới bị lỗi
                    sql = "select * from tTaiLieu where MaTaiLieu = N'" + txtMaTaiLieu.Text + "'";
                    DataTable dataTable = connection.DataReader(sql);
                    if (dataTable.Rows.Count > 0)
                    {
                        errorMaTaiLieu.SetError(txtMaTaiLieu, "Mã sản phẩm trùng trong dữ liệu!");
                        return;
                    }
                    errorMaTaiLieu.Clear();
                    // INSERTR TO SQL
                    sql = "INSERT  INTO  tTaiLieu VALUES(";
                    sql += "N'" + txtMaTaiLieu.Text + "'" +
                        ",N'" + txtTenTaiLieu.Text + "'" +
                        ",N'" + txtTenTacGia.Text + "'" +
                        ",'" + txtNamXB.Text + "'" +
                        ",'" + txtGiaBia.Text + "'" +
                        ",'" + txtSoLuong.Text + "'" +
                        ",'" + txtSoTrang.Text + "'" +
                        ",N'" + cbTheLoai.SelectedValue + "'" +
                        ",N'" + cbNXB.SelectedValue + "')";
                    MessageBox.Show("Thêm thành công!", "Thêm");
                }

                // nếu nút sửa enalble thì thực hiện sửa
                if (btnSua.Enabled == true)
                {
                    MessageBox.Show("Lưu thành công!", "Lưu");
                    sql = "update tTaiLieu set TenTaiLieu=N'" + txtTenTaiLieu.Text
                        + "',TenTacGia=N'" + txtTenTacGia.Text + "',NamXB='" + txtNamXB.Text
                        + "',GiaBia=N'" + txtGiaBia.Text + "',SoLuong='"
                        + txtSoLuong.Text + "',SoTrang='" + txtSoTrang.Text
                        + "',MaTheLoai=N'" + cbTheLoai.SelectedValue + "',MaNXB=N'"
                        + cbNXB.SelectedValue + "' where MaTaiLieu='" + txtMaTaiLieu.Text + "'";
                }

                // nếu nút xóa enable thì thực hiện xóa
                if (btnXoa.Enabled == true)
                {
                    sql = "delete from tTaiLieu where MaTaiLieu = '" + txtMaTaiLieu.Text + "'";
                    MessageBox.Show("Xóa thành công!", "Xóa");
                }

                connection.DataChange(sql);
                // cập nhật lại dataGrid
                dgvKetQua.DataSource = connection.DataReader(truyVanTatCa);
                hienChiTiet(false);
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnHuy.Enabled = false;
            }
            
        }
        void LoadData()
        {
            DataTable dgvKQua = connection.DataReader(truyVanTatCa);
            dgvKetQua.DataSource = dgvKQua;
        }
        private void frmTailieu_Load(object sender, EventArgs e)
        {
            // load dữ liệu
            dgvKetQua.DataSource = connection.DataReader(truyVanTatCa);

            // ẩn nút sửa, xóa
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            // ẩn groupbox chi tiết
            hienChiTiet(false);
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "SỬA TÀI LIỆU";
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            hienChiTiet(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Có hay không",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    connection.DataChange("delete tTaiLieu where MaTaiLieu='" + txtMaTaiLieu.Text + "'");
                    LoadData();
                    XoaTrangChiTiet();
                }
                catch
                {
                    MessageBox.Show("Bạn không được xóa vì nó liên quan đến các dữ liệu chung.");
                }
        }

        private void dgvKetQua_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTaiLieu.Text = dgvKetQua.CurrentRow.Cells[0].Value.ToString();
            txtTenTaiLieu.Text = dgvKetQua.CurrentRow.Cells[1].Value.ToString();
            txtTenTacGia.Text = dgvKetQua.CurrentRow.Cells[2].Value.ToString();
            txtNamXB.Text = dgvKetQua.CurrentRow.Cells[3].Value.ToString();
            cbNXB.SelectedValue = dgvKetQua.CurrentRow.Cells[8].Value.ToString();
            txtSoTrang.Text = dgvKetQua.CurrentRow.Cells[6].Value.ToString();
            txtGiaBia.Text = dgvKetQua.CurrentRow.Cells[4].Value.ToString();
            txtSoLuong.Text = dgvKetQua.CurrentRow.Cells[5].Value.ToString();
            cbTheLoai.SelectedValue = dgvKetQua.CurrentRow.Cells[7].Value.ToString();


            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
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
            exRange.Range["D4"].Value = "Danh Sách Tài Liệu";
          
          
            //In dong tieu de
            exSheet.Range["A6:G6"].Font.Size = 12;
            exSheet.Range["A6:G6"].Font.Bold = true;
            exSheet.Range["A6"].Value = "STT";
            exSheet.Range["B6"].Value = "Ma Tai Lieu";
            exSheet.Range["C6"].Value = "Ten Tai lieu";
            exSheet.Range["D6"].Value = "Ten Tac Gia ";
            exSheet.Range["E6"].Value = "Nam Xuat Ban";
            exSheet.Range["F6"].Value = "Gia Bia";
            exSheet.Range["G6"].Value = "So Luong";
            exSheet.Range["H6"].Value = "So Trang";
            exSheet.Range["I6"].Value = "The Loai";
            exSheet.Range["J6"].Value = "Nha Xuat Ban";
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
                exSheet.Range["G" + (dong + i).ToString()].Value = dgvKetQua.Rows[i].Cells[5].Value.ToString();
                exSheet.Range["H" + (dong + i).ToString()].Value = dgvKetQua.Rows[i].Cells[6].Value.ToString();
                exSheet.Range["I" + (dong + i).ToString()].Value = dgvKetQua.Rows[i].Cells[7].Value.ToString();
                exSheet.Range["J" + (dong + i).ToString()].Value = dgvKetQua.Rows[i].Cells[8].Value.ToString();
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
            exApp.Quit();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }
    }
}

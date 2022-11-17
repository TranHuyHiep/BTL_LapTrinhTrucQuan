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
//using Excel = Microsoft.Office.Interop.Excel;

namespace Giao_Dien_Dang_Nhap.View.Librarian
{
    public partial class frmDocGia : Form
    {
        CommonFunction commonFunction = new CommonFunction();
        Connection connection = new Connection();
        string truyVanTatCa = "SELECT [MSV] as \"Mã sinh viên\"\r\n      ,[HoTen] as \"Họ và tên\"\r\n      ,[SDT] as \"Số điện thoại\"\r\n      ,[Email] as \"Eamil\"\r\nfrom tSinhVien";
        public frmDocGia()
        {
            InitializeComponent();
            DataTable dtGioiTinh = connection.DataReader("select * from tSinhVien");
        }
        private void hienChiTiet(bool hien)
        {
            txtMaSV.Enabled = hien;
            txtName.Enabled = hien;
            txtSDT.Enabled = hien;
            txtEmail.Enabled = hien;
           
            //Ẩn hiện 2 nút Lưu và Hủy
            btnLuu.Enabled = hien;
            btnHuy.Enabled = hien;
        }
        private void XoaTrangChiTiet()
        {
            txtMaSV.Text = "";
            txtName.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            btnLuu.Enabled = false;
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNoCancel); //Gets users input by showing the message box
            if (result == DialogResult.Yes) //Creates the yes function
            {
                this.Close();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "THÊM THÔNG TIN SINH VIÊN";
            XoaTrangChiTiet();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            hienChiTiet(true);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn chắc chắn chứ?", "Lưu", MessageBoxButtons.YesNoCancel); //Gets users input by showing the message box
            if (result == DialogResult.Yes) //Creates the yes function
            {
                string sql = "";
                // sử dụng control ErrorProvider để hiển thị lỗi
                // Kiểm tra để trống không
            
                if (txtMaSV.Text.Trim() == "")
                {
                    errorProvider1.SetError(txtMaSV, "Bạn không thể để trống mã sinh viên!");
                    return;
                }
                errorProvider1.Clear();
                // Nếu nút thêm enable thì thực hiện thêm mới
                if (btnThem.Enabled == true)
                {
                    // kiểm tra xem mã tài liệu đã tồn tại chưa để tránh việc insert mới bị lỗi
                    sql = "select * from tSinhVien where MSV= N'" + txtMaSV.Text + "'";
                    DataTable dataTable = connection.DataReader(sql);
                    if (dataTable.Rows.Count > 0)
                    {
                        errorProvider1.SetError(txtMaSV, "Mã sinh viên trùng trong dữ liệu!");
                        return;
                    }
                    errorProvider1.Clear();
                    // INSERTR TO SQL
                    sql = "INSERT  INTO  tSinhVien(MSV, HoTen, SDT, Email) VALUES(";
                    sql += "N'" + txtMaSV.Text + "'" +
                        ",N'" + txtName.Text + "'" +
                        ",'" + txtSDT.Text + "'" +
                        ",'" + txtEmail.Text + "')";
                }

                // nếu nút sửa enalble thì thực hiện sửa
                if (btnSua.Enabled == true)
                {
                    MessageBox.Show("Lưu thành công!", "Lưu");
                    sql = "update tSinhVien set " +
                        "HoTen=N'" + txtName.Text + "'" +
                        ",SDT='" + txtSDT.Text + "'" +
                        ",Email='" + txtEmail.Text + "' " +
                        "where MSV='" + txtMaSV.Text + "'";
                }

                // nếu nút xóa enable thì thực hiện xóa
                if (btnXoa.Enabled == true)
                {
                    sql = "delete from tSinhVien where MSV = '" + txtMaSV.Text + "'";
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
        

        private void frmDocGia_Load(object sender, EventArgs e)
        {
            // load dữ liệu
            dgvKetQua.DataSource = connection.DataReader(truyVanTatCa);

            // ẩn nút sửa, xóa
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            // ẩn groupbox chi tiết
            hienChiTiet(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Có hay không",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    connection.DataChange("delete tSinhVien where MSV='" + txtMaSV.Text + "'");
                    LoadData();
                    XoaTrangChiTiet();
                }
                catch
                {
                    MessageBox.Show("Bạn không được xóa vì nó liên quan đến các dữ liệu chung.");
                }
        }

        private void dgvKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSV.Text = dgvKetQua.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvKetQua.CurrentRow.Cells[1].Value.ToString();
            txtSDT.Text = dgvKetQua.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dgvKetQua.CurrentRow.Cells[3].Value.ToString();

            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
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
            exRange.Range["D4"].Value = "Danh Sách Sinh Viên";
          
          
            //In dong tieu de
            exSheet.Range["A6:G6"].Font.Size = 12;
            exSheet.Range["A6:G6"].Font.Bold = true;
            exSheet.Range["A6"].Value = "STT";
            exSheet.Range["B6"].Value = "Ma Sinh Vien";
            exSheet.Range["C6"].Value = "Ho Ten";
            exSheet.Range["D6"].Value = "SDT";
            exSheet.Range["E6"].Value = "Gioi Tinh";
            exSheet.Range["F6"].Value = "Email";
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "SỬA THÔNG TIN SINH VIÊN";
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            hienChiTiet(true);
        }

        private void btnHuy_Click(object sender, EventArgs e)
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
    }
}

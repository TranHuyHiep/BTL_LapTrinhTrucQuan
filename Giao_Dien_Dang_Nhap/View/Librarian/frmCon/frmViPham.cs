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

namespace Giao_Dien_Dang_Nhap.View.Librarian
{
    public partial class frmViPham : Form
    {
        CommonFunction commonFunction = new CommonFunction();
        Connection connection = new Connection();
        public frmViPham()
        {
            InitializeComponent();
            DataTable dtLoiVP = connection.DataReader("Select * from tViPham");
            DataTable dtMaViPham = connection.DataReader("select * from tViPham");
            commonFunction.FillComboBox(cboLoiViPham, dtLoiVP, "MaViPham", "MaViPham");
            commonFunction.FillComboBox(cboMaViPham, dtMaViPham, "MaViPham", "MaViPham");
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
            txtMaSV.Enabled = hien;
            txtTenSV.Enabled = hien;
            cboLoiViPham.Enabled = hien;
            txtMucPhat.Enabled = hien;
            dtpNgayXuli.Enabled = hien;
            txtGhiChu.Enabled = hien;
           
            //Ẩn hiện 2 nút Lưu và Hủy
            btnLuu.Enabled = hien;
            btnHuy.Enabled = hien;
            btnTim.Enabled = hien;
        }
        private void XoaTrangChiTiet()
        {
            txtMaSV.Text = "";
            txtTenSV.Text = "";
            cboLoiViPham.Text = "";
            txtMucPhat.Text = "";
            dtpNgayXuli.Text = "";
            txtGhiChu.Text = "";
         
            btnLuu.Enabled = false;
            btnTim.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";
            DateTime dtNgayXuli;
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("chua nhap ma phieu muon");
                return;
            }
            if (txtTenSV.Text.Trim() == "")
            {
                MessageBox.Show("chua co thong tin tai lieu");
                return;
            }
            if (txtMucPhat.Text.Trim() == "")
            {
                MessageBox.Show("chua nhap thong tin sinh vien");
                return;
            }
            if (cboLoiViPham.Text.Trim() == "")
            {
                MessageBox.Show("ban chua nhap loi vi pham");
                cboLoiViPham.Focus();
                return;
            }
            dtNgayXuli = Convert.ToDateTime(dtpNgayXuli.Value.ToLongDateString());
            DataTable dataTable = connection.DataReader("select * from tViPham where MaViPham='" + txtMaViPham.Text + "'");
            // INSERTR TO SQL
            sql = "INSERT  INTO  tPhieuMuon VALUES(";
            sql += "N'" + txtMaViPham.Text + "'" + 
                    "N'" + txtMaSV.Text + "'" +
                    ",N'" + txtTenSV.Text + "'" +
                    ",N'" + cboLoiViPham.SelectedValue + "'" +
                    ",'" + txtMucPhat.Text + "'" +
                    ",'" + dtpNgayXuli.Text + "'" +
                    ",'" + txtGhiChu.Text+ "'" + "')";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaTrangChiTiet();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

        }
        void LoadData()
        {
            DataTable dgvKQua = connection.DataReader("Select * from tTaiLieu");
            dgvKetQua.DataSource = dgvKQua;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dtViPham = connection.DataReader("select * from tViPham where MaViPham='" + cboMaViPham.Text + "'");

            txtMaViPham.Text = cboMaViPham.Text;
            txtMaSV.Text = dtViPham.Rows[0]["MaViPham"].ToString();
            txtTenSV.Text = dtViPham.Rows[0]["MaViPham"].ToString();
            cboLoiViPham.SelectedValue = dtViPham.Rows[0]["MaViPham"].ToString();
            txtMucPhat.Text = dtViPham.Rows[0]["MaViPham"].ToString();
            dtpNgayXuli.Text = dtViPham.Rows[0]["MaViPham"].ToString();
            txtGhiChu.Text = dtViPham.Rows[0]["MaViPham"].ToString();
  
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show("Bạn có thực sự muốn xóa không?", "Có hay không",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    try
                    {
                        connection.DataChange("delete tViPham where MaViPham='" + txtMaViPham.Text + "'");
                        LoadData();
                        XoaTrangChiTiet();
                    }
                    catch
                    {
                        MessageBox.Show("Bạn không được xóa vì nó liên quan đến các dữ liệu chung.");
                    }
            }
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
  
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            connection.DataChange("update tViPham set MaSV=N'" + txtMaSV.Text
                + "',TenSV=N'" + txtTenSV.Text + ",LoiViPham=" + cboLoiViPham.SelectedValue
                + "',MucPhat=N'" + txtMucPhat.Text + ",NgayXuLY='"
                + dtpNgayXuli.Text + ",GhiChu='" + txtGhiChu.Text
                + "'");
            LoadData();
            XoaTrangChiTiet();
        }

        private void dgvKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaViPham.Text = dgvKetQua.CurrentRow.Cells[0].Value.ToString();
            txtMaSV.Text = dgvKetQua.CurrentRow.Cells[1].Value.ToString();
            txtTenSV.Text = dgvKetQua.CurrentRow.Cells[2].Value.ToString();
            cboLoiViPham.SelectedValue = dgvKetQua.CurrentRow.Cells[3].Value.ToString();
            txtMucPhat.Text = dgvKetQua.CurrentRow.Cells[4].Value.ToString();
            dtpNgayXuli.Text = dgvKetQua.CurrentRow.Cells[5].Value.ToString();
            txtGhiChu.Text = dgvKetQua.CurrentRow.Cells[6].Value.ToString();
         


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
            exRange.Range["D4"].Value = "Danh Sách Vi Phạm";
          
          
            //In dong tieu de
            exSheet.Range["A6:G6"].Font.Size = 12;
            exSheet.Range["A6:G6"].Font.Bold = true;
            exSheet.Range["A6"].Value = "STT";
            exSheet.Range["B6"].Value = "Ma Vi Pham";
            exSheet.Range["C6"].Value = "Ma Sinh Vien";
            exSheet.Range["D6"].Value = "Ten Sinh Vien";
            exSheet.Range["E6"].Value = "Loi Vi Pham";
            exSheet.Range["F6"].Value = "Muc Phat";
            exSheet.Range["G6"].Value = "Ngay Xu Ly";
            exSheet.Range["H6"].Value = "Ghi Chu";
         
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
    }
}

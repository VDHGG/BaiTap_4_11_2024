using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTap4_11_2024
{
    public partial class Form1 : Form
    {
        public class KhachHang
        {
            public string MaKhachHang { get; set; }
            public string TenKhachHang { get; set; }
            public string sdt { get; set; }
            public string DiaChi { get; set; }  
        }

        public class DichVu
        {
            public string MaDichVu { get; set; }
            public string TenDichVu { get; set; }
            public string GiaTien { get; set; }
        }

        private List<KhachHang> DanhSachKhachHang = new List<KhachHang>();
        private List<DichVu> DanhSachDichVu = new List<DichVu>();

        public Form1()
        {
            InitializeComponent();
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.MultiSelect = false;      
            dgvDichVu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void CapNhatDataGridView()
        {
            dgvKhachHang.DataSource = null;
            dgvKhachHang.DataSource = DanhSachKhachHang;
            dgvDichVu.DataSource = null;
            dgvDichVu.DataSource = DanhSachDichVu;
        }

        private void ClearTextBoxes()
        {
            MaKhText.Clear();
            TenKhText.Clear();
            SDTText.Clear();
            DiaChiKhText.Clear();     
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DanhSachKhachHang = new List<KhachHang>
            {
                new KhachHang { MaKhachHang = "KH01", TenKhachHang = "Nguyen Van A", sdt = "123456789", DiaChi = "123 Đường ABC, Hà Nội" },
                new KhachHang { MaKhachHang = "KH02", TenKhachHang = "Le Thi B", sdt = "987654321", DiaChi = "456 Đường DEF, Hà Nội" },
                new KhachHang { MaKhachHang = "KH03", TenKhachHang = "Tran Van C", sdt = "112233445", DiaChi = "789 Đường GHI, TP.HCM" },
                new KhachHang { MaKhachHang = "KH04", TenKhachHang = "Pham Thi D", sdt = "223344556", DiaChi = "101 Đường JKL, Đà Nẵng" },
                new KhachHang { MaKhachHang = "KH05", TenKhachHang = "Hoang Van E", sdt = "334455667", DiaChi = "202 Đường MNO, Cần Thơ" },
                new KhachHang { MaKhachHang = "KH06", TenKhachHang = "Vo Thi F", sdt = "445566778", DiaChi = "303 Đường PQR, Nha Trang" },
                new KhachHang { MaKhachHang = "KH07", TenKhachHang = "Phan Van G", sdt = "556677889", DiaChi = "404 Đường STU, Hải Phòng" },
                new KhachHang { MaKhachHang = "KH08", TenKhachHang = "Do Thi H", sdt = "667788990", DiaChi = "505 Đường VWX, Huế" }
            };

            DanhSachDichVu = new List<DichVu>
            {
              new DichVu { MaDichVu = "DV01", TenDichVu = "Dịch vụ vệ sinh máy lạnh", GiaTien = "200,000$" },
              new DichVu { MaDichVu = "DV02", TenDichVu = "Sửa chữa máy tính", GiaTien = "500,000$" },
              new DichVu { MaDichVu = "DV03", TenDichVu = "Thay thế màn hình điện thoại", GiaTien = "700,000$" },
              new DichVu { MaDichVu = "DV04", TenDichVu = "Nâng cấp phần mềm", GiaTien = "150,000$" },
              new DichVu { MaDichVu = "DV05", TenDichVu = "Dịch vụ vệ sinh nhà cửa", GiaTien = "300,000$" }
             };

            CapNhatDataGridView();
        }




        private void ThemButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(MaKhText.Text) && !string.IsNullOrEmpty(TenKhText.Text) && !string.IsNullOrEmpty(SDTText.Text) && !string.IsNullOrEmpty(DiaChiKhText.Text))
            {
                KhachHang kh = new KhachHang()
                {
                    MaKhachHang = MaKhText.Text,
                    TenKhachHang = TenKhText.Text,
                    sdt = SDTText.Text,
                    DiaChi = DiaChiKhText.Text,
                };

                DanhSachKhachHang.Add(kh);
                CapNhatDataGridView();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng.");
            }


        }

        private void SuaButton_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                int index = dgvKhachHang.SelectedRows[0].Index;
                KhachHang kh = DanhSachKhachHang[index];

                kh.MaKhachHang = MaKhText.Text;
                kh.TenKhachHang = TenKhText.Text;
                kh.sdt = SDTText.Text;
                kh.DiaChi = DiaChiKhText.Text;

                CapNhatDataGridView();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa.");
            }
        }

        private void XoaButton_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                int index = dgvKhachHang.SelectedRows[0].Index;
                DanhSachKhachHang.RemoveAt(index);

                CapNhatDataGridView();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng muốn xóa.");
            }

        }

        private void ThanhToanButton_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0 && dgvDichVu.SelectedRows.Count > 0)
            {
               
                int khachHangIndex = dgvKhachHang.SelectedRows[0].Index;
                KhachHang khachHang = DanhSachKhachHang[khachHangIndex];

                
                List<DichVu> dichVuDaChon = new List<DichVu>();
                decimal tongTien = 0;

                foreach (DataGridViewRow row in dgvDichVu.SelectedRows)
                {
                    int dichVuIndex = row.Index;
                    DichVu dichVu = DanhSachDichVu[dichVuIndex];
                    dichVuDaChon.Add(dichVu);

                   
                    if (decimal.TryParse(dichVu.GiaTien.Replace("$", "").Replace(",", ""), out decimal giaTien))
                    {
                        tongTien += giaTien;
                    }
                }

                // Hiển thị hóa đơn
                StringBuilder hoaDon = new StringBuilder();
                hoaDon.AppendLine("HÓA ĐƠN");
                hoaDon.AppendLine($"Mã khách hàng: {khachHang.MaKhachHang}");
                hoaDon.AppendLine($"Tên khách hàng: {khachHang.TenKhachHang}");
                hoaDon.AppendLine("Dịch vụ đã chọn:");

                foreach (var dichVu in dichVuDaChon)
                {
                    hoaDon.AppendLine($"- {dichVu.TenDichVu} - {dichVu.GiaTien}");
                }

                hoaDon.AppendLine($"Tổng tiền: {tongTien:C}");

                MessageBox.Show(hoaDon.ToString(), "Hóa Đơn");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng và ít nhất một dịch vụ.");
            }
        }
    }
}

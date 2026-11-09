using System;

namespace Lab12_MasterDetail_Transaction.DTO
{
    public class SinhVienDTO
    {
        public string MaSV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; } = true; // True: Nam, False: Nữ
        public string MaKhoa { get; set; } = string.Empty;
        public string TenKhoa { get; set; } = string.Empty;
        public decimal DiemTB { get; set; } = 0.0m;
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public byte[] RowVersion { get; set; } // Phục vụ kiểm soát xung đột Concurrency (Bài 9)

        public string GioiTinhText => GioiTinh ? "Nam" : "Nữ";
        public string TrangThaiText => IsActive ? "Đang học" : "Đã xóa mềm";

        public SinhVienDTO() { }

        public SinhVienDTO(string maSV, string hoTen, DateTime ngaySinh, bool gioiTinh, string maKhoa, decimal diemTB, string email = null)
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            MaKhoa = maKhoa;
            DiemTB = diemTB;
            Email = email;
            IsActive = true;
        }
    }
}

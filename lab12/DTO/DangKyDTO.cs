using System;

namespace Lab12_MasterDetail_Transaction.DTO
{
    public class DangKyDTO
    {
        public string MaSV { get; set; } = string.Empty;
        public string MaHP { get; set; } = string.Empty;
        public string TenHP { get; set; } = string.Empty;
        public int SoTinChi { get; set; } = 3;
        public int HocKy { get; set; } = 1;
        public decimal? Diem { get; set; } // Nullable decimal: Điểm có thể chưa nhập
        public DateTime NgayDangKy { get; set; } = DateTime.Now;

        public DangKyDTO() { }

        public DangKyDTO(string maSV, string maHP, int hocKy, decimal? diem = null)
        {
            MaSV = maSV;
            MaHP = maHP;
            HocKy = hocKy;
            Diem = diem;
            NgayDangKy = DateTime.Now;
        }
    }
}

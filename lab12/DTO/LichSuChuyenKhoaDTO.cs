using System;

namespace Lab12_MasterDetail_Transaction.DTO
{
    public class LichSuChuyenKhoaDTO
    {
        public int Id { get; set; }
        public string MaSV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string MaKhoaCu { get; set; } = string.Empty;
        public string TenKhoaCu { get; set; } = string.Empty;
        public string MaKhoaMoi { get; set; } = string.Empty;
        public string TenKhoaMoi { get; set; } = string.Empty;
        public DateTime NgayChuyen { get; set; } = DateTime.Now;
        public string LyDo { get; set; } = string.Empty;
        public string NguoiThucHien { get; set; } = "Phan Văn Thắng (24002545)";
    }
}

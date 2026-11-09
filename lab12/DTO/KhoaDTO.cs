namespace Lab12_MasterDetail_Transaction.DTO
{
    public class KhoaDTO
    {
        public string MaKhoa { get; set; } = string.Empty;
        public string TenKhoa { get; set; } = string.Empty;
        public int SoLuongSinhVien { get; set; } = 0;

        public KhoaDTO() { }

        public KhoaDTO(string maKhoa, string tenKhoa)
        {
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
        }

        public override string ToString()
        {
            return $"{TenKhoa} ({MaKhoa})";
        }
    }
}

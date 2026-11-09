namespace Lab12_MasterDetail_Transaction.DTO
{
    public class HocPhanDTO
    {
        public string MaHP { get; set; } = string.Empty;
        public string TenHP { get; set; } = string.Empty;
        public int SoTinChi { get; set; } = 3;

        public HocPhanDTO() { }

        public HocPhanDTO(string maHP, string tenHP, int soTinChi)
        {
            MaHP = maHP;
            TenHP = tenHP;
            SoTinChi = soTinChi;
        }

        public override string ToString()
        {
            return $"{MaHP} - {TenHP} ({SoTinChi} TC)";
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DAL;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.BUS
{
    public class HocPhanBUS
    {
        private readonly HocPhanDAL _hocPhanDAL = new HocPhanDAL();

        public DataTable GetAllHocPhan()
        {
            try
            {
                return _hocPhanDAL.GetAll();
            }
            catch (SqlException ex)
            {
                throw new BusinessException(ex.Number, "Lỗi nạp danh sách học phần: " + ex.Message, ex);
            }
        }

        public HocPhanDTO GetHocPhanById(string maHP)
        {
            if (string.IsNullOrWhiteSpace(maHP))
                throw new ValidationException("Mã học phần không được để trống.");

            try
            {
                return _hocPhanDAL.GetById(maHP);
            }
            catch (SqlException ex)
            {
                throw new BusinessException(ex.Number, "Lỗi truy vấn học phần: " + ex.Message, ex);
            }
        }

        public void AddHocPhan(HocPhanDTO dto)
        {
            if (dto == null) throw new ValidationException("Dữ liệu học phần rỗng.");
            if (string.IsNullOrWhiteSpace(dto.MaHP)) throw new ValidationException("Mã học phần không được để trống.");
            if (string.IsNullOrWhiteSpace(dto.TenHP)) throw new ValidationException("Tên học phần không được để trống.");
            if (dto.SoTinChi <= 0 || dto.SoTinChi > 10) throw new ValidationException("Số tín chỉ phải từ 1 đến 10.");

            try
            {
                _hocPhanDAL.Insert(dto);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    throw new BusinessException(50006, $"Mã học phần '{dto.MaHP}' đã tồn tại.", ex);
                throw new BusinessException(ex.Number, ex.Message, ex);
            }
        }
    }
}

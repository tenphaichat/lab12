using System;
using System.Data;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DAL;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.BUS
{
    public class KhoaBUS
    {
        private readonly KhoaDAL _khoaDAL = new KhoaDAL();

        public DataTable GetAllKhoa(bool includeAllOption = false)
        {
            try
            {
                return _khoaDAL.GetAll(includeAllOption);
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        public KhoaDTO GetKhoaById(string maKhoa)
        {
            if (string.IsNullOrWhiteSpace(maKhoa))
                throw new ValidationException("Mã khoa không được để trống.");

            try
            {
                return _khoaDAL.GetById(maKhoa);
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        public void AddKhoa(KhoaDTO dto)
        {
            ValidateKhoa(dto);
            try
            {
                _khoaDAL.Insert(dto);
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        public void UpdateKhoa(KhoaDTO dto)
        {
            ValidateKhoa(dto);
            try
            {
                _khoaDAL.Update(dto);
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        public void DeleteKhoa(string maKhoa)
        {
            if (string.IsNullOrWhiteSpace(maKhoa))
                throw new ValidationException("Mã khoa không được để trống.");

            try
            {
                _khoaDAL.Delete(maKhoa);
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        private void ValidateKhoa(KhoaDTO dto)
        {
            if (dto == null)
                throw new ValidationException("Dữ liệu khoa không hợp lệ.");

            if (string.IsNullOrWhiteSpace(dto.MaKhoa))
                throw new ValidationException("Mã khoa không được để trống.");

            if (dto.MaKhoa.Trim().Length > 10)
                throw new ValidationException("Mã khoa tối đa 10 ký tự.");

            if (string.IsNullOrWhiteSpace(dto.TenKhoa))
                throw new ValidationException("Tên khoa không được để trống.");
        }

        private Exception HandleSqlException(SqlException ex)
        {
            switch (ex.Number)
            {
                case 2627:
                case 2601:
                    return new BusinessException(50005, "Mã khoa đã tồn tại trong CSDL.", ex);
                case 547:
                    return new BusinessException(50003, "Không thể xóa khoa đang có dữ liệu ràng buộc liên quan (Sinh viên/Lịch sử).", ex);
                default:
                    return new BusinessException(ex.Number, $"Lỗi CSDL ({ex.Number}): {ex.Message}", ex);
            }
        }
    }
}

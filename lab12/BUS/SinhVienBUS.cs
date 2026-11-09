using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Lab12_MasterDetail_Transaction.DAL;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.BUS
{
    public class SinhVienBUS
    {
        private readonly SinhVienDAL _sinhVienDAL = new SinhVienDAL();

        public DataTable GetAllSinhVien(bool includeInactive = false)
        {
            try
            {
                return _sinhVienDAL.GetAll(includeInactive);
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        // Bài 1: Lấy danh sách sinh viên theo mã khoa phục vụ Master-Detail
        public DataTable GetByDepartment(string maKhoa)
        {
            try
            {
                return _sinhVienDAL.GetByDepartment(maKhoa);
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        public SinhVienDTO GetSinhVienById(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new ValidationException("Mã sinh viên không được để trống.");

            try
            {
                return _sinhVienDAL.GetById(maSV);
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        public void AddSinhVien(SinhVienDTO dto)
        {
            ValidateSinhVien(dto);

            try
            {
                _sinhVienDAL.Insert(dto);
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        public void UpdateSinhVien(SinhVienDTO dto)
        {
            ValidateSinhVien(dto);

            try
            {
                _sinhVienDAL.Update(dto);
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        // Bài 9: Cập nhật có kiểm tra xung đột đồng thời (Optimistic Concurrency)
        public void UpdateOptimistic(SinhVienDTO dto, byte[] originalRowVersion)
        {
            ValidateSinhVien(dto);

            if (originalRowVersion == null || originalRowVersion.Length == 0)
            {
                throw new ValidationException("Không tìm thấy thông tin phiên bản bản ghi (RowVersion).");
            }

            try
            {
                int affected = _sinhVienDAL.UpdateOptimistic(dto, originalRowVersion);
                if (affected == 0)
                {
                    throw new OptimisticConcurrencyException(dto.MaSV, 
                        $"XUNG ĐỘT ĐỒNG THỜI: Bản ghi sinh viên '{dto.MaSV}' đã bị người dùng khác sửa đổi hoặc cập nhật trước đó! Vui lòng làm mới dữ liệu.");
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 50010)
                {
                    throw new OptimisticConcurrencyException(dto.MaSV, ex.Message);
                }
                throw HandleSqlException(ex);
            }
        }

        public void DeleteSinhVien(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new ValidationException("Mã sinh viên không được để trống.");

            try
            {
                _sinhVienDAL.Delete(maSV);
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        public void SoftDeleteSinhVien(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new ValidationException("Mã sinh viên không được để trống.");

            try
            {
                _sinhVienDAL.SoftDelete(maSV);
            }
            catch (SqlException ex)
            {
                throw HandleSqlException(ex);
            }
        }

        public void ValidateSinhVien(SinhVienDTO dto)
        {
            if (dto == null)
                throw new ValidationException("Thông tin sinh viên không được để trống.");

            if (string.IsNullOrWhiteSpace(dto.MaSV))
                throw new ValidationException("Mã sinh viên không được để trống.");

            if (dto.MaSV.Trim().Length > 15)
                throw new ValidationException("Mã sinh viên tối đa 15 ký tự.");

            if (string.IsNullOrWhiteSpace(dto.HoTen))
                throw new ValidationException("Họ tên sinh viên không được để trống.");

            DateTime minAllowedDate = DateTime.Today.AddYears(-15);
            if (dto.NgaySinh.Date > minAllowedDate)
            {
                throw new ValidationException($"Sinh viên phải đủ 15 tuổi trở lên (Ngày sinh <= {minAllowedDate:dd/MM/yyyy}).");
            }

            if (string.IsNullOrWhiteSpace(dto.MaKhoa) || dto.MaKhoa == "ALL")
            {
                throw new ValidationException("Vui lòng chọn khoa đào tạo hợp lệ.");
            }

            if (dto.DiemTB < 0.0m || dto.DiemTB > 10.0m)
            {
                throw new ValidationException("Điểm trung bình tích lũy phải nằm trong đoạn từ 0.0 đến 10.0.");
            }

            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(dto.Email.Trim(), pattern, RegexOptions.IgnoreCase))
                {
                    throw new ValidationException("Địa chỉ Email không đúng định dạng chuẩn (ví dụ: name@domain.com).");
                }
            }
        }

        private Exception HandleSqlException(SqlException ex)
        {
            switch (ex.Number)
            {
                case 50001:
                case 2627:
                case 2601:
                    return new BusinessException(50001, "Mã sinh viên đã tồn tại trong hệ thống (Lỗi khóa chính).", ex);
                case 50002:
                    return new BusinessException(50002, "Không tìm thấy sinh viên tương ứng trong hệ thống.", ex);
                case 50004:
                    return new BusinessException(50004, "Địa chỉ Email đã được sử dụng bởi sinh viên khác.", ex);
                case 547:
                    return new BusinessException(50003, "Ràng buộc dữ liệu khóa ngoại: Mã khoa không tồn tại hoặc có bảng con tham chiếu.", ex);
                default:
                    return new BusinessException(ex.Number, $"Lỗi CSDL ({ex.Number}): {ex.Message}", ex);
            }
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DAL;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.BUS
{
    public class DangKyBUS
    {
        private readonly DangKyDAL _dangKyDAL = new DangKyDAL();

        // Bài 2: Lấy danh sách đăng ký học phần của sinh viên
        public DataTable GetDangKyByStudent(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                return new DataTable();

            try
            {
                return _dangKyDAL.GetByStudent(maSV);
            }
            catch (SqlException ex)
            {
                throw new BusinessException(ex.Number, "Lỗi nạp danh sách đăng ký: " + ex.Message, ex);
            }
        }

        public void AddDangKy(DangKyDTO dto)
        {
            if (dto == null) throw new ValidationException("Dữ liệu đăng ký không hợp lệ.");
            if (string.IsNullOrWhiteSpace(dto.MaSV)) throw new ValidationException("Mã sinh viên không được để trống.");
            if (string.IsNullOrWhiteSpace(dto.MaHP)) throw new ValidationException("Vui lòng chọn học phần cần đăng ký.");
            if (dto.HocKy <= 0) throw new ValidationException("Học kỳ phải lớn hơn 0.");

            if (dto.Diem.HasValue && (dto.Diem.Value < 0 || dto.Diem.Value > 10))
            {
                throw new ValidationException("Điểm học phần phải nằm trong đoạn từ 0.0 đến 10.0.");
            }

            try
            {
                _dangKyDAL.Insert(dto);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                    throw new BusinessException(50007, $"Sinh viên '{dto.MaSV}' đã đăng ký học phần '{dto.MaHP}' này rồi.", ex);
                if (ex.Number == 547)
                    throw new BusinessException(50008, "Mã học phần hoặc Mã sinh viên không tồn tại trong hệ thống.", ex);
                throw new BusinessException(ex.Number, ex.Message, ex);
            }
        }

        public void UpdateGrade(string maSV, string maHP, int hocKy, decimal? diem)
        {
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(maHP))
                throw new ValidationException("Mã sinh viên và Mã học phần không được để trống.");

            if (diem.HasValue && (diem.Value < 0 || diem.Value > 10))
            {
                throw new ValidationException("Điểm học phần phải nằm trong đoạn từ 0.0 đến 10.0.");
            }

            try
            {
                _dangKyDAL.UpdateGrade(maSV, maHP, hocKy, diem);
            }
            catch (SqlException ex)
            {
                throw new BusinessException(ex.Number, "Lỗi cập nhật điểm: " + ex.Message, ex);
            }
        }

        public void DeleteDangKy(string maSV, string maHP)
        {
            if (string.IsNullOrWhiteSpace(maSV) || string.IsNullOrWhiteSpace(maHP))
                throw new ValidationException("Mã sinh viên và Mã học phần không được để trống.");

            try
            {
                _dangKyDAL.Delete(maSV, maHP);
            }
            catch (SqlException ex)
            {
                throw new BusinessException(ex.Number, "Lỗi xóa đăng ký học phần: " + ex.Message, ex);
            }
        }
    }
}

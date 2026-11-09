using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DAL;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.BUS
{
    public class TransactionBUS
    {
        private readonly SinhVienDAL _sinhVienDAL = new SinhVienDAL();
        private readonly DangKyDAL _dangKyDAL = new DangKyDAL();
        private readonly KhoaDAL _khoaDAL = new KhoaDAL();
        private readonly LichSuChuyenKhoaDAL _lichSuDAL = new LichSuChuyenKhoaDAL();
        private readonly SinhVienBUS _sinhVienBUS = new SinhVienBUS();

        // ===================================================================
        // BÀI 3 & BÀI 5: Giao dịch thêm mới sinh viên và các học phần đăng ký
        // ===================================================================
        public void AddStudentWithEnrollments(SinhVienDTO svDto, List<DangKyDTO> dsDangKy)
        {
            _sinhVienBUS.ValidateSinhVien(svDto);

            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // Bước 1: Thêm thông tin sinh viên
                        _sinhVienDAL.Insert(svDto, conn, tx);

                        // Bước 2: Thêm từng học phần đăng ký ban đầu
                        if (dsDangKy != null && dsDangKy.Count > 0)
                        {
                            foreach (DangKyDTO dk in dsDangKy)
                            {
                                dk.MaSV = svDto.MaSV; // Đồng bộ mã sinh viên
                                _dangKyDAL.Insert(dk, conn, tx);
                            }
                        }

                        // Hoàn tất và ghi nhận vào CSDL
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); } catch { }
                        throw new BusinessException(50000, "Giao dịch thêm sinh viên và đăng ký thất bại, toàn bộ đã được Rollback!\nChi tiết: " + ex.Message, ex);
                    }
                }
            }
        }

        // ===================================================================
        // BÀI 4: Mô phỏng lỗi để kiểm chứng cơ chế Rollback
        // ===================================================================
        public bool SimulateRollbackWithInvalidCourse(SinhVienDTO svDto, string invalidMaHP, out string logResult)
        {
            _sinhVienBUS.ValidateSinhVien(svDto);

            List<DangKyDTO> dsDangKy = new List<DangKyDTO>
            {
                new DangKyDTO(svDto.MaSV, "HP01", 1, 8.5m),
                new DangKyDTO(svDto.MaSV, invalidMaHP, 1, 9.0m) // Mã học phần sai gây vi phạm FK
            };

            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // Bước 1: Insert sinh viên thành công
                        _sinhVienDAL.Insert(svDto, conn, tx);

                        // Bước 2: Insert HP01 thành công
                        _dangKyDAL.Insert(dsDangKy[0], conn, tx);

                        // Bước 3: Insert invalidMaHP gây Exception SQL FK (547)
                        _dangKyDAL.Insert(dsDangKy[1], conn, tx);

                        tx.Commit();
                        logResult = "Giao dịch không phát sinh lỗi (bất thường).";
                        return false;
                    }
                    catch (SqlException ex)
                    {
                        tx.Rollback();

                        // Kiểm chứng lại trong CSDL xem sinh viên có bị lưu dở dang không
                        SinhVienDTO checkSv = _sinhVienDAL.GetById(svDto.MaSV);
                        bool isClean = (checkSv == null);

                        logResult = $"[KẾT QUẢ ROLLBACK THÀNH CÔNG]\n" +
                                    $"- Phát hiện lỗi SqlException ({ex.Number}): {ex.Message}\n" +
                                    $"- Lệnh Rollback đã hủy toàn bộ thao tác trong giao dịch.\n" +
                                    $"- Kiểm chứng SELECT MaSV='{svDto.MaSV}': {(isClean ? "KHÔNG TỒN TẠI (CSDL hoàn toàn sạch)" : "Vẫn tồn tại (Lỗi)")}.";
                        return isClean;
                    }
                }
            }
        }

        // ===================================================================
        // BÀI 6: Chuyển sinh viên sang khoa khác có ghi nhật ký trong Transaction
        // ===================================================================
        public void TransferDepartment(string maSV, string maKhoaMoi, string lyDo, string nguoiThucHien)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new ValidationException("Vui lòng chọn sinh viên cần chuyển khoa.");

            if (string.IsNullOrWhiteSpace(maKhoaMoi))
                throw new ValidationException("Vui lòng chọn khoa chuyển đến.");

            SinhVienDTO sv = _sinhVienDAL.GetById(maSV);
            if (sv == null)
                throw new BusinessException(50002, "Không tìm thấy sinh viên trong hệ thống.");

            if (sv.MaKhoa.Equals(maKhoaMoi, StringComparison.OrdinalIgnoreCase))
                throw new ValidationException($"Sinh viên hiện tại đã thuộc khoa {maKhoaMoi}, không cần chuyển!");

            KhoaDTO khoaMoi = _khoaDAL.GetById(maKhoaMoi);
            if (khoaMoi == null)
                throw new BusinessException(50002, $"Khoa đích '{maKhoaMoi}' không tồn tại trong hệ thống.");

            string maKhoaCu = sv.MaKhoa;

            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Cập nhật MaKhoa của sinh viên
                        _sinhVienDAL.UpdateDepartment(maSV, maKhoaMoi, conn, tx);

                        // 2. Ghi nhật ký vào bảng LichSuChuyenKhoa
                        LichSuChuyenKhoaDTO logDto = new LichSuChuyenKhoaDTO
                        {
                            MaSV = maSV,
                            MaKhoaCu = maKhoaCu,
                            MaKhoaMoi = maKhoaMoi,
                            NgayChuyen = DateTime.Now,
                            LyDo = string.IsNullOrWhiteSpace(lyDo) ? "Chuyển khoa theo nguyện vọng đào tạo" : lyDo.Trim(),
                            NguoiThucHien = string.IsNullOrWhiteSpace(nguoiThucHien) ? "Quản trị viên" : nguoiThucHien.Trim()
                        };
                        _lichSuDAL.Insert(logDto, conn, tx);

                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); } catch { }
                        throw new BusinessException(50020, "Quá trình chuyển khoa thất bại và đã được Rollback: " + ex.Message, ex);
                    }
                }
            }
        }

        // ===================================================================
        // BÀI 7: Xóa khoa an toàn (Safe Delete Department)
        // ===================================================================
        public int SafeDeleteDepartment(string maKhoaCanXoa, string maKhoaChuyenDen)
        {
            if (string.IsNullOrWhiteSpace(maKhoaCanXoa))
                throw new ValidationException("Vui lòng chọn khoa cần xóa.");

            if (string.IsNullOrWhiteSpace(maKhoaChuyenDen))
                throw new ValidationException("Vui lòng chọn khoa tiếp nhận sinh viên.");

            if (maKhoaCanXoa.Equals(maKhoaChuyenDen, StringComparison.OrdinalIgnoreCase))
                throw new ValidationException("Khoa tiếp nhận không được trùng với khoa cần xóa!");

            KhoaDTO khoaXoa = _khoaDAL.GetById(maKhoaCanXoa);
            if (khoaXoa == null)
                throw new BusinessException(50002, $"Khoa cần xóa '{maKhoaCanXoa}' không tồn tại.");

            KhoaDTO khoaDen = _khoaDAL.GetById(maKhoaChuyenDen);
            if (khoaDen == null)
                throw new BusinessException(50002, $"Khoa tiếp nhận '{maKhoaChuyenDen}' không tồn tại.");

            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Chuyển toàn bộ sinh viên từ khoa cũ sang khoa mới
                        int soLuongChuyen = _sinhVienDAL.MoveStudentsDepartment(maKhoaCanXoa, maKhoaChuyenDen, conn, tx);

                        // 2. Xóa khoa cũ an toàn
                        _khoaDAL.Delete(maKhoaCanXoa, conn, tx);

                        tx.Commit();
                        return soLuongChuyen;
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); } catch { }
                        throw new BusinessException(50021, "Xóa khoa an toàn thất bại và đã Rollback: " + ex.Message, ex);
                    }
                }
            }
        }

        // ===================================================================
        // BÀI 8: Cập nhật điểm hàng loạt (Batch Grade Update with Validation & Rollback)
        // ===================================================================
        public void BatchUpdateGrades(List<DangKyDTO> danhSachDiem)
        {
            if (danhSachDiem == null || danhSachDiem.Count == 0)
                throw new ValidationException("Danh sách cập nhật điểm rỗng.");

            // Kiểm tra tính hợp lệ trước khi thực hiện
            foreach (var item in danhSachDiem)
            {
                if (item.Diem.HasValue && (item.Diem.Value < 0.0m || item.Diem.Value > 10.0m))
                {
                    throw new ValidationException($"Điểm không hợp lệ: {item.Diem.Value} (Điểm phải nằm trong đoạn [0.0, 10.0]). Toàn bộ giao dịch bị hủy!");
                }
            }

            using (SqlConnection conn = DbConnectionFactory.Create())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in danhSachDiem)
                        {
                            // Kiểm tra lại trong vòng lặp để đảm bảo tính an toàn giao dịch
                            if (item.Diem.HasValue && (item.Diem.Value < 0.0m || item.Diem.Value > 10.0m))
                            {
                                throw new ValidationException($"Điểm học phần {item.MaHP} của SV {item.MaSV} vi phạm giới hạn [0, 10].");
                            }

                            _dangKyDAL.UpdateGrade(item.MaSV, item.MaHP, item.HocKy, item.Diem, conn, tx);
                        }

                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        try { tx.Rollback(); } catch { }
                        throw new BusinessException(50022, "Cập nhật điểm hàng loạt thất bại và đã Rollback toàn bộ: " + ex.Message, ex);
                    }
                }
            }
        }
    }
}

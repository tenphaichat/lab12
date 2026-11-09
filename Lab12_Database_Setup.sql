-- ===================================================================
-- LAB 12: MASTER-DETAIL, TRANSACTION VÀ HOÀN THIỆN MÔ HÌNH 3 LỚP
-- Học phần: Lập trình .NET (IT3212) - EAUT
-- Sinh viên: Phan Văn Thắng - MSSV: 24002545 - Lớp: IT3212
-- CSDL: QLSinhVien ((localdb)\MSSQLLocalDB)
-- ===================================================================

USE QLSinhVien;
GO

-- 1. Bổ sung cột RowVersion vào bảng SinhVien phục vụ Bài 9 (Kiểm soát xung đột đồng thời)
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
    WHERE TABLE_NAME = 'SinhVien' AND COLUMN_NAME = 'RowVersion'
)
BEGIN
    ALTER TABLE SinhVien ADD RowVersion ROWVERSION NOT NULL;
END;
GO

-- 2. Tạo bảng LichSuChuyenKhoa phục vụ Bài 6 (Chuyển khoa có ghi log trong Transaction)
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.TABLES 
    WHERE TABLE_NAME = 'LichSuChuyenKhoa'
)
BEGIN
    CREATE TABLE LichSuChuyenKhoa (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        MaSV VARCHAR(15) NOT NULL,
        MaKhoaCu VARCHAR(10) NOT NULL,
        MaKhoaMoi VARCHAR(10) NOT NULL,
        NgayChuyen DATETIME NOT NULL DEFAULT GETDATE(),
        LyDo NVARCHAR(255) NULL,
        NguoiThucHien NVARCHAR(100) NULL,
        CONSTRAINT FK_LSCK_SinhVien FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV) ON DELETE CASCADE,
        CONSTRAINT FK_LSCK_KhoaCu FOREIGN KEY (MaKhoaCu) REFERENCES Khoa(MaKhoa),
        CONSTRAINT FK_LSCK_KhoaMoi FOREIGN KEY (MaKhoaMoi) REFERENCES Khoa(MaKhoa)
    );
END;
GO

-- 3. Đảm bảo dữ liệu danh mục Học phần (HocPhan)
IF NOT EXISTS (SELECT 1 FROM HocPhan WHERE MaHP = 'HP01')
    INSERT INTO HocPhan (MaHP, TenHP, SoTinChi) VALUES ('HP01', N'Lập trình .NET (C# WinForms)', 3);
IF NOT EXISTS (SELECT 1 FROM HocPhan WHERE MaHP = 'HP02')
    INSERT INTO HocPhan (MaHP, TenHP, SoTinChi) VALUES ('HP02', N'Cơ sở dữ liệu nâng cao', 3);
IF NOT EXISTS (SELECT 1 FROM HocPhan WHERE MaHP = 'HP03')
    INSERT INTO HocPhan (MaHP, TenHP, SoTinChi) VALUES ('HP03', N'Lập trình Hướng đối tượng', 3);
IF NOT EXISTS (SELECT 1 FROM HocPhan WHERE MaHP = 'HP04')
    INSERT INTO HocPhan (MaHP, TenHP, SoTinChi) VALUES ('HP04', N'Cấu trúc dữ liệu & Giải thuật', 3);
IF NOT EXISTS (SELECT 1 FROM HocPhan WHERE MaHP = 'HP05')
    INSERT INTO HocPhan (MaHP, TenHP, SoTinChi) VALUES ('HP05', N'Kiến trúc máy tính & HĐH', 3);
IF NOT EXISTS (SELECT 1 FROM HocPhan WHERE MaHP = 'HP06')
    INSERT INTO HocPhan (MaHP, TenHP, SoTinChi) VALUES ('HP06', N'Mạng máy tính & An toàn thông tin', 3);
GO

-- 4. Đảm bảo dữ liệu Đăng ký học phần (DangKy)
IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = '24002545' AND MaHP = 'HP01')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('24002545', 'HP01', 1, 9.5, GETDATE());
IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = '24002545' AND MaHP = 'HP02')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('24002545', 'HP02', 1, 9.0, GETDATE());
IF NOT EXISTS (SELECT 1 FROM DangKy WHERE MaSV = '24002545' AND MaHP = 'HP03')
    INSERT INTO DangKy (MaSV, MaHP, HocKy, Diem, NgayDangKy) VALUES ('24002545', 'HP03', 2, 8.8, GETDATE());
GO

-- ===================================================================
-- STORED PROCEDURES CHO LAB 12
-- ===================================================================

-- Bài 1: Lấy danh sách sinh viên theo khoa (sp_SinhVien_GetByDepartment)
CREATE OR ALTER PROCEDURE sp_SinhVien_GetByDepartment
    @MaKhoa VARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,
           CASE sv.GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
           sv.MaKhoa, k.TenKhoa, sv.DiemTB, sv.Email, sv.IsActive, sv.RowVersion
    FROM SinhVien sv
    JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
    WHERE (@MaKhoa IS NULL OR @MaKhoa = '' OR @MaKhoa = 'ALL' OR sv.MaKhoa = @MaKhoa)
      AND sv.IsActive = 1
    ORDER BY sv.MaSV;
END;
GO

-- Bài 2: Lấy danh sách đăng ký học phần của sinh viên (sp_DangKy_GetByStudent)
CREATE OR ALTER PROCEDURE sp_DangKy_GetByStudent
    @MaSV VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT dk.MaSV, dk.MaHP, hp.TenHP, hp.SoTinChi, dk.HocKy, dk.Diem, dk.NgayDangKy
    FROM DangKy dk
    JOIN HocPhan hp ON dk.MaHP = hp.MaHP
    WHERE dk.MaSV = @MaSV
    ORDER BY dk.HocKy, hp.TenHP;
END;
GO

-- Bài 6: Lấy lịch sử chuyển khoa của sinh viên
CREATE OR ALTER PROCEDURE sp_LichSuChuyenKhoa_GetByStudent
    @MaSV VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ls.Id, ls.MaSV, sv.HoTen,
           ls.MaKhoaCu, kCu.TenKhoa AS TenKhoaCu,
           ls.MaKhoaMoi, kMoi.TenKhoa AS TenKhoaMoi,
           ls.NgayChuyen, ls.LyDo, ls.NguoiThucHien
    FROM LichSuChuyenKhoa ls
    JOIN SinhVien sv ON ls.MaSV = sv.MaSV
    JOIN Khoa kCu ON ls.MaKhoaCu = kCu.MaKhoa
    JOIN Khoa kMoi ON ls.MaKhoaMoi = kMoi.MaKhoa
    WHERE (@MaSV IS NULL OR @MaSV = '' OR ls.MaSV = @MaSV)
    ORDER BY ls.NgayChuyen DESC;
END;
GO

-- Bài 9: Cập nhật có kiểm tra xung đột Optimistic Concurrency bằng RowVersion
CREATE OR ALTER PROCEDURE sp_SinhVien_UpdateOptimistic
    @MaSV VARCHAR(15),
    @HoTen NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh BIT,
    @MaKhoa VARCHAR(10),
    @DiemTB DECIMAL(4,2),
    @Email VARCHAR(100) = NULL,
    @OriginalRowVersion BINARY(8)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE SinhVien
    SET HoTen = @HoTen,
        NgaySinh = @NgaySinh,
        GioiTinh = @GioiTinh,
        MaKhoa = @MaKhoa,
        DiemTB = @DiemTB,
        Email = @Email
    WHERE MaSV = @MaSV AND RowVersion = @OriginalRowVersion;

    IF @@ROWCOUNT = 0
    BEGIN
        -- Phân biệt: Không tồn tại bản ghi hay bị sửa bởi người khác
        IF EXISTS (SELECT 1 FROM SinhVien WHERE MaSV = @MaSV)
        BEGIN
            THROW 50010, N'Dữ liệu đã bị thay đổi bởi người dùng khác (Xung đột Concurrency). Vui lòng tải lại!', 1;
        END
        ELSE
        BEGIN
            THROW 50002, N'Không tìm thấy sinh viên tương ứng trong hệ thống.', 1;
        END
    END
END;
GO

================================================================================
BÁO CÁO BÀI TẬP THỰC HÀNH LAB 12 - HỌC PHẦN LẬP TRÌNH .NET (IT3212)
ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á (EAUT) - KHOA CÔNG NGHỆ THÔNG TIN
================================================================================
Sinh viên thực hiện : Phan Văn Thắng
Mã số sinh viên     : 24002545
Lớp                 : IT3212
Ngày sinh           : 26/03/2006
Chủ đề Lab 12       : MASTER-DETAIL, TRANSACTION VÀ HOÀN THIỆN MÔ HÌNH 3 LỚP
Cơ sở dữ liệu       : QLSinhVien (Microsoft SQL Server / LocalDB)
================================================================================

I. CẤU TRÚC THƯ MỤC DỰ ÁN
--------------------------------------------------------------------------------
lab12/
│── IT3212_Labs.sln                     # File Solution Visual Studio / .NET 9
│── Lab12_Database_Setup.sql            # Script SQL tạo bảng LichSuChuyenKhoa, RowVersion, SP
│── 24002545_PhanVanThang_Lab12.docx    # Báo cáo thực hành chuẩn học thuật đầy đủ 10 bài
│── 24002545_PhanVanThang_Lab12.zip     # Tệp nén nộp bài hoàn chỉnh (không chứa bin/obj)
│── README.txt                          # Hướng dẫn chi tiết cấu hình và kiểm thử
│── .gitignore                          # Cấu hình bỏ qua bin, obj, .vs cho Git
│── screenshots/                        # Ảnh chụp màn hình kết quả kiểm thử 10 bài tập
│── lab12/                              # Dự án Windows Forms (.NET 9)
    │── Lab12_MasterDetail_Transaction.csproj
    │── App.config                      # Chuỗi kết nối CSDL QLSinhVien
    │── Program.cs                      # Khởi chạy ứng dụng & hỗ trợ chụp ảnh tự động
    │── ScreenshotCapture.cs            # Bộ chụp ảnh tự động phục vụ báo cáo
    │── DTO/                            # Data Transfer Objects
    │   ├── KhoaDTO.cs
    │   ├── SinhVienDTO.cs              # Tích hợp RowVersion kiểm soát Concurrency
    │   ├── HocPhanDTO.cs
    │   ├── DangKyDTO.cs
    │   └── LichSuChuyenKhoaDTO.cs
    │── DAL/                            # Data Access Layer (Nhận conn & tx từ BUS)
    │   ├── DbConnectionFactory.cs      # Khởi tạo kết nối SqlConnection an toàn
    │   ├── KhoaDAL.cs
    │   ├── SinhVienDAL.cs
    │   ├── HocPhanDAL.cs
    │   ├── DangKyDAL.cs
    │   └── LichSuChuyenKhoaDAL.cs
    │── BUS/                            # Business Logic Layer (Điều phối Transaction)
    │   ├── Exceptions.cs               # ValidationException, BusinessException, Concurrency
    │   ├── KhoaBUS.cs
    │   ├── SinhVienBUS.cs
    │   ├── HocPhanBUS.cs
    │   ├── DangKyBUS.cs
    │   ├── LichSuChuyenKhoaBUS.cs
    │   └── TransactionBUS.cs           # Giao dịch: Thêm SV+ĐK, Chuyển khoa, Xóa khoa, Điểm
    │── GUI/                            # Presentation Layer
    │   ├── frmMain.cs                  # Điều khiển giao diện, 5 Tab chuyên biệt
    │   └── frmMain.Designer.cs
    └── Images/                         # Tài nguyên ảnh đại diện sinh viên

II. NỘI DUNG 10 BÀI TẬP ĐÃ HOÀN THÀNH
--------------------------------------------------------------------------------
1. Bài 1: Giao diện Master-Detail Khoa - SinhVien
   - Lưới trên hiển thị danh mục Khoa. Khi click chọn khoa, lưới dưới tự động lọc sinh viên thuộc khoa đó qua sp_SinhVien_GetByDepartment.

2. Bài 2: Master-Detail SinhVien - Đăng ký học phần (DangKy)
   - Khi chọn một sinh viên ở lưới sinh viên, lưới chi tiết hiển thị toàn bộ học phần đã đăng ký (JOIN DangKy và HocPhan).
   - Hỗ trợ form chọn học phần và đăng ký nhanh.

3. Bài 3: Transaction thêm sinh viên và đăng ký học phần
   - Trong một SqlTransaction, thêm sinh viên vào bảng SinhVien rồi thêm danh sách học phần ban đầu vào bảng DangKy.
   - Gọi tx.Commit() khi thành công, tx.Rollback() khi thất bại.

4. Bài 4: Mô phỏng lỗi và kiểm chứng Rollback
   - Cố ý thêm mã học phần không tồn tại ở bước 2, kích hoạt SqlException (Lỗi 547).
   - Kiểm chứng lệnh tx.Rollback() đã hoàn tác toàn bộ: Sinh viên ở bước 1 hoàn toàn không bị lưu dở dang (CSDL sạch 100%).

5. Bài 5: Hoàn thiện lớp DAL dùng Transaction
   - Tất cả phương thức DAL nhận tham số tùy chọn (SqlConnection conn, SqlTransaction tx).
   - Tách biệt rõ ràng: BUS điều phối nghiệp vụ và vòng đời giao dịch; DAL chỉ chuyên biệt thực thi dữ liệu.

6. Bài 6: Chuyển sinh viên sang khoa khác
   - Dùng Transaction cập nhật MaKhoa của sinh viên và đồng thời ghi nhận lịch sử vào bảng LichSuChuyenKhoa.

7. Bài 7: Xóa khoa an toàn (Safe Delete Department)
   - Trong cùng một Transaction, tự động di dời toàn bộ sinh viên đang thuộc khoa cần xóa sang khoa tiếp nhận, sau đó mới thực hiện xóa bản ghi khoa.
   - Cam kết không có dữ liệu mồ côi (orphaned).

8. Bài 8: Cập nhật điểm hàng loạt (Batch Grade Update)
   - Cập nhật điểm trực tiếp trên DataGridView cho nhiều học phần.
   - Nếu có bất kỳ điểm nào ngoài đoạn [0.0, 10.0] thì ngắt và Rollback toàn bộ giao dịch, bảo toàn điểm cũ.

9. Bài 9: Kiểm soát xung đột cập nhật đồng thời (Optimistic Concurrency Control)
   - Bổ sung cột RowVersion vào bảng SinhVien.
   - Khi cập nhật, so sánh RowVersion ban đầu. Nếu người khác đã sửa CSDL trước đó, hệ thống ném OptimisticConcurrencyException ngăn chặn ghi đè mất dữ liệu.

10. Bài 10: Hoàn thiện giải pháp & Kiểm thử tự động hệ thống
   - Tab 5 tích hợp bộ kiểm thử tự động toàn diện 10 bài tập, xuất log debug chi tiết và bảng thống kê kết quả.

III. HƯỚNG DẪN CÀI ĐẶT VÀ CHẠY DỰ ÁN
--------------------------------------------------------------------------------
1. Yêu cầu môi trường:
   - Hệ điều hành: Windows 10/11
   - .NET SDK 9.0 trở lên
   - Microsoft SQL Server 2019/2022 hoặc LocalDB ((localdb)\MSSQLLocalDB)

2. Cài đặt CSDL:
   - Mở và thực thi tệp `Lab12_Database_Setup.sql` trên cơ sở dữ liệu `QLSinhVien`.

3. Biên dịch và khởi chạy:
   - Mở terminal tại thư mục chứa file `IT3212_Labs.sln`:
     dotnet build IT3212_Labs.sln
   - Khởi chạy ứng dụng:
     dotnet run --project lab12/Lab12_MasterDetail_Transaction.csproj

4. Chụp ảnh màn hình tự động (Tùy chọn):
     dotnet run --project lab12/Lab12_MasterDetail_Transaction.csproj -- --capture

================================================================================
HẾT TÀI LIỆU HƯỚNG DẪN

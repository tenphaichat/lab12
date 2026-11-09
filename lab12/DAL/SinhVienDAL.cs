using System;
using System.Data;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.DAL
{
    public class SinhVienDAL
    {
        public DataTable GetAll(bool includeInactive = false)
        {
            DataTable table = new DataTable("SinhVien");
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_SinhVien_GetAll", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IncludeInactive", SqlDbType.Bit).Value = includeInactive;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    table.Load(reader);
                }
            }
            return table;
        }

        // Bài 1: Lấy danh sách sinh viên theo khoa phục vụ Master-Detail
        public DataTable GetByDepartment(string maKhoa)
        {
            DataTable table = new DataTable("SinhVienTheoKhoa");
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_SinhVien_GetByDepartment", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = 
                    string.IsNullOrWhiteSpace(maKhoa) ? (object)DBNull.Value : maKhoa.Trim();
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    table.Load(reader);
                }
            }
            return table;
        }

        public SinhVienDTO GetById(string maSV, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = @"SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh,
                                        sv.MaKhoa, k.TenKhoa, sv.DiemTB, sv.Email, sv.IsActive, sv.RowVersion
                                 FROM SinhVien sv
                                 LEFT JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                                 WHERE sv.MaSV = @MaSV;";
            bool closeConn = false;
            if (conn == null)
            {
                conn = DbConnectionFactory.Create();
                conn.Open();
                closeConn = true;
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = maSV.Trim();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] rowVer = null;
                            if (reader["RowVersion"] != DBNull.Value)
                            {
                                rowVer = (byte[])reader["RowVersion"];
                            }

                            return new SinhVienDTO
                            {
                                MaSV = reader["MaSV"].ToString(),
                                HoTen = reader["HoTen"].ToString(),
                                NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                                GioiTinh = Convert.ToBoolean(reader["GioiTinh"]),
                                MaKhoa = reader["MaKhoa"].ToString(),
                                TenKhoa = reader["TenKhoa"] != DBNull.Value ? reader["TenKhoa"].ToString() : "",
                                DiemTB = Convert.ToDecimal(reader["DiemTB"]),
                                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null,
                                IsActive = reader["IsActive"] != DBNull.Value && Convert.ToBoolean(reader["IsActive"]),
                                RowVersion = rowVer
                            };
                        }
                    }
                }
                return null;
            }
            finally
            {
                if (closeConn) conn.Dispose();
            }
        }

        // Bài 3 & Bài 5: Thêm sinh viên có hỗ trợ tham gia Transaction ngoài
        public int Insert(SinhVienDTO dto, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = @"INSERT INTO SinhVien(MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email, IsActive)
                                 VALUES(@MaSV, @HoTen, @NgaySinh, @GioiTinh, @MaKhoa, @DiemTB, @Email, @IsActive);";
            bool closeConn = false;
            if (conn == null)
            {
                conn = DbConnectionFactory.Create();
                conn.Open();
                closeConn = true;
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = dto.MaSV.Trim();
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = dto.HoTen.Trim();
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dto.NgaySinh.Date;
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = dto.GioiTinh;
                    cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = dto.MaKhoa.Trim();

                    var pDiem = cmd.Parameters.Add("@DiemTB", SqlDbType.Decimal);
                    pDiem.Precision = 4;
                    pDiem.Scale = 2;
                    pDiem.Value = dto.DiemTB;

                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = 
                        string.IsNullOrWhiteSpace(dto.Email) ? (object)DBNull.Value : dto.Email.Trim();
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = dto.IsActive;

                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (closeConn) conn.Dispose();
            }
        }

        public int Update(SinhVienDTO dto, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = @"UPDATE SinhVien
                                 SET HoTen = @HoTen,
                                     NgaySinh = @NgaySinh,
                                     GioiTinh = @GioiTinh,
                                     MaKhoa = @MaKhoa,
                                     DiemTB = @DiemTB,
                                     Email = @Email,
                                     IsActive = @IsActive
                                 WHERE MaSV = @MaSV;";
            bool closeConn = false;
            if (conn == null)
            {
                conn = DbConnectionFactory.Create();
                conn.Open();
                closeConn = true;
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = dto.MaSV.Trim();
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = dto.HoTen.Trim();
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dto.NgaySinh.Date;
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = dto.GioiTinh;
                    cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = dto.MaKhoa.Trim();

                    var pDiem = cmd.Parameters.Add("@DiemTB", SqlDbType.Decimal);
                    pDiem.Precision = 4;
                    pDiem.Scale = 2;
                    pDiem.Value = dto.DiemTB;

                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = 
                        string.IsNullOrWhiteSpace(dto.Email) ? (object)DBNull.Value : dto.Email.Trim();
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = dto.IsActive;

                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (closeConn) conn.Dispose();
            }
        }

        // Bài 6: Cập nhật khoa của sinh viên trong Transaction chuyển khoa
        public int UpdateDepartment(string maSV, string maKhoaMoi, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = "UPDATE SinhVien SET MaKhoa = @MaKhoaMoi WHERE MaSV = @MaSV;";
            bool closeConn = false;
            if (conn == null)
            {
                conn = DbConnectionFactory.Create();
                conn.Open();
                closeConn = true;
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = maSV.Trim();
                    cmd.Parameters.Add("@MaKhoaMoi", SqlDbType.VarChar, 10).Value = maKhoaMoi.Trim();
                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (closeConn) conn.Dispose();
            }
        }

        // Bài 7: Chuyển toàn bộ sinh viên của một khoa sang khoa khác trước khi xóa
        public int MoveStudentsDepartment(string maKhoaCu, string maKhoaMoi, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = "UPDATE SinhVien SET MaKhoa = @MaKhoaMoi WHERE MaKhoa = @MaKhoaCu;";
            bool closeConn = false;
            if (conn == null)
            {
                conn = DbConnectionFactory.Create();
                conn.Open();
                closeConn = true;
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
                {
                    cmd.Parameters.Add("@MaKhoaCu", SqlDbType.VarChar, 10).Value = maKhoaCu.Trim();
                    cmd.Parameters.Add("@MaKhoaMoi", SqlDbType.VarChar, 10).Value = maKhoaMoi.Trim();
                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (closeConn) conn.Dispose();
            }
        }

        // Bài 9: Cập nhật có kiểm tra Optimistic Concurrency bằng RowVersion
        public int UpdateOptimistic(SinhVienDTO dto, byte[] originalRowVersion, SqlConnection conn = null, SqlTransaction tx = null)
        {
            bool closeConn = false;
            if (conn == null)
            {
                conn = DbConnectionFactory.Create();
                conn.Open();
                closeConn = true;
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand("sp_SinhVien_UpdateOptimistic", conn, tx))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = dto.MaSV.Trim();
                    cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar, 100).Value = dto.HoTen.Trim();
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dto.NgaySinh.Date;
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.Bit).Value = dto.GioiTinh;
                    cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = dto.MaKhoa.Trim();

                    var pDiem = cmd.Parameters.Add("@DiemTB", SqlDbType.Decimal);
                    pDiem.Precision = 4;
                    pDiem.Scale = 2;
                    pDiem.Value = dto.DiemTB;

                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = 
                        string.IsNullOrWhiteSpace(dto.Email) ? (object)DBNull.Value : dto.Email.Trim();

                    var pRowVer = cmd.Parameters.Add("@OriginalRowVersion", SqlDbType.Binary, 8);
                    pRowVer.Value = originalRowVersion ?? new byte[8];

                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (closeConn) conn.Dispose();
            }
        }

        public int Delete(string maSV, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = "DELETE FROM SinhVien WHERE MaSV = @MaSV;";
            bool closeConn = false;
            if (conn == null)
            {
                conn = DbConnectionFactory.Create();
                conn.Open();
                closeConn = true;
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = maSV.Trim();
                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (closeConn) conn.Dispose();
            }
        }

        public int SoftDelete(string maSV, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = "UPDATE SinhVien SET IsActive = 0 WHERE MaSV = @MaSV;";
            bool closeConn = false;
            if (conn == null)
            {
                conn = DbConnectionFactory.Create();
                conn.Open();
                closeConn = true;
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
                {
                    cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = maSV.Trim();
                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (closeConn) conn.Dispose();
            }
        }
    }
}

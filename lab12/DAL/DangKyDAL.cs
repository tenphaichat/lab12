using System;
using System.Data;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.DAL
{
    public class DangKyDAL
    {
        // Bài 2: Lấy danh sách học phần sinh viên đã đăng ký
        public DataTable GetByStudent(string maSV)
        {
            DataTable table = new DataTable("DangKyHocPhan");
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_DangKy_GetByStudent", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = maSV.Trim();
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    table.Load(reader);
                }
            }
            return table;
        }

        // Bài 3 & Bài 5: Thêm đăng ký học phần có hỗ trợ Transaction
        public int Insert(DangKyDTO dto, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = @"INSERT INTO DangKy(MaSV, MaHP, HocKy, Diem, NgayDangKy)
                                 VALUES(@MaSV, @MaHP, @HocKy, @Diem, @NgayDangKy);";
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
                    cmd.Parameters.Add("@MaHP", SqlDbType.VarChar, 10).Value = dto.MaHP.Trim();
                    cmd.Parameters.Add("@HocKy", SqlDbType.Int).Value = dto.HocKy;
                    
                    if (dto.Diem.HasValue)
                    {
                        var pDiem = cmd.Parameters.Add("@Diem", SqlDbType.Decimal);
                        pDiem.Precision = 4;
                        pDiem.Scale = 2;
                        pDiem.Value = dto.Diem.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@Diem", SqlDbType.Decimal).Value = DBNull.Value;
                    }

                    cmd.Parameters.Add("@NgayDangKy", SqlDbType.DateTime).Value = dto.NgayDangKy;
                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (closeConn) conn.Dispose();
            }
        }

        // Bài 8: Cập nhật điểm cho đăng ký học phần có hỗ trợ Transaction
        public int UpdateGrade(string maSV, string maHP, int hocKy, decimal? diem, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = @"UPDATE DangKy 
                                 SET Diem = @Diem 
                                 WHERE MaSV = @MaSV AND MaHP = @MaHP AND HocKy = @HocKy;";
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
                    cmd.Parameters.Add("@MaHP", SqlDbType.VarChar, 10).Value = maHP.Trim();
                    cmd.Parameters.Add("@HocKy", SqlDbType.Int).Value = hocKy;
                    
                    if (diem.HasValue)
                    {
                        var pDiem = cmd.Parameters.Add("@Diem", SqlDbType.Decimal);
                        pDiem.Precision = 4;
                        pDiem.Scale = 2;
                        pDiem.Value = diem.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@Diem", SqlDbType.Decimal).Value = DBNull.Value;
                    }

                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (closeConn) conn.Dispose();
            }
        }

        public int Delete(string maSV, string maHP, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = "DELETE FROM DangKy WHERE MaSV = @MaSV AND MaHP = @MaHP;";
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
                    cmd.Parameters.Add("@MaHP", SqlDbType.VarChar, 10).Value = maHP.Trim();
                    return cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (closeConn) conn.Dispose();
            }
        }

        public int DeleteByStudent(string maSV, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = "DELETE FROM DangKy WHERE MaSV = @MaSV;";
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

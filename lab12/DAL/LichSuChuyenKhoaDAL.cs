using System;
using System.Data;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.DAL
{
    public class LichSuChuyenKhoaDAL
    {
        public DataTable GetByStudent(string maSV = null)
        {
            DataTable table = new DataTable("LichSuChuyenKhoa");
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_LichSuChuyenKhoa_GetByStudent", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 15).Value = 
                    string.IsNullOrWhiteSpace(maSV) ? (object)DBNull.Value : maSV.Trim();
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    table.Load(reader);
                }
            }
            return table;
        }

        // Bài 6: Ghi nhật ký chuyển khoa trong Transaction
        public int Insert(LichSuChuyenKhoaDTO dto, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = @"INSERT INTO LichSuChuyenKhoa (MaSV, MaKhoaCu, MaKhoaMoi, NgayChuyen, LyDo, NguoiThucHien)
                                 VALUES (@MaSV, @MaKhoaCu, @MaKhoaMoi, @NgayChuyen, @LyDo, @NguoiThucHien);";
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
                    cmd.Parameters.Add("@MaKhoaCu", SqlDbType.VarChar, 10).Value = dto.MaKhoaCu.Trim();
                    cmd.Parameters.Add("@MaKhoaMoi", SqlDbType.VarChar, 10).Value = dto.MaKhoaMoi.Trim();
                    cmd.Parameters.Add("@NgayChuyen", SqlDbType.DateTime).Value = dto.NgayChuyen;
                    cmd.Parameters.Add("@LyDo", SqlDbType.NVarChar, 255).Value = 
                        string.IsNullOrWhiteSpace(dto.LyDo) ? (object)DBNull.Value : dto.LyDo.Trim();
                    cmd.Parameters.Add("@NguoiThucHien", SqlDbType.NVarChar, 100).Value = 
                        string.IsNullOrWhiteSpace(dto.NguoiThucHien) ? (object)DBNull.Value : dto.NguoiThucHien.Trim();
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

using System;
using System.Data;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.DAL
{
    public class KhoaDAL
    {
        public DataTable GetAll(bool includeAllOption = false)
        {
            DataTable table = new DataTable("Khoa");
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand("sp_Khoa_GetAll", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    table.Load(reader);
                }
            }

            if (includeAllOption)
            {
                DataRow r = table.NewRow();
                r["MaKhoa"] = "ALL";
                r["TenKhoa"] = "-- Tất cả các khoa --";
                table.Rows.InsertAt(r, 0);
            }

            return table;
        }

        public KhoaDTO GetById(string maKhoa, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = "SELECT MaKhoa, TenKhoa FROM Khoa WHERE MaKhoa = @MaKhoa;";
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
                    cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = maKhoa.Trim();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new KhoaDTO
                            {
                                MaKhoa = reader["MaKhoa"].ToString(),
                                TenKhoa = reader["TenKhoa"].ToString()
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

        public int Insert(KhoaDTO dto, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = "INSERT INTO Khoa(MaKhoa, TenKhoa) VALUES (@MaKhoa, @TenKhoa);";
            return ExecuteCommand(sql, conn, tx, cmd =>
            {
                cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = dto.MaKhoa.Trim();
                cmd.Parameters.Add("@TenKhoa", SqlDbType.NVarChar, 100).Value = dto.TenKhoa.Trim();
            });
        }

        public int Update(KhoaDTO dto, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = "UPDATE Khoa SET TenKhoa = @TenKhoa WHERE MaKhoa = @MaKhoa;";
            return ExecuteCommand(sql, conn, tx, cmd =>
            {
                cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = dto.MaKhoa.Trim();
                cmd.Parameters.Add("@TenKhoa", SqlDbType.NVarChar, 100).Value = dto.TenKhoa.Trim();
            });
        }

        public int Delete(string maKhoa, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = "DELETE FROM Khoa WHERE MaKhoa = @MaKhoa;";
            return ExecuteCommand(sql, conn, tx, cmd =>
            {
                cmd.Parameters.Add("@MaKhoa", SqlDbType.VarChar, 10).Value = maKhoa.Trim();
            });
        }

        private int ExecuteCommand(string sql, SqlConnection conn, SqlTransaction tx, Action<SqlCommand> bindParams)
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
                using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
                {
                    bindParams(cmd);
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

using System;
using System.Data;
using System.Data.SqlClient;
using Lab12_MasterDetail_Transaction.DTO;

namespace Lab12_MasterDetail_Transaction.DAL
{
    public class HocPhanDAL
    {
        public DataTable GetAll()
        {
            DataTable table = new DataTable("HocPhan");
            const string sql = "SELECT MaHP, TenHP, SoTinChi FROM HocPhan ORDER BY MaHP;";
            using (SqlConnection conn = DbConnectionFactory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    table.Load(reader);
                }
            }
            return table;
        }

        public HocPhanDTO GetById(string maHP, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = "SELECT MaHP, TenHP, SoTinChi FROM HocPhan WHERE MaHP = @MaHP;";
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
                    cmd.Parameters.Add("@MaHP", SqlDbType.VarChar, 10).Value = maHP.Trim();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new HocPhanDTO
                            {
                                MaHP = reader["MaHP"].ToString(),
                                TenHP = reader["TenHP"].ToString(),
                                SoTinChi = Convert.ToInt32(reader["SoTinChi"])
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

        public int Insert(HocPhanDTO dto, SqlConnection conn = null, SqlTransaction tx = null)
        {
            const string sql = "INSERT INTO HocPhan(MaHP, TenHP, SoTinChi) VALUES (@MaHP, @TenHP, @SoTinChi);";
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
                    cmd.Parameters.Add("@MaHP", SqlDbType.VarChar, 10).Value = dto.MaHP.Trim();
                    cmd.Parameters.Add("@TenHP", SqlDbType.NVarChar, 120).Value = dto.TenHP.Trim();
                    cmd.Parameters.Add("@SoTinChi", SqlDbType.Int).Value = dto.SoTinChi;
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

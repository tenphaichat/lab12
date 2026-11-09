using System.Data;
using Lab12_MasterDetail_Transaction.DAL;

namespace Lab12_MasterDetail_Transaction.BUS
{
    public class LichSuChuyenKhoaBUS
    {
        private readonly LichSuChuyenKhoaDAL _dal = new LichSuChuyenKhoaDAL();

        public DataTable GetLichSu(string maSV = null)
        {
            return _dal.GetByStudent(maSV);
        }
    }
}

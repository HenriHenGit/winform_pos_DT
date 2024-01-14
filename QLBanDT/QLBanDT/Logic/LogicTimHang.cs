using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLBanDT.Data;

namespace QLBanDT.Logic
{
    public class LogicTimHang
    {
        private static LogicTimHang instance;

        public static LogicTimHang Instance
        {
            get { if (instance == null) instance = new LogicTimHang(); return LogicTimHang.instance; }
            set => instance = value;
        }
        private LogicTimHang() { }

        public List<dtDienThoai> GetListDienThoai()
        {
            List<dtDienThoai> listDT = new List<dtDienThoai>();

            string query = ("SELECT A.*, B.TenNCC FROM DBO.DienThoai A, dbo.NhaCungCap B WHERE A.MaNCC = B.MaNCC");
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                dtDienThoai tableDT = new dtDienThoai(item);
                listDT.Add(tableDT);
            }

            return listDT;
        }

        public List<dtCauHinh> GetListDKCauHinh(string macauhinh)
        {
            List<dtCauHinh> listCH = new List<dtCauHinh>();

            string query = string.Format("SELECT * FROM dbo.CauHinh WHERE MaCauHinh = '{0}'", macauhinh);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                dtCauHinh tableCH = new dtCauHinh(item);
                listCH.Add(tableCH);
            }

            return listCH;
        }

        public List<dtDienThoai> TimHang(string name)
        {
            List<dtDienThoai> list = new List<dtDienThoai>();

            string query = string.Format("SELECT A.*, B.TenNCC FROM DBO.DienThoai A, dbo.NhaCungCap B WHERE A.MaNCC = B.MaNCC AND dbo.fuConvertToUnsign1(TenDT) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                dtDienThoai KH = new dtDienThoai(item);
                list.Add(KH);
            }
            return list;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanDT.Data;
using System.Data;

namespace QLBanDT.Logic
{
    public class LogicKhachHang
    {
        private static LogicKhachHang instance;

        public static LogicKhachHang Instance 
        {
            get { if (instance == null) instance = new LogicKhachHang(); return LogicKhachHang.instance; }
            set => instance = value;
        }

        private LogicKhachHang() { }

        
        public List<dtKhachHang> GetListKhachHang()
        {
            List<dtKhachHang> listKH = new List<dtKhachHang>();

            string query = ("SELECT MaKH, HoKH + ' ' + TenKH AS HoTenKH, SDT, DiaChi, CCCD, NgaySinh, Email, TrangThai FROM dbo.KhachHang");
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                dtKhachHang tableKH = new dtKhachHang(item);
                listKH.Add(tableKH);
            }

            return listKH;
        }

        public List<dtKhachHang> TimKhachHang(string name)
        {
            List<dtKhachHang> list = new List<dtKhachHang>();
            bool isNumeric = int.TryParse(name.Replace("0", ""), out int number);
            string sdt = "";
            if (isNumeric || name == "0")
            {
                sdt = name;
                name = "";
            }
            else
                sdt = ""; 

            string query = string.Format("SELECT MaKH, HoKH + ' ' + TenKH AS HoTenKH, SDT, DiaChi, CCCD, NgaySinh, Email, TrangThai FROM dbo.KhachHang WHERE dbo.fuConvertToUnsign1(TenKH) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%' AND dbo.fuConvertToUnsign1(SDT) LIKE N'%' + dbo.fuConvertToUnsign1(N'{1}') + '%'", name, sdt);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                dtKhachHang KH = new dtKhachHang(item);
                list.Add(KH);
            }
            return list;
        }

        public string maKH;

        public bool InsertKhachHang(string hokh, string tenkh, string sdt, string email, string diachi, string cccd, string trangthai)
        {
            string query = string.Format("INSERT DBO.KhachHang(MaKH, HoKH, TenKH, SDT, DiaChi, CCCD, NgaySinh, Email, TrangThai) VALUES( (SELECT CONCAT('000',MAX(MaKH) + 1) FROM DBO.KhachHang), N'{0}', N'{1}', '{2}', N'{4}', '{5}', GETDATE(), '{3}', {6} )", hokh, tenkh, sdt, email, diachi, cccd, trangthai);
            int result = DataProvider.Instance.ExecuteNoneQuery(query);
            return result > 0;
        }

        public bool UpdateKhachHang(string hokh, string tenkh, string sdt, string email, string diachi, string cccd, string trangthai)
        {
            string query = string.Format("UPDATE DBO.KhachHang  SET HoKH = N'{0}', TenKH = N'{1}',  SDT = '{2}', Email = '{3}', DiaChi = N'{4}', CCCD = '{5}', TrangThai = {6} WHERE MaKH = '{7}'", hokh, tenkh, sdt, email, diachi, cccd, trangthai, maKH);
            int result = DataProvider.Instance.ExecuteNoneQuery(query);
            return result > 0;
        }

        public bool DeleteKhachHang(string makh)
        {
            string query = string.Format("DELETE DBO.KhachHang WHERE MaKH = '{0}'", makh);
            int result = DataProvider.Instance.ExecuteNoneQuery(query);
            return result > 0;
        }


    }
}

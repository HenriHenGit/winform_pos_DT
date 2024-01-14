using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLBanDT.Data;

namespace QLBanDT.Logic
{
    public class LogicTimHoaDon
    {
        private static LogicTimHoaDon instance;

        public static LogicTimHoaDon Instance
        {
            get { if (instance == null) instance = new LogicTimHoaDon(); return LogicTimHoaDon.instance; }
            set => instance = value;
        }

        private LogicTimHoaDon() { }

        public List<dtHoaDon> GetListHoaDon()
        {
            List<dtHoaDon> list = new List<dtHoaDon>();

            string query = "SELECT a.*, SUM(b.SoLuong) AS TongSoLuong FROM DBO.HoaDon a INNER JOIN DBO.CTHDNhap b ON a.MaHD = b.MaHD GROUP BY a.MaHD, a.MaCH, a.NgayLapHD, a.Gia, a.ChietKhau, a.TrangThai HAVING COUNT(*) > 0";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                dtHoaDon table = new dtHoaDon(item);
                list.Add(table);
            }

            return list;
        }

        public List<dtHoaDon> TimHoaDon(string name)
        {
            List<dtHoaDon> list = new List<dtHoaDon>();
            bool isNumeric = int.TryParse(name.Replace("0", ""), out int number);
            string ngayLHD = "";
            if (isNumeric)
            {
                if (Convert.ToInt32(name.Replace("0", "1")) < 100)
                {
                    ngayLHD = name;
                    name = "";
                }
                else
                    ngayLHD = "";
            }
            else
            {
                ngayLHD = StringDoiNgay(name);
                name = "";
            }
                

            string query = string.Format("SELECT a.*, SUM(b.SoLuong) AS TongSoLuong FROM DBO.HoaDon a INNER JOIN DBO.CTHDNhap b ON a.MaHD = b.MaHD WHERE a.MaHD LIKE '%' + '{0}' + '%' AND a.NgayLapHD LIKE '%' + '{1}' + '%' GROUP BY a.MaHD, a.MaCH, a.NgayLapHD, a.Gia, a.ChietKhau, a.TrangThai HAVING COUNT(*) > 0", name, ngayLHD);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                dtHoaDon KH = new dtHoaDon(item);
                list.Add(KH);
            }
            return list;
        }

        public string StringDoiNgay(string text)
        {
            string kq = "";
            if (text != null || text != "")
            {
                string[] arr = text.Split('/');
                bool isNumeric = false;
                if (arr.Length > 1)
                    isNumeric = int.TryParse(arr[1], out int number);
                
                if (isNumeric)
                {
                    if (Convert.ToInt32(arr[1]) < 10)
                        kq = arr[0] + "-0" + arr[1];
                    else
                        kq = text.Replace("/", "-");

                }
                else
                    kq = text.Replace("/", "-");
            }
            
            
            return kq;
        }
        public string ReverseString (string text)
        {
            string reverse = string.Empty;
            for (int i = text.Length - 1; i >= 0; i--)
            {
                reverse += text[i];
            }
            return reverse;
        }

        
    }
}

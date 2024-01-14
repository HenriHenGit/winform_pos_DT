using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLBanDT.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace QLBanDT.Logic
{
    public class LogicGiaoDienChinh
    {
        private static LogicGiaoDienChinh instance;

        public static LogicGiaoDienChinh Instance 
        {
            get { if (instance == null) instance = new LogicGiaoDienChinh(); return LogicGiaoDienChinh.instance; } 
            set => instance = value; 
        }

        private LogicGiaoDienChinh() { }


        #region Get__Lấy dữ liệu
        public List<dtDienThoai_MaTenGia> GetListDienThoai(string Barcode)
        {
            List<dtDienThoai_MaTenGia> listGDC = new List<dtDienThoai_MaTenGia>();

            string query = string.Format("SELECT MaDT , TenDT , Gia FROM DBO.DienThoai WHERE MaDT = '{0}'", Barcode);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                dtDienThoai_MaTenGia tableGDC = new dtDienThoai_MaTenGia(item);
                listGDC.Add(tableGDC);
            }

            return listGDC;
        }
        public string GetTongSoLuong()
        {
            string query = "LaySoLuong";
            string TongSoLuong = DataProvider.Instance.ExecuteScalar(query).ToString();
            if (TongSoLuong != null)
                return TongSoLuong;
            else
                return "0";
        }
        
        public string GetThanhTien()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            string query = "LayTongGia";
            object result = DataProvider.Instance.ExecuteScalar(query);
            
            if (result != null && double.TryParse(result.ToString(), out double tongGia))
            {

                return (tongGia.ToString("c", culture)).Replace(',', '.');
            }

            return "0";
        }

        public string GetChietKhau()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            string query = "LayChietKhau";
            object result = DataProvider.Instance.ExecuteScalar(query);

            if (result != null && double.TryParse(result.ToString(), out double tongGia))
            {

                return (tongGia.ToString("c", culture)).Replace(',', '.');
            }

            return "0";
        }

        public string GetTongCong()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            string query = "LayTongCong";
            object result = DataProvider.Instance.ExecuteScalar(query);

            if (result != null && double.TryParse(result.ToString(), out double tongGia))
            {

                return (tongGia.ToString("c", culture)).Replace(',', '.');
            }

            return "0";
        }

        public string GetMaHDNhap()
        {
            string query = "SELECT CONCAT(0, MAX(MaHDNhap) + 1) AS MaNhap  FROM DBO.CTHDNhap";
            string maHDNhap = DataProvider.Instance.ExecuteScalar(query).ToString();
            if (maHDNhap != null)
                return maHDNhap;
            else
                return "0000";
        }

        private string MaNV;
        public void GetMaNV(string maNV)
        {
            this.MaNV = maNV;
        }
        public float GetThanhTien(float CK, float Gia)
        {
            Gia = Gia * (float)1000;
            return Gia - Gia * CK;
        }
        #endregion



        #region INSERT, DELETE, UPDATE

        public bool InsertCTNhapHoaDon(string barcode, int kt)
        {
            string query = string.Format("Insert_CTNhapHoaDon '{0}' , '{1}' , {2}", barcode, MaNV, kt);
            int result = DataProvider.Instance.ExecuteNoneQuery(query);
            return result > 0;   
        }
        public bool DeleteHoaDon()
        {
            string query = string.Format("HuyHoaDon");
            int result = DataProvider.Instance.ExecuteNoneQuery(query);
            return result > 0;
        }

        // trừ hóa đơn nhập và cập nhật lại bảng hóa đơn
        public bool DeleteCTHDNhap(string maHDNhap)
        {
            string query = string.Format("TruHoaDonNhap '{0}'", maHDNhap); 
            int result = DataProvider.Instance.ExecuteNoneQuery(query);
            return result > 0;  
        }
        #endregion



        int identyti = 0;
        public bool FlagTuThayDoi()
        {
            identyti++;
            if (identyti % 2 == 0)
                return true;
            else
                return false;
        }
    }
}

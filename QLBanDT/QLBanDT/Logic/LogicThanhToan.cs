using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanDT.Logic
{
    public class LogicThanhToan
    {
        private static LogicThanhToan instance;

        public static LogicThanhToan Instance 
        { get { if (instance == null) instance = new LogicThanhToan(); return LogicThanhToan.instance; } 
          set => instance = value; 
        }

        private LogicThanhToan() { }

        #region funtion
        private string tien = "";
        public string DoiGiaTriTien(int x)
        {
            tien += x.ToString();
            CultureInfo culture = new CultureInfo("vi-VN");
            if (tien != null && double.TryParse(tien, out double d))
                return d.ToString("c", culture).Replace(',', '.');
            return tien;
        }
        public string DoiGiaTriTien(double x)
        {
            tien += x.ToString();
            CultureInfo culture = new CultureInfo("vi-VN");
            if (tien != null && double.TryParse(tien, out double d))
                return d.ToString("c", culture).Replace(',', '.');
            return tien;
        }
        public string DoiGiaTriTien(string x)
        {
            // nhập KO bên textBox sẽ không thực hiện nữa
            if (x == "KO")
                return tien = "";
            if (KTTienCoSan(x))
            {
                // nhan 100, 50, 20, 10, 5, 2, 1, 5d
            }
            else
                tien += x.ToString();
            CultureInfo culture = new CultureInfo("vi-VN");
            if (tien != null && double.TryParse(tien, out double d))
                return d.ToString("c", culture).Replace(',', '.');
            return tien;
        }
        
        public string GetTienTraKhach(string tienKhachTra, string TongCong)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            double tienTra = 0;
            if (!string.IsNullOrEmpty(tienKhachTra))
            {
                //string tienTraStr = txbDuTien.Text.Replace(".", "").Replace("đ", "").Trim();
                string tienTraStr = tienKhachTra.Replace("₫", "").Replace(".", "").Trim();
                double.TryParse(tienTraStr, out tienTra);
            }

            // Lấy tổng cộng từ Label
            double tongCong = 0;
            if (!string.IsNullOrEmpty(TongCong))
            {
                //string tongCongStr = lblTongCong.Text.Replace(".", "").Replace("đ", "").Trim();
                string tongCongStr = TongCong.Replace("₫", "").Replace(".", "").Trim();
                double.TryParse(tongCongStr, out tongCong);
            }

            // Tính tiền thừa và đặt lại Label
            double tienThua = (tienTra - tongCong) / 100.0;
            return tienThua.ToString("c", culture).Replace(",", ".");
        }

        bool KTTienCoSan(string x)
        {
            if (x == "100k")
            {
                double tienDouble;
                if (tien == "")
                {
                    tienDouble = 0;
                }
                else
                    tienDouble = Convert.ToDouble(tien);
                tienDouble += 100.0;
                tien = tienDouble.ToString();
                return true;
            }

            if (x == "50k")
            {
                double tienDouble;
                if (tien == "")
                {
                    tienDouble = 0;
                }
                else
                    tienDouble = Convert.ToDouble(tien);
                tienDouble += 50.0;
                tien = tienDouble.ToString();
                return true;
            }
            if (x == "20k")
            {
                double tienDouble;
                if (tien == "")
                {
                    tienDouble = 0;
                }
                else
                    tienDouble = Convert.ToDouble(tien);
                tienDouble += 20.0;
                tien = tienDouble.ToString();
                return true;
            }
            if (x == "10k")
            {
                double tienDouble;
                if (tien == "")
                {
                    tienDouble = 0;
                }
                else
                    tienDouble = Convert.ToDouble(tien);
                tienDouble += 10.0;
                tien = tienDouble.ToString();
                return true;
            }
            if (x == "5k")
            {
                double tienDouble;
                if (tien == "")
                {
                    tienDouble = 0;
                }
                else
                    tienDouble = Convert.ToDouble(tien);
                tienDouble += 5.0;
                tien = tienDouble.ToString();
                return true;
            }
            if (x == "2k")
            {
                double tienDouble;
                if (tien == "")
                {
                    tienDouble = 0;
                }
                else
                    tienDouble = Convert.ToDouble(tien);
                tienDouble += 2.0;
                tien = tienDouble.ToString();
                return true;
            }
            if (x == "1k")
            {
                double tienDouble;
                if (tien == "")
                {
                    tienDouble = 0;
                }
                else
                    tienDouble = Convert.ToDouble(tien);
                tienDouble += 1.0;
                tien = tienDouble.ToString();
                return true;
            }
            if (x == "5d")
            {
                double tienDouble;
                if (tien == "")
                {
                    tienDouble = 0;
                }
                else
                    tienDouble = Convert.ToDouble(tien);
                tienDouble += 0.5;
                tien = tienDouble.ToString();
                return true;
            }
            return false;
        }
        #endregion

    }
}

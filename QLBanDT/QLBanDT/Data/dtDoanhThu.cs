using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLBanDT.Data
{
    public class dtDoanhThu
    {
        public dtDoanhThu(string ngayLapHD, int soluong, float gia, float chietkhau)
        {
            this.ngayLapHD = ngayLapHD;
            this.soLuong = soluong;
            this.gia = gia;
            this.chietKhau = chietkhau;
        }

        public dtDoanhThu(DataRow row)
        {
            
        }

        private string ngayLapHD;
        private int soLuong;
        private float gia;
        private float chietKhau;

        public string NgayLapHD { get => ngayLapHD; set => ngayLapHD = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float Gia { get => gia; set => gia = value; }
        public float ChietKhau { get => chietKhau; set => chietKhau = value; }
    }
}

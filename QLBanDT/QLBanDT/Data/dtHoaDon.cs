using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLBanDT.Data
{
    public class dtHoaDon
    {
        public dtHoaDon(string mahd, string mach, string ngaylaphd, float gia, float chietkhau, int trangthai, int tongsoluong)
        {
            this.maHD = mahd;
            this.maCH = mach;
            this.ngayLapHD = ngaylaphd;
            this.gia = gia;
            this.ChietKhau = chietkhau;
            this.trangThai = trangthai;
            this.tongSoLuong = tongsoluong;
        }

        public dtHoaDon(DataRow row)
        {
            this.maHD = row["MaHD"].ToString();
            this.MaCH = row["MaCH"].ToString();
            this.ngayLapHD = row["NgayLapHD"].ToString();
            this.gia = (float)Convert.ToDouble(row["Gia"].ToString());
            this.chietKhau = (float)Convert.ToDouble(row["ChietKhau"].ToString());
            this.trangThai = (int)row["TrangThai"];
            this.tongSoLuong = (int)row["TongSoLuong"];
        }

        private string maHD;
        private string maCH;
        private string ngayLapHD;
        private float gia;
        private float chietKhau;
        private int trangThai;
        private int tongSoLuong;


        public string MaHD { get => maHD; set => maHD = value; }
        public string MaCH { get => maCH; set => maCH = value; }
        public string NgayLapHD { get => ngayLapHD; set => ngayLapHD = value; }
        public float Gia { get => gia; set => gia = value; }
        public float ChietKhau { get => chietKhau; set => chietKhau = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public int TongSoLuong { get => tongSoLuong; set => tongSoLuong = value; }
    }
}

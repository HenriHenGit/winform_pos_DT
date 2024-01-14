using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLBanDT.Data
{
    public class dtDienThoai
    {
        public dtDienThoai(string madt, string macauhinh, string mancc, string tendt, string mau, string hinh, string tinhnang, int soluong, float gia, int trangthai, string tenncc)
        {
            this.maDT = madt;
            this.maCauHinh = macauhinh;
            this.maNCC = mancc;
            this.TenDT = tendt;
            this.mau = mau;
            this.hinh = hinh;
            this.tinhNang = tinhnang;
            this.soLuong = soluong;
            this.gia = gia;
            this.trangThai = trangthai;
            this.TenNCC = tenncc;

        }

        public dtDienThoai(DataRow row)
        {
            this.maDT = row["MaDT"].ToString();
            this.MaCauHinh = row["MaCauHinh"].ToString();
            this.MaNCC = row["MaNCC"].ToString();
            this.TenDT = row["TenDT"].ToString();
            this.Mau = row["Mau"].ToString();
            this.hinh = row["Hinh"].ToString();
            this.tinhNang = row["TinhNang"].ToString();
            this.soLuong = (int)row["SoLuong"];
            this.gia = (float)Convert.ToDouble(row["Gia"].ToString());
            this.trangThai = (int)row["TrangThai"];
            this.tenNCC = row["TenNCC"].ToString();
        }

        private string maDT;
        private string maCauHinh;
        private string maNCC;
        private string TenDT;
        private string mau;
        private string hinh;
        private string tinhNang;
        private int soLuong;
        private float gia;
        private int trangThai;
        private string tenNCC;

        public string MaDT { get => maDT; set => maDT = value; }
        public string MaCauHinh { get => maCauHinh; set => maCauHinh = value; }
        public string MaNCC { get => maNCC; set => maNCC = value; }
        public string TenDT1 { get => TenDT; set => TenDT = value; }
        public string Mau { get => mau; set => mau = value; }
        public string Hinh { get => hinh; set => hinh = value; }
        public string TinhNang { get => tinhNang; set => tinhNang = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float Gia { get => gia; set => gia = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
    }
}

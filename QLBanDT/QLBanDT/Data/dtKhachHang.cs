using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLBanDT.Data
{
    public class dtKhachHang
    {
        public dtKhachHang(string makh, string tenkh, string sdt, string diachi, string cccd, string ngaysinh, string email, int trangthai)
        {
            this.maKH = makh;
            this.tenKH = tenkh;
            this.SDT = sdt;
            this.diaChi = diachi;   
            this.CCCD = cccd;
            this.ngaySinh = ngaysinh;
            this.email = email;
            this.trangThai = trangthai;
        }

        public dtKhachHang(DataRow row)
        {
            this.maKH = row["MaKH"].ToString();
            this.tenKH = row["HoTenKH"].ToString();
            this.SDT = row["SDT"].ToString();
            this.diaChi = row["DiaChi"].ToString();
            this.CCCD = row["CCCD"].ToString();
            this.ngaySinh = row["NgaySinh"].ToString();
            this.email = row["Email"].ToString();
            this.trangThai = (int)row["TrangThai"];
        }
        private string maKH;
        private string tenKH;
        private string sDT;
        private string diaChi;
        private string cCCD;
        private string ngaySinh;
        private string email;
        private int trangThai;


        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string CCCD { get => cCCD; set => cCCD = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string Email { get => email; set => email = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLBanDT.Data
{
    public class dtNhanVien
    {
        public dtNhanVien(string manv, string mach, string honv, string tennv, string sdt, string diachi, string email)
        {
            this.maNV = manv;
            this.maCH = mach;
            this.hoNV = honv;
            this.tenNV = tennv;
            this.sdt = sdt; 
            this.diaChi = diachi;
            this.email = email;
        }
        public dtNhanVien()
        {
            this.maNV = "";
            this.maCH = "";
            this.hoNV = "";
            this.tenNV = "";
            this.sdt = "";
            this.diaChi = "";
            this.email = "";
        }
        public dtNhanVien(DataRow row)
        {
            this.maNV = row["MaNV"].ToString();
            this.maCH = row["MaCH"].ToString();
            this.hoNV = row["HoNV"].ToString();
            this.tenNV = row["TenNV"].ToString();
            this.sdt = row["SDT"].ToString();
            this.diaChi = row["DiaChi"].ToString();
            this.email = row["Email"].ToString();
        }

        private string maNV;
        private string maCH;
        private string hoNV;
        private string tenNV;
        private string sdt;
        private string diaChi;
        private string email;

        public string MaNV { get => maNV; set => maNV = value; }
        public string MaCH { get => maCH; set => maCH = value; }
        public string HoNV { get => hoNV; set => hoNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Email { get => email; set => email = value; }
        public string Sdt { get => sdt; set => sdt = value; }
    }
}

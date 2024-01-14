using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLBanDT.Data
{
    public class dtDienThoai_MaTenGia
    {
        public dtDienThoai_MaTenGia(string madt, string tendt, float gia)
        {
            this.maDT = madt;
            this.tenDT = tendt;
            this.gia = gia;
        }

        public dtDienThoai_MaTenGia(DataRow row)
        {
            this.maDT = row["MaDT"].ToString();
            this.tenDT = row["TenDT"].ToString();
            this.gia = (float)Convert.ToDouble(row["Gia"].ToString());
        }

        private string maDT;
        private string tenDT;
        private float gia;

        public string MaDT { get => maDT; set => maDT = value; }
        public string TenDT { get => tenDT; set => tenDT = value; }
        public float Gia { get => gia; set => gia = value; }
    }
}

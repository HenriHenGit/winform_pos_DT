using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLBanDT.Data
{
    public class dtCauHinh
    {
        public dtCauHinh(string macauhinh, string ram, string rom, string pin, string chip, string manhinh, string camerasau, int trangthai)
        {
            this.maCauHinh = macauhinh;
            this.ram = ram;
            this.rom = rom;
            this.pin = pin;
            this.chip = chip;
            this.manHinh = manhinh;
            this.cameraSau = camerasau;
            this.trangThai = trangthai;
        }
        public dtCauHinh(DataRow row)
        {
            this.maCauHinh = row["MaCauHinh"].ToString();
            this.ram = row["Ram"].ToString();
            this.rom = row["Rom"].ToString();
            this.pin = row["Pin"].ToString();
            this.chip = row["Chip"].ToString();
            this.manHinh = row["ManHinh"].ToString();
            this.CameraSau = row["CameraSau"].ToString();
            this.TrangThai = (int)row["TrangThai"];
        }
        private string maCauHinh;
        private string ram;
        private string rom;
        private string pin;
        private string chip;
        private string manHinh;
        private string cameraSau;
        private int trangThai;

        public string MaCauHinh { get => maCauHinh; set => maCauHinh = value; }
        public string Ram { get => ram; set => ram = value; }
        public string Rom { get => rom; set => rom = value; }
        public string Pin { get => pin; set => pin = value; }
        public string Chip { get => chip; set => chip = value; }
        public string ManHinh { get => manHinh; set => manHinh = value; }
        public string CameraSau { get => cameraSau; set => cameraSau = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
    }
}

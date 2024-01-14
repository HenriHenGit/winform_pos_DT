using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanDT.Data;

namespace QLBanDT.Logic
{
    public class LogicEditKhachHang
    {
        private static LogicEditKhachHang instance;

        public static LogicEditKhachHang Instance
        {
            get { if (instance == null) instance = new LogicEditKhachHang(); return LogicEditKhachHang.instance; }
            set => instance = value;
        }

        private LogicEditKhachHang() { }
    }
}

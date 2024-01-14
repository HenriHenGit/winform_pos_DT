using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBanDT.Data;

namespace QLBanDT.Logic
{
    public class LogicNhapLogin
    {
        private static LogicNhapLogin instance;

        public static LogicNhapLogin Instance {
            get { if (instance == null) instance = new LogicNhapLogin(); return instance; }
            private set { instance = value; }
        }

        private LogicNhapLogin() { }

        public bool Login(string maNV, string pass)
        {
            //dtNhanVien k;
            //k.MaNV = maNV;
            string query = string.Format("SELECT * FROM DBO.NhanVien WHERE MaNV = '{0}' AND MaCH = '0{1}'", maNV, pass);


            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            
            return result.Rows.Count > 0;
        }
        
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanDT.Data;
using QLBanDT.Logic;

namespace QLBanDT
{
    public partial class frThemKhachHang : Form
    {
        public frThemKhachHang()
        {
            InitializeComponent();
            this.AcceptButton = btnHoanThanh;
            this.CancelButton = btnExit;
            load();
        }

        #region Load
        void load()
        {
            DateTime dateKH = DateTime.Now;
            txtNLHD.Text = (dateKH.Day + "/" + dateKH.Month + "/" + dateKH.Year).ToString();
        }
        #endregion

        #region tác vụ khác
        void ThemKhachHang()
        {
            string tenKH = txtKhachHang.Text;
            string[] inputWords = tenKH.Split(' ');
            string firstName = inputWords[0];
            string lastName = "";
            if (inputWords.Length > 1)
            {
                lastName = string.Join(" ", inputWords.Skip(1));
            }

            if (LogicKhachHang.Instance.InsertKhachHang(firstName, lastName, txtSDT.Text, txtEmail.Text, txtDiaChi.Text, txtCCCD.Text, txtTrangThai.Text))
                MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else
                MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        void CapNhatKhachHang()
        {
            string tenKH = txtKhachHang.Text;
            string[] inputWords = tenKH.Split(' ');
            string firstName = inputWords[0];
            string lastName = "";
            if (inputWords.Length > 1)
            {
                lastName = string.Join(" ", inputWords.Skip(1));
            }

            if (LogicKhachHang.Instance.UpdateKhachHang(firstName, lastName, txtSDT.Text, txtEmail.Text, txtDiaChi.Text, txtCCCD.Text, txtTrangThai.Text))
                MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else
                MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        #endregion

        #region Event
        private void btnHoanThanh_Click(object sender, EventArgs e)
        {
            if(LogicKhachHang.Instance.maKH == null)
            {
                ThemKhachHang();

            }
            else
            {
                CapNhatKhachHang();
                LogicKhachHang.Instance.maKH = "";
            }
            this.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

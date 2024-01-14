using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanDT.Logic;
using QLBanDT.Data;

namespace QLBanDT
{
    public partial class frTimHoaDon : Form
    {
        public frTimHoaDon()
        {
            InitializeComponent();
            txtTiemKiem.Focus();
            this.AcceptButton = btnTimKiem;
            this.CancelButton = btnExit;
            load();
        }
        #region tác vụ khác
        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }

        void CapNhatMau()
        {
            for (int i = 0; i < lsvHoaDon.Items.Count; i++)
            {

                if (i % 2 == 0)
                    lsvHoaDon.Items[i].SubItems[0].BackColor = Color.White;
                else
                    lsvHoaDon.Items[i].SubItems[0].BackColor = Color.DarkGray;
            }
        }
        #endregion

        #region Load
        void load()
        {
            if (txtTiemKiem.Text == "Tìm kiếm")
                loadAllDonHang();
        }
        void loadChiTietHoaDon()
        {
            if (lsvHoaDon.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvHoaDon.SelectedItems[0];
                txtbarcode.Text = item.SubItems[0].Text;
                txtNgayMua.Text = item.SubItems[1].Text;
                txtSoLuong.Text = item.SubItems[2].Text;
                txtTongTien.Text = item.SubItems[3].Text;
                txtChietKhau.Text = item.SubItems[4].Text;

            }
        }

        void loadAllDonHang()
        {
            lsvHoaDon.Items.Clear();
            List<dtHoaDon> listKhachHang = LogicTimHoaDon.Instance.GetListHoaDon();
            foreach (dtHoaDon item in listKhachHang)
            {

                ListViewItem listItem = new ListViewItem(item.MaHD.ToString());
                if (LogicGiaoDienChinh.Instance.FlagTuThayDoi())
                    listItem.BackColor = Color.DarkGray;

                SetHeight(lsvHoaDon, 50);

                listItem.SubItems.Add(item.NgayLapHD.ToString());
                listItem.SubItems.Add(item.TongSoLuong.ToString());

                LogicThanhToan.Instance.DoiGiaTriTien("KO");

                listItem.SubItems.Add(LogicThanhToan.Instance.DoiGiaTriTien(item.Gia * 1000));

                LogicThanhToan.Instance.DoiGiaTriTien("KO");

                listItem.SubItems.Add(LogicThanhToan.Instance.DoiGiaTriTien(item.ChietKhau * 1000));

                lsvHoaDon.Items.Add(listItem);

            }
        }
        void LoadTimKiemHoaDon(string name)
        {
            lsvHoaDon.Items.Clear();
            List<dtHoaDon> listKhachHang = LogicTimHoaDon.Instance.TimHoaDon(name);
            foreach (dtHoaDon item in listKhachHang)
            {

                ListViewItem listItem = new ListViewItem(item.MaHD.ToString());
                if (LogicGiaoDienChinh.Instance.FlagTuThayDoi())
                    listItem.BackColor = Color.DarkGray;

                SetHeight(lsvHoaDon, 50);

                listItem.SubItems.Add(item.NgayLapHD.ToString());
                listItem.SubItems.Add(item.TongSoLuong.ToString());

                LogicThanhToan.Instance.DoiGiaTriTien("KO");

                listItem.SubItems.Add(LogicThanhToan.Instance.DoiGiaTriTien(item.Gia * 1000));

                LogicThanhToan.Instance.DoiGiaTriTien("KO");

                listItem.SubItems.Add(LogicThanhToan.Instance.DoiGiaTriTien(item.ChietKhau * 1000));

                lsvHoaDon.Items.Add(listItem);

            }
        }
        #endregion

        #region Event
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadChiTietHoaDon();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadTimKiemHoaDon(txtTiemKiem.Text);
            CapNhatMau();
        }

        private void txtTiemKiem_Click(object sender, EventArgs e)
        {
            if (txtTiemKiem.Text == "Tìm kiếm")
            {
                txtTiemKiem.Text = "";
                txtTiemKiem.ForeColor = Color.Black;

            }
        }

        private void txtTiemKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTiemKiem.ForeColor = Color.Black;
        }

        private void txtTiemKiem_TextChanged(object sender, EventArgs e)
        {
            LoadTimKiemHoaDon(txtTiemKiem.Text);
            CapNhatMau();
        }
        #endregion
    }
}

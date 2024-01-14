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
    public partial class frEditKhachHang : Form
    {
        public frEditKhachHang()
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
            for (int i = 0; i < lsvKhachHang.Items.Count; i++)
            {

                if (lsvKhachHang.Items[i].SubItems[4].Text == "Không tồn tại")
                {
                    lsvKhachHang.Items[i].BackColor = Color.LightBlue;
                }
                else
                {
                    if (i % 2 == 0)
                        lsvKhachHang.Items[i].SubItems[0].BackColor = Color.White;
                    else
                        lsvKhachHang.Items[i].SubItems[0].BackColor = Color.DarkGray;
                }
            }
        }
        void CapNhatKhachHang()
        {
            if (lsvKhachHang.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvKhachHang.SelectedItems[0];
                LogicKhachHang.Instance.maKH = item.SubItems[0].Text;
                new frThemKhachHang().ShowDialog();
            }
            else
                MessageBox.Show("Lỗi không chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void XoaKhachHang()
        {
            if (lsvKhachHang.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvKhachHang.SelectedItems[0];
                if (LogicKhachHang.Instance.DeleteKhachHang(item.SubItems[0].Text))
                    MessageBox.Show("Xóa thành công", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                else
                    MessageBox.Show("Xóa Thất bại", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);

            }
            else
                MessageBox.Show("Lỗi không chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion


        #region Load
        void load()
        {
            if (txtTiemKiem.Text == "Tìm kiếm")
                LoadALLKhachHang();
        }
        void loadChiTietKhachHang()
        {
            if (lsvKhachHang.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvKhachHang.SelectedItems[0];
                txtTenKH.Text = item.SubItems[1].Text;
                txtSDT.Text = item.SubItems[2].Text;
                txtEmail.Text = item.SubItems[3].Text;
                txtDiaChi.Text = item.SubItems[5].Text;
                txtCCCD.Text = item.SubItems[6].Text;

            }
        }

        void LoadALLKhachHang()
        {
            lsvKhachHang.Items.Clear();
            List<dtKhachHang> listKhachHang = LogicKhachHang.Instance.GetListKhachHang();
            foreach (dtKhachHang item in listKhachHang)
            {

                ListViewItem listItem = new ListViewItem(item.MaKH.ToString());
                if (LogicGiaoDienChinh.Instance.FlagTuThayDoi())
                    listItem.BackColor = Color.DarkGray;

                SetHeight(lsvKhachHang, 50);

                listItem.SubItems.Add(item.TenKH.ToString());
                listItem.SubItems.Add(item.SDT.ToString());
                listItem.SubItems.Add(item.Email.ToString());

                if (item.TrangThai.ToString() == "1")
                    listItem.SubItems.Add("Tồn tại");
                else
                {
                    listItem.BackColor = Color.LightBlue;
                    listItem.SubItems.Add("Không tồn tại");
                }

                listItem.SubItems.Add(item.DiaChi.ToString());
                listItem.SubItems.Add(item.CCCD.ToString());
                listItem.SubItems.Add(item.NgaySinh.ToString());



                lsvKhachHang.Items.Add(listItem);

            }
        }
        void LoadTimKiemKhachHang(string name)
        {
            lsvKhachHang.Items.Clear();
            List<dtKhachHang> listKhachHang = LogicKhachHang.Instance.TimKhachHang(name);
            foreach (dtKhachHang item in listKhachHang)
            {

                ListViewItem listItem = new ListViewItem(item.MaKH.ToString());
                if (LogicGiaoDienChinh.Instance.FlagTuThayDoi())
                    listItem.BackColor = Color.DarkGray;

                SetHeight(lsvKhachHang, 50);

                listItem.SubItems.Add(item.TenKH.ToString());
                listItem.SubItems.Add(item.SDT.ToString());
                listItem.SubItems.Add(item.Email.ToString());

                if (item.TrangThai.ToString() == "1")
                    listItem.SubItems.Add("Tồn tại");
                else
                    listItem.SubItems.Add("Không tồn tại");

                listItem.SubItems.Add(item.DiaChi.ToString());
                listItem.SubItems.Add(item.CCCD.ToString());
                listItem.SubItems.Add(item.NgaySinh.ToString());

                lsvKhachHang.Items.Add(listItem);

            }
        }
        #endregion


        #region Event
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTiemKiem_Click(object sender, EventArgs e)
        {
            if (txtTiemKiem.Focus() == false)
            {
                txtTiemKiem.Text = "Tìm kiếm";
            }  
            else
            txtTiemKiem.Text = "";
        }

        private void txtMaKH_Click(object sender, EventArgs e)
        {
            txtTenKH.Text = "";
        }

        private void txtTenKH_Click(object sender, EventArgs e)
        {
            if (txtTiemKiem.Text == "Tìm kiếm")
            {
                txtTiemKiem.Text = "";
                txtTiemKiem.ForeColor = Color.Black;

            }
        }

        private void txtSDT_Click(object sender, EventArgs e)
        {
            txtEmail.Text = "";
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = "";
        }

        private void txtDiaChi_Click(object sender, EventArgs e)
        {
            txtCCCD.Text = "";
        }

        private void lsvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadChiTietKhachHang();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadTimKiemKhachHang(txtTiemKiem.Text);
            CapNhatMau();
        }

        private void txtTiemKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTiemKiem.ForeColor = Color.Black;
        }

        private void txtTiemKiem_TextChanged(object sender, EventArgs e)
        {
            LoadTimKiemKhachHang(txtTiemKiem.Text);
            CapNhatMau();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            new frThemKhachHang().ShowDialog();
            LoadALLKhachHang();
        }

        private void btnCapNhatKH_Click(object sender, EventArgs e)
        {
            CapNhatKhachHang();
            LoadALLKhachHang();
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Muốn xóa Khách Hàng này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                XoaKhachHang();
                LoadALLKhachHang();
            }

        }
        #endregion


    }
}

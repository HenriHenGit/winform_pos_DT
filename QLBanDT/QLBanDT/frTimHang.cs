using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanDT.Data;
using QLBanDT.Logic;

namespace QLBanDT
{
    public partial class frTimHang : Form
    {
        public frTimHang()
        {
            InitializeComponent();
            txtTiemKiem.Focus();
            this.AcceptButton = btnTimKiem;
            this.CancelButton = btnExit;
            load();
        }

        

        #region tác vụ khác

        Bitmap GetFileAnh(string tenAnh ,string imgCha = null, string imgCon = null)
        {
            if (imgCha == null)
                imgCha = "img";
            if (imgCon == null)
                imgCon = "DienThoai";
            Bitmap bm = new Bitmap(Path.Combine(Application.StartupPath, imgCha, imgCon, tenAnh));
            return bm; 
        }
        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }

        void CapNhatMau()
        {
            for (int i = 0; i < lsvSanPham.Items.Count; i++)
            {

                if (i % 2 == 0)
                    lsvSanPham.Items[i].SubItems[0].BackColor = Color.White;
                else
                    lsvSanPham.Items[i].SubItems[0].BackColor = Color.DarkGray;
            }
        }
        #endregion

        #region Load
        void load()
        {
            if (txtTiemKiem.Text == "Tìm kiếm")
                LoadALLSanPham();
        }
        void loadChiTietDienThoai()
        {
            if (lsvSanPham.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvSanPham.SelectedItems[0];
                lblMaSanPham.Text = item.SubItems[0].Text;
                txbTenSanPham.Text = item.SubItems[1].Text;
                lblGiaSanPham.Text = item.SubItems[2].Text;
                ptbSanPham.Image = GetFileAnh(item.SubItems[5].Text);
                List<dtCauHinh> listCH = LogicTimHang.Instance.GetListDKCauHinh(item.SubItems[6].Text);
                foreach(dtCauHinh items in listCH){
                    txbManHinh.Text = items.ManHinh.ToString();
                    txbPin.Text = items.Pin.ToString();
                    txbCameraSau.Text = items.CameraSau.ToString();
                    txbCPU.Text = items.Chip.ToString();
                    txbRam.Text = items.Ram.ToString();
                    txbRom.Text = items.Rom.ToString();
                }
            }
        }

        void LoadALLSanPham()
        {
            lsvSanPham.Items.Clear();
            List<dtDienThoai> listDT = LogicTimHang.Instance.GetListDienThoai();
            foreach (dtDienThoai item in listDT)
            {
                
                ListViewItem listItem = new ListViewItem(item.MaDT.ToString());
                if (LogicGiaoDienChinh.Instance.FlagTuThayDoi())
                    listItem.BackColor = Color.DarkGray;

                SetHeight(lsvSanPham, 50);

                listItem.SubItems.Add(item.TenDT1.ToString());

                // làm lệnh kết thúc doi giá trị
                LogicThanhToan.Instance.DoiGiaTriTien("KO");
                // tạo lệnh mới có sẵn

                listItem.SubItems.Add(LogicThanhToan.Instance.DoiGiaTriTien(item.Gia * 1000));
                listItem.SubItems.Add(item.TenNCC.ToString());
                if ((int)item.TrangThai > 0)
                    listItem.SubItems.Add("Còn hàng");
                else
                    listItem.SubItems.Add("Hết");
                listItem.SubItems.Add(item.Hinh.ToString());
                listItem.SubItems.Add(item.MaCauHinh.ToString());

                lsvSanPham.Items.Add(listItem);

            }
        }
        void LoadTimKiemSanPham(string name)
        {
            lsvSanPham.Items.Clear();
            List<dtDienThoai> listDT = LogicTimHang.Instance.TimHang(name);
            foreach (dtDienThoai item in listDT)
            {

                ListViewItem listItem = new ListViewItem(item.MaDT.ToString());
                if (LogicGiaoDienChinh.Instance.FlagTuThayDoi())
                    listItem.BackColor = Color.DarkGray;

                SetHeight(lsvSanPham, 50);

                listItem.SubItems.Add(item.TenDT1.ToString());

                // làm lệnh kết thúc doi giá trị
                LogicThanhToan.Instance.DoiGiaTriTien("KO");
                // tạo lệnh mới có sẵn

                listItem.SubItems.Add(LogicThanhToan.Instance.DoiGiaTriTien(item.Gia * 1000));
                listItem.SubItems.Add(item.TenNCC.ToString());
                if ((int)item.TrangThai > 0)
                    listItem.SubItems.Add("Còn hàng");
                else
                    listItem.SubItems.Add("Hết");
                listItem.SubItems.Add(item.Hinh.ToString());
                listItem.SubItems.Add(item.MaCauHinh.ToString());

                lsvSanPham.Items.Add(listItem);

            }
        }


        #endregion

        #region Event
        private void btnEdit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ vởi quản trị viên để có thể sử dụng tính năng này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void lsvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadChiTietDienThoai();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadTimKiemSanPham(txtTiemKiem.Text);
            CapNhatMau();
        }

        private void txtTiemKiem_TextChanged(object sender, EventArgs e)
        {
            LoadTimKiemSanPham(txtTiemKiem.Text);
            CapNhatMau();
        }
        #endregion

        
    }
}

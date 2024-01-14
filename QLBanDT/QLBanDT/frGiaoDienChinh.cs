using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanDT.Data;
using QLBanDT.Logic;

namespace QLBanDT
{
    public partial class frGiaoDienChinh : Form
    {
        public frGiaoDienChinh()
        {
            InitializeComponent();
            txtBarcode.Focus();
            this.CancelButton = btnExit;
            this.AcceptButton = btnList;  
        }

        #region tác vụ khác
        private void SetHeight(ListView listView, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listView.SmallImageList = imgList;
        }

        private int CreateHD = 1;
        
         
        float ThanhTien(float CK, float Gia)
        {
            return LogicGiaoDienChinh.Instance.GetThanhTien(CK, Gia);
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

        void HuyHang()
        {
            if (lsvSanPham.Items.Count > 0)
            {
                DialogResult ok = MessageBox.Show("Bạn muốn hủy hàng", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                if (ok == DialogResult.Yes)
                {
                    lsvSanPham.Items.Clear();
                    LoadHDSauKhiHuyHang();

                    LogicGiaoDienChinh.Instance.DeleteHoaDon();
                }
            }
            else MessageBox.Show("Hủy hàng lỗi");
        }
        #endregion


        #region Load
        void LoadThemHoaDon()
        {
            LogicGiaoDienChinh.Instance.InsertCTNhapHoaDon(txtBarcode.Text, CreateHD); // Insert vào bảng hóa đơn
            CreateHD++;
        }
        void LoadHoaDon()
        {
            
            lblSoLuong.Text = LogicGiaoDienChinh.Instance.GetTongSoLuong();  // lấy ra số lượng

            lblThanhTien.Text = LogicGiaoDienChinh.Instance.GetThanhTien(); // lấy ra thành tiền

            lblChietKhau.Text = LogicGiaoDienChinh.Instance.GetChietKhau(); // lấy ra chiết khấu

            lblTongCong.Text = LogicGiaoDienChinh.Instance.GetTongCong(); // lấy ra tổng cộng

        }

        void LoadSanPham()
        {

            float CK = (float)5 / 100;
            float thanhTien;
            List<dtDienThoai_MaTenGia> listSanPham = LogicGiaoDienChinh.Instance.GetListDienThoai(txtBarcode.Text);
            foreach (dtDienThoai_MaTenGia item in listSanPham)
            {
                CultureInfo culture = new CultureInfo("vi-VN");
                ListViewItem listItem = new ListViewItem(item.MaDT.ToString());
                if (LogicGiaoDienChinh.Instance.FlagTuThayDoi())
                    listItem.BackColor = Color.DarkGray;

                SetHeight(lsvSanPham, 50);
                thanhTien = ThanhTien(CK, (float)item.Gia);

                listItem.SubItems.Add(item.TenDT.ToString());
                listItem.SubItems.Add(item.Gia.ToString() + ".000.00đ");
                listItem.SubItems.Add("1");
                listItem.SubItems.Add("5%");

                listItem.SubItems.Add((thanhTien.ToString("c", culture)).Replace(",", "."));
                listItem.SubItems.Add(LogicGiaoDienChinh.Instance.GetMaHDNhap());
                

                lsvSanPham.Items.Add(listItem);
                
            }
        }

        void LoadTruHang()
        {
            if (lsvSanPham.SelectedItems.Count > 0)
            {
                DialogResult dl = MessageBox.Show("Bạn muốn trừ hàng", "canh bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dl == DialogResult.OK)
                {
                    if (lsvSanPham.SelectedItems.Count > 0)
                    {
                            
                        if (LogicGiaoDienChinh.Instance.DeleteCTHDNhap(lsvSanPham.SelectedItems[0].SubItems[6].Text))
                            lsvSanPham.Items.Remove(lsvSanPham.SelectedItems[0]);
                        

                    }   
                }

            }
            else MessageBox.Show("Trừ hàng lỗi");
        }

        void LoadSauKhiThanhToan()
        {
            lsvSanPham.Items.Clear();
            LoadHDSauKhiHuyHang();
            txtBarcode.Text = "Barcode";
            txtBarcode.ForeColor = Color.DarkGray;
        }
        void LoadHDSauKhiHuyHang()
        {
            CreateHD = 1;
            lblSoLuong.Text = "0";
            lblChietKhau.Text = "0";
            lblThanhTien.Text = "0";
            lblTongCong.Text = "0";
        }
        #endregion


        #region Event
        private void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSanPham();
                LoadThemHoaDon();
                LoadHoaDon();
            }
            catch
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnTruHang_Click(object sender, EventArgs e)
        {
            LoadTruHang();
            LoadHoaDon();
            CapNhatMau();
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtBarcode.ForeColor = Color.Black;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBarcode_Click_1(object sender, EventArgs e)
        {
            if (txtBarcode.Text == "Barcode")
            {
                txtBarcode.Text = "";
                txtBarcode.ForeColor = Color.Black;

            }
        }

        private void btnHuyHang_Click(object sender, EventArgs e)
        {
            HuyHang();
        }
        #endregion


        #region Hiển thị form
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            new frKhachHang().ShowDialog();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lsvSanPham.Items.Count > 0)
            {
                LoadSauKhiThanhToan();
                new frThanhToan().ShowDialog();
            }
            else MessageBox.Show("Chưa có sản phẩm");
        }

        private void btnTimHang_Click(object sender, EventArgs e)
        {
            new frTimHang().ShowDialog();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            new frDichVu().ShowDialog();
        }

        private void btnDonOnl_Click(object sender, EventArgs e)
        {
            new frDonHangOnl().ShowDialog();
        }

        private void btnTimHoaDon_Click(object sender, EventArgs e)
        {
            new frTimHoaDon().ShowDialog(); 
        }

        #endregion
    }
}

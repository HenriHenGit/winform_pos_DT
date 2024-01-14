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
    public partial class frKhachHang : Form
    {
        public frKhachHang()
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
                if(lsvKhachHang.Items[i].SubItems[4].Text == "Không tồn tại")
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
        #endregion



        #region Load
        void load()
        {
            if(txtTiemKiem.Text == "Tìm kiếm")
            LoadALLKhachHang();   
        }
        void loadChiTietKhachHang()
        {
            if (lsvKhachHang.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvKhachHang.SelectedItems[0];
                lblMaKH.Text = item.SubItems[0].Text;
                lblTenKH.Text = item.SubItems[1].Text;
                lblSDT.Text = item.SubItems[2].Text;
                txtEmail.Text = item.SubItems[3].Text;
                txtDiaChi.Text = item.SubItems[5].Text;
                lblCCCD.Text = item.SubItems[6].Text;
                lblNgaySinh.Text = item.SubItems[7].Text;
                lblTrangThai.Text = item.SubItems[4].Text;

            }
        }
        
        void LoadALLKhachHang()
        {
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

                if(item.TrangThai.ToString() == "1")
                    listItem.SubItems.Add("Tồn tại");
                else
                {
                    listItem.BackColor= Color.LightBlue;
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
        private void lsvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadChiTietKhachHang();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            new frEditKhachHang().ShowDialog();
            LoadALLKhachHang();
        }

        private void pnlEdit_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lsvKhachHang.Items.Clear();
            LoadTimKiemKhachHang(txtTiemKiem.Text);
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
            lsvKhachHang.Items.Clear();
            LoadTimKiemKhachHang(txtTiemKiem.Text);
            CapNhatMau();
        }
        #endregion


    }
}

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
using QLBanDT.Logic;

namespace QLBanDT
{
    public partial class frThanhToan : Form
    {
        public frThanhToan()
        {
            InitializeComponent();
            this.CancelButton = btnExit;
            this.AcceptButton = btnThanhToan;
            load();
        }
        #region Load
        
        void load()
        {
            loadThanhTien();
            loadHD();
        }
        void loadThanhTien()
        {
            txbHienThiTien.Text = LogicGiaoDienChinh.Instance.GetTongCong();
        }
        void loadHD()
        {
            //lấy dữ liệu từ LogicGiaoDienChinh
            lblChietKhau.Text = LogicGiaoDienChinh.Instance.GetChietKhau();
           lblSoLuong.Text = LogicGiaoDienChinh.Instance.GetTongSoLuong();
            lblThanhTien.Text = LogicGiaoDienChinh.Instance.GetThanhTien();
            lblTongCong.Text = LogicGiaoDienChinh.Instance.GetTongCong();
            
        }
        #endregion

        #region Event

        #region Event__bấm số

        private void btn7_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien(7);
            txbDuTien_TextChanged(sender, e);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien(8);
            txbDuTien_TextChanged(sender, e);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien(9);
            txbDuTien_TextChanged(sender, e);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien(4);
            txbDuTien_TextChanged(sender, e);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien(5);
            txbDuTien_TextChanged(sender, e);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien(6);
            txbDuTien_TextChanged(sender, e);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien(1);
            txbDuTien_TextChanged(sender, e);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien(2);
            txbDuTien_TextChanged(sender, e);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien(3);
            txbDuTien_TextChanged(sender, e);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien(0);
            txbDuTien_TextChanged(sender, e);
        }
        private void txbDuTien_KeyUp(object sender, KeyEventArgs e)
        {
            // nhập số từ bàn phím và chuyển thành tiền 
            if (txbDuTien.Text != null && double.TryParse(txbDuTien.Text, out double d))
            {

                for (int i = 0; i < 10; i++)
                {

                    if (txbDuTien.Text == (i.ToString()))
                    {
                        txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien(i);
                        txbDuTien.SelectAll();
                    }
                }
            }
        }

        #endregion

        #region Event__nút có sẵn
        private void btn100k_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien("100k");
            txbDuTien_TextChanged(sender, e);
        }

        private void btn50k_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien("50k");
            txbDuTien_TextChanged(sender, e);
        }

        private void btn20k_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien("20k");
            txbDuTien_TextChanged(sender, e);
        }

        private void btn10k_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien("10k");
            txbDuTien_TextChanged(sender, e);
        }

        private void btn5k_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien("5k");
            txbDuTien_TextChanged(sender, e);
        }

        private void btn2k_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien("2k");
            txbDuTien_TextChanged(sender, e);
        }

        private void btn1k_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien("1k");
            txbDuTien_TextChanged(sender, e);
        }

        private void btn5d_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = LogicThanhToan.Instance.DoiGiaTriTien("5d");
            txbDuTien_TextChanged(sender, e);
        }
        #endregion

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn phải hoàn thành hóa đơn này", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        private void btnDuTienMat_Click(object sender, EventArgs e)
        {
            txbDuTien.Clear();

            // lấy thành tiền bên logic giao dien chinh
            txbDuTien.Text = LogicGiaoDienChinh.Instance.GetTongCong(); 
        }

        private void btnClearX_Click(object sender, EventArgs e)
        {
            txbDuTien.Text = "0";

            // Nếu giá trị chuyền vào là "KO" thì bien tien sẽ chuyển về là 0
            LogicThanhToan.Instance.DoiGiaTriTien("KO");
            txbDuTien.SelectAll();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pctClearSymbol_Click(object sender, EventArgs e)
        {
            btnClear.Focus();
        }
        private void txbDuTien_TextChanged(object sender, EventArgs e)
        {
            lblTienKhachTra.Text = txbDuTien.Text;
            if (txbDuTien.Text == "")
                lblTienKhachTra.Text = "0";

            // tính ra số tiền tiền dư = Khách trả - Tổng cộng
            lblTienTraKhach.Text = LogicThanhToan.Instance.GetTienTraKhach(lblTienKhachTra.Text, lblTongCong.Text);


        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lblTienKhachTra.Text == "0" || Convert.ToDouble((lblTienTraKhach.Text).Replace("₫", "").Replace(".", "").Trim()) < 0)
            {
                MessageBox.Show("Chưa nhận đủ", "cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Lấy đối tượng form hiện tại
                //Form.ActiveForm lấy form đang được hiển thị trên màn hinh
                // Gồm có 3 Form đang hiển thị

                //Form currentForm = Form.ActiveForm;

                //// Kiểm tra xem form đó có phải là frGiaoDienChinh hay không
                //// Là frGiaoDienChinh đang có trong 3 form đang hiển thị không
                //if (currentForm is frGiaoDienChinh)
                //{
                //    // Ép kiểu form hiện tại về kiểu frGiaoDienChinh để sử dụng lại
                //    // là ta đang thực thi trên frGiaoDienChinh
                //    frGiaoDienChinh f = (frGiaoDienChinh)currentForm;


                //    f.lsvSanPham.BeginUpdate();
                //    f.lsvSanPham.Items.Clear();
                //    f.lsvSanPham.EndUpdate();
                //}
                this.Close();


            }

        }




        #endregion
    }
}

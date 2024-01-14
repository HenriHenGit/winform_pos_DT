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
    public partial class frNhapLogin : Form
    {
        public frNhapLogin()
        {
            InitializeComponent();
        }

        

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string pass = txtPass.Text;
            if (Login(maNV, pass))
            {
                LogicGiaoDienChinh.Instance.GetMaNV(maNV);
                
                new frGiaoDienChinh().ShowDialog();
                txtMaNV.Text = "ID nhân viên";
                txtPass.Text = "PassWord";
                txtPass.ForeColor = Color.DarkGray;
                txtMaNV.ForeColor = Color.DarkGray;
                txtPass.UseSystemPasswordChar = true;
                txtMaNV.Focus();

            }
            else
            {
                new frWarningLogin().ShowDialog();
                txtMaNV.Focus();

            }
        }
        
        bool Login(string MaNV, string pass)
        {
            return LogicNhapLogin.Instance.Login(MaNV, pass);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtMaNV_Click_1(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "ID nhân viên")
            {
                txtMaNV.Text = "";
                txtMaNV.ForeColor = Color.Black;
                if (txtPass.Text == "")
                {
                    txtPass.UseSystemPasswordChar = true;
                    txtPass.Text = "PassWord";
                    txtPass.ForeColor = Color.DarkGray;

                }
            }
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            if (txtPass.Text == "PassWord")
            {
                txtPass.UseSystemPasswordChar = false;
                txtPass.Text = "";
                txtPass.PasswordChar = '•';
                txtPass.ForeColor = Color.Black;
                if (txtMaNV.Text == "")
                {
                    txtMaNV.Text = "ID nhân viên";
                    txtMaNV.ForeColor = Color.DarkGray;
                }
            }
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMaNV.Text == "ID nhân viên")
            {
                txtMaNV.Text = "";
                txtMaNV.ForeColor = Color.Black;
                if (txtPass.Text == "")
                {
                    txtPass.UseSystemPasswordChar = true;
                    txtPass.Text = "PassWord";
                    txtPass.ForeColor = Color.DarkGray;

                }
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPass.Text == "PassWord")
            {
                txtPass.UseSystemPasswordChar = false;
                txtPass.Text = "";
                txtPass.PasswordChar = '•';
                txtPass.ForeColor = Color.Black;
                if (txtMaNV.Text == "")
                {
                    txtMaNV.Text = "ID nhân viên";
                    txtMaNV.ForeColor = Color.DarkGray;
                }
            }
        }

        private void frNhapLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

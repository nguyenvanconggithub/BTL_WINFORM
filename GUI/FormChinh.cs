using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormChinh : Form
    {
        bool lockStatus = false;
        public FormChinh()
        {
            InitializeComponent();
        }

        private void FormChinh_Load(object sender, EventArgs e)
        {
            //Setup Color in Navigation
            pnlNavigation.BackColor = Color.FromArgb(68, 68, 68);

            //set all text in Nagigation to RGB(233,213,213)
            pnlNavigation.ForeColor = Color.FromArgb(233, 213, 213);

            //set BackColor of MenuLevel1 in Navigation to RGB(73,66,66) && borderColor to RGB(142,140,140) *BUTTON MENU1*
            btnQuanLyNguoiTimViec.BackColor = Color.FromArgb(73, 66, 66);
            btnQuanLyNguoiTimViec.FlatAppearance.BorderColor = Color.FromArgb(142, 140, 140);
            btnQuanLyTuyenDung.BackColor = Color.FromArgb(73, 66, 66);
            btnQuanLyTuyenDung.FlatAppearance.BorderColor = Color.FromArgb(142, 140, 140);
            btnTimKiem.BackColor = Color.FromArgb(73, 66, 66);
            btnTimKiem.FlatAppearance.BorderColor = Color.FromArgb(142, 140, 140);
            btnThemXoaTaiKhoan.BackColor = Color.FromArgb(73, 66, 66);
            btnThemXoaTaiKhoan.FlatAppearance.BorderColor = Color.FromArgb(142, 140, 140);

            //set Color of MenuLevel2 in Navigation to RGB(68,68,68) *BUTTON MENU2*
            btnThemNguoiTimViec.BackColor = Color.FromArgb(68, 68, 68);
            btnDuyetTinMoi_TimViec.BackColor = Color.FromArgb(68, 68, 68);
            btnQuanLyTinDaDuyet_TimViec.BackColor = Color.FromArgb(68, 68, 68);
            btnThemTinTuyenDung.BackColor = Color.FromArgb(68, 68, 68);
            btnDuyetTinMoi_TuyenDung.BackColor = Color.FromArgb(68, 68, 68);
            btnQuanLyTinDaDuyet_TuyenDung.BackColor = Color.FromArgb(68, 68, 68);

            //hide the VerticalScrollBar
            pnlNavigation.VerticalScroll.Maximum = 0;
            pnlNavigation.AutoScroll = true;

            txtMatKhau.Hide();
        }

        //set all ForeColor of Button to RGB(233,213,213)
        private void clearButtonColor()
        {
            Button cpyBtn = new Button();
            foreach (object obj in pnlQuanLyNguoiTimViec.Controls)
            {
                if (obj.GetType() == cpyBtn.GetType())
                {
                    cpyBtn = obj as Button;
                }
                if (cpyBtn.ForeColor == Color.White)
                {
                    cpyBtn.ForeColor = Color.FromArgb(233, 213, 213);
                }
            }
            foreach (object obj in pnlQuanLyTuyenDung.Controls)
            {
                if (obj.GetType() == cpyBtn.GetType())
                {
                    cpyBtn = obj as Button;
                }
                if (cpyBtn.ForeColor == Color.White)
                {
                    cpyBtn.ForeColor = Color.FromArgb(233, 213, 213);
                }
            }
        }
        //set sender as button is Holderbutton 
        private void setHolderButton(object sender)
        {
            Button holderButton = sender as Button;
            clearButtonColor();
            holderButton.ForeColor = Color.White;

        }
        
        private void btnThemNguoiTimViec_Click(object sender, EventArgs e)
        {
            themNguoiTimViec.BringToFront();
            setHolderButton(sender);

            //themNguoiTimViec.Update();
        }

        private void btnDuyetTinMoi_TimViec_Click(object sender, EventArgs e)
        {
            duyetTinMoi_TimViec.BringToFront();
            setHolderButton(sender);

        }

        private void btnQuanLyTinDaDuyet_TimViec_Click(object sender, EventArgs e)
        {
            quanLyTinDaDuyet_TimViec.BringToFront();
            setHolderButton(sender);

        }

        private void btnThemTinTuyenDung_Click(object sender, EventArgs e)
        {
            themTinTuyenDung.BringToFront();
            setHolderButton(sender);

        }

        private void btnDuyetTinMoi_TuyenDung_Click(object sender, EventArgs e)
        {
            duyetTinMoi_TuyenDung.BringToFront();
            setHolderButton(sender);

        }

        private void btnQuanLyTinDaDuyet_TuyenDung_Click(object sender, EventArgs e)
        {
            quanLyTinDaDuyet_TuyenDung.BringToFront();
            setHolderButton(sender);

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            timKiem.BringToFront();
            clearButtonColor();
        }

        private void btnThemXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            themXoaTaiKhoan.BringToFront();
            clearButtonColor();
        }
        
        private void ptbLock_Click(object sender, EventArgs e)
        {
            //lock all content when pictureBox Lock(ptbLock) is clicked
            if(lockStatus == false)
            {
                ptbLock.Image = Properties.Resources._lock;
                lockStatus = true;
                pnlContent.Enabled = false;
                pnlQuanLyNguoiTimViec.Enabled = false;
                pnlQuanLyTuyenDung.Enabled = false;
                pnlThemXoaTaiKhoan.Enabled = false;
                pnlTimKiem.Enabled = false;
                txtMatKhau.Text = "Nhập mật khẩu cho: " + lblTaiKhoan.Text;
                txtMatKhau.ForeColor = Color.LightGray;
                txtMatKhau.Show();
            }
           
            if (lockStatus == true && txtMatKhau.Text != "password" && txtMatKhau.Text != "Nhập mật khẩu cho: " + lblTaiKhoan.Text)
                txtMatKhau.ForeColor = Color.Red;
            //enable all content when password is correct
            if(lockStatus == true && txtMatKhau.Text == "password")
            {
                ptbLock.Image = Properties.Resources.unlock;
                lockStatus = false;
                pnlContent.Enabled = true;
                pnlQuanLyNguoiTimViec.Enabled = true;
                pnlQuanLyTuyenDung.Enabled = true;
                pnlThemXoaTaiKhoan.Enabled = true;
                pnlTimKiem.Enabled = true;
                txtMatKhau.Hide();
            }
        }

        private void lblDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void FormChinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            txtMatKhau.Clear();
            txtMatKhau.ForeColor = Color.Black;
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau.ForeColor = Color.Black;
        }

        private void txtMatKhau_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                ptbLock_Click(sender, e);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanlyDontu
{
    public partial class Login : Form
    {
        TestDBEntities context = new TestDBEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            var account = txtTendangnhap.Text;
            var password = txtMatkhau.Text;
            var checkNV = context.tblNhanviens.Where(x => x.ma_nhan_vien == account && x.mat_khau == password).FirstOrDefault();
            if (checkNV != null)
            {
                this.Hide();
                MainForm mainForm = new MainForm();
                MainForm.type = "nv";
                mainForm.Show();
            }
            else
            {
                var checkSV = context.tblSinhviens.Where(x => x.ma_sinh_vien == account && x.mat_khau == password).FirstOrDefault();
                if (checkSV != null)
                {
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    MainForm.type = "sv";
                    mainForm.Show();
                }
                else
                    MessageBox.Show("Thất bại", "Đăng nhập không thành công");
            }

        }
    }
}

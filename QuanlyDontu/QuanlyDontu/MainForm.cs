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
    public partial class MainForm : Form
    {
        public static string type = "nv";
        public MainForm()
        {
            InitializeComponent();
            if (type == "sv")
            {
                quảnLýToolStripMenuItem.Visible = false;
                thốngKêToolStripMenuItem.Visible = false;
            }
                
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        { 
            Application.Exit();
        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSinhvien sinhvien = new fSinhvien();
            sinhvien.Show();
            sinhvien.MdiParent = this;
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhanvien fnhanvien = new fNhanvien();
            fnhanvien.Show();
            fnhanvien.MdiParent = this;
        }

        private void quảnLýPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPhongban fPhongban = new fPhongban();
            fPhongban.Show();
            fPhongban.MdiParent = this;
        }

        private void quảnLýĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDontu fDontu = new fDontu();
            fDontu.Show();
            fDontu.MdiParent = this;
        }

        private void quảnLýLoạiĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fLoaidontu fDontu = new fLoaidontu();
            fDontu.Show();
            fDontu.MdiParent = this;
        }

        private void chàoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KiemtraDontu fkiemtra = new KiemtraDontu();
            fkiemtra.Show();
            fkiemtra.MdiParent = this;
        }

        private void sinhVieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thongke1 thongke = new Thongke1();
            thongke.Show();
            thongke.MdiParent = this;
        }
    }
}

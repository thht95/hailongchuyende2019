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
        public static string type;
        public MainForm()
        {
            InitializeComponent();
            if (type == "sv")
                quảnLýToolStripMenuItem.Visible = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        { 
            Application.Exit();
        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSinhvien sinhvien = new fSinhvien();
        }
    }
}

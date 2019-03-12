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
    public partial class KiemtraDontu : Form
    {
        TestDBEntities context = new TestDBEntities();
        public KiemtraDontu()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string txt = txtSearch.Text;
            int iTxt = Convert.ToInt32(txt); 
            if (MainForm.type == "nv")
            {
                var list = context.tblDontus.Where(x => x.ID == iTxt).ToList();
                dataGridView1.DataSource = list;
            }
            else
            {
                var list = context.tblDontus.Where(x => x.ID == iTxt).ToList();
            }
        }
    }
}

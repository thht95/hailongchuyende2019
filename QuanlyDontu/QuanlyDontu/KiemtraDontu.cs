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
                var list = context.tblDontus.Where(x => x.ID == iTxt || x.FK_SinhvienID == iTxt).ToList();
                dgvDontu.DataSource = list;
            }
            else
            {
                var list = context.tblDontus.Where(x => x.ID == iTxt).ToList();
            }
        }

        private void dgvDontu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 10)
                {
                    e.Value = ((tblNhanvien)e.Value).ho_va_ten;
                }

                if (e.ColumnIndex == 9)
                {
                    e.Value = ((tblLoaiDontu)e.Value).TenLoai;
                }

                if (e.ColumnIndex == 11)
                {
                    e.Value = ((tblSinhvien)e.Value).ho_va_ten;
                }

            }
        }
    }
}

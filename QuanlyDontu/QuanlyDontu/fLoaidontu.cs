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
    public partial class fLoaidontu : Form
    {
        TestDBEntities context = new TestDBEntities();
        public fLoaidontu()
        {
            InitializeComponent();
            dgvLoaidon.AutoGenerateColumns = false;

            reloadDgv();
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            if (txtTimkiem.Text == "Gõ một cái gì đó để tìm một cái gì đó")
            {
                txtTimkiem.Text = "";
                txtTimkiem.Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }

        private void txtTimkiem_Leave(object sender, EventArgs e)
        {
            if (txtTimkiem.Text == "")
            {
                txtTimkiem.Font = new Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtTimkiem.Text = "Gõ một cái gì đó để tìm một cái gì đó";
            }
        }

        private void Search(string keyword)
        {
            int int_keyword;

            var checkInt = int.TryParse(keyword, out int_keyword);
            var temp_result1 = context.tblLoaiDontus.Where(x => x.TenLoai.Contains(keyword)

            ).ToList();

            var temp_result2 = new List<tblLoaiDontu>();

            if (checkInt)
            {
                temp_result2 = context.tblLoaiDontus.Where(x => x.ID == int_keyword).ToList();
            }

            dgvLoaidon.DataSource = temp_result1.Union(temp_result2).ToList();
        }

        private void txtTimkiem_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var keyword = txtTimkiem.Text;
                Search(keyword);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var keyword = txtTimkiem.Text;
            Search(keyword);
        }

        private void reloadDgv()
        {
            dgvLoaidon.DataSource = context.tblNhanviens.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tblLoaiDontu nhanvien = new tblLoaiDontu();

            nhanvien.TenLoai = txtTenLoai.Text;
        
            reloadDgv();
        }

        private void dgvSinhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var col_index = e.ColumnIndex;
            var row_index = e.RowIndex;

            if (row_index >= 0)
            {
                txtID.Text = dgvLoaidon[0, row_index].Value.ToString();
                txtTenLoai.Text = dgvLoaidon[1, row_index].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Chọn 1 loại đơn để sửa");
            }
            else
            {
                var id = Convert.ToInt32(txtID.Text);

                tblLoaiDontu nhanvien = context.tblLoaiDontus.Where(x => x.ID == id).FirstOrDefault();

                nhanvien.TenLoai = txtTenLoai.Text;

                
                context.SaveChanges();

                reloadDgv();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Chọn 1 loại đơn để xóa");
            }
            else
            {
                var id = Convert.ToInt32(txtID.Text);

                tblLoaiDontu nhanvien = context.tblLoaiDontus.Where(x => x.ID == id).FirstOrDefault();
                context.tblLoaiDontus.Remove(nhanvien);
                context.SaveChanges();
                reloadDgv();
            }
        }

        private void dgvNhanvien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                e.Value = ((tblPhongban)e.Value).Ten_phong_ban;
            }
        }
    }
}

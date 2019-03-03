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
    public partial class fPhongban : Form
    {
        TestDBEntities context = new TestDBEntities();
        public fPhongban()
        {

            InitializeComponent();
            dgvPhongban.AutoGenerateColumns = false;
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
            
            var temp_result1 = context.tblPhongbans.Where(x => x.Ten_phong_ban.Contains(keyword)).ToList();
            var temp_result2 = new List<tblPhongban>();

            if (checkInt)
            {
                temp_result2 = context.tblPhongbans.Where(x => x.ID == int_keyword).ToList();
            }

            dgvPhongban.DataSource = temp_result1.Union(temp_result2).ToList();
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
            dgvPhongban.DataSource = context.tblPhongbans.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tblPhongban phongban = new tblPhongban();

            phongban.Ma_phong_ban = txtMaPB.Text;
            phongban.Ten_phong_ban = txtTenphongban.Text;

            context.tblPhongbans.Add(phongban);
            context.SaveChanges();

            reloadDgv();
        }

        private void dgvSinhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var col_index = e.ColumnIndex;
            var row_index = e.RowIndex;

            if (row_index >= 0)
            {
                txtID.Text = dgvPhongban[0, row_index].Value.ToString();
                txtMaPB.Text = dgvPhongban[1, row_index].Value.ToString();
                txtTenphongban.Text = dgvPhongban[2, row_index].Value.ToString();
            }
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Chọn 1 phòng ban để sửa");
            }
            else
            {
                var id = Convert.ToInt32(txtID.Text);


                tblPhongban phongban = context.tblPhongbans.Where(x => x.ID == id).FirstOrDefault();

                phongban.Ma_phong_ban = txtMaPB.Text;
                phongban.Ten_phong_ban = txtTenphongban.Text;

                context.SaveChanges();
                reloadDgv();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Chọn 1 phòng ban để xóa");
            }
            else
            {
                var id = Convert.ToInt32(txtID.Text);

                tblPhongban phongban = context.tblPhongbans.Where(x => x.ID == id).FirstOrDefault();
                context.tblPhongbans.Remove(phongban);
                context.SaveChanges();
                reloadDgv();
            }
        }
    }
}

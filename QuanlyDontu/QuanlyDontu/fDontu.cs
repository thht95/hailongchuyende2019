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
    public partial class fDontu : Form
    {
        TestDBEntities context = new TestDBEntities();
        public fDontu()
        {
            InitializeComponent();
            dgvNhanvien.AutoGenerateColumns = false;

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
            var temp_result1 = context.tblNhanviens.Where(x => x.mat_khau.Contains(keyword)
                                    || x.ma_nhan_vien.Contains(keyword)
                                    || x.ho_va_ten.Contains(keyword)
                                    || x.email.Contains(keyword)
            ).ToList();

            var temp_result2 = new List<tblNhanvien>();

            if (checkInt)
            {
                temp_result2 = context.tblNhanviens.Where(x => x.ID == int_keyword || x.so_dien_thoai == int_keyword).ToList();
            }

            dgvNhanvien.DataSource = temp_result1.Union(temp_result2).ToList();
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
            dgvNhanvien.DataSource = context.tblNhanviens.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tblNhanvien nhanvien = new tblNhanvien();

            nhanvien.ma_nhan_vien = txtMaSV.Text;
            nhanvien.mat_khau = txtMatkhau.Text;
            nhanvien.email = txtEmail.Text;
            nhanvien.ho_va_ten = txtHovaTen.Text;
            nhanvien.so_dien_thoai = Convert.ToInt32(txtSodienthoai.Text);
            nhanvien.FK_PhongbanID = Convert.ToInt32(cbbPhongban.SelectedValue);

            context.tblNhanviens.Add(nhanvien);
            context.SaveChanges();

            reloadDgv();
        }

        private void dgvSinhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var col_index = e.ColumnIndex;
            var row_index = e.RowIndex;

            if (row_index >= 0)
            {
                txtID.Text = dgvNhanvien[0, row_index].Value.ToString();
                txtMaSV.Text = dgvNhanvien[1, row_index].Value.ToString();
                txtMatkhau.Text = dgvNhanvien[2, row_index].Value.ToString();
                txtEmail.Text = dgvNhanvien[3, row_index].Value.ToString();
                txtHovaTen.Text = dgvNhanvien[4, row_index].Value.ToString();
                txtSodienthoai.Text = dgvNhanvien[5, row_index].Value.ToString();
                cbbPhongban.SelectedIndex = Convert.ToInt32(dgvNhanvien[6, row_index].Value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Chọn 1 nhân viên để sửa");
            }
            else
            {
                var id = Convert.ToInt32(txtID.Text);

                tblNhanvien nhanvien = context.tblNhanviens.Where(x => x.ID == id).FirstOrDefault();

                nhanvien.ma_nhan_vien = txtMaSV.Text;
                nhanvien.mat_khau = txtMatkhau.Text;
                nhanvien.email = txtEmail.Text;
                nhanvien.ho_va_ten = txtHovaTen.Text;
                nhanvien.so_dien_thoai = Convert.ToInt32(txtSodienthoai.Text);
                nhanvien.FK_PhongbanID = Convert.ToInt32(cbbPhongban.SelectedValue);
                
                context.SaveChanges();

                reloadDgv();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Chọn 1 nhân viên để xóa");
            }
            else
            {
                var id = Convert.ToInt32(txtID.Text);

                tblNhanvien nhanvien = context.tblNhanviens.Where(x => x.ID == id).FirstOrDefault();
                context.tblNhanviens.Remove(nhanvien);
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

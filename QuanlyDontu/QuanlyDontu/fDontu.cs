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
            dgvDontu.AutoGenerateColumns = false;
                
            reloadDgv();
            reloadLoaiDon();
            reloadNV();
            reloadSV();
        }

        private void reloadLoaiDon()
        {
            cbbLoaidon.DataSource = context.tblLoaiDontus.ToList();
            cbbLoaidon.DisplayMember = "TenLoai";
            cbbLoaidon.ValueMember = "ID";
        }

        private void reloadNV()
        {
            cbbNV.DataSource = context.tblNhanviens.ToList();
            cbbNV.DisplayMember = "ho_va_ten";
            cbbNV.ValueMember = "ID";
        }

        private void reloadSV()
        {
            cbbSV.DataSource = context.tblSinhviens.ToList();
            cbbSV.DisplayMember = "ho_va_ten";
            cbbSV.ValueMember = "ID";
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

            dgvDontu.DataSource = temp_result1.Union(temp_result2).ToList();
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
            dgvDontu.DataSource = context.tblDontus.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dtpNgaytao.Value > dtpNgayXuly.Value)
            {
                MessageBox.Show("Ngày tạo không được nhỏ hơn ngày cập nhật");
            }
            else
            {
                tblDontu dontu = new tblDontu();

                dontu.Ten = txtTen.Text;
                dontu.Noidung = txtNoidung.Text;
                dontu.Ngaytao = dtpNgaytao.Value;
                dontu.Ngaycapnhat = dtpNgayXuly.Value;
                dontu.Trangthai = txtTrangthai.Text;
                dontu.FK_LoaiDonTuID = Convert.ToInt32(cbbLoaidon.SelectedValue);
                dontu.FK_NhanvienID = Convert.ToInt32(cbbNV.SelectedValue);
                dontu.FK_SinhvienID = Convert.ToInt32(cbbSV.SelectedValue);

                context.tblDontus.Add(dontu);
                context.SaveChanges();

                reloadDgv();
            }
        }

        private void dgvSinhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var col_index = e.ColumnIndex;
            var row_index = e.RowIndex;

            if (row_index >= 0)
            {
                txtID.Text = dgvDontu[0, row_index].Value.ToString();
                txtTen.Text = dgvDontu[1, row_index].Value.ToString();
                txtNoidung.Text = dgvDontu[2, row_index].Value.ToString();
                dtpNgaytao.Value = Convert.ToDateTime(dgvDontu[3, row_index].Value);
                dtpNgayXuly.Value = Convert.ToDateTime(dgvDontu[4, row_index].Value);
                cbbLoaidon.SelectedValue = dgvDontu[5, row_index].Value.ToString();
                cbbNV.SelectedValue = dgvDontu[6, row_index].Value;
                cbbSV.SelectedValue = dgvDontu[7, row_index].Value;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Chọn 1 dơn từ để sửa");
            }
            else
            {
                if (dtpNgaytao.Value > dtpNgayXuly.Value)
                {
                    MessageBox.Show("Ngày tạo không được nhỏ hơn ngày cập nhật");
                }
                else
                {
                    var id = Convert.ToInt32(txtID.Text);

                    tblDontu dontu = context.tblDontus.Where(x => x.ID == id).FirstOrDefault();

                    dontu.Ten = txtTen.Text;
                    dontu.Noidung = txtNoidung.Text;
                    dontu.Ngaytao = dtpNgaytao.Value;
                    dontu.Ngaycapnhat = dtpNgayXuly.Value;
                    dontu.Trangthai = txtTrangthai.Text;
                    dontu.FK_LoaiDonTuID = Convert.ToInt32(cbbLoaidon.SelectedValue);
                    dontu.FK_NhanvienID = Convert.ToInt32(cbbNV.SelectedValue);
                    dontu.FK_SinhvienID = Convert.ToInt32(cbbSV.SelectedValue);

                    context.SaveChanges();

                    reloadDgv();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Chọn 1 dơn từ để xóa");
            }
            else
            {
                var id = Convert.ToInt32(txtID.Text);

                tblDontu dontu = context.tblDontus.Where(x => x.ID == id).FirstOrDefault();
                context.tblDontus.Remove(dontu);
                context.SaveChanges();
                reloadDgv();
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

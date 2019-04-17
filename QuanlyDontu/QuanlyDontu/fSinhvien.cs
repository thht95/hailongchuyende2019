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
    public partial class fSinhvien : Form
    {
        TestDBEntities context = new TestDBEntities();
        public fSinhvien()
        {

            InitializeComponent();
            dgvSinhvien.AutoGenerateColumns = false;
            var list_all_sv = context.tblSinhviens.ToList();
            dgvSinhvien.DataSource = list_all_sv;
            
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
            DateTime date_keyword;

            var checkInt = int.TryParse(keyword, out int_keyword);
            var checkDate = DateTime.TryParse(keyword, out date_keyword);
            var result = new List<tblSinhvien>(); 
            var temp_result = context.tblSinhviens.Where(x => x.mat_khau.Contains(keyword)
                                    || x.ma_sinh_vien.Contains(keyword)
                                    || x.ho_va_ten.Contains(keyword)
                                    || x.noi_sinh.Contains(keyword)
                                    || x.cmnd.Contains(keyword)
                                    || x.email.Contains(keyword)
            );

            if (checkInt)
            {
                temp_result = temp_result.Where(x => true || x.ID == int_keyword);
            }
            
            if (checkDate)
            {
                temp_result = temp_result.Where(x => true || x.ngay_sinh == date_keyword);
            }

            if (keyword.ToLower() == "nam")
            {
                result = temp_result.Where(x => x.gioi_tinh == true).ToList();
            }
            else if (keyword.ToLower() == "nu" || keyword.ToLower() == "nữ")
            {
                result = temp_result.Where(x => x.gioi_tinh == false).ToList();
            }
            else
            {
                result = temp_result.ToList();
            }

            dgvSinhvien.DataSource = result;
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
            dgvSinhvien.DataSource = context.tblSinhviens.ToList();
        }

        private bool checkTrungSV(string masv)
        {
            var check = context.tblSinhviens.Where(x => x.ma_sinh_vien == masv).FirstOrDefault();
            return (check != null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkTrungSV(txtMaSV.Text))
            {
                MessageBox.Show("Đã có mã sinh viên này");
            }
            else
            {
                tblSinhvien sinhvien = new tblSinhvien();

                sinhvien.ma_sinh_vien = txtMaSV.Text;
                sinhvien.mat_khau = txtMatkhau.Text;
                sinhvien.email = txtEmail.Text;
                sinhvien.ho_va_ten = txtHovaTen.Text;
                sinhvien.ngay_sinh = dtpNgaysinh.Value.Date;
                sinhvien.gioi_tinh = Convert.ToBoolean(cbbGioitinh.SelectedIndex);
                sinhvien.noi_sinh = txtNoisinh.Text;
                sinhvien.cmnd = txtCMND.Text;

                context.tblSinhviens.Add(sinhvien);
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
                txtID.Text = dgvSinhvien[0, row_index].Value.ToString();
                txtMaSV.Text = dgvSinhvien[1, row_index].Value.ToString();
                txtMatkhau.Text = dgvSinhvien[2, row_index].Value.ToString();
                txtEmail.Text = dgvSinhvien[3, row_index].Value.ToString();
                txtHovaTen.Text = dgvSinhvien[4, row_index].Value.ToString();
                dtpNgaysinh.Value = Convert.ToDateTime(dgvSinhvien[5, row_index].Value);
                cbbGioitinh.SelectedIndex = Convert.ToInt32(dgvSinhvien[6, row_index].Value);
                txtNoisinh.Text = dgvSinhvien[7, row_index].Value.ToString();
                txtCMND.Text = dgvSinhvien[8, row_index].Value.ToString();
            }
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Chọn 1 Sinh viên để sửa");
            }
            else
            {
                var id = Convert.ToInt32(txtID.Text);
                tblSinhvien sinhvien = context.tblSinhviens.Where(x => x.ID == id).FirstOrDefault();

                if (sinhvien.ma_sinh_vien != txtMaSV.Text)
                {
                    if (checkTrungSV(txtMaSV.Text))
                    {
                        MessageBox.Show("Đã có mã sinh viên này");
                        return;
                    }
                }

                sinhvien.ma_sinh_vien = txtMaSV.Text;
                sinhvien.mat_khau = txtMatkhau.Text;
                sinhvien.email = txtEmail.Text;
                sinhvien.ho_va_ten = txtHovaTen.Text;
                sinhvien.ngay_sinh = dtpNgaysinh.Value.Date;
                sinhvien.gioi_tinh = Convert.ToBoolean(cbbGioitinh.SelectedIndex);
                sinhvien.noi_sinh = txtNoisinh.Text;
                sinhvien.cmnd = txtCMND.Text;

                context.SaveChanges();

                reloadDgv();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Chọn 1 Sinh viên để xóa");
            }
            else
            {
                var id = Convert.ToInt32(txtID.Text);

                tblSinhvien sinhvien = context.tblSinhviens.Where(x => x.ID == id).FirstOrDefault();
                context.tblSinhviens.Remove(sinhvien);
                context.SaveChanges();
                reloadDgv();
            }
        }

        private void dgvSinhvien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 5)
                {
                    e.Value = string.Format("{0:d/M/yyyy}", e.Value);
                }
            }
        }
    }
}

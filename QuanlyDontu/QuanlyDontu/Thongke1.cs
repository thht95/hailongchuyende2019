using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanlyDontu
{
    public partial class Thongke1 : Form
    {
        TestDBEntities context = new TestDBEntities();

        public Thongke1()
        {
            InitializeComponent();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void Thongke1_Load(object sender, EventArgs e)
        {
            //ReportDocument rptDoc = new ReportDocument();
            //string reportPath = Application.StartupPath + "\\" + "CrystalReport1.rpt";
            var list = context.tblSinhviens.Where(x => x.gioi_tinh == true).ToList();

            //DataTable dt = ToDataTable(list);
            //MessageBox.Show(dt.Rows.Count + "");
            //rptDoc.Load(reportPath);
            //rptDoc.SetDataSource(dt);

            SqlConnection cnn = new SqlConnection("data source=.;initial catalog=TestDB;integrated security=True");
            cnn.Open();
            SqlCommand cmd = new SqlCommand("select * from tblSinhvien where Gioi_tinh = 1", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dt.Rows[i][6] = "Nam";
            //}


            
            CrystalReport1 crystalReport = new CrystalReport1();
            crystalReport.SetDataSource(dt);
            crystalReportViewer1.ReportSource = crystalReport;
            crystalReportViewer1.Refresh();
        }

        public DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("data source=.;initial catalog=TestDB;integrated security=True");
            cnn.Open();
            string data = textBox1.Text; 
            SqlCommand cmd = new SqlCommand("select * from tblSinhvien where ID = "+ data + " OR masinhvien LIKE '%"+ data + "%'", cnn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            CrystalReport1 crystalReport = new CrystalReport1();
            crystalReport.SetDataSource(dt);
            crystalReportViewer1.ReportSource = crystalReport;
            crystalReportViewer1.Refresh();
        }
    }
}

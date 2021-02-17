using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace WindowsFormsApp1
{
    public partial class reportSoldItems : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        formSoldItems frpt;
        public reportSoldItems(formSoldItems frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            frpt = frm;
        }

        private void reportSoldItems_Load(object sender, EventArgs e)
        {

        }

        public void LoadReport()
        {
            try
            {
                ReportDataSource rptDS;

                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report2.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                if(frpt.cboCashier.Text == "All Cashierss")
                {
                    da.SelectCommand = new SqlCommand("select c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total from tblCart as c inner join tblProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between'" + frpt.dt1.Value.ToString() + "' and '" + frpt.dt2.Value.ToString() + "'", cn);
                }
                else
                {
                    da.SelectCommand = new SqlCommand("select c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total from tblCart as c inner join tblProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between'" + frpt.dt1.Value.ToString() + "' and '" + frpt.dt2.Value.ToString() + "'and cashier like'" + frpt.cboCashier.Text + "'", cn);
                }
                da.Fill(ds.Tables["dtSoldItems"]);
                cn.Close();
                ReportParameter pDate = new ReportParameter("pDate", "Date From: " + frpt.dt1.Value.ToShortDateString() + " To: " + frpt.dt2.Value.ToShortDateString());
                ReportParameter pCashier = new ReportParameter("pCashier", "Cashier: " + frpt.cboCashier.Text);
                ReportParameter pHeader = new ReportParameter("pHeader", "SALES REPORT");

                reportViewer1.LocalReport.SetParameters(pDate);
                reportViewer1.LocalReport.SetParameters(pCashier);
                reportViewer1.LocalReport.SetParameters(pHeader);

                rptDS = new ReportDataSource("DataSet1", ds.Tables["dtSoldItems"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
            } catch(Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void formBrand_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}

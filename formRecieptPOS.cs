using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class formRecieptPOS : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        //SqlDataReader dr;
        string store = "Sakhar Cash and Carry";
        string address = "Sakhar";

        POS fpos;
        public formRecieptPOS(POS frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            fpos = frm;
        }

        private void formRecieptPOS_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer3_Load(object sender, EventArgs e)
        {

        }

        public void LoadReport(string pcash, string pchange)
        {
            ReportDataSource rptDataSource;
            try
            {
                this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\Report1.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                da.SelectCommand = new SqlCommand("select c.id, c.transno, c.pcode, c.price, c.qty, c.disc, c.total, c.sdate, c.status, p.pdesc, c.cashier from tblCart as c inner join tblProduct as p on c.pcode = p.pcode where transno like '"+fpos.lblTransaction.Text+"'", cn);
                da.Fill(ds.Tables["dtSold"]);
                cn.Close();

                ReportParameter pVatable = new ReportParameter("pVatable", fpos.lblVatable.Text);
                ReportParameter pVat = new ReportParameter("pVat", fpos.lblVat.Text);
                ReportParameter pDiscount = new ReportParameter("pDiscount", fpos.lblDiscount.Text);
                ReportParameter pTotal = new ReportParameter("pTotal", fpos.lblTotal.Text);
                ReportParameter pCash = new ReportParameter("pCash", pcash);
                ReportParameter pChange = new ReportParameter("pChange", pchange);
                ReportParameter pStore = new ReportParameter("pStore", store);
                ReportParameter pAddress = new ReportParameter("pAddress", address);
                ReportParameter pCashier = new ReportParameter("pCashier", fpos.lblName.Text);
                ReportParameter pTransaction = new ReportParameter("pTransaction","Invoice # : "+ fpos.lblTransaction.Text);


                reportViewer1.LocalReport.SetParameters(pVatable);
                reportViewer1.LocalReport.SetParameters(pVat);
                reportViewer1.LocalReport.SetParameters(pDiscount);
                reportViewer1.LocalReport.SetParameters(pTotal);
                reportViewer1.LocalReport.SetParameters(pCash);
                reportViewer1.LocalReport.SetParameters(pChange);
                reportViewer1.LocalReport.SetParameters(pStore);
                reportViewer1.LocalReport.SetParameters(pAddress);
                reportViewer1.LocalReport.SetParameters(pCashier);
                reportViewer1.LocalReport.SetParameters(pTransaction);



                rptDataSource = new ReportDataSource("DataSet1", ds.Tables["dtSold"]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSource);
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;


               

            }
           catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}

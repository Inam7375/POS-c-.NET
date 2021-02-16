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

namespace WindowsFormsApp1
{
    public partial class formSoldItems : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        public formSoldItems()
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            dt1.Value = DateTime.Now;
            dt2.Value = DateTime.Now;
            LoadRecords();
        }

        public void LoadRecords()
        {
            try
            {
                int i =  0;
                double _total = 0;
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total from tblCart as c inner join tblProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between'"+dt1.Value.ToString()+"' and '"+dt2.Value.ToString()+"'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    _total += Double.Parse(dr["total"].ToString());
                    dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["transno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), dr["total"].ToString(), cn);

                }
                dr.Close();
                cn.Close();
                lblTotal.Text = _total.ToString();
            } catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void formBrand_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dt1_ValueChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void dt2_ValueChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            reportSoldItems rpt = new reportSoldItems(this);
            rpt.LoadReport();
            rpt.ShowDialog();
        }
    }
}

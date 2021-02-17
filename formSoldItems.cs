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
        POS fpos;
        SqlDataReader dr;
        public formSoldItems(POS frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            dt1.Value = DateTime.Now;
            dt2.Value = DateTime.Now;
            LoadRecords();
            LoadCashier();
            fpos = frm;
        }

        public void LoadRecords()
        {
            try
            {
                int i =  0;
                double _total = 0;
                dataGridView1.Rows.Clear();
                cn.Open();
                if (cboCashier.Text == "All Cashiers") {
                    cm = new SqlCommand("select c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total from tblCart as c inner join tblProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between'" + dt1.Value.ToString() + "' and '" + dt2.Value.ToString() + "'", cn);
                } else
                {
                    cm = new SqlCommand("select c.id, c.transno, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total from tblCart as c inner join tblProduct as p on c.pcode = p.pcode where status like 'Sold' and sdate between'" + dt1.Value.ToString() + "' and '" + dt2.Value.ToString() + "' and cashier like '" + cboCashier.Text + "'", cn);
                }
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    _total += Double.Parse(dr["total"].ToString());
                    dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["transno"].ToString(), dr["pcode"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), dr["total"].ToString(), "Cancel", cn);

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

        private void cboCashier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void cboCashier_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        public void LoadCashier()
        {
            cboCashier.Items.Clear();
            cboCashier.Items.Add("All Cashiers");
            cn.Open();
            cm = new SqlCommand("select * from tbluser where role like 'Cashier'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cboCashier.Items.Add(dr["name"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colCancel")
            {
                formCancelDetails frm = new formCancelDetails(this);
                frm.txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                frm.txtTransNo.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                frm.txtPCode.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                frm.txtDesc.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                frm.txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                frm.txtQty.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                frm.txtDiscount.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                frm.txtTotal.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                frm.txtCancel.Text = fpos.lblName.Text.Substring(0, fpos.lblName.Text.IndexOf(" |"));
                frm.ShowDialog();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void dt2_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class POS : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        string stitle = "POS System";

        public POS()
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            lblDate.Text = DateTime.Now.ToLongDateString();
            this.KeyPreview = true;

        }

        private void getTransNo ()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                string transno;
                int count;
                cn.Open();
                cm = new SqlCommand("select top 1 transno from tblCart where transno like '"+sdate+"%' order by id desc", cn);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows) { 
                    transno = dr[0].ToString();
                    count = int.Parse(transno.Substring(8));
                    lblTransaction.Text = sdate + (count + 2);
                } else { 
                    transno = sdate + "0001";
                    lblTransaction.Text = transno;
                }
                dr.Close();
                cn.Close();
                


            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void LoadCart()
        {
            try
            {
                dataGridView1.Rows.Clear();
                int i = 0;
                double total = 0;
                cn.Open();
                cm = new SqlCommand("select c.id, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total from tblCart as c inner join tblProduct as p on c.pcode = p.pcode where transno like'"+lblTransaction.Text+"'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    total += Double.Parse(dr["total"].ToString());
                    dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["qty"].ToString(), dr["disc"].ToString(), Double.Parse(dr["total"].ToString()).ToString("#,##0.00"), "Delete");

                }
                dr.Close();
                cn.Close();
                lblSales.Text = total.ToString("#,##0.00");
                GetCartTotal();
            } catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void GetCartTotal()
        {
            double sales = Double.Parse(lblSales.Text);
            double discount = 0;
            double vat = sales * dbCon.GetVal();
            double vatable = sales - vat;
            lblVat.Text = vat.ToString("#,##0.00");
            lblVatable.Text = vatable.ToString("#,##0.00");
        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void formBrand_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            getTransNo();
            txtSearch.Enabled = true;
            txtSearch.Focus();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_TabStopChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            { 
                if (txtSearch.Text == String.Empty) { return; }
                else
                {
                    cn.Open();
                    cm = new SqlCommand("select * from tblProduct where barcode like '" + txtSearch.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        formQty frm = new formQty(this);
                        frm.ProductDetails(dr["pcode"].ToString(), double.Parse(dr["price"].ToString()), lblTransaction.Text);
                        dr.Close();
                        cn.Close();
                        frm.ShowDialog();

                    }
                    else
                    {
                        dr.Close();
                        cn.Close();
                    }

                    
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }  
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (lblTransaction.Text == "0000000000") { return; }
            formLookUp frm = new formLookUp(this);
            frm.LoadRecords();
            frm.ShowDialog(); 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colName == "Delete")
            {
                if(MessageBox.Show("Remove this item?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from tblCart where id like '"+dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()+"'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Record deleted succesfully", stitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCart();
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

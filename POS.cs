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
        string id;
        string price;
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
            labelDate.Text = DateTime.Now.ToLongDateString();
            this.KeyPreview = true;

        }

        public void getTransNo ()
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
                Boolean hasrecord = false;
                dataGridView1.Rows.Clear();
                int i = 0;
                double total = 0;
                double discount = 0;
                cn.Open();
                cm = new SqlCommand("select c.id, c.pcode, p.pdesc, c.price, c.qty, c.disc, c.total from tblCart as c inner join tblProduct as p on c.pcode = p.pcode where transno like'"+lblTransaction.Text+"'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    total += Double.Parse(dr["total"].ToString());
                    discount += Double.Parse(dr["disc"].ToString());
                    dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["pdesc"].ToString(), dr["price"].ToString(), dr["disc"].ToString(), dr["qty"].ToString(), Double.Parse(dr["total"].ToString()).ToString("#,##0.00"), "Delete", dr["pcode"].ToString());
                    hasrecord = true;
                }
                dr.Close();
                cn.Close();
                lblSales.Text = total.ToString("#,##0.00");
                lblDiscount.Text = discount.ToString("#,##0.00");
                GetCartTotal();
                if (hasrecord == true) {
                    btnPayment.Enabled = true;
                    btnDiscount.Enabled = true;
                } else {
                    btnPayment.Enabled = false;
                    btnDiscount.Enabled = false;
                }
            } catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void GetCartTotal()
        {
            double discount = Double.Parse(lblDiscount.Text);
            double sales = Double.Parse(lblSales.Text) - discount;
            double vat = sales * dbCon.GetVal();
            double vatable = sales - vat;
            //lblSales.Text = sales.ToString("#,##0.00");
            lblVat.Text = vat.ToString("#,##0.00");
            lblVatable.Text = vatable.ToString("#,##0.00");
            lblTotal.Text = sales.ToString("#,##0.00");
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
            if(dataGridView1.Rows.Count > 0)
            {
                return;
            }
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
            if (dataGridView1.Rows.Count > 0)
            {
                MessageBox.Show("Unable to logout. Please cancel transaction", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(MessageBox.Show("You want to logout?","Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                formSecurity frm = new formSecurity();
                frm.ShowDialog();
            }
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            id = dataGridView1[1, i].Value.ToString();
            price = dataGridView1[3, i].Value.ToString();

        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            formDiscount frm = new formDiscount(this);
            frm.lblID.Text = id;
            frm.txtPrice.Text = price;
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            formSettle frm = new formSettle(this);
            frm.txtSale.Text = lblTotal.Text;
            frm.ShowDialog();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            formSoldItems frm = new formSoldItems(this);
            frm.dt1.Enabled = false;
            frm.dt2.Enabled = false;
            frm.cboCashier.Enabled = false;
            frm.cboCashier.Text = lblName.Text.Substring(0, lblName.Text.IndexOf(" |"));
            frm.ShowDialog();
        }
    }
}

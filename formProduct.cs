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
    public partial class formProduct : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        formProductList flist;

        public formProduct(formProductList frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            flist = frm;
        }

        public void loadCategory()
        {
            try
            {
                catCombo.Items.Clear();
                cn.Open();
                cm = new SqlCommand("select category from tblCategory", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    catCombo.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cn.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void loadBrand()
        {
            try
            {
                brandCombo.Items.Clear();
                cn.Open();
                cm = new SqlCommand("select brand from tblBrand", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    brandCombo.Items.Add(dr[0].ToString());
                }
                dr.Close();
                cn.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formProduct_Load(object sender, EventArgs e)
        {

        }

        private void formBrand_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add this product?", "Save Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                {
                    try
                    {
                        string bid = "";
                        string cid = "";
                        cn.Open();
                        cm = new SqlCommand("select id from tblBrand where Brand like '" + brandCombo.Text + "'", cn);
                        dr = cm.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows) { bid = dr[0].ToString(); }
                        dr.Close();
                        cn.Close();

                        cn.Open();
                        cm = new SqlCommand("select id from tblCategory where Category like '" + catCombo.Text + "'", cn);
                        dr = cm.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows) { cid = dr[0].ToString(); }
                        dr.Close();
                        cn.Close();


                        cn.Open();
                        cm = new SqlCommand("insert into tblProduct (pcode, barcode, pdesc, bid, cid, price) values (@pcode, @barcode, @pdesc, @bid, @cid, @price)", cn);
                        cm.Parameters.AddWithValue("@pcode", txtProd.Text);
                        cm.Parameters.AddWithValue("@barcode", txtBarCode.Text);
                        cm.Parameters.AddWithValue("@pdesc", txtDesc.Text);
                        cm.Parameters.AddWithValue("@bid", bid);
                        cm.Parameters.AddWithValue("@cid", cid);
                        cm.Parameters.AddWithValue("@price", txtPrice.Text);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Product has been successfully added");
                        clear();
                        flist.LoadRecords();
                    }
                    catch (Exception ex)
                    {
                        cn.Close();
                        MessageBox.Show(ex.Message);
                    }
                }
        
        }
        
        public void clear()
        {
            txtProd.Clear();
            txtPrice.Clear();
            txtDesc.Clear();
            txtBarCode.Clear();
            catCombo.Text = "";
            brandCombo.Text = "";
            txtProd.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add this product?", "Save Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    string bid = "", cid = "";
                    cn.Open();
                    cm = new SqlCommand("select id from tblBrand where Brand like '" + brandCombo.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { bid = dr[0].ToString(); }
                    dr.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("select id from tblCategory where Category like '" + catCombo.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows) { cid = dr[0].ToString(); }
                    dr.Close();
                    cn.Close();

                   
                    cn.Open();
                    cm = new SqlCommand("update tblProduct set pcode=@pcode, pdesc=@pdesc, barcode=@barcode, bid=@bid, cid=@cid, price=@price where pcode like @pcode", cn);
                    cm.Parameters.AddWithValue("@pcode", txtProd.Text);
                    cm.Parameters.AddWithValue("@barcode", txtBarCode.Text);
                    cm.Parameters.AddWithValue("@pdesc", txtDesc.Text);
                    cm.Parameters.AddWithValue("@bid", bid);
                    cm.Parameters.AddWithValue("@cid", cid);
                    cm.Parameters.AddWithValue("@price", txtPrice.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product has been successfully updated");
                    clear();
                    flist.LoadRecords();
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    cn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtProd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtPrice_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}

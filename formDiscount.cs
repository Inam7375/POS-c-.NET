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
    public partial class formDiscount : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        string stitle = "POS System";
        POS fpos;

        public formDiscount(POS frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            fpos = frm;
        }

        private void formBrand_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtDiscPerc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double discount = Double.Parse(txtPrice.Text) * Double.Parse(txtDiscPerc.Text);
                txtDiscAmount.Text = discount.ToString("#,##0.00");
            } catch (Exception)
            {
                txtDiscAmount.Text = "0.00";
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Add discount? Click Yes To Confirm.", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("update tblcart set disc = @disc where id = @id", cn);
                    cm.Parameters.AddWithValue("@disc", Double.Parse(txtDiscAmount.Text));
                    cm.Parameters.AddWithValue("@id", int.Parse(lblID.Text));
                    cm.ExecuteNonQuery();
                    cn.Close();
                    fpos.LoadCart();
                    this.Dispose();

                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

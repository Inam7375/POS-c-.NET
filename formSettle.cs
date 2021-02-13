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
    public partial class formSettle : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        POS fpos;
        public formSettle(POS frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            fpos = frm;
        }

        private void formSettle_Load(object sender, EventArgs e)
        {

        }

        private void formBrand_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double sale = double.Parse(txtSale.Text);
                double cash = double.Parse(txtCash.Text);
                double change = cash - sale;
                txtChange.Text = change.ToString("#,##0.00");
            } catch (Exception)
            {
                txtChange.Text = "0.00";
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtCash.Text = btn7.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtCash.Text = btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtCash.Text = btn9.Text;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtCash.Text = "";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtCash.Text = btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtCash.Text = btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtCash.Text = btn6.Text;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtCash.Text = btn0.Text;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtCash.Text = btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtCash.Text = btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtCash.Text = btn3.Text;
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            txtCash.Text = btn00.Text;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if((double.Parse(txtChange.Text) < 0) || (txtChange.Text.ToString() == String.Empty))
                {
                    MessageBox.Show("Insufficient amount. Please enter the correct amount!", "Danger!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } else
                {
                    for (int i =0; i<fpos.dataGridView1.Rows.Count; i++)
                    {
                        //Update Product Table
                        cn.Open();
                        cm = new SqlCommand("update tblProduct set qty = qty - "+int.Parse(fpos.dataGridView1.Rows[i].Cells[5].Value.ToString())+" where pcode = '"+ fpos.dataGridView1.Rows[i].Cells[8].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        //Update Cart Table
                        cn.Open();
                        cm = new SqlCommand("update tblCart set status = 'Sold' where id like '"+ fpos.dataGridView1.Rows[i].Cells[1].Value.ToString() + "' and status like 'Pending'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                    }
                    MessageBox.Show("Payment Sucessfuly Saved", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fpos.getTransNo();
                    fpos.LoadCart();
                    this.Dispose();
                }
                }
                 catch(Exception ex)
                 {
                     MessageBox.Show("Insufficient amount. Please enter the correct amount!", "Danger!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 } 
            }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    if ((double.Parse(txtChange.Text) < 0) || (txtChange.Text.ToString() == String.Empty))
                    {
                        MessageBox.Show("Insufficient amount. Please enter the correct amount!", "Danger!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < fpos.dataGridView1.Rows.Count; i++)
                        {
                            //Update Product Table
                            cn.Open();
                            cm = new SqlCommand("update tblProduct set qty = qty - " + int.Parse(fpos.dataGridView1.Rows[i].Cells[5].Value.ToString()) + " where pcode = '" + fpos.dataGridView1.Rows[i].Cells[8].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();

                            //Update Cart Table
                            cn.Open();
                            cm = new SqlCommand("update tblCart set status = 'Sold' where id like '" + fpos.dataGridView1.Rows[i].Cells[1].Value.ToString() + "' and status like 'Pending'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();
                        }
                        MessageBox.Show("Payment Sucessfuly Saved", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fpos.getTransNo();
                        fpos.LoadCart();
                        this.Dispose();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Insufficient amount. Please enter the correct amount!", "Danger!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}

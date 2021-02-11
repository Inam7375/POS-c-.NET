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
    public partial class formProductList : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        public formProductList()
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            LoadRecords();
        }

        public void LoadRecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select p.pcode, p.barcode ,p.pdesc, p.qty, b.brand, c.category, p.price from tblProduct as p inner join tblBrand as b on b.id = p.bid inner join tblCategory as c on c.id = p.cid where p.pdesc like'" + txtSearch.Text + "%'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[3].ToString(), "Edit", "Remove");

            }
            cn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                try
                {
                    formProduct frm = new formProduct(this);
                    frm.btnSave.Enabled = false;
                    frm.btnUpdate.Enabled = true;
                    frm.txtProd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    frm.txtBarCode.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    frm.txtDesc.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    frm.brandCombo.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    frm.catCombo.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    frm.txtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    frm.loadBrand();
                    frm.loadCategory();
                    frm.ShowDialog();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } else if (colName == "Delete")
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to delete this product?", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblProduct where pcode like '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        LoadRecords();
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            formProduct frm = new formProduct(this);
            frm.btnSave.Enabled = true;
            frm.btnUpdate.Enabled = false;
            frm.loadBrand();
            frm.loadCategory();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            LoadRecords();
        }
    }
}

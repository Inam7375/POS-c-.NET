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
    public partial class formSearchProductStockIn : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        string stitle = "POS System";
        formStockIn slist;
        public formSearchProductStockIn(formStockIn flist)
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            slist = flist;
        }

        public void LoadProduct()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select pcode, pdesc, qty from tblProduct where pdesc like '" + txtSearch.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), "select");
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formBrand_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formSearchProductStockIn_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                if (slist.txtReferenece.Text == string.Empty)
                {
                    MessageBox.Show("Please enter reference no", stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    slist.txtReferenece.Focus();
                    return;
                }
                if (slist.txtStockIn.Text == string.Empty)
                {
                    MessageBox.Show("Please enter stock in by", stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    slist.txtStockIn.Focus();
                    return;
                }
                if (MessageBox.Show("Add this item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    string rowIndex = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cm = new SqlCommand("insert into tblStockIn(refno, pcode, sdate, stockinby ) values(@refno, @pcode, @sdate, @stockinby ) ", cn);
                    cm.Parameters.AddWithValue("@refno", slist.txtReferenece.Text);
                    cm.Parameters.AddWithValue("@pcode", rowIndex);
                    cm.Parameters.AddWithValue("@sdate", slist.dateTimePicker1.Value);
                    cm.Parameters.AddWithValue("@stockinby", slist.txtStockIn.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show("Record succesfully added", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    slist.loadStockIn();
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            LoadProduct();
        }
    }
}

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
    public partial class formLookUp : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        string stitle = "POS System";
        POS fpos;
        public formLookUp(POS frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            fpos = frm;
        }

        public void LoadRecords()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select p.pcode, p.barcode ,p.pdesc, p.qty, b.brand, c.category, p.price from tblProduct as p inner join tblBrand as b on b.id = p.bid inner join tblCategory as c on c.id = p.cid where p.pdesc like'" + txtSearch.Text + "%'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[3].ToString(), "Select");

                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "POS System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void formBrand_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colName == "Select")
            {
                formQty frm = new formQty(fpos);
                frm.ProductDetails(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), Double.Parse(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()), fpos.lblTransaction.Text);
                frm.ShowDialog();
            }
        }
    }
}

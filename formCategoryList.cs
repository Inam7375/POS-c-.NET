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
    public partial class formCategoryList : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        public formCategoryList()
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            LoadRecords();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formCategory frm = new formCategory(this);
            frm.btnSave.Enabled = true;
            frm.btnUpdate.Enabled = false;
            frm.ShowDialog();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadRecords()
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from tblCategory order by category", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {

                i += 1;
                dataGridView1.Rows.Add(i, dr["id"].ToString(), dr["category"].ToString(), "Edit", "Remove");
            }
            dr.Close();
            cn.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                formCategory frm = new formCategory(this);
                frm.btnSave.Enabled = true;
                frm.lblID.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                frm.txtCategory.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                frm.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this category?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("delete from tblCategory where id like '" + int.Parse(dataGridView1[1, e.RowIndex].Value.ToString()) + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Reoord has been succesfully deleted", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadRecords();
                }
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

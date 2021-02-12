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
    
    public partial class formStockIn : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        string stitle = "POS System";
        

        public formStockIn()
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
        }

        

        public void loadStockIn()
        {
            try
            {
                int i = 0;
                dataGridView2.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from vwStockProd where refno like '"+txtReferenece.Text+"'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dataGridView2.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[6].ToString(), dr[3].ToString(), dr[5].ToString(), dr[4].ToString(), "delete");
                }
                dr.Close();
                cn.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
        }

        public void clear()
        {
            txtReferenece.Clear();
            txtStockIn.Clear();
            dateTimePicker1.Value = DateTime.Now;
            txtReferenece.Focus();
        }

        public void loadStockByHistory()
        {
            try
            {
                int i = 0;
                dataGridView1.Rows.Clear();
                cn.Open();
                cm = new SqlCommand("select * from vwStockProd where cast(sdate as date) between '" + date1.Value.ToShortDateString() + "' and '"+date2.Value.ToShortDateString()+"' and status like 'Done'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    i++;
                    dataGridView1.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[6].ToString(), dr[3].ToString(), DateTime.Parse(dr[5].ToString()).ToShortDateString(), dr[4].ToString(), "delete");
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formStockIn_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void formSearchLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formSearchProductStockIn frm = new formSearchProductStockIn(this);
            frm.LoadProduct();
            frm.ShowDialog();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtStockIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void formSearchLink_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            formSearchProductStockIn frm = new formSearchProductStockIn(this);
            frm.LoadProduct();
            frm.ShowDialog();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = dataGridView2.Columns[e.ColumnIndex].Name;
                if(colName == "Delete")
                {
                    if(MessageBox.Show("Remove this item?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tblStockIn where id ='"+dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString()+"'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Record has been deleted", stitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadStockIn();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    if (MessageBox.Show("Are you sure you want to save this record?", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            //update tblProduct qty
                            cn.Open();
                            cm = new SqlCommand("update tblProduct set qty = '" + int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString()) + "' where pcode like '" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();

                            //update tblStockIn qty
                            cn.Open();
                            cm = new SqlCommand("update tblStockIn set qty = '" + int.Parse(dataGridView2.Rows[i].Cells[5].Value.ToString()) + "', status='Done' where id like '" + dataGridView2.Rows[i].Cells[1].Value.ToString() + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();

                        }
                        loadStockIn();
                        clear();
                    }
                }
            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, stitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadStockByHistory();
        }
    }
}

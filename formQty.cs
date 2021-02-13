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
    public partial class formQty : Form
    {

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        string stitle = "POS System";
        POS fpos;
        private String pcode;
        private double price;
        private String transno;
        public formQty(POS frmpos)
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            fpos = frmpos;
        }

        public void ProductDetails(String pcode, double price, String transno)
        {
            this.pcode = pcode;
            this.price = price;
            this.transno = transno;
        }

        private void formQty_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar==13) && (textBox1.Text != String.Empty))
            {
                cn.Open();
                cm = new SqlCommand("insert into tblCart (transno, pcode, price, qty, sdate) values (@transno, @pcode, @price, @qty, @sdate)", cn);
                cm.Parameters.AddWithValue("@transno", transno);
                cm.Parameters.AddWithValue("@pcode", pcode);
                cm.Parameters.AddWithValue("@price", price);
                cm.Parameters.AddWithValue("@qty", int.Parse(textBox1.Text));
                cm.Parameters.AddWithValue("@sdate", DateTime.Now);
                cm.ExecuteNonQuery();
                cn.Close();

                fpos.txtSearch.Clear();
                fpos.txtSearch.Focus();
                fpos.LoadCart();
                this.Dispose();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

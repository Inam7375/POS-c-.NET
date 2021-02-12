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
	public partial class Form1 : Form
	{

		SqlConnection cn = new SqlConnection();
		SqlCommand cm = new SqlCommand();
		dbConnection dbCon = new dbConnection();

		public Form1()
		{
			InitializeComponent();
			cn = new SqlConnection(dbCon.MyConnection());
			// cn.Open();
			// MessageBox.Show("Connected");

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void label1_Click_1(object sender, EventArgs e)
		{

		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{

		}

        private void brandButton_Click(object sender, EventArgs e)
        {
            formBrandList brandForm = new formBrandList
            {
                TopLevel = false
            };
            buttonCategory.Controls.Add(brandForm);
			brandForm.BringToFront();
			brandForm.Show();
        }

        private void bt_Click(object sender, EventArgs e)
        {
            formCategoryList catForm = new formCategoryList
            {
                TopLevel = false
            };
            buttonCategory.Controls.Add(catForm);
			catForm.BringToFront();
			catForm.Show();
		}

        private void button3_Click(object sender, EventArgs e)
        {
			formProductList prodForm = new formProductList
			{
				TopLevel = false
			};
			buttonCategory.Controls.Add(prodForm);
			prodForm.BringToFront();
			prodForm.Show();
		}

        private void button5_Click(object sender, EventArgs e)
        {
			formStockIn frm = new formStockIn();
			frm.Show();
        }
    }
}

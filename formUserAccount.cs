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
    public partial class formUserAccount : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        public formUserAccount()
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void tabPage1_Resize(object sender, EventArgs e)
        {

        }

        private void formUserAccount_Resize(object sender, EventArgs e)
        {
            metroTabControl1.Left = (this.Width - metroTabControl1.Width) / 2;
            metroTabControl1.Top = (this.Height - metroTabControl1.Height) / 2;
        }

        private void Clear ()
        {
            txtUsername.Clear();
            txtPass.Clear();
            txtRetypePass.Clear();
            cboRole.Text = "";
            txtName.Clear();
            txtUsername.Focus();
        }

        private void formUserAccount_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtPass.Text != txtRetypePass.Text)
                {
                    MessageBox.Show("Passwords did not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                cn.Open();
                cm = new SqlCommand("insert into tbluser (username, password, role, name) values(@username, @password, @role, @name)", cn);
                cm.Parameters.AddWithValue("@username", txtUsername.Text);
                cm.Parameters.AddWithValue("@password", txtPass.Text);
                cm.Parameters.AddWithValue("@role", cboRole.Text);
                cm.Parameters.AddWithValue("@name", txtName.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Record has been saved!");
                Clear();
            } catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }
    }
}

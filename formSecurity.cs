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
    public partial class formSecurity : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        public formSecurity()
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPass.Clear();
            txtUsername.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool found = false;
            string _username="", _role="", _name="";
            cn.Open();
            cm = new SqlCommand("select * from tblUser where username = @username and password = @password", cn);
            cm.Parameters.AddWithValue("@username", txtUsername.Text);
            cm.Parameters.AddWithValue("@password", txtPass.Text);
            dr = cm.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                found = true;
                _username = dr["username"].ToString();
                _role = dr["role"].ToString();
                _name = dr["name"].ToString();
            } else
            {
                found = false;
            }

            if (found == true)
            {
                if (_role == "Cashier")
                {
                    MessageBox.Show("Welcome " + _name + "!", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPass.Clear();
                    txtUsername.Clear();
                    this.Hide();
                    POS frm = new POS();
                    frm.lblName.Text = _name +" | "+_role;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Welcome " + _name + "!", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPass.Clear();
                    txtUsername.Clear();
                    this.Hide();
                    Form1 frm = new Form1();
                    frm.lblName.Text = _name;
                    frm.lblRole.Text = _role;
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dr.Close();
            cn.Close();
        }
    }
}

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
    public partial class formVoid : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbConnection dbCon = new dbConnection();
        SqlDataReader dr;
        formCancelDetails fcancel;
        public formVoid(formCancelDetails frm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbCon.MyConnection());
            fcancel = frm;
        }

        private void formBrand_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtpassword.Text != String.Empty)
                {
                    string user;
                    cn.Open();
                    cm = new SqlCommand("select * from tblUser where username = @username and password = @password", cn);
                    cm.Parameters.AddWithValue("@username", txtUsername.Text);
                    cm.Parameters.AddWithValue("@password", txtpassword.Text);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        user = dr["username"].ToString();
                        dr.Close();
                        cn.Close();

                        SaveCancelOrder(user);
                        if(fcancel.cboAction.Text == "Yes")
                        {
                            UpdateData("update tblProduct set qty = qty + " + int.Parse(fcancel.txtCancelQty.Text) + "where pcode = '" + fcancel.txtPCode.Text + "'");
                        }
                        UpdateData("update tblCart set qty = qty - "+int.Parse(fcancel.txtCancelQty.Text)+"where id like '"+fcancel.txtID.Text+"'");
                        MessageBox.Show("Order Transaction Sucessfully Canceled", "Cancel Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                        fcancel.RefreshList();
                        fcancel.Dispose();
                    }
                    dr.Close();
                    cn.Close();
                }
            } catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SaveCancelOrder(string user)
        {
            cn.Open();
            cm = new SqlCommand("insert into tblcancel (transno, pcode, price, qty, sdate, voidby, cancelledby, reason, action) values(@transno, @pcode, @price, @qty, @sdate, @voidby, @cancelledby, @reason, @action)", cn);
            cm.Parameters.AddWithValue("@transno", fcancel.txtTransNo.Text);
            cm.Parameters.AddWithValue("@pcode", fcancel.txtPCode.Text);
            cm.Parameters.AddWithValue("@price", double.Parse(fcancel.txtPrice.Text));
            cm.Parameters.AddWithValue("@qty", int.Parse(fcancel.txtCancelQty.Text));
            cm.Parameters.AddWithValue("@sdate", DateTime.Now);
            cm.Parameters.AddWithValue("@voidby", user);
            cm.Parameters.AddWithValue("@cancelledby", fcancel.txtCancel.Text);
            cm.Parameters.AddWithValue("@reason", fcancel.txtReason.Text);
            cm.Parameters.AddWithValue("@action", fcancel.cboAction.Text);
            cm.ExecuteNonQuery();
            cn.Close();
        }

        public void UpdateData(string sql)
        {
            cn.Open();
            cm = new SqlCommand(sql, cn);
            cm.ExecuteNonQuery();
            cn.Close();
        }
    }
}

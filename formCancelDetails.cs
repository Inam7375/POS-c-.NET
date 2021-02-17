using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class formCancelDetails : Form
    {
        formSoldItems fsold;
        public formCancelDetails(formSoldItems frm)
        {
            InitializeComponent();
            fsold = frm;
        }

        private void formCancelDetails_Load(object sender, EventArgs e)
        {

        }

        private void formBrand_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cboAction_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if((cboAction.Text!=String.Empty) && (txtCancelQty.Text!=String.Empty) && (txtReason.Text != String.Empty))
                {
                    if(int.Parse(txtQty.Text) >= int.Parse(txtCancelQty.Text)) {
                    formVoid frm = new formVoid(this);
                    frm.ShowDialog();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshList()
        {
            fsold.LoadRecords();
        }
    }
}

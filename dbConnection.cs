using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
	class dbConnection
	{
		SqlConnection cn = new SqlConnection();
		SqlCommand cm = new SqlCommand();
		SqlDataReader dr;
		public string MyConnection()
		{
			string con = "Data Source=DESKTOP-S6OS7FN;Initial Catalog=POS_DEMO_DB;Integrated Security=True";
			return con;
		}

		public double GetVal()
        {
			double vat=0;
			cn.ConnectionString = MyConnection();
			cn.Open();
			cm = new SqlCommand("select * from tblVat", cn);
			dr = cm.ExecuteReader();
            while (dr.Read())
            {
				vat = Double.Parse(dr["vat"].ToString());
            }
			cn.Close();
			return vat;
		}
	}
}

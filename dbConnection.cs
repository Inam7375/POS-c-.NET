using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	class dbConnection
	{
		public string MyConnection()
		{
			string con = "Data Source=DESKTOP-S6OS7FN;Initial Catalog=POS_DEMO_DB;Integrated Security=True";
			return con;
		}
	}
}

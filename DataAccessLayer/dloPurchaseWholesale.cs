using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class dloPurchaseWholesale
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        public void connection()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }
        /* supplier dropdown filling */
        public DataTable fillSupplier()
        {
            connection();

            cmd = new SqlCommand("sp_PurchaseWholesale", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 1);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        /* item dropdown filling */
        public DataTable fillItem(int supplier_id)
        {
            connection();

            cmd = new SqlCommand("sp_PurchaseWholesale", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 2);
            cmd.Parameters.AddWithValue("@supplier_id", supplier_id);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
    }
}

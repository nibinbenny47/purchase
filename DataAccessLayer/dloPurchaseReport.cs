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
    public class dloPurchaseReport
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        public void connection()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }
        /*between 2 dates*/
        public DataTable dateBetween(string fromdate,string enddate)
        {
            connection();

            cmd = new SqlCommand("sp_PurchaseReport", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 1);
            cmd.Parameters.AddWithValue("@fromdate", fromdate);
            cmd.Parameters.AddWithValue("@enddate", enddate);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        /*fill grid*/
        public DataTable purchaseHeadGrid(int ph_id)
        {
            connection();

            cmd = new SqlCommand("sp_PurchaseReport", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 2);
            cmd.Parameters.AddWithValue("@ph_id", ph_id);
           
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
    }
}

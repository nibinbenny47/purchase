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
        /* insert values to purchase head table*/
        public void  insertPurchaseHead(string ph_date,int ph_invoice,int ph_grandtotal, int supplier_id)
        {
            connection();

            cmd = new SqlCommand("sp_PurchaseWholesale", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 3);
            cmd.Parameters.AddWithValue("@ph_date", ph_date);
            cmd.Parameters.AddWithValue("@ph_invoice", ph_invoice);
            cmd.Parameters.AddWithValue("@ph_grandtotal", ph_grandtotal);
            cmd.Parameters.AddWithValue("@supplier_id", supplier_id);
            cmd.ExecuteNonQuery();
        }
        /* insert values to purchase details table*/
        public void insertPurchaseDetails(int ph_id, int item_id, int pd_quantity, string pd_rate)
        {
            connection();

            cmd = new SqlCommand("sp_PurchaseWholesale", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 4);
            cmd.Parameters.AddWithValue("@ph_id", ph_id);
            cmd.Parameters.AddWithValue("@item_id", item_id);
            cmd.Parameters.AddWithValue("@pd_quantity", pd_quantity);
            cmd.Parameters.AddWithValue("@pd_rate", pd_rate);
            cmd.ExecuteNonQuery();

        }
        /*select ph_id to insert into purchaseDetails table*/
        public DataTable selectphID()
        {
            connection();

            cmd = new SqlCommand("sp_PurchaseWholesale", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 5);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
    }
}

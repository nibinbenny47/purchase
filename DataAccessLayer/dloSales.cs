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
    public class dloSales
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        public void connection()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }
        /* item dropdown filling */
        public DataTable fillItem()
        {
            connection();

            cmd = new SqlCommand("sp_Sales", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 1);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        /*insert sales table*/
        public void insertSales(string sales_date, int sales_bill, int sales_grandtotal)
        {
            connection();

            cmd = new SqlCommand("sp_Sales", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 2);
            cmd.Parameters.AddWithValue("@sales_date", sales_date);
            cmd.Parameters.AddWithValue("@sales_bill", sales_bill);
            cmd.Parameters.AddWithValue("@sales_grandtotal", sales_grandtotal);
            cmd.ExecuteNonQuery();

        }
        /*select sales id to insert into salesDetails table*/
        public DataTable selectsalesID()
        {
            connection();

            cmd = new SqlCommand("sp_Sales", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 3);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }
        public DataTable selectStock(int item_id)
        {
            connection();

            cmd = new SqlCommand("sp_Sales", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 4);
            cmd.Parameters.AddWithValue("@item_id",item_id);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }
        /*insert salesDetais table*/
        public void insertSalesDetails(int sales_id,int item_id,int sales_quantity,int sales_rate)
        {
            connection();

            cmd = new SqlCommand("sp_Sales", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 5);
            cmd.Parameters.AddWithValue("@sales_id", sales_id);
            cmd.Parameters.AddWithValue("@item_id", item_id);
            cmd.Parameters.AddWithValue("@sales_quantity", sales_quantity);
            cmd.Parameters.AddWithValue("@sales_rate", sales_rate);
            cmd.ExecuteNonQuery();
            


        }
        /*update stock*/
        public void stockUpdate(int availQnty,int item_id)
        {
            connection();

            cmd = new SqlCommand("sp_Sales", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 6);
            cmd.Parameters.AddWithValue("@availQnty", @availQnty);
            cmd.Parameters.AddWithValue("@item_id", item_id);
            cmd.ExecuteNonQuery();
        }
    }
}

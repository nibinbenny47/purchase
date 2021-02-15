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
    public class dloPlace
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        public void connection()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }
        /* dropdown filling */
        public DataTable fillDistrict()
        {
            connection();

            cmd = new SqlCommand("sp_Place", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 5);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;
        }
        /* insert place  names*/
        public void insertPlace(string placename, int id)
        {
            connection();

            cmd = new SqlCommand("sp_Place", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 1);
            cmd.Parameters.AddWithValue("@place_name", placename);
            cmd.Parameters.AddWithValue("@district_id", id);
            cmd.ExecuteNonQuery();

        }
        //Delete place names 
        public void deleteData(int id)
        {
            connection();

            cmd = new SqlCommand("sp_Place", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 2);
            cmd.Parameters.AddWithValue("@place_id", id);
            cmd.ExecuteNonQuery();

        }
        //Fill repeater with place names
        public DataTable fillRepeater()
        {
            connection();

            cmd = new SqlCommand("sp_Place", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 3);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }
        /* fill repeater with place names by id */
        public DataTable selectPlace(int id)
        {
            connection();

            cmd = new SqlCommand("sp_Place", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 4);
            cmd.Parameters.AddWithValue("@place_id", id);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }
        /* update place names */
        public void updateData(int id, string name, int did)
        {
            connection();

            cmd = new SqlCommand("sp_Place", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 5);
            cmd.Parameters.AddWithValue("@place_id", id);
            cmd.Parameters.AddWithValue("@district_id", did);
            cmd.Parameters.AddWithValue("@place_name", name);
            cmd.ExecuteNonQuery();

        }
    }
}

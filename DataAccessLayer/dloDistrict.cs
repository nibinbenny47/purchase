using  System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

using System.Data;

namespace DataAccessLayer
{
    public class dloDistrict
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        public void connection()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }
        //Add district into table
        public void insertData(string name)
        {
            connection();

            cmd = new SqlCommand("sp_AddDistrict", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@district_name", name);
            cmd.ExecuteNonQuery();


        }
        //Delete district names 
        public void deleteData(int id)
        {
            connection();

            cmd = new SqlCommand("sp_EditDeleteDistrict", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 1);
            cmd.Parameters.AddWithValue("@district_id", id);
            cmd.ExecuteNonQuery();

        }
        //Fill repeater with district names
        public DataTable fillRepeater()
        {
            connection();

            cmd = new SqlCommand("sp_EditDeleteDistrict", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 2);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }
        /* fill repeater with district names by id */
        public DataTable selectDistrict(int id)
        {
            connection();

            cmd = new SqlCommand("sp_EditDeleteDistrict", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 3);
            cmd.Parameters.AddWithValue("@district_id", id);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            return dt;

        }
        /* update district names */
        public void updateData(int id, string name)
        {
            connection();

            cmd = new SqlCommand("sp_EditDeleteDistrict", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@status", 4);
            cmd.Parameters.AddWithValue("@district_id", id);
            cmd.Parameters.AddWithValue("@district_name", name);
            cmd.ExecuteNonQuery();

        }
    }
}


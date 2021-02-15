
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BusinessAccessLayer;
namespace _3TierPurchaseWork.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static int id, status = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillRepeater();
            }
        }
        public bloDistrict obj = new bloDistrict();


        protected void btnSave_Click(object sender, EventArgs e)
        {
            /* update district name*/
            if (status == 1)
            {
                obj.updateData(id, txtName.Text);


                status = 0;
            }



            else
            {
                obj.inserData(txtName.Text);

            }
            fillRepeater();

        }
        //fill repeater wit district names
        protected void fillRepeater()
        {
            DataTable dt = new DataTable();
            dt = obj.fillRepeater();
            rptrDistrict.DataSource = dt;
            rptrDistrict.DataBind();
        }

        protected void rptrDistrict_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            id = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName == "deleteDistrict")
            {
                obj.deleteData(id);
            }




            if (e.CommandName == "editDistrict")
            {
                DataTable dt = obj.selectDistrict(id);
                txtName.Text = dt.Rows[0]["district_name"].ToString();
                status = 1;


            }
            fillRepeater();


        }
    }
}
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
    public partial class WebForm2 : System.Web.UI.Page
    {
        public static int id, status = 0;
        public bloPlace obj = new bloPlace();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = obj.fillDistrict();
                ddlDistrict.DataSource = dt;


                ddlDistrict.DataTextField = "district_name";
                ddlDistrict.DataValueField = "district_id";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "--select--");
                fillRepeater();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            /* update district name*/
            if (status == 1)
            {
                obj.updateData(id, txtName.Text, Convert.ToInt32(ddlDistrict.SelectedValue));
                status = 0;
            }
            else
            {
                obj.insertPlace(txtName.Text, Convert.ToInt32(ddlDistrict.SelectedValue));

            }
            fillRepeater();
        }
        //fill repeater wit place names and district names
        protected void fillRepeater()
        {
            DataTable dt = new DataTable();
            dt = obj.fillRepeater();
            rptrPlace.DataSource = dt;
            rptrPlace.DataBind();
        }

        protected void rptrPlace_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            id = Convert.ToInt32(e.CommandArgument.ToString());
            if (e.CommandName == "deletePlace")
            {
                obj.deleteData(id);
            }
            if (e.CommandName == "editPlace")
            {
                DataTable dt = obj.selectPlace(id);
                txtName.Text = dt.Rows[0]["place_name"].ToString();

                ddlDistrict.SelectedValue = dt.Rows[0]["district_id"].ToString();
                status = 1;


            }
            fillRepeater();

        }
    }
}
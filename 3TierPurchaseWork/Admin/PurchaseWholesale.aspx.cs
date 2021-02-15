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
    public partial class WebForm3 : System.Web.UI.Page
    {
        public bloPurchaseWholesale obj = new bloPurchaseWholesale();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = obj.fillSupplier();
                ddlSupplier.DataSource = dt;


                ddlSupplier.DataTextField = "supplier_name";
                ddlSupplier.DataValueField = "supplier_id";
                ddlSupplier.DataBind();
                ddlSupplier.Items.Insert(0, "--select--");
              
            }
        }
    }
}
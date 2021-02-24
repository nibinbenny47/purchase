using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BusinessAccessLayer;
using System.IO;

namespace _3TierPurchaseWork.Admin
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        public bloPurchaseReport obj = new bloPurchaseReport();
        public static int id;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            DataTable dt = obj.dateBetween(txtFromDate.Text,txtToDate.Text);
            grdPurchaseReport.DataSource = dt;
            grdPurchaseReport.DataBind();

        }

        protected void grdPurchaseReport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            id = Convert.ToInt32(e.CommandArgument.ToString());
            Session["phid"] = id;
            if (e.CommandName == "invoiceNumber")
            {
                MultiView1.ActiveViewIndex = 1;
                fillGrid();
            }
        }
        protected void fillGrid()
        {
            DataTable dt = obj.purchaseHeadGrid(Convert.ToInt32(Session["phid"]));
            grdPurchaseDetails.DataSource = dt;
            grdPurchaseDetails.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "ExcelDemo" + DateTime.Now + ".xls";
            StringWriter strwriter = new StringWriter();
            HtmlTextWriter htmltextwriter = new HtmlTextWriter(strwriter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grdPurchaseDetails.GridLines = GridLines.Both;
            grdPurchaseDetails.HeaderStyle.Font.Bold = true;
            grdPurchaseDetails.RenderControl(htmltextwriter);
            Response.Write(strwriter.ToString());
            Response.End();
        }
    }
}
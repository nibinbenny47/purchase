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
        public static int qnty, rate, total;
        public static int temp = 0;
        //public static int qnty, rate, total;
        //public static int temp = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillSupplierdropDown();
                DataTable dtpurchase = new DataTable();

                DataColumn clm = new DataColumn("Item", typeof(string));
                dtpurchase.Columns.Add(clm);
                clm = new DataColumn("Quantity", typeof(string));
                dtpurchase.Columns.Add(clm);
                clm = new DataColumn("Rate", typeof(Int32));
                dtpurchase.Columns.Add(clm);
                clm = new DataColumn("Total", typeof(string));

                dtpurchase.Columns.Add(clm);
                dtpurchase.AcceptChanges();

                //Session["cart_id"] = 0;
                Session["purchase"] = dtpurchase;
                fillGrid();
                //fillDatatable();




            }
        }
        protected void fillSupplierdropDown()
        {
            DataTable dt = obj.fillSupplier();
            ddlSupplier.DataSource = dt;


            ddlSupplier.DataTextField = "supplier_name";
            ddlSupplier.DataValueField = "supplier_id";
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, "--select--");
        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillItem();
        }
        protected void fillItem()
        {
            DataTable dt = obj.fillItem(Convert.ToInt32(ddlSupplier.SelectedValue));
            ddlItem.DataSource = dt;


            ddlItem.DataTextField = "item_name";
            ddlItem.DataValueField = "item_id";
            ddlItem.DataBind();
            ddlItem.Items.Insert(0, "--select--");
        }



        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["purchase"];
            DataRow row = dt.NewRow();

            row["Item"] = ddlItem.SelectedItem.Text;
            row["Quantity"] = txtQuantity.Text;
            row["Rate"] = txtRate.Text;
            qnty = Convert.ToInt32(txtQuantity.Text);
            rate = Convert.ToInt32(txtRate.Text);
            total = qnty * rate;
            row["Total"] = total.ToString();
            temp = temp + total;
            txtGrandTotal.Text = temp.ToString();
            //row["Total"] = Convert.ToInt32(txtQuantity.Text) * Convert.ToInt32(txtRate.Text);

            dt.Rows.Add(row);
            dt.AcceptChanges();
            Session["purchase"] = dt;

            fillGrid();
        }
        protected void fillGrid()
        {
            DataTable dt = (DataTable)Session["purchase"];
            grdPurchase.DataSource = dt;
            grdPurchase.DataBind();
        }

        //protected void grdPurchase_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Label lb = (Label)e.Row.FindControl("lblTotal");
        //        total += Convert.ToInt32(lb.Text);
        //        txtGrandTotal.Text = total.ToString();
        //        //txtGrandTotal.Text = "Total Amount Rs:" + total.ToString() + "/-";
        //        Session["amount"] = total;
        //    }
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            /*insert into purchasehead table*/
            obj.insertPurchaseHead(txtDate.Text, Convert.ToInt32(txtInvoice.Text), txtGrandTotal.Text, Convert.ToInt32(ddlSupplier.SelectedValue));
          
            DataTable dt1 = obj.selectphID();
            Session["phid"] = dt1.Rows[0]["headID"];
            DataTable dt2 = Session["purchase"] as DataTable;
            foreach (DataRow dr in dt2.Rows)
            {
                obj.insertPurchaseDetails(Convert.ToInt32(Session["phid"]), Convert.ToInt32(dr["Item"]), Convert.ToInt32(dr["Quantity"]), Convert.ToInt32(dr["Rate"]));

                DataTable dt3 = obj.selectItemFromStock();
                if (dt3.Rows.Count > 0)
                {
                    int availQnty = Convert.ToInt32(dt3.Rows[0]["Quantity"]);
                    int newQnty = Convert.ToInt32(dr["quantity"]);
                    int upQnty = Convert.ToInt32(availQnty + newQnty);

                    obj.stockUpdate(upQnty, Convert.ToInt32(dr["Item"]));
                }
                else
                {
                    /*insert stock table*/
                    obj.insertStock(Convert.ToInt32(dr["Quantity"]), Convert.ToInt32(dr["Item"]));

                }
            }
        }
    }
}


        //protected void grdPurchase_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "del")
        //    {
        //        DataTable dt = (DataTable)Session["purchase"];
        //        int id = (int)Session["cart_id"];

        //        foreach (DataRow rw in dt.Rows)
        //        {
        //            if (rw["id"].ToString() == e.CommandArgument.ToString())
        //            {
        //                rw.Delete();
        //                id--;
        //            }
        //        }
        //        dt.AcceptChanges();
        //        Session["cart"] = dt;
        //        Session["cart_id"] = id;
        //        fillcart();
        //    }
        //}




        //public void fillDatatable()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add(new DataColumn("Items"));
        //    dt.Columns.Add(new DataColumn("Quantity"));
        //    dt.Columns.Add(new DataColumn("Rate"));
        //    dt.Columns.Add(new DataColumn("Total"));
        //    dt.AcceptChanges();
        //    Session["purchase"] = dt;
        //}
        //protected void btnAdd_Click(object sender, EventArgs e)
        //{

        //DataTable dt = new DataTable();
        //dt = (DataTable)Session["purchase"];
        //DataRow dr = dt.NewRow();
        //dr["Items"] = ddlItem.SelectedValue;
        //dr["Quantity"] = Convert.ToInt32(txtQuantity.Text);
        //dr["Rate"] = Convert.ToInt32(txtRate.Text);
        //dr["Total"] = Convert.ToInt32(txtQuantity.Text) * Convert.ToInt32(txtRate.Text);
        //dt.Rows.Add(dr);
        //dt.AcceptChanges();
        //Session["purchase"] = dt;
        //fillGrid();
        //}
        //public void createnewrow()
        //{
        //    DataTable dt = new DataTable();
        //    if (ViewState["purchase"] != null)
        //    {
        //        dt = (DataTable)ViewState["purchase"];
        //        DataRow dr = null;
        //        if (dt.Rows.Count > 0)
        //        {
        //            dr = dt.NewRow();
        //            dr["Item"] = ddlItem.SelectedItem.Text;
        //            dr["Quantity"] = txtQuantity.Text;
        //            dr["Rate"] = txtRate.Text;
        //            dr["Total"] = Convert.ToInt32( txtQuantity.Text) *Convert.ToInt32( txtRate.Text);

        //            dt.Rows.Add(dr);
        //            ViewState["purchase"] = dt;
        //            grdPurchase.DataSource = ViewState["purchase"];
        //            grdPurchase.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        dt.Columns.Add("Item", typeof(int));
        //        dt.Columns.Add(new DataColumn("Quantity", typeof(int)));
        //        dt.Columns.Add("Rate", typeof(int));
        //        dt.Columns.Add("Total", typeof(int));
        //        DataRow dr1 = dt.NewRow();
        //        dr1 = dt.NewRow(); 
        //        dr1["Item"] = ddlItem.SelectedItem.Text;
        //        dr1["Quantity"] = txtQuantity.Text;
        //        dr1["Rate"] = txtRate.Text;
        //        dr1["Total"] = Convert.ToInt32(txtQuantity.Text) * Convert.ToInt32(txtRate.Text);
        //        dt.Rows.Add(dr1);
        //        ViewState["purchase"] = dt;
        //        grdPurchase.DataSource = ViewState["purchase"];
        //        grdPurchase.DataBind();
        //    }
        //}



    

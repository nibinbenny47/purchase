using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessAccessLayer;
using System.Data;

namespace _3TierPurchaseWork.Admin
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        public bloSales obj = new bloSales();
        public static int qnty, rate, total;
        public static int temp = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillItem();
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
        protected void fillItem()
        {
            DataTable dt = obj.fillItem();
           
            ddlItem.DataSource = dt;


            ddlItem.DataTextField = "item_name";
            ddlItem.DataValueField = "item_id";
            ddlItem.DataBind();
            ddlItem.Items.Insert(0, "--select--");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            obj.insertSales(txtDate.Text,Convert.ToInt32(txtInvoice.Text),Convert.ToInt32(txtGrandTotal.Text));
            /*select sales id to insert into salesDetails table*/
            DataTable dt = obj.selectsalesID();
            Session["sid"] = dt.Rows[0]["sales_id"];
            DataTable dt1 = Session["purchase"] as DataTable;
            foreach (DataRow dr in dt1.Rows)
            {
                //checking if the item is available in the stock and if so checking if the availble quantity greater than the user requested quantity
                DataTable dt2 = obj.selectStock(Convert.ToInt32(dr["Item"]));
                lblsaleQnty.Text = Convert.ToInt32(dr["Quantity"]).ToString();
                int salesqnty = Convert.ToInt32(lblsaleQnty.Text);
                if (dt2.Rows.Count > 0)
                {
                    lblQuantity.Text = dt2.Rows[0]["stock_quantity"].ToString();
                    int qnty = Convert.ToInt32(lblQuantity.Text);

                    if (salesqnty <= qnty)
                    {
                        /*insert salesDetais table*/
                        obj.insertSalesDetails(Convert.ToInt32(Session["sid"]), Convert.ToInt32(dr["Item"]), Convert.ToInt32(dr["Quantity"]), Convert.ToInt32(dr["Rate"]));
                        int availableQnty = Convert.ToInt32(qnty - salesqnty);
                        obj.stockUpdate(availableQnty, Convert.ToInt32(dr["Item"]));
                    }
                    else
                    {
                        Response.Write("<script>alert('sorry out of stock!!')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Sorry !! no such item in the stock')</script>");
                }
            }
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
            grdSales.DataSource = dt;
            grdSales.DataBind();
        }

    }
}

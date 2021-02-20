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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillSupplierdropDown();
                AddDefaultFirstRecord();
                AddNewRecordToGrid();



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
        /* fill item in dropdown*/
        protected void fillItem()
        {
            DataTable dt = obj.fillItem(Convert.ToInt32( ddlSupplier.SelectedValue));
            ddlItem.DataSource = dt;


            ddlItem.DataTextField = "item_name";
            ddlItem.DataValueField = "item_id";
            ddlItem.DataBind();
            ddlItem.Items.Insert(0, "--select--");
        }
        /*creating temporary datatable*/
        private void AddDefaultFirstRecord()
        {
            //creating datatable
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                DataRow dr;
                dt.TableName = "purchase";
                dt.Columns.Add(new DataColumn("Item", typeof(string)));
                dt.Columns.Add(new DataColumn("Quantity", typeof(string)));
                dt.Columns.Add(new DataColumn("Rate", typeof(string)));
                dt.Columns.Add(new DataColumn("Total", typeof(string)));
                dr = dt.NewRow();
                dt.Rows.Add(dr);
                //saving datatable into viewstate
                ViewState["purchase"] = dt;
                Session["purchase"] = dt;
                //bind gridview
                grdPurchase.DataSource = dt;
                grdPurchase.DataBind();
            }
           
        }
        /* on clicking add buttton data saved to temporary grid or datatable */
        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            qnty = Convert.ToInt32(txtQuantity.Text);
            rate = Convert.ToInt32(txtRate.Text);
            total = qnty * rate;
            temp = temp + total;
            AddNewRecordToGrid();
        }
        /* insert values to purchase head,purchase details and update stock */
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            /*insert into purchasehead table*/
            obj.insertPurchaseHead(txtDate.Text, Convert.ToInt32(txtInvoice.Text), Convert.ToInt32(txtGrandTotal.Text), Convert.ToInt32(ddlSupplier.SelectedValue));

            DataTable dt1 = obj.selectphID();
            Session["phid"] = dt1.Rows[0]["headID"];

            DataTable dt2 = Session["purchase"] as DataTable;
            foreach (DataRow dr in dt2.Rows)
            {
                /* insert values to purchase details table*/
                obj.insertPurchaseDetails(Convert.ToInt32( Session["phid"]), Convert.ToInt32(dr["Item"]), Convert.ToInt32(dr["Quantity"]), Convert.ToInt32(dr["Rate"]));
                DataTable dt = obj.selectItemFromStock();
                if(dt.Rows.Count > 0)
                {
                    lblAvailQnty.Text = dt2.Rows[0]["stock_quantity"].ToString();
                    lblGivenQnty.Text = Convert.ToInt32(dr["Quantity"]).ToString();
                    int availQnty = Convert.ToInt32(lblAvailQnty.Text);
                    int givenQnty = Convert.ToInt32(lblGivenQnty.Text);
                    int newQnty = Convert.ToInt32(availQnty + givenQnty);
                    obj.stockUpdate(newQnty, Convert.ToInt32(dr["Item"]));

                }
                else
                { 
                    /*insert stock table*/
                    obj.insertStock(Convert.ToInt32(dr["Quantity"]), Convert.ToInt32(dr["Item"]));

                }
            }
           
           


        }
        
      

            /*clear all valuesin temporary grid and grandtotal*/
            protected void btnClear_Click(object sender, EventArgs e)
        {
            AddDefaultFirstRecord();
            txtGrandTotal.Text = "";
        }

        /* adding new record to the temporary grid*/
        public void AddNewRecordToGrid()
        {

            //check viewstate is not null
            if (ViewState["purchase"] != null)
            {
                //get datatable from viewstate
                DataTable dtCurrentTable = (DataTable)ViewState["purchase"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        //addeach row into datatable
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["Item"] = ddlItem.SelectedValue;
                        drCurrentRow["Quantity"] = txtQuantity.Text;
                        drCurrentRow["Rate"] = txtRate.Text;
                        drCurrentRow["Total"] = total.ToString();
                        //Prints grandtotal in the textbox
                        txtGrandTotal.Text = temp.ToString();





                    }
                    //remove initial blank row
                    if (dtCurrentTable.Rows[0][0].ToString() == "")
                    {
                        dtCurrentTable.Rows[0].Delete();
                        dtCurrentTable.AcceptChanges();
                    }
                    //add created rows into datatable 
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //save datatable into viewstate  after creating each row
                    ViewState["purchase"] = dtCurrentTable;
                    Session["purchase"] = dtCurrentTable;
                    //bind gridview with latest row
                    grdPurchase.DataSource = dtCurrentTable;
                    grdPurchase.DataBind();
                }
            }
        }
       
       
    }
}
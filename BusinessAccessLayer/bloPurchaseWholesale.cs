using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessAccessLayer
{
    public class bloPurchaseWholesale
    {
        public dloPurchaseWholesale obj = new dloPurchaseWholesale();
        /*supplier  dropdown filling */
        public DataTable fillSupplier()
        {
            return obj.fillSupplier();
        }
        /* item dropdown filling */
        public DataTable fillItem(int supplier_id)
        {
            return obj.fillItem(supplier_id);
        }
        /* insert values to purchase head table*/
        public void insertPurchaseHead(string ph_date, int ph_invoice, string  ph_grandtotal, int supplier_id)
        {
            obj.insertPurchaseHead(ph_date, ph_invoice, ph_grandtotal, supplier_id);
        }
        /* insert values to purchase details table*/
        public void insertPurchaseDetails(int ph_id, int item_id, int pd_quantity, int pd_rate)
        {
            obj.insertPurchaseDetails(ph_id, item_id, pd_quantity, pd_rate);
        }
            /*select ph_id to insert into purchaseDetails table*/
            public DataTable selectphID()
        {
            return obj.selectphID();
        }
        /*select item id from the stock table*/
        public DataTable selectItemFromStock()
        {
            return obj.selectItemFromStock();
        }
        /*update stock table*/
        public void stockUpdate(int newQnty, int item_id)
        {
            obj.stockUpdate(newQnty, item_id);
        }
        /*insert stock table*/
        public void insertStock(int newQnty, int item_id)
        {
            obj.insertStock(newQnty, item_id);
        }
    }
}

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
    public class bloSales
    {
        public dloSales obj = new dloSales();
        /* item dropdown filling */
        public DataTable fillItem()
        {
            return obj.fillItem();
        }
        /*insert sales table*/
        public void insertSales(string sales_date, int sales_bill, int sales_grandtotal)
        {
            obj.insertSales(sales_date, sales_bill, sales_grandtotal);
        }
        /*select sales id to insert into salesDetails table*/
        public DataTable selectsalesID()
        {
            return obj.selectsalesID();
        }
        public DataTable selectStock(int item_id)
        {
            return obj.selectStock(item_id);
        }
        /*insert salesDetais table*/
        public void insertSalesDetails(int sales_id, int item_id, int sales_quantity, int sales_rate)
        {
            obj.insertSalesDetails(sales_id, item_id, sales_quantity, sales_rate);
        }
        /*update stock*/
        public void stockUpdate(int availQnty, int item_id)
        {
            obj.stockUpdate(availQnty, item_id);
        }
    }
}

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
    public class bloPurchaseReport
    {
        public dloPurchaseReport obj = new dloPurchaseReport();
        /*between 2 dates*/
        public DataTable dateBetween(string fromdate, string enddate)
        {
            return obj.dateBetween(fromdate, enddate);
        }
        /*fill grid*/
        public DataTable purchaseHeadGrid(int ph_id)
        {
            return obj.purchaseHeadGrid(ph_id);
        }
    }
}

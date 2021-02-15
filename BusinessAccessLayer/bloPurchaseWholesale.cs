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
    }
}

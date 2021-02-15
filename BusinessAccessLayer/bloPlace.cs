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
    public class bloPlace
    {
        public dloPlace obj = new dloPlace();
        /* dropdown filling */
        public DataTable fillDistrict()
        {
            return obj.fillDistrict();
        }
        /* insert place  names*/
        public void insertPlace(string placename, int id)
        {
            obj.insertPlace(placename, id);
        }
        //Fill repeater with place names
        public DataTable fillRepeater()
        {
            return obj.fillRepeater();
        }
        //Delete place names 
        public void deleteData(int id)
        {
            obj.deleteData(id);
        }
        public DataTable selectPlace(int id)
        {
            return obj.selectPlace(id);
        }
        /* update place names */
        public void updateData(int id, string name, int did)
        {
            obj.updateData(id, name, did);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer
{
    public class bloDistrict
    {
        public dloDistrict obj = new dloDistrict();

        public void inserData(string name)
        {
            obj.insertData(name);

        }
        //delete district name by id
        public void deleteData(int id)
        {
            obj.deleteData(id);
        }
        //Fill repeater with district names
        public DataTable fillRepeater()
        {
            return obj.fillRepeater();
        }
        /* fill repeater with district names by id */
        public DataTable selectDistrict(int id)
        {
            return obj.selectDistrict(id);
        }
        /* update district names */
        public void updateData(int id, string name)
        {
            obj.updateData(id, name);
        }
    }
}


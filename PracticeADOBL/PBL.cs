using PracticeADODAL;
using PracticeADODTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeADOBL
{
    public class PBL
    {
        PDAL dalObj = new PDAL();
        public List<PDTO> GetAllProducts()
        {          
            return dalObj.FetchAllProducts();
        }

        public List<PDTO> GetAllProductsByName(string pName)
        {
            return dalObj.FetchAllProductsByName(pName);
        }
        public List<DDTO> GetAllDepts()
        {
            return dalObj.FetchAllDepartments();
        }
        public int AddNewDepartment(DDTO dtObj)
        {
            return dalObj.InsertNewDepartment(dtObj);
        }
        public int UpdateDept(DDTO dtObj)
        {
            return dalObj.UpdateDepartment(dtObj);
        }
    }
}

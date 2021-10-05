using PracticeADOBL;
using PracticeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeMVC.Controllers
{
    public class ProDeptController : Controller
    {
        // GET: ProDept
        public ActionResult ViewAllProducts()
        {
            List<ProDept> lstprodept = new List<ProDept>();
            PBL blObj = new PBL();
            var result = blObj.GetAllProducts();
            foreach (var item in result)
            {
                lstprodept.Add(new ProDept()
                {
                    ProductName = item.ProductName,
                    ProductListPrice = item.ProductListPrice
                });
            }
            return View(lstprodept);
        }
    }
}
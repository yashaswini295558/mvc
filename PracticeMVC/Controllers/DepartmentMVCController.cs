using PracticeADOBL;
using PracticeADODTO;
using PracticeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeMVC.Controllers
{
    public class DepartmentMVCController : Controller
    {
        // GET: DepartmentMVC
        public ActionResult ViewAllDepartments()
        {
            List<DepartmentsMVC> lstdept = new List<DepartmentsMVC>();
            PBL blObj = new PBL();
            var result = blObj.GetAllDepts();
            foreach (var item in result)
            {
                lstdept.Add(new DepartmentsMVC()
                {
                    DeptName = item.DeptName,
                    DeptGroupName = item.DeptGroupName
                });
            }
            return View(lstdept);
        }
        [HttpGet]
        public ActionResult AddNewDept()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewDeptPost(DepartmentsMVC dobj)
        {
            try
            {
                PBL blObj = new PBL();
                DDTO newdptObj = new DDTO();
                newdptObj.DeptName = dobj.DeptName;
                newdptObj.DeptGroupName = dobj.DeptGroupName;
                int result = blObj.AddNewDepartment(newdptObj);
                if (result == 1)
                {
                    return RedirectToAction("ViewAllDepartments");
                }
                else
                {
                    return View("AddNewDept");
                }
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }
    }
}
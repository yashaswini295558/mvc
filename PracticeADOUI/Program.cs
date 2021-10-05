using PracticeADOBL;
using PracticeADODTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeADOUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Adventure Works");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Fetch all proucts name and list price");
            PBL blObj = new PBL();
            var products = blObj.GetAllProducts();
            foreach(var pro in products)
            {
                Console.WriteLine(pro.ProductName + "|" + pro.ProductListPrice);
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Fetch a particular product's name and list price by taking input from user");
            Console.WriteLine("Enter a product name");
            string pName = Console.ReadLine();
            var proName = blObj.GetAllProductsByName(pName);
            foreach(var pro in proName)
            {
                Console.WriteLine(pro.ProductListPrice);
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Insert New Department");
            Console.WriteLine("Enter department name and department group name");
            string dptName = Console.ReadLine();
            string dptGrpName = Console.ReadLine();
            DDTO DeptObj = new DDTO()
            {
                DeptName = dptName,
                DeptGroupName = dptGrpName
            };
            int retVal = blObj.AddNewDepartment(DeptObj);
            if (retVal == 1)
            {
                Console.WriteLine("Department has been added successfully");
            }
            else if (retVal == -1)
            {
                Console.WriteLine("Department name cannot be empty");
            }
            else if (retVal == -2)
            {
                Console.WriteLine("Department group name cannot be empty");
            }
            else if (retVal == -3)
            {
                Console.WriteLine("Department date cannot be empty");
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Update Department");
            Console.WriteLine("Enter department ID, name and group name");
            string dptId = Console.ReadLine();
            string deptName = Console.ReadLine();
            string deptGrpName = Console.ReadLine();
            DDTO DptObj = new DDTO()
            {
                DeptID = Convert.ToInt32(dptId),
                DeptName = deptName,
                DeptGroupName = deptGrpName
            };
            int retValue = blObj.AddNewDepartment(DptObj);
            if (retValue == 1)
            {
                Console.WriteLine("Department updated successfully");
            }
            else if (retValue == -1)
            {
                Console.WriteLine("Department Name cannot be empty");
            }
            else if (retValue == -2)
            {
                Console.WriteLine("Department Group Name cannot be empty");
            }
            else if (retValue == -3)
            {
                Console.WriteLine("Department Modification Date cannot be empty");
            }
            else
            {
                Console.WriteLine("No Department exits with ID " + dptId);
            }
        }
    }
}

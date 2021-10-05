using PracticeADODTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeADODAL
{
    public class PDAL
    {
        string conStr = ConfigurationManager.ConnectionStrings["AdvWorksConStr"].ConnectionString;
        public List<PDTO> FetchAllProducts()
        {
            List<PDTO> lstProduccts = new List<PDTO>();

            //SqlConnection conObj = new SqlConnection(@"data source = (localdb)\ProjectsV13; database = AdventureWorks2012; integrated security = SSPI");
            SqlConnection conObj = new SqlConnection();
            conObj.ConnectionString = conStr;

            SqlCommand queryObj = new SqlCommand();
            queryObj.CommandText = @"SELECT [Name],ListPrice FROM Production.Product";
            queryObj.CommandType = System.Data.CommandType.Text;
            queryObj.Connection = conObj;
            try
            {
                conObj.Open();
                SqlDataReader drProduct = queryObj.ExecuteReader();
                while(drProduct.Read())
                {
                    lstProduccts.Add(new PDTO()
                    {
                        ProductName = drProduct["Name"].ToString(),
                        ProductListPrice = drProduct["ListPrice"].ToString()
                    });
                }
                return lstProduccts;                
            }
            catch (Exception ex)
            {
                throw ex;
               /* Console.WriteLine("Oops something went wrong");
                Console.WriteLine(ex.Message);*/
            }
            /*finally
            {
                conObj.Close();
                Console.WriteLine(conObj.State);
                Console.ReadKey();
            }*/
        }

        public List<PDTO> FetchAllProductsByName(string productName)
        {
            List<PDTO> lstProduccts = new List<PDTO>();

            //SqlConnection conObj = new SqlConnection(@"data source = (localdb)\ProjectsV13; database = AdventureWorks2012; integrated security = SSPI");
            SqlConnection conObj = new SqlConnection();
            conObj.ConnectionString = conStr;

            SqlCommand queryObj = new SqlCommand();
            queryObj.CommandText = @"SELECT [Name],ListPrice FROM Production.Product WHERE [Name] LIKE @productName";
            queryObj.Parameters.AddWithValue("@productName", "%"+productName+"%");
            queryObj.CommandType = System.Data.CommandType.Text;
            queryObj.Connection = conObj;
            try
            {
                conObj.Open();
                SqlDataReader drProduct = queryObj.ExecuteReader();
                while (drProduct.Read())
                {
                    lstProduccts.Add(new PDTO()
                    {
                        ProductName = drProduct["Name"].ToString(),
                        ProductListPrice = drProduct["ListPrice"].ToString()
                    });
                }
                return lstProduccts;
            }
            catch (Exception ex)
            {
                throw ex;
                /* Console.WriteLine("Oops something went wrong");
                 Console.WriteLine(ex.Message);*/
            }
            /*finally
            {
                conObj.Close();
                Console.WriteLine(conObj.State);
                Console.ReadKey();
            }*/
        }
        public List<DDTO> FetchAllDepartments()
        {
            List<DDTO> lstDepts = new List<DDTO>();

            //SqlConnection conObj = new SqlConnection(@"data source = (localdb)\ProjectsV13; database = AdventureWorks2012; integrated security = SSPI");
            SqlConnection conObj = new SqlConnection();
            conObj.ConnectionString = conStr;

            SqlCommand queryObj = new SqlCommand();
            queryObj.CommandText = @"SELECT [Name],GroupName FROM HumanResources.Department";
            queryObj.CommandType = System.Data.CommandType.Text;
            queryObj.Connection = conObj;
            try
            {
                conObj.Open();
                SqlDataReader drDept = queryObj.ExecuteReader();
                while (drDept.Read())
                {
                    lstDepts.Add(new DDTO()
                    {
                        DeptName = drDept["Name"].ToString(),
                        DeptGroupName = drDept["GroupName"].ToString()
                    });
                }
                return lstDepts;
            }
            catch (Exception ex)
            {
                throw ex;
                /* Console.WriteLine("Oops something went wrong");
                 Console.WriteLine(ex.Message);*/
            }
        }  
        public int InsertNewDepartment(DDTO deptObj)
        {
            try
            {
                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"usp_AddNewDepartment";
                queryObj.CommandType = System.Data.CommandType.StoredProcedure;
                queryObj.Connection = conObj;
                queryObj.Parameters.AddWithValue("@dName", deptObj.DeptName);
                queryObj.Parameters.AddWithValue("@dGName", deptObj.DeptGroupName);
                queryObj.Parameters.AddWithValue("@mDate", System.DateTime.Now);
                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                queryObj.Parameters.Add(prmReturn);
                conObj.Open();
                queryObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateDepartment(DDTO deptObj)
        {
            try
            {
                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"usp_UpdateDepartment";
                queryObj.CommandType = System.Data.CommandType.StoredProcedure;
                queryObj.Connection = conObj;
                queryObj.Parameters.AddWithValue("@dId", deptObj.DeptID);
                queryObj.Parameters.AddWithValue("@dName", deptObj.DeptName);
                queryObj.Parameters.AddWithValue("@dGName", deptObj.DeptName);
                queryObj.Parameters.AddWithValue("@mDate", System.DateTime.Now);
                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                queryObj.Parameters.Add(prmReturn);
                conObj.Open();
                queryObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

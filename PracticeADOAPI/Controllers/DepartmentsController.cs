using PracticeADOBL;
using PracticeADODTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PracticeADOAPI.Controllers
{
    public class DepartmentsController : ApiController
    {
        PBL blObj;
        [HttpPost]
        public HttpResponseMessage InsertDepartment(DDTO newDeptObj)
        {
            try
            {
                blObj = new PBL();
                int result = blObj.AddNewDepartment(newDeptObj);
                if (result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Department added successfully");
                }
                else if (result == -1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Department name cannot be empty");
                }
                else if (result == -2)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Department group name cannot be empty");
                }
                else if (result == -3)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Department date cannot be empty");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Something went wrong");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Err error");
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateDepartment(DDTO newDptObj)
        {
            try
            {
                blObj = new PBL();
                int result = blObj.UpdateDept(newDptObj);
                if (result == 1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Department updated successfully");
                }
                else if (result == -1)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Department name cannot be empty");
                }
                else if (result == -2)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Department group name cannot be empty");
                }
                else if (result == -3)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Department date cannot be empty");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "No Department with this id");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Err error");
            }
        }
    }
}


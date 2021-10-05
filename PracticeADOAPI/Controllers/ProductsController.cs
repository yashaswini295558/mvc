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
    //Controller Class
    public class ProductsController : ApiController
    {
        PBL blObj;
        //Actions
        [HttpGet]
        public string Hello()
        {
            return "Hello World";
        }
        [HttpGet]
        public string Bye()
        {
            return "Bye World";
        }
        [HttpGet]
        public HttpResponseMessage GetProducts()
        {
            try
            {
                blObj = new PBL();
                var result = blObj.GetAllProducts();
                if(result!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "No products found");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something went wrong");
            }

        }
        public HttpResponseMessage GetProductsByName(string pName)
        {
            try
            {
                blObj = new PBL();
                var result = blObj.GetAllProductsByName(pName);
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NoContent, "No products found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Something went wrong");
            }

        }

    }
}

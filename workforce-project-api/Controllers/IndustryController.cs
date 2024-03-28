using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repository;
using Model;
using Newtonsoft.Json;

namespace workforce_project_api.Controllers
{
    public class IndustryController : ApiController
    {
        private IndustriesCrud ic = new IndustriesCrud();
        
        [HttpPost]
        public IHttpActionResult Create(Industry_Details newIndustry)
        {
            int response = 0;
            try
            {
                response = ic.createIndustry(newIndustry);
                if (response > 0)
                {
                    return Ok("Industry Successfully Created");
                }
                else
                {
                    return Ok("Unable To Create Industry");
                }
            }   
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
                         
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Industry_Details> il = new List<Industry_Details>();
            try
            {
                il = ic.getAllIndustries();
                if(il !=null)
                {
                    string json = JsonConvert.SerializeObject(il);

                    return Ok(json);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}

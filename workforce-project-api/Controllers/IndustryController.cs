using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repository;
using Model;

namespace workforce_project_api.Controllers
{
    public class IndustryController : ApiController
    {
        private IndustriesCrud ic = new IndustriesCrud();
        
        [HttpPost]
        public IHttpActionResult Create(Industry_Details newIndustry)
        {
            int response = 0;
            if (ModelState.IsValid)
            {
               response=ic.createIndustry(newIndustry);
                if(response>0)
                {
                    return Ok("Industry Successfully Created");
                }
                else
                {
                    return Ok("Unable To Create Industry");
                }
            }
            else
            {
                return BadRequest("Model Is Incomplete");
            }            
        }

    }
}

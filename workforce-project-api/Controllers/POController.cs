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
    public class POController : ApiController
    {
        private PoCrud pc = new PoCrud();

        [HttpPost]
        public IHttpActionResult Create(PO_Details PO)
        {
            int response = 0;
            try
            {
                response = pc.CreatePO(PO);
                if(response>0 && response!=202)
                {
                    return Ok("PO Successfully Created");
                }
                else if(response==202)
                {
                    return BadRequest("Industry Doesnt Exist");
                }
                else
                {
                    return BadRequest("Unable To Create PO");
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public IHttpActionResult GetAllPO(int id)
        {
            List<Model.ReturnClasses.Po> Pos = new List<Model.ReturnClasses.Po>();
            try
            {
                Pos = pc.GetAllPOsByIndustryId(id);
                if(Pos!=null)
                {
                    return Ok(Pos);
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

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
        [Route("Api/Industry/Create")]
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
        [Route("Api/Industry/GetAll")]
        public IHttpActionResult GetAll()
        {
            List<Model.ReturnClasses.Industry> il = new List<Model.ReturnClasses.Industry>();
            try
            {
                il = ic.getAllIndustries();
                if(il !=null)
                {                    

                    return Ok(il);
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

        [HttpGet]
        
        public IHttpActionResult GetById(int id)
        {
            Model.ReturnClasses.Industry iid = new Model.ReturnClasses.Industry();
            try
            {
                iid = ic.getIndustryById(id);
                if(iid!=null)
                {
                    return Ok(iid);
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

        [HttpPost]
        [Route("Api/Industry/EditById")]
        public IHttpActionResult EditById(Industry_Details editid)
        {
            int response = 0;
            try
            {
                response = ic.editIndustryById(editid);
                if(response>0 && response !=202)
                {
                    return Ok("Successfully Edited Industry");
                }
                else if(response==202)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest("Unable To Edit Industry");
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("Api/Industry/DeleteById")]
        public IHttpActionResult DeleteById(int id)
        {
            int response = 0;
            try
            {
                response = ic.deleteIndustryById(id);
                if(response>0 && response!=202)
                {
                    return Ok("Successfully Deleted Industry");
                }
                else if(response==202)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest("Unable To Delete Industry");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }
    }
}

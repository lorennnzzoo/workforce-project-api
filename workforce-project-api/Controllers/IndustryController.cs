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
    [RoutePrefix("Api/Industry")]
    public class IndustryController : ApiController
    {
        private IndustriesCrud ic = new IndustriesCrud();
        
        [HttpPost]
        [Route("Create")]
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
                    return BadRequest("Unable To Create Industry");
                }
            }   
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
                         
        }

        [HttpGet]
        [Route("GetAll")]
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
        [Route("GetById")]
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
        [Route("EditById")]
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

        [HttpDelete]
        [Route("DeleteById")]
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

        [HttpGet]
        [Route("GetAllIndustryTypes")]
        public IHttpActionResult GetAllIndustryTypes()
        {
            List<Model.ReturnClasses.Industry_Types> IT = new List<Model.ReturnClasses.Industry_Types>();
            try
            {
                IT = ic.getIndustryTypes();
                if(IT!=null)
                {
                    return Ok(IT);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("AddIndustryTypes")]
        public IHttpActionResult AddIndustryType(Industry_Types it)
        {
            int response = 0;
            try
            {
                response = ic.AddIndustryTypes(it);
                if(response>0 && response !=100)
                {
                    return Ok("Successfully Added Industry Type");
                }
                else if(response==100)
                {
                    return BadRequest("Industry Type With Name \"" + it.IndustryType + "\" Already Exists");
                }
                else
                {
                    return BadRequest("Unable To Add Industry Type");
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("DeleteIndustryTypes")]
        public IHttpActionResult DeleteIndustryType(int id)
        {
            int response = 0;
            try
            {
                response = ic.DeleteIndustryTypes(id);
                if(response>0 && response !=202)
                {
                    return Ok("Successfully Deleted");
                }
                else if(response==202)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest("Unable To Delete");
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}

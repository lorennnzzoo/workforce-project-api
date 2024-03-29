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
        [Route("Api/Po/Create")]
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
                    return NotFound();
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
        [Route("Api/Po/GetAll")]
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

        [HttpGet]
        public IHttpActionResult GetPoById(int id)
        {
            Model.ReturnClasses.Po po = new Model.ReturnClasses.Po();
            try
            {
                po = pc.GetPoById(id);
                if(po!=null)
                {
                    return Ok(po);
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
        [Route("Api/Po/EditById")]
        public IHttpActionResult Edit(PO_Details po)
        {
            int response = 0;
            try
            {
                response = pc.EditPoDetails(po);
                if(response>0 && response!=202)
                {
                    return Ok("Successfully Edited Po");
                }
                else if(response==202)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest("Unable To Edit PO");
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("Api/Po/DeleteById")]
        public IHttpActionResult Delete(int id)
        {
            int response = 0;
            try
            {
                response = pc.DeletePoById(id);
                if(response>0 && response!=202)
                {
                    return Ok("Successfully Deleted PO");
                }
                else if(response==202)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest("Unable To Delete PO");
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("Api/Po/GetAllPurchaseCategories")]
        public IHttpActionResult GetPurchaseCategories()
        {
            List<Model.ReturnClasses.PurchaseCategories_Types> pctypes = new List<Model.ReturnClasses.PurchaseCategories_Types>();
            try
            {
                pctypes = pc.GetPurchaseCategories();
                if(pctypes!=null)
                {
                    return Ok(pctypes);
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
        [Route("Api/Po/AddPurchaseCategory")]
        public IHttpActionResult AddPurchaseCategory(Purchase_Categories puc)
        {
            int response = 0;
            try
            {
                response = pc.AddPurchaseCategories(puc);
                if (response > 0  && response != 100)
                {
                    return Ok("Successfully Addded New Purchase Category");
                }
                else if(response==100)
                {
                    return BadRequest("Purchase Category With Name \"" + puc.purchase_categorytype + "\" Already Exists");
                }
                else
                {
                    return BadRequest("Unable To Add Purchase Category");
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        [Route("Api/Po/DeletePurchaseCategory")]
        public IHttpActionResult DeletePurchaseCategory(int id)
        {
            int response = 0;
            try
            {
                response = pc.DeletePurchaseCategory(id);
                if(response>0 && response!=202)
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

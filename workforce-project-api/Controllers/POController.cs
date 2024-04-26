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
    [RoutePrefix("Api/Po")]
    public class POController : ApiController
    {
        private PoCrud pc = new PoCrud();
        private EquipmentCrud ec = new EquipmentCrud();

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create(Model.ReturnClasses.Po PO)
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
        [Route("GetAll")]
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
        [Route("GetPoById")]
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
        [Route("EditById")]
        public IHttpActionResult Edit(Model.ReturnClasses.Po po)
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

        [HttpGet]
        [Route("DeleteById")]
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
        [Route("GetAllPurchaseCategories")]
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

        [HttpGet]
        [Route("GetEquipmentTypes")]
        public IHttpActionResult GetEquipmentTypes(int poid)
        {
            List<Model.ReturnClasses.Equipment_Types> eqtypes = new List<Model.ReturnClasses.Equipment_Types>();
            try
            {
                eqtypes = ec.GetEquipmentTypes(poid);
                if(eqtypes!=null)
                {
                    return Ok(eqtypes);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch( Exception ex)
            {
                return InternalServerError(ex);
            }
        }   
        
        
        [HttpPost]     
        [Route("AddEquipmentType")]
        public IHttpActionResult AddEquipmentType(string Type,int poid)
        {
            try
            {
                int success = ec.AddEquipmentType(Type, poid);
                if(success>0 && success !=303)
                {
                    return Ok("Equipment Type Added Successfully");
                }
                else if(success==303)
                {
                    return BadRequest("Equipment Type Already Exists");
                }
                else
                {
                    return BadRequest("Unable To Add Equipment Type");
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        [Route("AddInstrumentationDetails")]
        public IHttpActionResult AddInstrumentationDetails(Instrument_Equipment_Details IED)
        {
            try
            {
                int success = ec.CreateInstrumentationEquipmentDetails(IED);
                if(success>0 && success!=303)
                {
                    return Ok("Instrumentation Equipment Details Created Successfully");
                }
                else if(success==303)
                {
                    return BadRequest("Same SerialNumber Already Exists In The Records Of This Po");
                }
                else
                {
                    return BadRequest("Unable To Create Instrument Equipment Details");
                }
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("GetInstrumentationEquipmentDetails")]
        public IHttpActionResult GetInstrumentationEquipmentDetails(int poid)
        {
            List<Model.ReturnClasses.Instrumentation_Equipment_Details> IDE = new List<Model.ReturnClasses.Instrumentation_Equipment_Details>();
            try
            {
                IDE = ec.GetInstrumentationEquipmentDetails(poid);
                if(IDE!=null)
                {
                    return Ok(IDE);
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
        //[HttpPost]
        //[Route("AddPurchaseCategory")]
        //public IHttpActionResult AddPurchaseCategory(Purchase_Categories puc)
        //{
        //    int response = 0;
        //    try
        //    {
        //        response = pc.AddPurchaseCategories(puc);
        //        if (response > 0  && response != 100)
        //        {
        //            return Ok("Successfully Addded New Purchase Category");
        //        }
        //        else if(response==100)
        //        {
        //            return BadRequest("Purchase Category With Name \"" + puc.purchase_categorytype + "\" Already Exists");
        //        }
        //        else
        //        {
        //            return BadRequest("Unable To Add Purchase Category");
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

        //[HttpDelete]
        //[Route("DeletePurchaseCategory")]
        //public IHttpActionResult DeletePurchaseCategory(int id)
        //{
        //    int response = 0;
        //    try
        //    {
        //        response = pc.DeletePurchaseCategory(id);
        //        if(response>0 && response!=202)
        //        {
        //            return Ok("Successfully Deleted");
        //        }
        //        else if(response==202)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return BadRequest("Unable To Delete");
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}
    }
}

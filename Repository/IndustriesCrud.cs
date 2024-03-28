﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class IndustriesCrud
    {
        private workforce_Entities wfe = new workforce_Entities();

        public List<Industry_Types> getIndustryTypes()
        {
            var IndustryTypes = wfe.Industry_Types.ToList();
            if(IndustryTypes != null)
            {
                return IndustryTypes;
            }
            else
            {
                return null;
            }
        }
        public int createIndustry(Industry_Details indModel)
        {               
            wfe.Industry_Details.Add(indModel);
            int success = wfe.SaveChanges();
            return success;                          
        }
        
        public int deleteIndustryById(int id)
        {            
            var indToDelete = wfe.Industry_Details.FirstOrDefault(e => e.id == id);
            if(indToDelete != null)
            {
                wfe.Industry_Details.Remove(indToDelete);
                int success=wfe.SaveChanges();
                return success;
            }
            else
            {
                return 202;
                //unable to delete industry for id
            }           
        }

        public List<Model.ReturnClasses.Industry> getAllIndustries()
        {           
            var industries = wfe.Industry_Details.ToList();              
            if(industries != null)
            {
                List<Model.ReturnClasses.Industry> returnallinds = new List<Model.ReturnClasses.Industry>();
                foreach(Industry_Details ids in industries)
                {
                    Model.ReturnClasses.Industry newid = new Model.ReturnClasses.Industry
                    {
                        id = ids.id,
                        Industry_FullName = ids.Industry_FullName,
                        Industry_ShortName = ids.Industry_ShortName,
                        Industry_Code = ids.Industry_Code,
                        Industry_TypeID = ids.Industry_TypeID,
                        Address = ids.Address,
                        City = ids.City,
                        State = ids.State,
                        Email_ID = ids.Email_ID,
                        ContactNumber = ids.ContactNumber,
                        
                    };
                    returnallinds.Add(newid);
                    
                }
               


                return returnallinds;
            }
            else
            {
                return null;
            }            
        }

        public Model.ReturnClasses.Industry getIndustryById(int id)
        {
            var industry = wfe.Industry_Details.FirstOrDefault(ind => ind.id == id);
            if(industry !=null)
            {
                Model.ReturnClasses.Industry newid = new Model.ReturnClasses.Industry
                {
                    id = industry.id,
                    Industry_FullName = industry.Industry_FullName,
                    Industry_ShortName = industry.Industry_ShortName,
                    Industry_Code = industry.Industry_Code,
                    Industry_TypeID = industry.Industry_TypeID,
                    Address = industry.Address,
                    City = industry.City,
                    State = industry.State,
                    Email_ID = industry.Email_ID,
                    ContactNumber = industry.ContactNumber,

                };

                return newid;
            }
            else
            {
                return null;
            }
        }

        public int editIndustryById(Industry_Details updatedIndustry)
        {
            var industry = wfe.Industry_Details.FirstOrDefault(ind => ind.id == updatedIndustry.id);
            if(industry!=null)
            {
                industry.Industry_Code = updatedIndustry.Industry_Code;
                industry.Industry_FullName = updatedIndustry.Industry_FullName;
                industry.Industry_ShortName = updatedIndustry.Industry_ShortName;
                industry.Industry_TypeID = updatedIndustry.Industry_TypeID;
                industry.Address = updatedIndustry.Address;
                industry.City = updatedIndustry.City;
                industry.State = updatedIndustry.State;
                industry.Email_ID = updatedIndustry.Email_ID;
                industry.ContactNumber = updatedIndustry.ContactNumber;
                int success= wfe.SaveChanges();
                return success;
            }
            else
            {
                return 202;
                //unable to edit industry for id
            }            
        }
    }
}

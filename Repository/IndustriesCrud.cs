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

        public List<Industry_Details> getAllIndustries()
        {           
            var industries = wfe.Industry_Details.ToList();              
            if(industries != null)
            {
                return industries;
            }
            else
            {
                return null;
            }            
        }

        public Industry_Details getIndustryById(int id)
        {
            var industry = wfe.Industry_Details.FirstOrDefault(ind => ind.id == id);
            if(industry !=null)
            {
                return industry;
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

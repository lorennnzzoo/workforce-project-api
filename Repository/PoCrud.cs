using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class PoCrud
    {
        private workforce_Entities wfe = new workforce_Entities();
        public List<Purchase_Categories> GetPurchaseCategories()
        {
            var purchaseCategories = wfe.Purchase_Categories.ToList();
            if(purchaseCategories!=null)
            {
                return purchaseCategories;
            }
            else
            {
                return null;
            }
        }

        public int CreatePO(PO_Details PO)
        {
            wfe.PO_Details.Add(PO);
            int success=wfe.SaveChanges();
            return success;
        }

        public int DeletePoById(int id)
        {
            var Po = wfe.PO_Details.FirstOrDefault(e => e.id == id);
            if(Po !=null)
            {
                wfe.PO_Details.Remove(Po);
                int success=wfe.SaveChanges();
                return success;
            }
            else
            {
                return 202;
                //unable to delete po details for id
            }
        }

        public List<PO_Details> GetAllPOsByIndustryId(int id)
        {
            var PoDetalisByIndustryId = wfe.PO_Details.Where(e => e.INDUSTRY_ID == id).ToList();
            if(PoDetalisByIndustryId!=null)
            {
                return PoDetalisByIndustryId;
            }
            else
            {
                return null;
            }
        }

        public PO_Details GetPoById(int id)
        {
            var PO = wfe.PO_Details.FirstOrDefault(e => e.id == id);
            if (PO != null)
            {
                return PO;
            }
            else
            {
                return null;
            }
        }

        public int EditPoDetails(PO_Details UpdatedPO)
        {
            var Po = wfe.PO_Details.FirstOrDefault(e => e.id == UpdatedPO.id);
            if(Po!=null)
            {
                Po.INDUSTRY_ID = UpdatedPO.INDUSTRY_ID;            
                Po.PO_DATE = UpdatedPO.PO_DATE;
                Po.PO_NUMBER = UpdatedPO.PO_NUMBER;
                Po.PURCHASE_CATEGORYID = UpdatedPO.PURCHASE_CATEGORYID;
                Po.WORK_SCOPE = UpdatedPO.WORK_SCOPE;
                Po.DEPT_PRIMARY_CONTACTNAME = UpdatedPO.DEPT_PRIMARY_CONTACTNAME;
                Po.DEPT_PRIMARY_CONTACTNUMBER = UpdatedPO.DEPT_PRIMARY_CONTACTNUMBER;
                Po.DEPT_PRIMARY_EMAILID = UpdatedPO.DEPT_PRIMARY_EMAILID;
                Po.PURCHASE_CONTACTNAME = UpdatedPO.PURCHASE_CONTACTNAME;
                Po.PURCHASE_CONTACTNUMBER = UpdatedPO.PURCHASE_CONTACTNUMBER;
                Po.PURCHASE_EMAILID = UpdatedPO.PURCHASE_EMAILID;
                Po.PAYMENT_CONTACTNAME = UpdatedPO.PAYMENT_CONTACTNAME;
                Po.PAYMENT_CONTACTNUMBER = UpdatedPO.PAYMENT_CONTACTNUMBER;
                Po.PAYMENT_EMAILID = UpdatedPO.PAYMENT_EMAILID;
                Po.PAYMENT_DATE = UpdatedPO.PAYMENT_DATE;

                int success=wfe.SaveChanges();
                return success;
            }
            else
            {
                return 202;
                //unable to edit po details for id
            }
        }
    }
}

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
        public List<Model.ReturnClasses.PurchaseCategories_Types> GetPurchaseCategories()
        {
            var purchaseCategories = wfe.Purchase_Categories.ToList();
            if(purchaseCategories!=null)
            {
                List<Model.ReturnClasses.PurchaseCategories_Types> pctypes = new List<Model.ReturnClasses.PurchaseCategories_Types>();
                foreach(Purchase_Categories pc in purchaseCategories)
                {
                    Model.ReturnClasses.PurchaseCategories_Types pcc = new Model.ReturnClasses.PurchaseCategories_Types
                    {
                        id=pc.id,
                        purchase_categorytype=pc.purchase_categorytype.Replace("\r\n", ""),
                    };
                    pctypes.Add(pcc);
                }
                return pctypes;
            }
            else
            {
                return null;
            }
        }

        public int CreatePO(Model.ReturnClasses.Po PO)
        {
            var isindExist = wfe.Industry_Details.FirstOrDefault(e => e.id == PO.INDUSTRY_ID);
            if(isindExist!=null)
            {
                var category = wfe.Purchase_Categories.FirstOrDefault(e => e.purchase_categorytype == PO.PURCHASE_CATEGORY);
                PO_Details newpo = new PO_Details
                {
                    id=PO.id,
                    INDUSTRY_ID=PO.INDUSTRY_ID,
                    PO_DATE=PO.PO_DATE,
                    PO_NUMBER=PO.PO_NUMBER,
                    WORK_SCOPE=PO.WORK_SCOPE,
                    DEPT_PRIMARY_CONTACTNAME=PO.DEPT_PRIMARY_CONTACTNAME,
                    DEPT_PRIMARY_CONTACTNUMBER=PO.DEPT_PRIMARY_CONTACTNUMBER,
                    DEPT_PRIMARY_EMAILID=PO.DEPT_PRIMARY_EMAILID,
                    PURCHASE_CONTACTNAME=PO.PURCHASE_CONTACTNAME,
                    PURCHASE_CONTACTNUMBER=PO.PURCHASE_CONTACTNUMBER,
                    PURCHASE_EMAILID=PO.PURCHASE_EMAILID,
                    PAYMENT_CONTACTNAME=PO.PAYMENT_CONTACTNAME,
                    PAYMENT_CONTACTNUMBER=PO.PAYMENT_CONTACTNUMBER,
                    PAYMENT_EMAILID=PO.PAYMENT_EMAILID,
                    PURCHASE_CATEGORYID=category.id,
                    PAYMENT_DATE=PO.PAYMENT_DATE
                };

                wfe.PO_Details.Add(newpo);
                int success = wfe.SaveChanges();
                return success;
            }
            else
            {
                return 202;
                //industry with PO.INDUSTRY_ID doesnt exist
            }

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

        public List<Model.ReturnClasses.Po> GetAllPOsByIndustryId(int id)
        {
            var PoDetalisByIndustryId = wfe.PO_Details.Where(e => e.INDUSTRY_ID == id).ToList();
            if(PoDetalisByIndustryId!=null)
            {
                List<Model.ReturnClasses.Po> Pos = new List<Model.ReturnClasses.Po>();
                foreach(PO_Details po in PoDetalisByIndustryId)
                {
                    var category = wfe.Purchase_Categories.FirstOrDefault(e => e.id == po.PURCHASE_CATEGORYID);
                    Model.ReturnClasses.Po getpo = new Model.ReturnClasses.Po
                    {
                        id = po.id,
                        INDUSTRY_ID = po.INDUSTRY_ID,
                        PO_DATE = po.PO_DATE,
                        PO_NUMBER = po.PO_NUMBER,
                        PURCHASE_CATEGORY = category.purchase_categorytype,
                        WORK_SCOPE = po.WORK_SCOPE,
                        DEPT_PRIMARY_CONTACTNAME = po.DEPT_PRIMARY_CONTACTNAME,
                        DEPT_PRIMARY_CONTACTNUMBER = po.DEPT_PRIMARY_CONTACTNUMBER,
                        DEPT_PRIMARY_EMAILID=po.DEPT_PRIMARY_EMAILID,
                        PURCHASE_CONTACTNAME=po.PURCHASE_CONTACTNAME,
                        PURCHASE_CONTACTNUMBER=po.PURCHASE_CONTACTNUMBER,
                        PURCHASE_EMAILID=po.PURCHASE_EMAILID,
                        PAYMENT_CONTACTNAME=po.PAYMENT_CONTACTNAME,
                        PAYMENT_CONTACTNUMBER=po.PAYMENT_CONTACTNUMBER,
                        PAYMENT_EMAILID=po.PAYMENT_EMAILID,
                        PAYMENT_DATE=po.PAYMENT_DATE,

                    };
                    Pos.Add(getpo);
                }
                return Pos;
            }
            else
            {
                return null;
            }
        }

        public Model.ReturnClasses.Po GetPoById(int id)
        {
            var PO = wfe.PO_Details.FirstOrDefault(e => e.id == id);
            if (PO != null)
            {
                var category = wfe.Purchase_Categories.FirstOrDefault(e => e.id == PO.PURCHASE_CATEGORYID);
                Model.ReturnClasses.Po po = new Model.ReturnClasses.Po
                {
                    id = PO.id,
                    INDUSTRY_ID = PO.INDUSTRY_ID,
                    PO_DATE = PO.PO_DATE,
                    PO_NUMBER = PO.PO_NUMBER,
                    PURCHASE_CATEGORY = category.purchase_categorytype,
                    WORK_SCOPE = PO.WORK_SCOPE,
                    DEPT_PRIMARY_CONTACTNAME = PO.DEPT_PRIMARY_CONTACTNAME,
                    DEPT_PRIMARY_CONTACTNUMBER = PO.DEPT_PRIMARY_CONTACTNUMBER,
                    DEPT_PRIMARY_EMAILID = PO.DEPT_PRIMARY_EMAILID,
                    PURCHASE_CONTACTNAME = PO.PURCHASE_CONTACTNAME,
                    PURCHASE_CONTACTNUMBER = PO.PURCHASE_CONTACTNUMBER,
                    PURCHASE_EMAILID = PO.PURCHASE_EMAILID,
                    PAYMENT_CONTACTNAME = PO.PAYMENT_CONTACTNAME,
                    PAYMENT_CONTACTNUMBER = PO.PAYMENT_CONTACTNUMBER,
                    PAYMENT_EMAILID = PO.PAYMENT_EMAILID,
                    PAYMENT_DATE = PO.PAYMENT_DATE,
                };
                return po;
            }
            else
            {
                return null;
            }
        }

        public int EditPoDetails(Model.ReturnClasses.Po UpdatedPO)
        {
            var Po = wfe.PO_Details.FirstOrDefault(e => e.id == UpdatedPO.id);
            var categoryofpo = wfe.Purchase_Categories.FirstOrDefault(e => e.purchase_categorytype == UpdatedPO.PURCHASE_CATEGORY);
            if(Po!=null)
            {
                Po.INDUSTRY_ID = UpdatedPO.INDUSTRY_ID;            
                Po.PO_DATE = UpdatedPO.PO_DATE;
                Po.PO_NUMBER = UpdatedPO.PO_NUMBER;
                Po.PURCHASE_CATEGORYID = categoryofpo.id;
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

        public int AddPurchaseCategories(Purchase_Categories  puc)
        {
            var isPurExist = wfe.Purchase_Categories.Any(e => e.purchase_categorytype == puc.purchase_categorytype);
            if (isPurExist)
            {
                return 100;
                //purchase_categorytype already exist
            }
            else
            {
                wfe.Purchase_Categories.Add(puc);
                int success=wfe.SaveChanges();
                return success;
            }
        }

        public int DeletePurchaseCategory(int id)
        {
            var isCategoryExist = wfe.Purchase_Categories.FirstOrDefault(e => e.id == id);
            if(isCategoryExist!=null)
            {
                wfe.Purchase_Categories.Remove(isCategoryExist);
                int success = wfe.SaveChanges();
                return success;
            }
            else
            {
                return 202;
            }
        }
    }
}

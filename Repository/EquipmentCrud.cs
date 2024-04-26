using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EquipmentCrud
    {
        private workforce_Entities wfe = new workforce_Entities();
        public List<Model.ReturnClasses.Equipment_Types> GetEquipmentTypes(int poid)
        {
            List<Model.ReturnClasses.Equipment_Types> eqtypes = new List<Model.ReturnClasses.Equipment_Types>();           
            var podetails = wfe.PO_Details.Where(e => e.id == poid);
            if(podetails!=null)
            {
                var purchasecategoryid = podetails.Select(e => e.PURCHASE_CATEGORYID).FirstOrDefault();                
                if(purchasecategoryid!=null)
                {
                    List<Equipment_Types> equiptyes = wfe.Equipment_Types.Where(e => e.Purchase_Category_Id == purchasecategoryid).ToList();
                    if(equiptyes!=null)
                    {
                        foreach(Equipment_Types eqtype in equiptyes)
                        {
                            Model.ReturnClasses.Equipment_Types eqt = new Model.ReturnClasses.Equipment_Types
                            {
                                id = eqtype.id,       
                                PoId=poid,                         
                                Equipment_Type=eqtype.Equipment_Type
                            };
                            eqtypes.Add(eqt);
                        }
                        return eqtypes;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }



        //public int CreateInstrumentationEquipmentDetails(Instrument_Equipment_Details IED)
        //{

        //}

        public int AddEquipmentType(string Type, int poid)
        {
            int success = 0;
            var podetails = wfe.PO_Details.Where(e => e.id == poid);
            var purchasecategoryid = podetails.Select(e => e.PURCHASE_CATEGORYID).FirstOrDefault();
            Equipment_Types eq = new Equipment_Types
            {
                Purchase_Category_Id =Convert.ToInt32( purchasecategoryid),
                Equipment_Type= Type,
            };
            wfe.Equipment_Types.Add(eq);
            success = wfe.SaveChanges();
            if(success>0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}

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

        public List<Model.ReturnClasses.Instrumentation_Equipment_Details> GetInstrumentationEquipmentDetails(int Poid)
        {
            List<Model.ReturnClasses.Instrumentation_Equipment_Details> AllDetails = new List<Model.ReturnClasses.Instrumentation_Equipment_Details>();
            List<Instrument_Equipment_Details> IDE = wfe.Instrument_Equipment_Details.Where(e => e.PO_Id == Poid).ToList();
            if(IDE!=null)
            {
                foreach(Instrument_Equipment_Details ID in IDE)
                {
                    string equipmentype = wfe.Equipment_Types.Where(e => e.id == ID.Equipment_Type_Id).Select(e => e.Equipment_Type).FirstOrDefault();
                    Model.ReturnClasses.Instrumentation_Equipment_Details returnide = new Model.ReturnClasses.Instrumentation_Equipment_Details
                    {
                        id=ID.id,
                        PO_Id=ID.PO_Id,
                        Equipment_Type= equipmentype,
                        Analyzer_Name=ID.Analyzer_Name,
                        Make=ID.Make,
                        Model=ID.Model,
                        Serial_Number=ID.Serial_Number,
                        Purchase_Year=ID.Purchase_Year,
                        Calibration_Certificate_Number=ID.Calibration_Certificate_Number
                    };
                    AllDetails.Add(returnide);
                }
                return AllDetails;
            }
            else
            {
                return null;
            }

        }

        public int CreateInstrumentationEquipmentDetails(Instrument_Equipment_Details IED)
        {
            int success = 0;
            List<Instrument_Equipment_Details> currentEquipmentDetails = wfe.Instrument_Equipment_Details.Where(e => e.PO_Id == IED.PO_Id).ToList();
            if (currentEquipmentDetails != null)
            {
                var isSerialNumberDuplicate = currentEquipmentDetails.Where(e => e.Serial_Number == IED.Serial_Number);
                if(isSerialNumberDuplicate==null)
                {
                    wfe.Instrument_Equipment_Details.Add(IED);
                    success = wfe.SaveChanges();
                    return success;
                }
                else
                {
                    return 303;
                }
            }
            else
            {
                wfe.Instrument_Equipment_Details.Add(IED);
                success = wfe.SaveChanges();
                return success;
            }
        }

        public int AddEquipmentType(string Type, int poid)
        {
            int success = 0;
            var istypeexists = wfe.Equipment_Types.FirstOrDefault(e => e.Equipment_Type.ToUpper() == Type.ToUpper());
            if(istypeexists==null)
            {
                var podetails = wfe.PO_Details.Where(e => e.id == poid);
                var purchasecategoryid = podetails.Select(e => e.PURCHASE_CATEGORYID).FirstOrDefault();
                Equipment_Types eq = new Equipment_Types
                {
                    Purchase_Category_Id = Convert.ToInt32(purchasecategoryid),
                    Equipment_Type = Type.ToUpper(),
                };
                wfe.Equipment_Types.Add(eq);
                success = wfe.SaveChanges();
                return success;
            }
            else
            {
                return 303;
            }
            
        }
    }
}

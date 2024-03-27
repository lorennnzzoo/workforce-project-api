using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Model;

namespace RepoTesting
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //testing Repo Methods Industry   
            // Repository.IndustriesCrud ic = new IndustriesCrud();
            // List<Industry_Details> idc= ic.getAllIndustries();

            //Industry_Details id = ic.getIndustryById(1);
            //List<Industry_Types> it = ic.getIndustryTypes();


            //Industry_Details iddd = new Industry_Details
            //{
            //    Industry_FullName = "fullname",
            //    Industry_ShortName = "shortname",
            //    Industry_TypeID = 1,
            //    Industry_Code = "code",
            //    Address = "address",
            //    City = "city",
            //    State = "state",
            //    Email_ID = "hello@gmail.com",
            //    ContactNumber = "+919999999999"

            //};
            //string succ = ic.createIndustry(iddd);



            //Industry_Details iddd2 = new Industry_Details
            //{
            //    id=6,
            //    Industry_FullName = "fullname",
            //    Industry_ShortName = "shortname222",
            //    Industry_TypeID = 1,
            //    Industry_Code = "code",
            //    Address = "address",
            //    City = "city",
            //    State = "state",
            //    Email_ID = "hello@gmail.com",
            //    ContactNumber = "+919999999999"

            //};
            //string succ2 = ic.editIndustryById(iddd2);

            //string delsucc = ic.deleteIndustryById(6);


            //testing Repo Methods Po
            Repository.PoCrud pc = new PoCrud();

            //PO_Details podd = new PO_Details
            //{
            //    INDUSTRY_ID = 1,
            //    PO_DATE = Convert.ToDateTime("2024-02-14"),
            //    PO_NUMBER = "33",
            //    PURCHASE_CATEGORYID = 1,
            //    WORK_SCOPE = "helksjdbflsadbvfogadfjgsaiugfasdjg",
            //    DEPT_PRIMARY_CONTACTNAME = "ramesh",
            //    DEPT_PRIMARY_CONTACTNUMBER = "+912345678890",
            //    DEPT_PRIMARY_EMAILID = "ramesh@gmail.com",
            //    PURCHASE_CONTACTNAME = "bhanu",
            //    PURCHASE_CONTACTNUMBER = "+911234512345",
            //    PURCHASE_EMAILID = "bhanu@gmail.com",
            //    PAYMENT_CONTACTNAME = "dharma",
            //    PAYMENT_CONTACTNUMBER = "+911234512345",
            //    PAYMENT_EMAILID = "dharma@gmail.com",
            //    PAYMENT_DATE = Convert.ToDateTime("2024-02-14")
            //};
            //string succpo = pc.CreatePO(podd);

            List<PO_Details> pode = pc.GetAllPOsByIndustryId(1);
            PO_Details po = pc.GetPoById(1);
            List<Purchase_Categories> pcat = pc.GetPurchaseCategories();


            PO_Details edpodd = new PO_Details
            {
                id=3,
                INDUSTRY_ID = 1,
                PO_DATE = Convert.ToDateTime("2024-02-14"),
                PO_NUMBER = "33",
                PURCHASE_CATEGORYID = 1,
                WORK_SCOPE = "helksjdbflsadbvfogadfjgsaiugfasdjg",
                DEPT_PRIMARY_CONTACTNAME = "ramesh",
                DEPT_PRIMARY_CONTACTNUMBER = "+912345678890",
                DEPT_PRIMARY_EMAILID = "ramesh@gmail.com",
                PURCHASE_CONTACTNAME = "bhanu",
                PURCHASE_CONTACTNUMBER = "+911234512345",
                PURCHASE_EMAILID = "bhanu@gmail.com",
                PAYMENT_CONTACTNAME = "dharma",
                PAYMENT_CONTACTNUMBER = "+911234512345",
                PAYMENT_EMAILID = "dharma@gmail.com",
                PAYMENT_DATE = Convert.ToDateTime("2024-02-14")
            };

            string succedpodd = pc.EditPoDetails(edpodd);
        }
    }
}

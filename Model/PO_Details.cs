//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PO_Details
    {
        public int id { get; set; }
        public Nullable<int> INDUSTRY_ID { get; set; }
        public Nullable<System.DateTime> PO_DATE { get; set; }
        public string PO_NUMBER { get; set; }
        public Nullable<int> PURCHASE_CATEGORYID { get; set; }
        public string WORK_SCOPE { get; set; }
        public string DEPT_PRIMARY_CONTACTNAME { get; set; }
        public string DEPT_PRIMARY_CONTACTNUMBER { get; set; }
        public string DEPT_PRIMARY_EMAILID { get; set; }
        public string PURCHASE_CONTACTNAME { get; set; }
        public string PURCHASE_CONTACTNUMBER { get; set; }
        public string PURCHASE_EMAILID { get; set; }
        public string PAYMENT_CONTACTNAME { get; set; }
        public string PAYMENT_CONTACTNUMBER { get; set; }
        public string PAYMENT_EMAILID { get; set; }
        public Nullable<System.DateTime> PAYMENT_DATE { get; set; }
    
        public virtual Industry_Details Industry_Details { get; set; }
        public virtual Purchase_Categories Purchase_Categories { get; set; }
    }
}

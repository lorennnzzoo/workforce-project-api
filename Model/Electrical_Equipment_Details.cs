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
    
    public partial class Electrical_Equipment_Details
    {
        public int Id { get; set; }
        public Nullable<int> PO_Id { get; set; }
        public Nullable<int> Equipment_Type_Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public Nullable<System.DateTime> Purchase_Year { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual Equipment_Types Equipment_Types { get; set; }
        public virtual PO_Details PO_Details { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ReturnClasses
{
    public class Electrical_Equipment_Details
    {
        public int Id { get; set; }
        public Nullable<int> PO_Id { get; set; }
        public string Equipment_Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        //public Nullable<System.DateTime> Purchase_Year { get; set; }
        public string Purchase_Year { get; set; }
        public Nullable<int> Quantity { get; set; }

        public virtual Equipment_Types Equipment_Types { get; set; }
        public virtual PO_Details PO_Details { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ReturnClasses
{
    public class Instrumentation_Equipment_Details
    {
        public int id { get; set; }
        public int PO_Id { get; set; }
        public string Equipment_Type { get; set; }
        public string Analyzer_Name { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Serial_Number { get; set; }
        public Nullable<System.DateTime> Purchase_Year { get; set; }
        public string Calibration_Certificate_Number { get; set; }
    }
}

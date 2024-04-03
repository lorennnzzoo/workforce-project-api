using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ReturnClasses
{
    public class Industry
    {
        public int id { get; set; }
        public string Industry_FullName { get; set; }
        public string Industry_ShortName { get; set; }
        public string Industry_Code { get; set; }
        public string Industry_Type { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Email_ID { get; set; }
        public string ContactNumber { get; set; }
    }
}

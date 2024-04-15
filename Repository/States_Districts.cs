using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class States_Districts
    {
        private workforce_Entities wfe = new workforce_Entities();
        public List<state> getAllStates()
        {
            List<state> states = wfe.states.ToList();
            if(states!=null)
            {
                return states;
            }
            return null;            
        }



        public List<district> GetDistrictByStateid(int stateid)
        {
            List < district > districts = wfe.districts.Where(e => e.stateid == stateid).ToList();

            if(districts!=null)
            {
                return districts;
            }
            else
            {
                return null;
            }
        }
    }
}

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
        public List<Model.ReturnClasses.States> getAllStates()
        {
            List<state> states = wfe.states.ToList();
            List<Model.ReturnClasses.States> statestoreturn = new List<Model.ReturnClasses.States>();
            if(states!=null)
            {
                
                foreach(state st in states)
                {
                    Model.ReturnClasses.States newst = new Model.ReturnClasses.States
                    {
                        id=st.id,
                        state=st.state1
                    };
                    statestoreturn.Add(newst);
                }
                return statestoreturn;

            }
            return null;         
        }



        public List<Model.ReturnClasses.Districts> GetDistrictByStateid(int stateid)
        {
            List < district > districts = wfe.districts.Where(e => e.stateid == stateid).ToList();
            List<Model.ReturnClasses.Districts> districsttoretun = new List<Model.ReturnClasses.Districts>();
            if(districts!=null)
            {
                foreach(district dt in districts)
                {
                    Model.ReturnClasses.Districts newdt = new Model.ReturnClasses.Districts
                    {
                        id=dt.id,
                        stateid=dt.stateid,
                        district=dt.district1
                    };
                    districsttoretun.Add(newdt);                   
                }
                return districsttoretun;
            }
            else
            {
                return null;
            }
        }
    }
}

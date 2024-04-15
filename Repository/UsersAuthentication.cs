using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class UsersAuthentication
    {
        private workforce_Entities wfe = new workforce_Entities();
        public  bool IsUserAuthorized(User user)
        {
            var isuser = wfe.Users.FirstOrDefault(e => e.username == user.username);
            if(isuser!=null)
            {
                if(isuser.password==user.password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

    }
}

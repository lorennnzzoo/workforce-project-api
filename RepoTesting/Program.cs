using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace RepoTesting
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //testing Repo Methods Industry   
             Repository.IndustriesCrud ic = new IndustriesCrud();
            ic.getAllIndustries();
        }
    }
}

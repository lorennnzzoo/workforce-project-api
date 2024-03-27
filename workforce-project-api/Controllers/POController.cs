using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Repository;

namespace workforce_project_api.Controllers
{
    public class POController : ApiController
    {
        private PoCrud pc = new PoCrud();
    }
}

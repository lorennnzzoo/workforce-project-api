using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using Model.Auth;
using Repository;

namespace workforce_project_api.Controllers
{
    [RoutePrefix("Api/Auth")]
    public class AuthController : ApiController
    {
        private UsersAuthentication ua = new UsersAuthentication();
        [HttpGet]
        [Route("Login")]
        public IHttpActionResult Login(User user)
        {
            
            bool isauthorized = ua.IsUserAuthorized(user);
            if(isauthorized)
            {
                JwtAuthenticationManager jwt = new JwtAuthenticationManager("PF36qeEbfPPryjLAyDL04rwr6hZpNGVp");
                string token=jwt.GenerateToken(user.username);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

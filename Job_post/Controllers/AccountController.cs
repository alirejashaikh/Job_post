using Job_post.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI;

namespace Job_post.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        [Route("api/Account/LoginPost")]
        public HttpResponseMessage LoginPost([FromBody]  LoginData user)
        {
            using (var context = new DataContext())
            {
                var isValid = context.loginDatas.Any(x => x.username == user.username && x.password == user.password);
                if (isValid)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, value: TokenManager.GenerateToken(user.username));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "username and password in invalid");
                }
            }
        }
        
        public HttpResponseMessage Get()
        {
            using (DataContext dBContext = new DataContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, dBContext.loginDatas.ToList());
            }
        }
        //post signup
        [HttpPost]
        [Route("api/Account/SignupPost")]
        public HttpResponseMessage SignupPost([FromBody] LoginData user)
        {
            try
            {
                using (DataContext dbContext = new DataContext())
                {
                    dbContext.loginDatas.Add(user);
                    dbContext.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, user);
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}

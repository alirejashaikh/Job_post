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
    public class AdminController : ApiController
    {
        public HttpResponseMessage Post([FromBody] AdminLogin user)
        {
            try
            {
                using (DataContext dbContext = new DataContext())
                {
                    dbContext.AdminLogins.Add(user);
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
        [HttpPost]
        [Route("api/Admin/LoginPost")]
        public HttpResponseMessage LoginPost([FromBody]  AdminLogin user)
        {
            using (var context = new DataContext())
            {
                var isValid = context.AdminLogins.Any(x => x.UserName == user.UserName && x.Password == user.Password);
                if (isValid)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, value: TokenManager.GenerateToken(user.UserName));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "username and password in invalid");
                }
            }
        }
    }
}

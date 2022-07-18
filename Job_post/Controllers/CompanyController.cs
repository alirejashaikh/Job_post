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
    public class CompanyController : ApiController
    {
        [HttpPost]
        [Route("api/Company/CompanyLoginPost")]
        public HttpResponseMessage CompanyLoginPost([FromBody]  CompanyRegistration company)
        {
            using (var context = new DataContext())
            {
                var isValid = context.CompanyRegistrations.Any(x => x.UserName == company.UserName && x.Password == company.Password);
                if (isValid)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, value: TokenManager.GenerateToken(company.UserName));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "username and password in invalid");
                }
            }
        }

        [Route("api/Company/Get")]
        public HttpResponseMessage Get()
        {
            using (DataContext dBContext = new DataContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, dBContext.CompanyRegistrations.ToList());
            }
        }

        [HttpPost]
        [Route("api/Company/CompanySignupPost")]
        public HttpResponseMessage CompanySignupPost([FromBody] CompanyRegistration user)
        {
            try
            {
                using (DataContext dbContext = new DataContext())
                {
                    dbContext.CompanyRegistrations.Add(user);
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

        [HttpGet]
        [Route("api/Company/GetUserData/{UserName}")]
        public HttpResponseMessage GetUserData(string UserName)
        {
            using (DataContext dBContext = new DataContext())
            {
                var userDetail = dBContext.CompanyRegistrations.Where(x => x.UserName == UserName).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, userDetail);
            }
        }
    }
}

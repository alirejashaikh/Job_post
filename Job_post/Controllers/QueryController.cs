using Job_post.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Job_post.Controllers
{
    public class QueryController : ApiController
    {
        [HttpPost]
        [Route("api/Query/UserQuery")]
        //[CustomAuthenticationFilter]
        public HttpResponseMessage UserQuery([FromBody] UserQuery  user)
        {
            try
            {
                using (DataContext dbContext = new DataContext())
                {
                    dbContext.UserQueries.Add(user);
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
        [Route("api/Query/CompanyQuery")]
        //[CustomAuthenticationFilter]
        public HttpResponseMessage CompanyQuery([FromBody] CompanyQuery user)
        {
            try
            {
                using (DataContext dbContext = new DataContext())
                {
                    dbContext.companyQueries.Add(user);
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
        [Route("api/Query/UserGet")]
        public HttpResponseMessage Get()
        {
            using (DataContext dBContext = new DataContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, dBContext.UserQueries.ToList());
            }
        }
        [HttpGet]
        [Route("api/Query/CompanyGet")]
        public HttpResponseMessage CompanyGet()
        {
            using (DataContext dBContext = new DataContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, dBContext.companyQueries.ToList());
            }
        }

    }
}

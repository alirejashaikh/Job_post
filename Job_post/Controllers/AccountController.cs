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
        [Route("api/Account/Get")]
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
        //[CustomAuthenticationFilter]
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

        [HttpGet]
        [Route("api/Account/GetUserProfile/{email}")]
        public HttpResponseMessage GetUserProfile(string email)
        {
            using (DataContext dBContext = new DataContext())
            {
                var userDetail = dBContext.userProfiles.Where(x=>x.Email==email).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, userDetail);
            }
        }

        [HttpPost]
        [Route("api/Account/UserProfilePost")]
        public HttpResponseMessage UserProfilePost([FromBody] UserProfile userProfile)
        {
            try
            {
                using (DataContext dbContext = new DataContext())
                {
                    dbContext.userProfiles.Add(userProfile);
                    dbContext.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, userProfile);
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpGet]
        [Route("api/Account/GetUserData/{UserName}")]
        public HttpResponseMessage GetUserData(string UserName)
        {
            using (DataContext dBContext = new DataContext())
            {
                var userDetail = dBContext.loginDatas.Where(x => x.username == UserName).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, userDetail);
            }
        }

    }
}

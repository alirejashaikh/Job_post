using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Job_post.Models;
using WebAPI;

namespace Job_post.Controllers
{
    public class Job_DataController : ApiController
    {
        
        public HttpResponseMessage Get()
        {
            using (DataContext dBContext = new DataContext())
            {
                return Request.CreateResponse(HttpStatusCode.OK, dBContext.job_Datas.ToList());
            }
        }

        public HttpResponseMessage Post([FromBody] Job_Data job_Data)
        {
            try
            {
                using (DataContext dbContext = new DataContext())
                {
                    dbContext.job_Datas.Add(job_Data);
                    dbContext.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, job_Data);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_post.Models
{
    public class CompanyRegistration
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public string ContactPerson { get; set; }
        public string Detail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
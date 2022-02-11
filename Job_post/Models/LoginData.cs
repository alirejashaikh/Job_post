using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_post.Models
{
    public class LoginData
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Email { get; set; }
        public DateTime Date_Of_Birth  { get; set; }
        public string Address { get; set; }

    }
}
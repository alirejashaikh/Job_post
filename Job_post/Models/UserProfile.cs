using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_post.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Qualification { get; set; }
    }
}
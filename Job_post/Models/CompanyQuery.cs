﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_post.Models
{
    public class CompanyQuery
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string CompanyName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Job_post.Models
{
    [Table("tbl_JobData")]

    public class Job_Data
    {
        [Key]
        public int Job_Id { get; set; }

        [StringLength(40,ErrorMessage ="Cannot accept more then 40 letter")]
        public string Job_Title { get; set; }

        public int No_Of_Openings { get; set; }

        public int Salary { get; set; }

        [StringLength(40, ErrorMessage = "Cannot accept more then 40 letter")]
        public string Job_Location { get; set; }

        [StringLength(200,ErrorMessage = "Cannot accept more then 200 letter")]
        public string Job_Description { get; set; }

        public string Job_Timing { get; set; }

        [StringLength(40, ErrorMessage = "Cannot accept more then 40 letter")]
        public string Interview_Details { get; set; }

        [StringLength(40, ErrorMessage = "Cannot accept more then 40 letter")]
        public string Company_Name { get; set; }

        [StringLength(40, ErrorMessage = "Cannot accept more then 40 letter")]
        public string Contact_Person_Name { get; set; }

        public int Phone_Number { get; set; }

        [StringLength(40, ErrorMessage = "Cannot accept more then 40 letter")]
        public string Email { get; set; }

        [StringLength(40, ErrorMessage = "Cannot accept more then 40 letter")]
        public string Job_Address { get; set; }


    }

    
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace templateProj.Models
{

    [Table("user")]
    public class UserModel
    {
        public int id { get; set; }
        [Key]
        public string Username { get; set; } 

        public string password { get; set; }

        public string salt { get; set; }

        public string Email { get; set; }

        public string role { get; set; }

        public string ProfilePic { get; set; }

        public string Designation { get; set; }

        public int NumOfProjcts { get; set; }

        public string Skills { get; set; }

        public string Status { get; set; }
         
        public string Location { get; set; }

        public string Education { get; set; }

        public string CurrentProject { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string DoB { get; set; }

        public int CurrentProj { get; set; }


    }
}
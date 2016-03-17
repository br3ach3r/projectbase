using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace templateProj.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DBcon")         
        {
        } 
 
        public DbSet<UserModel> Umodel { get; set; }


    }
} 
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.Models
{
    public class StudentContaxt : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}
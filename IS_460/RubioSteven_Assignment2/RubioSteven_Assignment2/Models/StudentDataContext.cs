using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RubioSteven_Assignment2.Models
{
    public class StudentDataContext : DbContext
    {
        public StudentDataContext(DbContextOptions<StudentDataContext> options)
            : base(options)
        {
        }

        public DbSet<RubioSteven_Assignment2.Models.Student> StudentItems { get; set; }
    }
}

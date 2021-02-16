using backwebangular.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backwebangular
{
    public class Dbcontext : DbContext
    {
       public DbSet<Newstudentm1DB> new_student_register_m1 { get; set; }
       public DbSet<Newstudentm4DB> new_student_register_m4 { get; set; } 
       

        public Dbcontext()
        {

        }
        public Dbcontext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=pwkswebangular");
            }
            
        }
       
    }
}

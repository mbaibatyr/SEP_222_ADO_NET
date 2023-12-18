using Microsoft.EntityFrameworkCore;
using MyEFCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyEFCore.DbContextEF
{
    public class MyContext : DbContext
    {
        public DbSet<Car> Car { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<Child> Child { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Country> Country { get; set; }
        public DbSet<Capital> Capital { get; set; }

        
        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server=206-P;Database=testDB;Trusted_Connection=True;");
        }
    }
}

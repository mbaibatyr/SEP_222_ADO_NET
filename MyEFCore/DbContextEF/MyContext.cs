using Microsoft.EntityFrameworkCore;
using MyEFCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEFCore.DbContextEF
{
    public class MyContext : DbContext
    {
        public DbSet<Car> Car { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer("Server=206-P;Database=testDB;Trusted_Connection=True;");
        }
    }
}

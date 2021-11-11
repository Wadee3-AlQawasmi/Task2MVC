using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Task2MVC.Data
{
    public class SysContext:DbContext
    {
        IConfiguration configuration;
        public SysContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public DbSet<City> city { set; get; }
        public DbSet<Country> country { set; get; }
        public DbSet<Department> department { set; get; }
        public DbSet<Employee> employee { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Task2Company"));
            /*optionsBuilder.UseSqlServer("data source = localhost ; initial catalog = Task2; Integrated Security = true");*/
            base.OnConfiguring(optionsBuilder);
        }
    }
    
}

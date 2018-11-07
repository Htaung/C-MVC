using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMVC.Models;

namespace TestMVC.Repository
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("SalesERPDAL") { }


        public DbSet<Employee> employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

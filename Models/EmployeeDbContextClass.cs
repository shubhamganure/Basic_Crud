using System;
using Microsoft.EntityFrameworkCore;

namespace Basic_Crud
{
    public class EmployeeDbContextClass: DbContext
    {
        public EmployeeDbContextClass(DbContextOptions<EmployeeDbContextClass> options) : base(options)
        {
        }

        public DbSet<EmployeeNewClass> Employees { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<Location> Locations { get; set; }


    }
}

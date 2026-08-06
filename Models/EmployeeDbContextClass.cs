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
        public DbSet<TeacherModel> TeacherModels { get; set; }

        public DbSet<ProductDetailsModel> ProductDetailsModels {get;set;}
        public DbSet<ProductExtraDetailsModel> ProductExtraDetailsModels {get;set;}

        public DbSet<EmployeeMasterModel> EmployeeMasterModels { get; set; }
        public DbSet<EmployeeIdentityDetailsModel> EmployeeIdentityDetailsModels { get; set; }
        public DbSet<CustomerModel> CustomerModels { get; set; }
        public DbSet<CustomerAddressModel> CustomerAddressModels { get; set; }

    }
}

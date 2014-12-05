using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EFConvention.CA.Model.Conventions;
using EFConvention.CA.Model.Entities;

namespace EFConvention.CA.Model
{
    public class EFConventionContext : DbContext
    {
        public EFConventionContext()
        {
            Initialization();
        }

        public EFConventionContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Initialization(); 
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }

        private void Initialization()
        {
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            RemoveConventions(modelBuilder);
            AddCustomConventions(modelBuilder);

            AddConfigurations(modelBuilder);
        }

        private static void RemoveConventions(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        private static void AddCustomConventions(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Where(x => x.Name.ToLower().Contains("name")).Configure(c => c.HasMaxLength(150));
            modelBuilder.Properties<string>().Where(x => x.Name.ToLower().Contains("address")).Configure(c => c.HasMaxLength(450));
        }
        
        private static void AddConfigurations(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new ContactPersonConfiguration());
        }
    }
}
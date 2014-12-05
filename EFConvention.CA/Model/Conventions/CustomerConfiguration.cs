using System.Data.Entity.ModelConfiguration;
using EFConvention.CA.Model.Entities;

namespace EFConvention.CA.Model.Conventions
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("Customers");
            HasMany(p => p.Addresses).WithRequired(p => p.Customer).WillCascadeOnDelete(true);
        }
    }
}
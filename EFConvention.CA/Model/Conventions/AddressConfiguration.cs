using System.Data.Entity.ModelConfiguration;
using EFConvention.CA.Model.Entities;

namespace EFConvention.CA.Model.Conventions
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            ToTable("CustomersAddresses");
        }
    }
}
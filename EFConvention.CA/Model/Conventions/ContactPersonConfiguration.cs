using System.Data.Entity.ModelConfiguration;
using EFConvention.CA.Model.Entities;

namespace EFConvention.CA.Model.Conventions
{
    public class ContactPersonConfiguration : EntityTypeConfiguration<ContactPerson>
    {
        public ContactPersonConfiguration()
        {
            ToTable("CustomersAddressesContactPersons");
        }
    }
}
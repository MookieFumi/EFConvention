using System.Collections.Generic;

namespace EFConvention.CA.Model.Entities
{
    public class Address
    {
        public Address()
        {
            ContactPersons = new HashSet<ContactPerson>();
        }

        public virtual int AddressId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual string FullAddress { get; set; }
        public virtual string Country { get; set; }
        public virtual ICollection<ContactPerson> ContactPersons { get; set; }
    }
}

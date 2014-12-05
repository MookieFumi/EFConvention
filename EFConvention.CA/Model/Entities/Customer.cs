using System.Collections.Generic;

namespace EFConvention.CA.Model.Entities
{
    public class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();    
        }

        public virtual int CustomerId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
namespace EFConvention.CA.Model.Entities
{
    public class ContactPerson
    {
        public ContactPerson()
        {
        }

        public virtual int ContactPersonId { get; set; }
        public virtual int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual string Name { get; set; }
        public virtual string Departament { get; set; }
    }
}
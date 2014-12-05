using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFConvention.CA.Model;
using EFConvention.CA.Model.Entities;

namespace EFConvention.CA
{
    class Program
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["EFConventionContext"].ConnectionString;

        static void Main(string[] args)
        {
            using (var context = new EFConventionContext(ConnectionString))
            {
                var customer = context.Customers.FirstOrDefault();
                if (customer != null)
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                }
                CustomersGenerator(context, 1);

                var clone = context.Customers.
                    Include(p => p.Addresses).
                    Include(t => t.Addresses.Select(c => c.ContactPersons)).
                    AsNoTracking().
                    FirstOrDefault();

                context.Customers.Add(clone);
                context.SaveChanges();

                Console.ReadKey();
            }
        }

        private static void CustomersGenerator(EFConventionContext context, int customerNumber)
        {
            var nameGenerator = new MaxHampton.RandomNameGenerator.NameGenerator();

            for (int i = 0; i < customerNumber; i++)
            {
                var customer = new Customer
                {
                    FirstName = nameGenerator.RandomFirstName(),
                    LastName = nameGenerator.RandomLastName(),
                    Addresses = new Collection<Address>()
                                           {
                                               new Address()
                                               {
                                                   FullAddress = String.Format("{0} {1}",nameGenerator.RandomFirstName(), nameGenerator.RandomLastName()),
                                                   Country = "USA",
                                                   ContactPersons = new Collection<ContactPerson>()
                                                                    {
                                                                        new ContactPerson()
                                                                        {
                                                                            Name = String.Format("{0} {1}",nameGenerator.RandomFirstName(), nameGenerator.RandomLastName()),
                                                                            Departament = "DevOps"
                                                                        }
                                                                    }
                                               },
                                               new Address()
                                               {
                                                   FullAddress = String.Format("{0} {1}",nameGenerator.RandomFirstName(), nameGenerator.RandomLastName()),
                                                   Country = "USA",
                                                   ContactPersons = new Collection<ContactPerson>()
                                                                    {
                                                                        new ContactPerson()
                                                                        {
                                                                            Name = String.Format("{0} {1}",nameGenerator.RandomFirstName(), nameGenerator.RandomLastName()),
                                                                            Departament = "DevOps"
                                                                        },
                                                                        new ContactPerson()
                                                                        {
                                                                            Name = String.Format("{0} {1}",nameGenerator.RandomFirstName(), nameGenerator.RandomLastName()),
                                                                            Departament = "DevOps"
                                                                        }
                                                                    }
                                               }
                                           }
                };
                context.Customers.AddOrUpdate(customer);
            }

            context.SaveChanges();
        }
    }
}

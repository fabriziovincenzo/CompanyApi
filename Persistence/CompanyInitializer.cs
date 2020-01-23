using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApi.Persistence
{
    public class CompanyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CompanyApiContext>
    {
        protected override void Seed(CompanyApiContext context)
        {
            // ADDRESSES
            var addresses = new List<Address>()
            {
                new Address() { Address1 = "Rue alfred", Locality = "Bruxelles" },
                new Address() { Address1 = "Rue albert", Locality = "Liège" },
                new Address() { Address1 = "Rue Jeanne", Locality = "Namur" },
                new Address() { Address1 = "Rue H1", Locality = "Hainaut" },
                new Address() { Address1 = "Rue H2", Locality = "Hainaut" },
                new Address() { Address1 = "Rue H3", Locality = "Hainaut" },
                new Address() { Address1 = "Rue H4", Locality = "Hainaut" }
            };
            addresses.ForEach(c => context.Addresses.Add(c));
            context.SaveChanges();


            // COMPANIES
            var companies = new List<Company>()
            {
                new Company() { Name = "Oracle", Tva="123", Persons = new List<Person>(), Headquarter = addresses[0] },
                new Company() { Name = "Microsoft", Tva="456", Persons = new List<Person>(), Headquarter = addresses[1]  },
                new Company() { Name = "Genesis", Tva="789", Persons = new List<Person>(), Headquarter = addresses[2]  }
            };
            companies.ForEach(c => context.Companies.Add(c));
            context.SaveChanges();

            // PERSONS
            var contacts = new List<Person>()
            {
                new Employee() { Name = "Albert", Address = addresses[3] },
                new Employee() { Name = "Carole", Address = addresses[4] },
                new Freelance() { Name = "Gus", Tva = "1223", Address = addresses[5] },
                new Freelance() { Name = "Fabrizio", Tva = "223", Address = addresses[6] }
            };
            contacts.ForEach(c => context.People.Add(c));
            context.SaveChanges();


            // Oracle company
            companies[0].Persons.Add(contacts[2]);
            companies[0].Persons.Add(contacts[3]);

            // Microsoft company
            companies[1].Persons.Add(contacts[0]);
            companies[1].Persons.Add(contacts[1]);

            // Genesis company
            companies[2].Persons.Add(contacts[0]);
            companies[2].Persons.Add(contacts[1]);
            companies[2].Persons.Add(contacts[2]);
            context.SaveChanges();
        }
    }
}
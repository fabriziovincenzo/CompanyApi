using CompanyApi.Domain.Repositories;
using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompanyApi.Persistence.Repositories
{
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public AddressRepository(CompanyApiContext context)
            : base(context)
        {
        }

        public IQueryable<Address> GetAll()
        {
            return _context.Addresses;
        }

        public Address Get(int id)
        {
            return _context.Addresses
                .SingleOrDefault(b => b.Id == id);
        }

        public void Add(Address address)
        {
            _context.Addresses
                .Add(address);
        }

        public void Update(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
        }

        public void Remove(Address address)
        {
            _context.Addresses
                .Remove(address);
        }
    }
}
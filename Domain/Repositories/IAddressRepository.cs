using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Domain.Repositories
{
    public interface IAddressRepository
    {
        IQueryable<Address> GetAll();

        Address Get(int id);

        void Add(Address address);

        void Update(Address address);

        void Remove(Address address);
    }
}

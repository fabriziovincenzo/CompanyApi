using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Domain.Services
{
    public interface IAddressService
    {
        IQueryable<Address> GetAll();
        Address Get(int id);
        Address Add(Address address);
        Address Update(int id, Address address);
        Address Delete(int id);
    }
}

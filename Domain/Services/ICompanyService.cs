using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Domain.Services
{
    public interface ICompanyService
    {
        IQueryable<Company> GetAll();
        Company Get(int id);
        Company Add(Company company);
        Company Update(Company company);
        Company Delete(int id);
    }
}

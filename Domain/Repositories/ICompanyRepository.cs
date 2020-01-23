using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Domain.Repositories
{
    public interface ICompanyRepository
    {
        IQueryable<Company> GetAll();
        
        Company Get(int id);

        void Add(Company company);

        void Update(Company company);

        void Remove(Company company);
    }
}

using CompanyApi.Domain.Repositories;
using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CompanyApi.Persistence.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(CompanyApiContext context) 
            : base(context)
        {
        }

        public IQueryable<Company> GetAll()
        {
            return _context.Companies
                .Include(a => a.Headquarter);
        }

        public Company Get(int id)
        {
            return _context.Companies
                .Include(a => a.Headquarter)
                .SingleOrDefault(b => b.Id == id);
        }

        public void Add(Company company)
        {
            _context.Companies
                .Add(company);
        }

        public void Update(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
        }

        public void Remove(Company company)
        {
            _context.Companies.Remove(company);
        }
    }
}
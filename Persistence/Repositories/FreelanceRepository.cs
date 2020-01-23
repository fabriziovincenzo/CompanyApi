using CompanyApi.Domain.Repositories;
using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CompanyApi.Persistence.Repositories
{
    public class FreelanceRepository : BaseRepository, IFreelanceRepository
    {
        public FreelanceRepository(CompanyApiContext context)
            : base(context)
        {
        }

        public IQueryable<Freelance> GetAll()
        {
            return _context.Freelances
                .Include(a => a.Address);
        }

        public Freelance Get(int id)
        {
            return _context.Freelances
                .Include(a => a.Address)
                .SingleOrDefault(b => b.Id == id);
        }

        public void Add(Freelance freelance)
        {
            _context.Freelances
                .Add(freelance);
        }

        public void Update(Freelance freelance)
        {
            _context.Entry(freelance).State = EntityState.Modified;
        }

        public void Remove(Freelance freelance)
        {
            _context.Freelances
                .Remove(freelance);
        }
    }
}
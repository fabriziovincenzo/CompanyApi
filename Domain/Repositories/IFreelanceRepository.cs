using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Domain.Repositories
{
    public interface IFreelanceRepository
    {
        IQueryable<Freelance> GetAll();

        Freelance Get(int id);

        void Add(Freelance freelance);

        void Update(Freelance freelance);

        void Remove(Freelance freelance);
    }
}

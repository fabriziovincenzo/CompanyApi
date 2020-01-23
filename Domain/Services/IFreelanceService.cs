using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Domain.Services
{
    public interface IFreelanceService
    {
        IQueryable<Freelance> GetAll();
        Freelance Get(int id);
        Freelance Add(Freelance freelance);
        Freelance Update(Freelance freelance);
        Freelance Delete(int id);
    }
}

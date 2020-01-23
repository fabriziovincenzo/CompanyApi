using CompanyApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApi.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyApiContext _context;

        public UnitOfWork(CompanyApiContext context)
        {
            _context = context;
        }

        public void Complete()
        {
             int x = _context.SaveChanges();
        }
    }
}
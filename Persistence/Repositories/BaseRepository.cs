using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApi.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly CompanyApiContext _context;

        public BaseRepository(CompanyApiContext context)
        {
            _context = context;
        }
    }
}
using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAll();

        Employee Get(int id);

        void Add(Employee employee);

        void Update(Employee employee);

        void Remove(Employee employee);
    }
}

using CompanyApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CompanyApi.Models;

namespace CompanyApi.Persistence.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(CompanyApiContext context)
            : base(context)
        {
        }

        public IQueryable<Employee> GetAll()
        {
            return _context.Employees
                .Include(a => a.Address);
        }

        public Employee Get(int id)
        {
            return _context.Employees
                .Include(a => a.Address)
                .SingleOrDefault(b => b.Id == id);
        }

        public void Add(Employee employee)
        {
            _context.Employees
                .Add(employee);
        }

        public void Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }

        public void Remove(Employee employee)
        {
            _context.Employees
                .Remove(employee);
        }
    }
}
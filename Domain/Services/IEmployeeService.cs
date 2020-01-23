using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi.Domain.Services
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetAll();
        Employee Get(int id);
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int id);
    }
}

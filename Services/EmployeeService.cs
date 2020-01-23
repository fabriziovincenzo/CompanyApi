using CompanyApi.Domain.Repositories;
using CompanyApi.Domain.Services;
using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IUnitOfWork _unitOfWork;


        public EmployeeService(IEmployeeRepository EmployeeRepository, IUnitOfWork unitOfWork)
        {
            this._EmployeeRepository = EmployeeRepository;
            this._unitOfWork = unitOfWork;
        }


        public IQueryable<Employee> GetAll()
        {
            return _EmployeeRepository.GetAll();
        }

        public Employee Get(int id)
        {
            return _EmployeeRepository.Get(id);
        }

        public Employee Add(Employee employee)
        {
            _EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
            return employee;
        }

        public Employee Update(Employee employee)
        {
            _EmployeeRepository.Update(employee);
            _unitOfWork.Complete();
            return employee;
        }

        public Employee Delete(int id)
        {
            var existingEmployee = Get(id);
            if (existingEmployee == null)
                return null;

            _EmployeeRepository.Remove(existingEmployee);
            _unitOfWork.Complete();
            return existingEmployee;
        }
    }
}
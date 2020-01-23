using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CompanyApi.Persistence;
using CompanyApi.Models;
using CompanyApi.Domain.Services;
using CompanyApi.Models.Result;
using CompanyApi.Models.Request;

namespace CompanyApi.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employees
        public IQueryable<EmployeeResult> GetEmployees()
        {
            var employees = _employeeService.GetAll();

            return employees
                .Select(b => new EmployeeResult()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Address = new AddressResult
                    {
                        Id = b.Address.Id,
                        Address1 = b.Address.Address1,
                        Locality = b.Address.Locality,
                    }
                });
        }

        // GET: api/Employees/5
        [ResponseType(typeof(EmployeeResult))]
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = _employeeService.Get(id);
            if (employee == null)
                return NotFound();
            
            return Ok(new EmployeeResult
            {
                Id = employee.Id,
                Name = employee.Name,
                Address = new AddressResult
                {
                    Id = employee.Address.Id,
                    Address1 = employee.Address.Address1,
                    Locality = employee.Address.Locality,
                }
            });
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, UpdateEmployeeRequest employeeRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingEmployee = _employeeService.Get(id);
            if (existingEmployee == null)
                return NotFound();

            existingEmployee.Name = employeeRequest.Name;

            _employeeService.Update(existingEmployee);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employees
        [ResponseType(typeof(EmployeeResult))]
        public IHttpActionResult PostEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employee = new Employee
            {
                Name = addEmployeeRequest.Name,
                Address = new Address
                {
                    Address1 = addEmployeeRequest.Address1,
                    Locality = addEmployeeRequest.Locality
                }
            };

            _employeeService.Add(employee);
            return CreatedAtRoute(
                "DefaultApi",
                new { id = employee.Id },
                new EmployeeResult
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Address = new AddressResult
                    {
                        Id = employee.Address.Id,
                        Address1 = employee.Address.Address1,
                        Locality = employee.Address.Locality,
                    }
                });
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var result = _employeeService.Delete(id);
            if (result == null)
                return NotFound();

            return Ok();
        }
    }
}
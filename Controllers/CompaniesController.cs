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
    public class CompaniesController : ApiController
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/Companies
        public IQueryable<CompanyResult> GetCompanies()
        {
            var companies = _companyService.GetAll();

            return companies
                .Select(b => new CompanyResult()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tva = b.Tva,
                    HeadquarterAddress = new AddressResult
                    {
                        Id = b.Headquarter.Id,
                        Address1 = b.Headquarter.Address1,
                        Locality = b.Headquarter.Locality,
                    }
                });
        }

        // GET: api/Companies/5
        [ResponseType(typeof(CompanyResult))]
        public IHttpActionResult GetCompany(int id)
        {
            var company = _companyService.Get(id);
            if (company == null)
                return NotFound();

            return Ok(new CompanyResult
            {
                Id = company.Id,
                Name = company.Name,
                Tva = company.Tva,
                HeadquarterAddress = new AddressResult
                {
                    Id = company.Headquarter.Id,
                    Address1 = company.Headquarter.Address1,
                    Locality = company.Headquarter.Locality,
                }
            });
        }

        // PUT: api/Companies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompany(int id, UpdateCompanyRequest companyRequest)
        {
            if (!ModelState.IsValid)
                 return BadRequest(ModelState);

            var existingCompany = _companyService.Get(id);
            if (existingCompany == null)
                return NotFound();

            existingCompany.Name = companyRequest.Name;
            existingCompany.Tva = companyRequest.Tva;

            _companyService.Update(existingCompany);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Companies
        [ResponseType(typeof(CompanyResult))]
        public IHttpActionResult PostCompany(AddCompanyRequest addCompanyRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var company = new Company
            {
                Name = addCompanyRequest.Name,
                Tva = addCompanyRequest.Tva,
                Headquarter = new Address
                {
                    Address1 = addCompanyRequest.Address1,
                    Locality = addCompanyRequest.Locality
                }
            };

            _companyService.Add(company);
            return CreatedAtRoute(
                "DefaultApi", 
                new { id = company.Id },
                new CompanyResult
                {
                    Id = company.Id,
                    Name = company.Name,
                    Tva = company.Tva,
                    HeadquarterAddress = new AddressResult
                    {
                        Id = company.Headquarter.Id,
                        Address1 = company.Headquarter.Address1,
                        Locality = company.Headquarter.Locality,
                    }
                });
        }

        // DELETE: api/Companies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteCompany(int id)
        {
            var result = _companyService.Delete(id);
            if (result == null)
                return NotFound();

            return Ok();
        }
    }
}
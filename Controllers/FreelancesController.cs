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
    public class FreelancesController : ApiController
    {
        private readonly IFreelanceService _freelanceService;

        public FreelancesController(IFreelanceService freelanceService)
        {
            _freelanceService = freelanceService;
        }

        // GET: api/Freelances
        public IQueryable<FreelanceResult> GetFreelances()
        {
            var freelances = _freelanceService.GetAll();

            return freelances
                .Select(b => new FreelanceResult()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tva = b.Tva,
                    Address = new AddressResult
                    {
                        Id = b.Address.Id,
                        Address1 = b.Address.Address1,
                        Locality = b.Address.Locality,
                    }
                });
        }

        // GET: api/Freelances/5
        [ResponseType(typeof(FreelanceResult))]
        public IHttpActionResult GetFreelance(int id)
        {
            var freelance = _freelanceService.Get(id);
            if (freelance == null)
                return NotFound();

            return Ok(new FreelanceResult
            {
                Id = freelance.Id,
                Name = freelance.Name,
                Tva = freelance.Tva,
                Address = new AddressResult
                {
                    Id = freelance.Address.Id,
                    Address1 = freelance.Address.Address1,
                    Locality = freelance.Address.Locality,
                }
            });
        }

        // PUT: api/Freelances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFreelance(int id, UpdateFreelanceRequest freelanceRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingFreelance = _freelanceService.Get(id);
            if (existingFreelance == null)
                return NotFound();

            existingFreelance.Name = freelanceRequest.Name;
            existingFreelance.Tva = freelanceRequest.Tva;

            _freelanceService.Update(existingFreelance);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Freelances
        [ResponseType(typeof(FreelanceResult))]
        public IHttpActionResult PostFreelance(AddFreelanceRequest addFreelanceRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var freelance = new Freelance
            {
                Name = addFreelanceRequest.Name,
                Tva = addFreelanceRequest.Tva,
                Address = new Address
                {
                    Address1 = addFreelanceRequest.Address1,
                    Locality = addFreelanceRequest.Locality
                }
            };

            _freelanceService.Add(freelance);
            return CreatedAtRoute(
                "DefaultApi",
                new { id = freelance.Id },
                new FreelanceResult
                {
                    Id = freelance.Id,
                    Name = freelance.Name,
                    Tva = freelance.Tva,
                    Address = new AddressResult
                    {
                        Id = freelance.Address.Id,
                        Address1 = freelance.Address.Address1,
                        Locality = freelance.Address.Locality,
                    }
                });
        }

        // DELETE: api/Freelances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteFreelance(int id)
        {
            var result = _freelanceService.Delete(id);
            if (result == null)
                return NotFound();

            return Ok();
        }
    }
}
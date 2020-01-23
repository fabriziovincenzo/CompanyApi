using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyApi.Domain.Repositories;
using CompanyApi.Domain.Services;
using CompanyApi.Models;

namespace CompanyApi.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;


        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork)
        {
            this._companyRepository = companyRepository;
            this._unitOfWork = unitOfWork;
        }


        public IQueryable<Company> GetAll()
        {
            return _companyRepository.GetAll();
        }

        public Company Get(int id)
        {
            return _companyRepository.Get(id);
        }

        public Company Add(Company company)
        {
            _companyRepository.Add(company);
            _unitOfWork.Complete();
            return company;
        }

        public Company Update(Company company)
        {
            _companyRepository.Update(company);
            _unitOfWork.Complete();
            return company;
        }

        public Company Delete(int id)
        {
            var existingCompany = Get(id);
            if (existingCompany == null)
                return null;

            _companyRepository.Remove(existingCompany);
            _unitOfWork.Complete();
            return existingCompany;
        }
    }
}
using CompanyApi.Domain.Repositories;
using CompanyApi.Domain.Services;
using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreelanceApi.Services
{
    public class FreelanceService : IFreelanceService
    {
        private readonly IFreelanceRepository _freelanceRepository;
        private readonly IUnitOfWork _unitOfWork;


        public FreelanceService(IFreelanceRepository freelanceRepository, IUnitOfWork unitOfWork)
        {
            this._freelanceRepository = freelanceRepository;
            this._unitOfWork = unitOfWork;
        }


        public IQueryable<Freelance> GetAll()
        {
            return _freelanceRepository.GetAll();
        }

        public Freelance Get(int id)
        {
            return _freelanceRepository.Get(id);
        }

        public Freelance Add(Freelance freelance)
        {
            _freelanceRepository.Add(freelance);
            _unitOfWork.Complete();
            return freelance;
        }

        public Freelance Update(Freelance freelance)
        {
            _freelanceRepository.Update(freelance);
            _unitOfWork.Complete();
            return freelance;
        }

        public Freelance Delete(int id)
        {
            var existingFreelance = Get(id);
            if (existingFreelance == null)
                return null;

            _freelanceRepository.Remove(existingFreelance);
            _unitOfWork.Complete();
            return existingFreelance;
        }
    }
}
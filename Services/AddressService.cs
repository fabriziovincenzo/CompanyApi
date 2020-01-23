using CompanyApi.Domain.Repositories;
using CompanyApi.Domain.Services;
using CompanyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyApi.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUnitOfWork _unitOfWork;


        public AddressService(IAddressRepository addressRepository, IUnitOfWork unitOfWork)
        {
            this._addressRepository = addressRepository;
            this._unitOfWork = unitOfWork;
        }


        public IQueryable<Address> GetAll()
        {
            return _addressRepository.GetAll();
        }

        public Address Get(int id)
        {
            return _addressRepository.Get(id);
        }

        public Address Add(Address address)
        {
            _addressRepository.Add(address);
            _unitOfWork.Complete();
            return address;
        }

        public Address Update(int id, Address address)
        {
            var existingAddress = Get(id);
            if (existingAddress == null)
                return null;

            existingAddress.Address1 = address.Address1;
            existingAddress.Locality = address.Locality;

            _addressRepository.Update(existingAddress);
            _unitOfWork.Complete();
            return existingAddress;
        }

        public Address Delete(int id)
        {
            var existingAddress = Get(id);
            if (existingAddress == null)
                return null;

            _addressRepository.Remove(existingAddress);
            _unitOfWork.Complete();
            return existingAddress;
        }
    }
}
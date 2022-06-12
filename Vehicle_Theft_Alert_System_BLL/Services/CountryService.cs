using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Vehicle_Theft_Alert_System_BLL.Exceptions;
using Vehicle_Theft_Alert_System_BLL.Interfaces;
using Vehicle_Theft_Alert_System_BLL.Models;
using Vehicle_Theft_Alert_System_DAL.Interfaces;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Services
{
    public class CountryService : ICountryService
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<CountryService> _logger;

        public CountryService(IMapper mapper, ICountryRepository countryRepository, ILogger<CountryService> logger)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
            _logger = logger;
        }

        public IEnumerable<Country> GetAllCountrys()
        {
            try 
            { 
                return _mapper.Map<List<Country>>(_countryRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAllCountrys method");
                throw new CountryServiceException(ex.Message);
            }
        }

        public Country AddNewCountry(Country country)
        {
            try 
            { 
                var countryToAdd = _mapper.Map<CountryDB>(country);
                var newCountry = _countryRepository.AddEntity(countryToAdd);

                return _mapper.Map<Country>(newCountry);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in AddNewCountry method");
                throw new CountryServiceException(ex.Message);
            }
        }

        public void DeleteCountry(Guid id)
        {
            try 
            { 
                _countryRepository.DeleteEntity(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in DeleteCountry method");
                throw new CountryServiceException(ex.Message);
            }
        }

        public Country UpdateCountry(Country updatedCountry)
        {
            try 
            { 
                var mappedCountry = _mapper.Map<CountryDB>(updatedCountry);

                return _mapper.Map<Country>(_countryRepository.UpdateEntity(mappedCountry));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in UpdateCountry method");
                throw new CountryServiceException(ex.Message);
            }
        }

        public Country GetCountryById(Guid id)
        {
            try 
            { 
                var country = _countryRepository.GetById(id);
                if (country == null)
                {
                    _logger.LogError($"Country with id {id} doesn't exist.");
                    throw new CountryServiceException($"Country with id {id} doesn't exist.");
                }

                return _mapper.Map<Country>(country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetCountryById method");
                throw new CountryServiceException(ex.Message);
            }
        }
    }
}

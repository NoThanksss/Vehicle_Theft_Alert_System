using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Exceptions;
using Vehicle_Theft_Alert_System_BLL.Interfaces;
using Vehicle_Theft_Alert_System_BLL.Models;
using Vehicle_Theft_Alert_System_DAL.Interfaces;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Services
{
    public class FamilyService : IFamilyService
    {
        private readonly IMapper _mapper;
        private readonly IFamilyRepository _familyRepository;
        private readonly IAccountService _accountService;
        private readonly ILogger<FamilyService> _logger;

        public FamilyService(IMapper mapper, IFamilyRepository familyRepository,
            IAccountService accountService, ILogger<FamilyService> logger)
        {
            _mapper = mapper;
            _familyRepository = familyRepository;
            _accountService = accountService;
            _logger = logger;
        }

        public IEnumerable<Account> GetAllFamilyAcounts(Guid id)
        {
            try 
            { 
                return _accountService.GetAllAccounts().Where(x => x.FamilyId == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAllFamilyAcounts method");
                throw new FamilyServiceException(ex.Message);
            }
        }

        public IEnumerable<Family> GetAllFamilies()
        {
            try 
            { 
                return _mapper.Map<List<Family>>(_familyRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAllFamilies method");
                throw new FamilyServiceException(ex.Message);
            }
        }

        public Family AddNewFamily(Family family)
        {
            try 
            { 
                var familyToAdd = _mapper.Map<FamilyDB>(family);
                var newFamily = _familyRepository.AddEntity(familyToAdd);

                return _mapper.Map<Family>(newFamily);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in AddNewFamily method");
                throw new FamilyServiceException(ex.Message);
            }
        }

        public void DeleteFamily(Guid id)
        {
            try 
            { 
                _familyRepository.DeleteEntity(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in DeleteFamily method");
                throw new FamilyServiceException(ex.Message);
            }
        }

        public Family UpdateFamily(Family updatedFamily)
        {
            try 
            { 
                var mappedFamily = _mapper.Map<FamilyDB>(updatedFamily);

                return _mapper.Map<Family>(_familyRepository.UpdateEntity(mappedFamily));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in UpdateFamily method");
                throw new FamilyServiceException(ex.Message);
            }
        }

        public Family GetFamilyById(Guid id)
        {
            try 
            { 
                var family = _familyRepository.GetById(id);
                if (family == null)
                {
                    _logger.LogError($"Family with id {id} doesn't exist.");
                    throw new FamilyServiceException($"Family with id {id} doesn't exist.");
                }

                return _mapper.Map<Family>(family);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetFamilyById method");
                throw new FamilyServiceException(ex.Message);
            }
        }
    }
}

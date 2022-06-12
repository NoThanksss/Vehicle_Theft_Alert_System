using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Exceptions;
using Vehicle_Theft_Alert_System_BLL.Interfaces;
using Vehicle_Theft_Alert_System_BLL.Models;
using Vehicle_Theft_Alert_System_DAL.Interfaces;
using Vehicle_Theft_Alert_System_DAL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Services
{
    public class FamilyPlanService : IFamilyPlanService
    {
        private readonly IMapper _mapper;
        private readonly IFamilyPlanRepository _familyPlanRepository;
        private readonly ILogger<FamilyPlanService> _logger;

        public FamilyPlanService(IMapper mapper, IFamilyPlanRepository familyPlanRepository, ILogger<FamilyPlanService> logger)
        {
            _mapper = mapper;
            _familyPlanRepository = familyPlanRepository;
            _logger = logger;

        }

        public IEnumerable<FamilyPlan> GetAllFamilyPlans()
        {
            try 
            { 
                return _mapper.Map<List<FamilyPlan>>(_familyPlanRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAllFamilyPlans method");
                throw new FamilyPlanServiceException(ex.Message);
            }
        }

        public FamilyPlan AddNewFamilyPlan(FamilyPlan familyPlan)
        {
            try
            { 
                var familyPlanToAdd = _mapper.Map<FamilyPlanDB>(familyPlan);
                var newFamilyPlan = _familyPlanRepository.AddEntity(familyPlanToAdd);

                return _mapper.Map<FamilyPlan>(newFamilyPlan);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in AddNewFamilyPlan method");
                throw new FamilyPlanServiceException(ex.Message);
            }
        }

        public void DeleteFamilyPlan(Guid id)
        {
            try 
            {
                _familyPlanRepository.DeleteEntity(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in DeleteFamilyPlan method");
                throw new FamilyPlanServiceException(ex.Message);
            }
        }

        public FamilyPlan UpdateFamilyPlan(FamilyPlan updatedFamilyPlan)
        {
            try 
            { 
                var mappedFamilyPlan = _mapper.Map<FamilyPlanDB>(updatedFamilyPlan);

                return _mapper.Map<FamilyPlan>(_familyPlanRepository.UpdateEntity(mappedFamilyPlan));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in UpdateFamilyPlan method");
                throw new FamilyPlanServiceException(ex.Message);
            }
        }

        public FamilyPlan GetFamilyPlanById(Guid id)
        {
            try 
            { 
                var familyPlan = _familyPlanRepository.GetById(id);
                if (familyPlan == null)
                {
                    _logger.LogError($"FamilyPlan with id {id} doesn't exist.");
                    throw new FamilyPlanServiceException($"FamilyPlan with id {id} doesn't exist.");
                }

                return _mapper.Map<FamilyPlan>(familyPlan);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetFamilyPlanById method");
                throw new FamilyPlanServiceException(ex.Message);
            }
        }
    }
}

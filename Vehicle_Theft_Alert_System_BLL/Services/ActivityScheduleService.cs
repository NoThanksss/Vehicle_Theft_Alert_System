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
    public class ActivityScheduleService : IActivityScheduleService
    {
        private readonly IMapper _mapper;
        private readonly IActivityScheduleRepository _activityScheduleRepository;
        private readonly ILogger<ActivityScheduleService> _logger;

        public ActivityScheduleService(IMapper mapper, IActivityScheduleRepository activityScheduleRepository, ILogger<ActivityScheduleService> logger)
        {
            _mapper = mapper;
            _activityScheduleRepository = activityScheduleRepository;
            _logger = logger;

        }

        public IEnumerable<ActivitySchedule> GetAllTrackerActivitySchedules(Guid trackerId)
        {
            try 
            { 
                return _mapper.Map<List<ActivitySchedule>>(_activityScheduleRepository.GetAll().Where(x => x.TrackerDBId == trackerId));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAllTrackerActivitySchedules method");
                throw new ActivityScheduleServiceException(ex.Message);
            }
        }

        public IEnumerable<ActivitySchedule> GetAllActivitySchedules()
        {
            try
            { 
                return _mapper.Map<List<ActivitySchedule>>(_activityScheduleRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAllActivitySchedules method");
                throw new ActivityScheduleServiceException(ex.Message);
            }
        }

        public ActivitySchedule AddNewActivitySchedule(ActivitySchedule activitySchedule)
        {
            try 
            { 
                var activityScheduleToAdd = _mapper.Map<ActivityScheduleDB>(activitySchedule);
                var newActivitySchedule = _activityScheduleRepository.AddEntity(activityScheduleToAdd);

                return _mapper.Map<ActivitySchedule>(newActivitySchedule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in AddNewActivitySchedule method");
                throw new ActivityScheduleServiceException(ex.Message);
            }
        }

        public void DeleteActivitySchedule(Guid id)
        {
            try 
            { 
                _activityScheduleRepository.DeleteEntity(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in DeleteActivitySchedule method");
                throw new ActivityScheduleServiceException(ex.Message);
            }
        }

        public ActivitySchedule UpdateActivitySchedule(ActivitySchedule updatedActivitySchedule)
        {
            try 
            { 
                var mappedActivitySchedule = _mapper.Map<ActivityScheduleDB>(updatedActivitySchedule);

                return _mapper.Map<ActivitySchedule>(_activityScheduleRepository.UpdateEntity(mappedActivitySchedule));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in UpdateActivitySchedule method");
                throw new ActivityScheduleServiceException(ex.Message);
            }
        }

        public ActivitySchedule GetActivityScheduleById(Guid id)
        {
            try 
            { 
                var activitySchedule = _activityScheduleRepository.GetById(id);
                if (activitySchedule == null)
                {
                    _logger.LogError($"ActivitySchedule with id {id} doesn't exist.");
                    throw new ActivityScheduleServiceException($"ActivitySchedule with id {id} doesn't exist.");
                }

                return _mapper.Map<ActivitySchedule>(activitySchedule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetActivityScheduleById method");
                throw new ActivityScheduleServiceException(ex.Message);
            }
        }
    }
}

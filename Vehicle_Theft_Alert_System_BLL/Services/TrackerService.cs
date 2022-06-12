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
    public class TrackerService : ITrackerService
    {
        private readonly IMapper _mapper;
        private readonly ITrackerRepository _trackerRepository;
        private readonly ILogger<TrackerService> _logger;

        public TrackerService(IMapper mapper, ITrackerRepository trackerRepository, ILogger<TrackerService> logger)
        {
            _mapper = mapper;
            _trackerRepository = trackerRepository;
            _logger = logger;

        }

        public IEnumerable<Tracker> GetAllTrackers()
        {
            try 
            { 
                return _mapper.Map<List<Tracker>>(_trackerRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAllTrackers method");
                throw new TrackerServiceException(ex.Message);
            }
        }

        public Tracker AddNewTracker(Tracker tracker)
        {
            try 
            { 
                var trackerToAdd = _mapper.Map<TrackerDB>(tracker);
                var newTracker = _trackerRepository.AddEntity(trackerToAdd);

                return _mapper.Map<Tracker>(newTracker);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in AddNewTracker method");
                throw new TrackerServiceException(ex.Message);
            }
        }

        public void DeleteTracker(Guid id)
        {
            try 
            { 
                _trackerRepository.DeleteEntity(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in DeleteTracker method");
                throw new TrackerServiceException(ex.Message);
            }
        }

        public Tracker UpdateTracker(Tracker updatedTracker)
        {
            try 
            { 
                var mappedTracker = _mapper.Map<TrackerDB>(updatedTracker);

                return _mapper.Map<Tracker>(_trackerRepository.UpdateEntity(mappedTracker));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in UpdateTracker method");
                throw new TrackerServiceException(ex.Message);
            }
        }

        public Tracker GetTrackerById(Guid id)
        {
            try 
            { 
                var tracker = _trackerRepository.GetById(id);
                if (tracker == null)
                {
                    _logger.LogError($"Tracker with id {id} doesn't exist.");
                    throw new TrackerServiceException($"Tracker with id {id} doesn't exist.");
                }

                return _mapper.Map<Tracker>(tracker);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetTrackerById method");
                throw new TrackerServiceException(ex.Message);
            }
        }
    }
}

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
    public class ConnectionService : IConnectionService
    {
        private readonly IMapper _mapper;
        private readonly IConnectionRepository _connectionRepository;
        private readonly ILogger<ConnectionService> _logger;

        public ConnectionService(IMapper mapper, IConnectionRepository connectionRepository, ILogger<ConnectionService> logger)
        {
            _mapper = mapper;
            _connectionRepository = connectionRepository;
            _logger = logger;

        }

        public IEnumerable<Connection> GetAllAccountConnections(Guid accountId)
        {
            try 
            { 
            var connectionDbs = _connectionRepository.GetAll().Where(x => x.AccountDBId == accountId);

            return _mapper.Map<List<Connection>>(connectionDbs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAllAccountConnections method");
                throw new ConnectionServiceException(ex.Message);
            }
        }

        public IEnumerable<Connection> GetAllFamilyConnections(Guid familyId)
        {
            try 
            { 
                var connectionDbs = _connectionRepository.GetAll().Where(x => x.FamilyDBId == familyId);
            
                return _mapper.Map<List<Connection>>(connectionDbs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAllFamilyConnections method");
                throw new ConnectionServiceException(ex.Message);
            }
        }

        public IEnumerable<Connection> GetAllConnections()
        {
            try 
            { 
                return _mapper.Map<List<Connection>>(_connectionRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetAllConnections method");
                throw new ConnectionServiceException(ex.Message);
            }
        }

        public Connection AddNewConnection(Connection connection)
        {
            try
            { 
                var connectionToAdd = _mapper.Map<ConnectionDB>(connection);
                var newConnection = _connectionRepository.AddEntity(connectionToAdd);

                return _mapper.Map<Connection>(newConnection);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in AddNewConnection method");
                throw new ConnectionServiceException(ex.Message);
            }
        }

        public void DeleteConnection(Guid id)
        {
            try 
            { 
                _connectionRepository.DeleteEntity(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in DeleteConnection method");
                throw new ConnectionServiceException(ex.Message);
            }
        }

        public Connection UpdateConnection(Connection updatedConnection)
        {
            try 
            { 
                var mappedConnection = _mapper.Map<ConnectionDB>(updatedConnection);

                return _mapper.Map<Connection>(_connectionRepository.UpdateEntity(mappedConnection));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in UpdateConnection method");
                throw new ConnectionServiceException(ex.Message);
            }
        }

        public Connection GetConnectionById(Guid id)
        {
            try 
            { 
                var connection = _connectionRepository.GetById(id);
                if (connection == null)
                {
                    _logger.LogError($"Connection with id {id} doesn't exist.");
                    throw new ConnectionServiceException($"Connection with id {id} doesn't exist.");
                }

                return _mapper.Map<Connection>(connection);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in GetConnectionById method");
                throw new ConnectionServiceException(ex.Message);
            }
        }
    }
}

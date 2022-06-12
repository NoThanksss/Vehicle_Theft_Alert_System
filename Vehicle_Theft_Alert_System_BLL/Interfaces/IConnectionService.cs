using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Interfaces
{
    public interface IConnectionService
    {
        IEnumerable<Connection> GetAllConnections();
        Connection AddNewConnection(Connection connection);
        void DeleteConnection(Guid id);
        Connection UpdateConnection(Connection updatedConnection);
        Connection GetConnectionById(Guid id);
    }
}

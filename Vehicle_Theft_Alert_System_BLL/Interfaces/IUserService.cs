using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User AddNewUser(User user);
        void DeleteUser(Guid id);
        User UpdateUser(User updatedUser);
        User GetUserById(Guid id);
    }
}

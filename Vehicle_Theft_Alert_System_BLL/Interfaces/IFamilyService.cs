using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Interfaces
{
    public interface IFamilyService
    {
        IEnumerable<Family> GetAllFamilies();
        Family AddNewFamily(Family family);
        void DeleteFamily(Guid id);
        Family UpdateFamily(Family updatedFamily);
        Family GetFamilyById(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Interfaces
{
    public interface ITrackerService
    {
        IEnumerable<Tracker> GetAllTrackers();
        Tracker AddNewTracker(Tracker tracker);
        void DeleteTracker(Guid id);
        Tracker UpdateTracker(Tracker updatedTracker);
        Tracker GetTrackerById(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Models;

namespace Vehicle_Theft_Alert_System_BLL.Interfaces
{
    public interface IActivityScheduleService
    {
        IEnumerable<ActivitySchedule> GetAllActivitySchedules();
        ActivitySchedule AddNewActivitySchedule(ActivitySchedule activitySchedule);
        void DeleteActivitySchedule(Guid id);
        ActivitySchedule UpdateActivitySchedule(ActivitySchedule updatedActivitySchedule);
        ActivitySchedule GetActivityScheduleById(Guid id);
    }
}

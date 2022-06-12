using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_DAL.Models
{
    public class ActivityScheduleDB
    {
        public Guid Id { get; set; }

        public DateTimeOffset StartDate { get; set; } 

        public DateTimeOffset EndDate { get; set; }

        public bool ActivityStatus { get; set; }

        public Guid TrackerDBId { get; set; }
        public TrackerDB TrackerDB { get; set; }
    }
}

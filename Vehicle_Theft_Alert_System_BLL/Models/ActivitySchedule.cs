using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Attributes;

namespace Vehicle_Theft_Alert_System_BLL.Models
{
    public class ActivitySchedule
    {
        [SwaggerExclude]
        public Guid Id { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset EndDate { get; set; }

        public bool ActivityStatus { get; set; }

        public Guid TrackerId { get; set; }
    }
}

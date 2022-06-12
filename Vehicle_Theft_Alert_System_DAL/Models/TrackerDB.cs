using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_DAL.Models
{
    public class TrackerDB
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsOn { get; set; }

        public string SerialNumber { get; set; }

        public DateTime ExperationDate { get; set; }

        public string LastCoordinates { get; set; }

        public string Mac { get; set; }

        public string IP { get; set; }

        public virtual List<ActivityScheduleDB> ActivityScheduleDBs { get; set; }
    }
}

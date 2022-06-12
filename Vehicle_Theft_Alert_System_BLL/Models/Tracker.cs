using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Attributes;

namespace Vehicle_Theft_Alert_System_BLL.Models
{
    public class Tracker
    {
        [SwaggerExclude]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsOn { get; set; }

        public string SerialNumber { get; set; }

        public DateTime ExperationDate { get; set; }

        public string LastCoordinates { get; set; }

        public string Mac { get; set; }

        public string IP { get; set; }

    }
}

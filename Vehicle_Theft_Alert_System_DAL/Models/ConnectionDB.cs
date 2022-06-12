using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_DAL.Models
{
    public class ConnectionDB
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ConnectionType { get; set; }

        public Guid? AccountDBId { get; set; }
        public AccountDB AccountDB { get; set; }

        public Guid? FamilyDBId { get; set; }
        public FamilyDB FamilyDB { get; set; }

        public Guid TrackerDBId { get; set; }
        public TrackerDB TrackerDB { get; set; }
    }
}

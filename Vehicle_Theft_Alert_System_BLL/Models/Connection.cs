using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Attributes;

namespace Vehicle_Theft_Alert_System_BLL.Models
{
    public class Connection
    {
        [SwaggerExclude]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ConnectionType { get; set; }

        public Guid? AccountId { get; set; }

        public Guid? FamilyId { get; set; }

        public Guid TrackerId { get; set; }
    }
}

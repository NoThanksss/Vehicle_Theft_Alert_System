using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Attributes;

namespace Vehicle_Theft_Alert_System_BLL.Models
{
    public class FamilyPlan
    {
        [SwaggerExclude]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Discount { get; set; }

        public int MaxMemberNumber { get; set; }

    }
}

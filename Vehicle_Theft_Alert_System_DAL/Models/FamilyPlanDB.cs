using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_DAL.Models
{
    public class FamilyPlanDB
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Discount { get; set; }

        public int MaxMemberNumber { get; set; }

        public virtual List<FamilyDB> FamilyDBs { get; set; }
    }
}

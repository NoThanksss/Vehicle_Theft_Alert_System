using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_DAL.Models
{
    public class FamilyDB
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid? FamilyPlanDBId { get; set; }

        public FamilyPlanDB FamilyPlanDB { get; set; }

        public virtual List<AccountDB> AccountDBs { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_DAL.Models
{
    public class CountryDB
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContinentName { get; set; }

        public virtual List<UserDB> UserDBs { get; set; }

    }
}

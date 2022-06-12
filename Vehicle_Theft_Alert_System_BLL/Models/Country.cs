using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Attributes;

namespace Vehicle_Theft_Alert_System_BLL.Models
{
    public class Country
    {
        [SwaggerExclude]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContinentName { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Vehicle_Theft_Alert_System_BLL.Attributes;

namespace Vehicle_Theft_Alert_System_BLL.Models
{
    public class Account 
    {
        [SwaggerExclude]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Email { get; set; }

        public decimal BillAmount { get; set; }

        public Guid? FamilyId { get; set; }

    }
}

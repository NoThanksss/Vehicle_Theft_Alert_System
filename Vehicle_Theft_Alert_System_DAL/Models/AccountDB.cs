using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_DAL.Models
{
    public class AccountDB : IdentityUser<Guid>
    {
        public Guid UserDBId { get; set; }
        public UserDB UserDB { get; set; }

        public decimal BillAmount { get; set; }

        public Guid? FamilyDBId { get; set; }
        public FamilyDB FamilyDB { get; set; }


    }
}

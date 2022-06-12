using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_DAL.Models
{
    public class UserDB
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public Guid CountryDBId { get; set; }
        public CountryDB CountryDB { get; set; }

        public AccountDB AccountDB { get; set; }
    }
}

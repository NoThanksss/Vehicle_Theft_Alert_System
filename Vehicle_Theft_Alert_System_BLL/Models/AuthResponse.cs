using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_BLL.Models
{
    public class AuthResponse
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
    }
}

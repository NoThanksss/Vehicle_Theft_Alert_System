using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_BLL.Exceptions
{
    public class CountryServiceException : Exception
    {
        public CountryServiceException()
        {
        }

        public CountryServiceException(string message)
            : base(message)
        {
        }

        public CountryServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

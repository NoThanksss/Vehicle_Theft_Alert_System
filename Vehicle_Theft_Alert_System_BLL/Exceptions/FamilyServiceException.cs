using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_BLL.Exceptions
{
    public class FamilyServiceException : Exception
    {
        public FamilyServiceException()
        {
        }

        public FamilyServiceException(string message)
            : base(message)
        {
        }

        public FamilyServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_BLL.Exceptions
{
    public class UserServiceException : Exception
    {
        public UserServiceException()
        {
        }

        public UserServiceException(string message)
            : base(message)
        {
        }

        public UserServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

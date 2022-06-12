using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_BLL.Exceptions
{
    public class ConnectionServiceException : Exception
    {
        public ConnectionServiceException()
        {
        }

        public ConnectionServiceException(string message)
            : base(message)
        {
        }

        public ConnectionServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_BLL.Exceptions
{
    public class TrackerServiceException : Exception
    {
        public TrackerServiceException()
        {
        }

        public TrackerServiceException(string message)
            : base(message)
        {
        }

        public TrackerServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

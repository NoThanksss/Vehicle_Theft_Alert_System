using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_BLL.Exceptions
{
    public class ActivityScheduleServiceException : Exception
    {
        public ActivityScheduleServiceException()
        {
        }

        public ActivityScheduleServiceException(string message)
            : base(message)
        {
        }

        public ActivityScheduleServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

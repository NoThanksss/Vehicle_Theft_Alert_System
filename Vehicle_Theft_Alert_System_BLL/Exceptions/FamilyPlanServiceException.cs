using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle_Theft_Alert_System_BLL.Exceptions
{
    public class FamilyPlanServiceException : Exception
    {
        public FamilyPlanServiceException()
        {
        }

        public FamilyPlanServiceException(string message)
            : base(message)
        {
        }

        public FamilyPlanServiceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

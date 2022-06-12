using Serilog.Events;
using System;
using System.Collections.Generic;

namespace Vehicle_Theft_Alert_System.Models
{
    public class LogModel
    {
        public string Message { get; set; }
        public string Level { get; set; }
        public Exception Exception { get; set; }
        public string StatusCode { get; set; }
        public IReadOnlyDictionary<string, LogEventPropertyValue> Properties { get; set; }
    }
}

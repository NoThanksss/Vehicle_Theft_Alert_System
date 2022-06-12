using Serilog.Core;
using Serilog.Events;
using System.Collections.Generic;
using System.Linq;

namespace Vehicle_Theft_Alert_System.Logging.Destructure
{
    public class SensitiveDataDestructuringPolicy : IDestructuringPolicy
    {
        private readonly List<ISensitiveDataStrategy> _strategies;

        public SensitiveDataDestructuringPolicy()
        {
            _strategies = new List<ISensitiveDataStrategy>();
            _strategies.Add(new RemoveFromLoggingStrategy());
            _strategies.Add(new ArrayStrategy(new RemoveFromLoggingStrategy()));
        }

        public bool TryDestructure(object value, ILogEventPropertyValueFactory propertyValueFactory, out LogEventPropertyValue result)
        {
            var dictionary = new Dictionary<string, object>();

            dictionary = _strategies.First(strategy => strategy.IsApplicable(value)).Apply(dictionary, value);

            result = new ScalarValue(dictionary);
            return true;
        }
    }
}
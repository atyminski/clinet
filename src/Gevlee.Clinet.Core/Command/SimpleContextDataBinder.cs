using System;
using System.Collections.Generic;
using System.Linq;

namespace Gevlee.Clinet.Core.Command
{
    public class SimpleContextDataBinder : IContextDataBinder
    {
        public TData Bind<TData>(IDictionary<string, object> source, TData destination)
        {
            foreach (var pair in source)
            {
                var destinationType = typeof(TData);

                var targetProperty = destinationType.GetProperties().FirstOrDefault(x =>
                    x.Name.Equals(pair.Key, StringComparison.OrdinalIgnoreCase) && x.CanWrite &&
                    x.PropertyType == pair.Value?.GetType());

                if (targetProperty != null)
                {
                    targetProperty.SetValue(destination, pair.Value);
                }
            }

            return destination;
        }
    }
}
using PropertyMonitor.Core.Helpers;
using PropertyMonitor.General.Extensions;
using PropertyMonitor.General.Interfaces;
using System.Reflection;

namespace PropertyMonitor.General;
public abstract class PropertyMonitor : IMonitorable
{
    internal Dictionary<string, object?> _monitoredProperties = new();

    public IEnumerable<PropertyInfo> ChangedProperties
    {
        get
        {
            var properties = GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                if (!_monitoredProperties.TryGetValue(properties[i].Name, out var originalValue))
                {
                    continue;
                }

                var currentValue = properties[i].GetValue(this);
                if (ObjectHelpers.HaveDifferentValues(properties[i].PropertyType, originalValue, currentValue))
                {
                    yield return properties[i];
                }
            }
        }
    }

    internal PropertyMonitor AsMonitored()
    {
        var properties = GetType().GetProperties();

        for (int i = 0; i < properties.Length; i++)
        {
            var name = properties[i].Name;
            var value = properties[i].GetValue(this);

            if (!properties[i].CanWrite)
            {
                continue;
            }

            if (properties[i].IsMonitored())
            {
                _monitoredProperties[name] = value;
            }
        }

        return this;
    }


}

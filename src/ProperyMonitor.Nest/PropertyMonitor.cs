using PropertyMonitor.Core.Helpers;
using PropertyMonitor.Nest.Extensions;
using PropertyMonitor.Nest.Interfaces;

namespace PropertyMonitor.Nest;
public abstract class PropertyMonitor : IMonitorable
{
    internal Dictionary<string, object?> _monitoredProperties = new();

    public IDictionary<string, object?> ChangedFields
    {
        get
        {
            var result = new Dictionary<string, object?>();

            var properties = GetType().GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                properties[i].TryGetElasticsearchPropertyName(out var name);

                if (string.IsNullOrWhiteSpace(name))
                {
                    name = properties[i].Name;
                }

                if (!_monitoredProperties.TryGetValue(name, out var originalValue))
                {
                    continue;
                }

                var currentValue = properties[i].GetValue(this);
                if (ObjectHelpers.HaveDifferentValues(properties[i].PropertyType, originalValue, currentValue))
                {
                    result[name] = currentValue;
                }
            }

            return result;
        }
    }

    internal PropertyMonitor AsMonitored()
    {
        var properties = GetType().GetProperties();

        for (int i = 0; i < properties.Length; i++)
        {
            if (!properties[i].CanWrite)
            {
                continue;
            }

            if (!properties[i].IsMonitored())
            {
                continue;
            }

            properties[i].TryGetElasticsearchPropertyName(out var name);

            if (string.IsNullOrWhiteSpace(name))
            {
                name = properties[i].Name;
            }

            var value = properties[i].GetValue(this);

            _monitoredProperties[name] = value;
        }

        return this;
    }


}

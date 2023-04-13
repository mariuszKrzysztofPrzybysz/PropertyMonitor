using PropertyMonitor.Core.Attributes;
using System.Reflection;

namespace PropertyMonitor.Core.Extensions;
public static class PropertyInfoExtensions
{
    public static bool IsMonitored(this PropertyInfo propertyInfo)
        => propertyInfo.GetCustomAttribute<UnmonitoredAttribute>() is null;
}

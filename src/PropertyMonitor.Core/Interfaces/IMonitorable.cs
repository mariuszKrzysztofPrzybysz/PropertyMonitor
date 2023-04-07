using System.Reflection;

namespace PropertyMonitor.Core.Interfaces;
public interface IMonitorable
{
    IEnumerable<PropertyInfo> ChangedProperties { get; }
}

using System.Reflection;

namespace PropertyMonitor.General.Interfaces;
public interface IMonitorable
{
    IEnumerable<PropertyInfo> ChangedProperties { get; }
}

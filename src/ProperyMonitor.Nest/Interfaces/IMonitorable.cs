namespace PropertyMonitor.Nest.Interfaces;
public  interface IMonitorable
{
    IDictionary<string, object?> ChangedFields { get; }
}

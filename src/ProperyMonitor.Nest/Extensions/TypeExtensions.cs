namespace PropertyMonitor.Nest.Extensions;
public static class TypeExtensions
{
    public static T AsMonitorable<T>(this T instance)
        where T : PropertyMonitor
    {
        var @object = instance as object;

        return AsMonitorableHelper<T>(@object);
    }

    private static T AsMonitorableHelper<T>(this object @object)
        where T : PropertyMonitor
    {
        ArgumentNullException.ThrowIfNull(@object, nameof(@object));

        if (@object is T monitor)
        {
            @object = monitor.AsMonitored();

            return (T)@object;
        }

        throw new InvalidCastException($"{@object.GetType().Name} is not of type {typeof(T).Name}");
    }
}

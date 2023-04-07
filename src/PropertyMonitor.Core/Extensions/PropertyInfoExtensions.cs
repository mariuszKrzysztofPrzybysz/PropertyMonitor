﻿using PropertyMonitor.Core.Attributes;
using System.Reflection;

namespace PropertyMonitor.Core.Extensions;
internal static class PropertyInfoExtensions
{
    internal static bool IsMonitored(this PropertyInfo propertyInfo)
        => propertyInfo.GetCustomAttribute<UnmonitoredAttribute>() is null;
}

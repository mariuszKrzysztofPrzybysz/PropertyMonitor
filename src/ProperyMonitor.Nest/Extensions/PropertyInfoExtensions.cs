using Nest;
using System.Reflection;

namespace PropertyMonitor.Nest.Extensions
{
    internal static class PropertyInfoExtensions
    {
        internal static bool TryGetElasticsearchPropertyName(this PropertyInfo propertyInfo, out string? name)
        {
            var attribute = propertyInfo.GetCustomAttribute<ElasticsearchPropertyAttributeBase>();
            if(attribute is null)
            {
                name = null;
                return false;
            }

            name = attribute.Name;
            return true;
        }
    }
}

namespace PropertyMonitor.Core.Helpers
{
    internal sealed class ObjectHelpers
    {
        internal static bool HaveDifferentValues(Type type, object? originalValue, object? currentValue)
        {
            bool? result = HaveDifferentValuesHelper(type, originalValue, currentValue);

            if (result.HasValue)
            {
                return result.Value;
            }

            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
            {
                result = HaveDifferentValuesHelper(underlyingType, originalValue, currentValue);
            }

            if (result.HasValue)
            {
                return result.Value;
            }

            return false;
        }

        private static bool? HaveDifferentValuesHelper(Type type, object? firstValue, object? secondValue)
            => Type.GetTypeCode(type) switch
            {
                TypeCode.Empty => true,
                TypeCode.Object => null,
                TypeCode.DBNull => true,
                TypeCode.Boolean => Convert.ToBoolean(firstValue) != Convert.ToBoolean(secondValue),
                TypeCode.Char => Convert.ToChar(firstValue) != Convert.ToChar(secondValue),
                TypeCode.SByte => Convert.ToSByte(firstValue) != Convert.ToSByte(secondValue),
                TypeCode.Byte => Convert.ToByte(firstValue) != Convert.ToByte(secondValue),
                TypeCode.Int16 => Convert.ToInt16(firstValue) != Convert.ToInt16(secondValue),
                TypeCode.UInt16 => Convert.ToUInt16(firstValue) != Convert.ToUInt16(secondValue),
                TypeCode.Int32 => Convert.ToInt32(firstValue) != Convert.ToInt32(secondValue),
                TypeCode.UInt32 => Convert.ToUInt32(firstValue) != Convert.ToUInt32(secondValue),
                TypeCode.Int64 => Convert.ToInt64(firstValue) != Convert.ToInt64(secondValue),
                TypeCode.UInt64 => Convert.ToUInt64(firstValue) != Convert.ToUInt64(secondValue),
                TypeCode.Single => Convert.ToSingle(firstValue) != Convert.ToSingle(secondValue),
                TypeCode.Double => Convert.ToDouble(firstValue) != Convert.ToDouble(secondValue),
                TypeCode.Decimal => Convert.ToDecimal(firstValue) != Convert.ToDecimal(secondValue),
                TypeCode.DateTime => Convert.ToDateTime(firstValue) != Convert.ToDateTime(secondValue),
                TypeCode.String => Convert.ToString(firstValue) != Convert.ToString(secondValue),
                _ => null
            };
    }
}

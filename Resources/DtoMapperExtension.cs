using System.Text.Json;

namespace PagoEfectivoApi.Resources
{
     public static class DtoMapperExtension
    {
        public static T MapTo<T>(this object value)
        {
            var options = new JsonSerializerOptions()
            {
                MaxDepth = 0,
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true,
                WriteIndented = true
            };
            return JsonSerializer.Deserialize<T>(
                JsonSerializer.Serialize(value, options)
            );
        }
    }
}
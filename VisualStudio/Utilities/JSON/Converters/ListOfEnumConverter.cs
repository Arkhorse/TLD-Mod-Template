using System.Text.Json;
using System.Text.Json.Serialization;

namespace TEMPLATE.Utilities.Converters
{
    // https://stackoverflow.com/a/75253804
    public class ListOfEnumConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {

            if (!typeToConvert.IsGenericType)
            {
                return false;
            }

            if (typeToConvert.GetGenericTypeDefinition() != typeof(List<>))
            {
                return false;
            }

            return typeToConvert.GetGenericArguments()[0].IsEnum;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type enumType = typeToConvert.GetGenericArguments()[0];

            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(ListOfEnumConverterInner<>).MakeGenericType(
                    new Type[] { enumType }),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] { options },
                culture: null)!;

            return converter;
        }
    }
    public class ListOfEnumConverterInner<TEnum> :
        JsonConverter<List<TEnum>> where TEnum : struct, Enum
    {
        private readonly JsonConverter<TEnum> _itemConverter;
        private readonly Type _itemType;
        public ListOfEnumConverterInner(JsonSerializerOptions options)
        {
            // For performance, use the existing converter.
            _itemConverter = (JsonConverter<TEnum>)options
                    .GetConverter(typeof(TEnum));

            // Cache the enum types.
            _itemType = typeof(TEnum);
        }

        public override List<TEnum>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new JsonException();
            }

            var enumList = new List<TEnum>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndArray)
                {
                    return enumList;
                }
                // Get the item.
                if (reader.TokenType != JsonTokenType.String)
                {
                    throw new JsonException();
                }

                string? nextItem = reader.GetString();

                // For performance, parse with ignoreCase:false first.
                if (!Enum.TryParse(nextItem, ignoreCase: false, out TEnum item) &&
                    !Enum.TryParse(nextItem, ignoreCase: true, out item))
                {
                    throw new JsonException(
                        $"Unable to convert \"{nextItem}\" to Enum \"{_itemType}\".");
                }

                //add to list now
                enumList.Add(item);
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, List<TEnum> enumList, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (TEnum item in enumList)
            {
                var nextItem = item.ToString();
                writer.WriteStringValue
                    (options.PropertyNamingPolicy?.ConvertName(nextItem) ?? nextItem);

                _itemConverter.Write(writer, item, options);
            }

            writer.WriteEndArray();
        }
    }
}

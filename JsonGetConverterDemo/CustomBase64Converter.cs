using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonGetConverterDemo;

public class CustomBase64Converter<T> : JsonConverter<T>
{
    private readonly Type _valueType = typeof(T);

    public T? Deserialize(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
        var converter = (JsonConverter<T>?)options.GetConverter(_valueType);

        if (converter != null)
        {
            return converter.Read(ref reader, _valueType, options);
        }
        else
        {
            return JsonSerializer.Deserialize<T>(ref reader, options);
        }
    }

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            return Deserialize(ref reader, options);
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            var data = reader.GetString();
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new JsonException();
            }

            var decodedData = Convert.FromBase64String(data);
            var encodedReader = new Utf8JsonReader(decodedData);
            return Deserialize(ref encodedReader, options);
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, options);
    }
}

using System.Net;
using System.Text.Json.Serialization;

namespace JsonGetConverterDemo;

public class SampleResponse
{
    public HttpStatusCode StatusCode { get; set; }
    public string Description { get; set; }

    [JsonConverter(typeof(CustomBase64Converter<Address>))]
    public Address AddressJson { get; set; } = new Address();
}
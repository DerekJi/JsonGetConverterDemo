// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonGetConverterDemo;

Demo();

Console.WriteLine("Ok!");


void Demo()
{
    //var address = new Address()
    //{
    //    Country = "Australia",
    //    State = "South Australia",
    //    Street = "Sample Street",
    //    StreetNo = "5A"
    //};
    //var sampleResponse = new SampleResponse()
    //{
    //    StatusCode = HttpStatusCode.Accepted,
    //    Description = "Testing",
    //    AddressJson = address
    //};

    //var addrJson = JsonSerializer.Serialize(address);
    //var json = JsonSerializer.Serialize(sampleResponse);

    var encoded =
        "{\"StatusCode\":202,\"Description\":\"Testing\",\"AddressJson\":\"eyJTdHJlZXRObyI6IjVBIiwiU3RyZWV0IjoiU2FtcGxlIFN0cmVldCIsIlN1YnVyYiI6bnVsbCwiU3RhdGUiOiJTb3V0aCBBdXN0cmFsaWEiLCJDb3VudHJ5IjoiQXVzdHJhbGlhIn0=\"}";

    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    };

    var decoded = JsonSerializer.Deserialize<SampleResponse>(encoded, options);
}



using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SDK;
using SDK.Contracts;
using SDK.Enums;
using SDK.Models;
using System.Net;


var builder = new HostBuilder()
        .ConfigureServices((context, services) =>
        {
            services.AddHttpClient(Options.DefaultName, options =>
            {
            })
            .ConfigurePrimaryHttpMessageHandler(x => new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli
            });
            services.AddSingleton<IOneApi, OneApi>();
        })
        .UseConsoleLifetime();

var host = builder.Build();

try
{
    var sdkService = host.Services.GetRequiredService<IOneApi>();
    sdkService.Configure("2t7oclBeJJUb8i2wkOUl");

    var books = await sdkService.RetrieveAll<Book>();
    foreach(var item in books)
    {
        Console.WriteLine(JsonConvert.SerializeObject(item));
    }

    Console.WriteLine("##########################");

}
catch (Exception ex)
{
    Console.WriteLine(ex?.InnerException.ToString() ?? ex.Message);
}


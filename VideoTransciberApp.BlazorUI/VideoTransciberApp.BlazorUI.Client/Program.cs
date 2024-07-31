using BlazorDownloadFile;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5214/api/") });
builder.Services.AddBlazorDownloadFile(ServiceLifetime.Scoped);
var app = builder.Build();
await builder.Build().RunAsync();

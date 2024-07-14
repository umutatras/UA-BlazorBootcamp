using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.Extensions;
using UA.BlazorOpenAIStarter;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var openAIApikey = builder.Configuration.GetSection("OpenAIApiKey").Value;
builder.Services.AddOpenAIService(settings => { settings.ApiKey = Environment.GetEnvironmentVariable(openAIApikey); });
await builder.Build().RunAsync();

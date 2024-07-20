using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OpenAI.Extensions;
using UA.BlazorGiftSuggestionApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var openAIApikey = builder.Configuration["OpenAIApiKey"];
builder.Services.AddOpenAIService(settings => { settings.ApiKey = openAIApikey; });
await builder.Build().RunAsync();

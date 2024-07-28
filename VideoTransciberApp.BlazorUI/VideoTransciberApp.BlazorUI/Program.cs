using VideoTransciberApp.BlazorUI.Client.Pages;
using VideoTransciberApp.BlazorUI.Components;
using OpenAI.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5214/api/") }); var app = builder.Build();
var openAIApiKey = builder
    .Configuration
    .GetSection("OpenAIApiKey")
    .Value;
builder.Services.AddOpenAIService(settings => settings.ApiKey = openAIApiKey);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(VideoTransciberApp.BlazorUI.Client._Imports).Assembly);
app.MapControllers();
app.Run();

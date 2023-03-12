using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Gestion.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPersonaServices, PersonaServices>();
builder.Services.AddScoped<IAporteServices, AporteServices>();
builder.Services.AddScoped<ITiposAportesServices, TiposAportesServices>();
await builder.Build().RunAsync();

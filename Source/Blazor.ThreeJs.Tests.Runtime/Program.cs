using Blazor.ThreeJs;
using Blazor.ThreeJs.Tests.Runtime;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.FluentUI.AspNetCore.Components;
using SpawnDev.BlazorJS;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazorJSRuntime();
builder.Services.AddThreeJs();

builder.Services.AddFluentUIComponents(options =>
{
    options.ValidateClassNames = false;
});

await builder.Build().BlazorJSRunAsync();

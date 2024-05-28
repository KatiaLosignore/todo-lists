using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebApp.Components;
using WebApp.Components.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new TodoListService());

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();





//var builder = WebApplication.CreateBuilder(args);

//// Aggiungi servizi al contenitore.
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();




//var app = builder.Build();

//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthorization();

//app.MapRazorPages();
//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");

//app.Run();









//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorComponents()
//    .AddInteractiveServerComponents();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error", createScopeForErrors: true);
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();

//app.UseStaticFiles();
//app.UseAntiforgery();

//app.MapRazorComponents<App>()
//    .AddInteractiveServerRenderMode();

//app.Run();



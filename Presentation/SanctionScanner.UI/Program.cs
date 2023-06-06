using Microsoft.Extensions.Configuration;
using Polly;
using Refit;
using SanctionScanner.UI.APIs;

var builder = WebApplication.CreateBuilder(args);


RegisterClients(builder);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


void RegisterClients(WebApplicationBuilder builer)
{
    var baseUrl = builer.Configuration.GetSection("Settings").GetSection("Host")["CoreAPIServer"]; ;
    var baseUri = new Uri("https://localhost:7101/");

    builer.Services.AddHttpClient<IBookApi>()
        .ConfigureHttpClient(client => { client.BaseAddress = baseUri; })
        .AddTypedClient(client => RestService.For<IBookApi>(client))
        .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(60)))
        .AddTransientHttpErrorPolicy(p => p.RetryAsync(3));
}
using ReverseProxyApplication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.Middleware;
using ReverseProxyProject;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseMiddleware<ReverseProxyMiddleware>();

app.UseRouting();

app.MapRazorPages();

app.Run();

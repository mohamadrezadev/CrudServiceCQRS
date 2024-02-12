using Application.Tools;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Persistances.Contexts;
using Application.DependencyInjections;
using Infrastructure.DependencyInjections;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using EndPoint.Web.DependencyInjections;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
builder.Services.AddServices();

builder.Services
    .AddHealthChecks()
    .AddSqlite(builder.Configuration.GetConnectionString("SqliteDb"));
    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();


app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(config =>
{
    config.MapHealthChecks("/health", new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse

    });
});
app.Run();

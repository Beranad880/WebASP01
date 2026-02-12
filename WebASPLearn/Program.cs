using WebASPLearn.Models;
using WebASPLearn.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// MongoDB setup
var mongoConfig = builder.Configuration.GetSection("MongoDBSettings");
var mongoClient = new MongoClient(mongoConfig["ConnectionString"]);
var mongoDatabase = mongoClient.GetDatabase(mongoConfig["DatabaseName"]);

builder.Services.AddSingleton(mongoDatabase.GetCollection<User>(mongoConfig["UsersCollectionName"]));
builder.Services.AddSingleton<UserService>();

// Add Blazor specific services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers(); // Keep this for the API endpoints

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Map Blazor components
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Map API controllers
app.MapControllers();

app.Run();

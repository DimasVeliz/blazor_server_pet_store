using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorServerDemo.Data;
using BlazorServerDemo.Data.Infrastructure;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Add mongodb config

builder.Services.AddSingleton<IMongoSettings>(options=>builder
                                                        .Configuration
                                                        .GetSection("MongoDbSettings")
                                                        .Get<MongoSettings>());                                             
builder.Services.AddSingleton(typeof(IMongoCRUD<>), typeof(MongoCRUD<>));
           

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<LocationService>();


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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

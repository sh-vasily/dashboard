using ContainerBuilderExtensions;
using Dashboard.Data;
using DotNet.Testcontainers.Builders;
    
var redisContainer = new ContainerBuilder()
    .WithImage("redis/redis-stack-server")
    .WithPortBinding(6379)
    .WithBindMountToUserHome("/data")
    .Build();

await redisContainer.StartAsync();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<ApplicationsService>();

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

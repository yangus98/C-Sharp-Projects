using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using WebConcessionaria.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string cnStr = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<AutoContext>(opt =>
    opt.UseSqlServer(cnStr)
);

string file = Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "logs", "log.txt");
builder.Host.UseSerilog(
    (ctx, lc) =>
    lc.MinimumLevel.Error() //gli dico di loggare da Debug in sù dei miei eventi!
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Error) // per Microsoft logga solo da Error in sù
    .WriteTo.File(file, rollingInterval: RollingInterval.Day)
);

builder.Services.AddPaging(options => {
    options.ViewName = "Bootstrap5";
    options.PageParameterName = "pageindex";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

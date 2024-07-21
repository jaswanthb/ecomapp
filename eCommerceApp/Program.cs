using eCommerce.Service;
using eCommerce.Service.Contracts;
using eCommerceRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Logging.ClearProviders(); // Clear loggin providers
//Log.Logger = new LoggerConfiguration()
//                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
//                .Enrich.FromLogContext()
//                .WriteTo.Console()
//                .CreateBootstrapLogger();

builder.Services.AddSerilog();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("eCommerceConStr");
builder.Services.AddDbContext<eCommerceContext>(options => options
                                                .UseLazyLoadingProxies()
                                                .UseSqlServer(connectionString));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

//builder.Services.AddSerilog((services, lc) => lc
//                             .ReadFrom.Configuration(builder.Configuration)
//                             .ReadFrom.Services(services)
//                             .Enrich.FromLogContext()
//                             .WriteTo.Console()
//                             .WriteTo.File(System.IO.Path.Combine("C:\\SeriLog-Sample", "LogFiles", "Application", "diagnostics.txt"),
//                                           rollingInterval: RollingInterval.Day,
//                                           fileSizeLimitBytes: 10 * 1024 * 1024,
//                                           retainedFileCountLimit: 2,
//                                           rollOnFileSizeLimit: true,
//                                           shared: true,
//                                            flushToDiskInterval: TimeSpan.FromSeconds(1))
//                             .CreateLogger()
//                             );

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    // Add this line:
    .WriteTo.File(
       System.IO.Path.Combine("C:\\SeriLog-Sample", "LogFiles", "Application", "diagnostics.txt"),
       rollingInterval: RollingInterval.Day,
       fileSizeLimitBytes: 10 * 1024 * 1024,
       retainedFileCountLimit: 2,
       rollOnFileSizeLimit: true,
       shared: true,
       flushToDiskInterval: TimeSpan.FromSeconds(1))
    .CreateLogger();

//builder.Services.AddTransient<ICustomerService, CustomerService>();

//builder.Services.AddSingleton<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();

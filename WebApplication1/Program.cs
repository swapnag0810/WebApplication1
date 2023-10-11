
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DBFirstApproach;
using WebApplication1.Models;
using WebApplication1.Services;
using Serilog;

var MyAllowSpecificOrigins = "myapp";

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//allow cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                      });
});

// Add services to the container.

//add DB conn
builder.Services.AddDbContext<SampleDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SampleDBConnStr")));
builder.Services.AddDbContext<TestdbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SampleDBConnStrOther")));
//add third party service
builder.Services.AddSingleton<IThirdPartyHolidayService, ThirdPartyHolidayService>();
builder.Services.AddHttpClient("PublicHolidaysApi", c => c.BaseAddress = new Uri("https://date.nager.at"));


var app = builder.Build();

app.Logger.LogInformation("Adding Routes");
app.MapGet("/", () => "Hello World!");
app.Logger.LogInformation("Starting the app");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} 

app.UseHttpsRedirection();

app.UseAuthorization();

//allow cors
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();

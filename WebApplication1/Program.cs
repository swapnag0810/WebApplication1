
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

var MyAllowSpecificOrigins = "myapp";

var builder = WebApplication.CreateBuilder(args);


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

var app = builder.Build();

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

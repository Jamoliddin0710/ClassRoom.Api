using ClassRoom.Context;
using ClassRoom.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("classroom.log",
    rollingInterval: RollingInterval.Minute ,outputTemplate: "  [{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {yyyy-MM-dd HH:mm} {Message:lj}{NewLine}{Exception}"
    ).CreateLogger();
builder.Logging.AddSerilog(logger) ;

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlite("Data source = data.db");
});
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    
}).AddEntityFrameworkStores<AppDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

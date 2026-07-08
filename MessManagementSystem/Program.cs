using MessManagementSystem.Data;
using MessManagementSystem.Mappings;
using MessManagementSystem.Repositories.Implementations;
using MessManagementSystem.Repositories.Interfaces;
using MessManagementSystem.Services.Implementations;
using MessManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registering the services for dbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Registering Automapping
builder.Services.AddAutoMapper(cfg => { }, typeof(AutoMapperProfiles));

//Registering Interfaces from repository
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IFoodService, FoodService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

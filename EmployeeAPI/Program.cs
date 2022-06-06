using EmployeeAPI.Model;
using EmployeeAPI.Repository;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Sebuilder.Services.AddDbContext<EmpContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));

builder.Services.AddScoped<EmpRepository, EmpRepository>();
rvices.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

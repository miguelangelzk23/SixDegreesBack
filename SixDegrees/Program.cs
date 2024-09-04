using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using SixDegrees.Business;
using SixDegrees.Dal;
using SixDegrees.Dto;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar SqlConnection como un servicio
builder.Services.AddScoped<SqlConnection>(_ => new SqlConnection(connectionString));

builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<IUserDal, UserDal>();

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
app.MapControllers();
app.Run();

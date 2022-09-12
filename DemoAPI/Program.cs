using Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Mapping;
using Mapping.IRepository;
using Mapping.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();

Console.WriteLine("Add automapper");
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
using (var config = builder.Configuration)
{
    string connectionString = config.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<DemoContext>(options => options.UseSqlServer(connectionString));
    builder.Services.AddAutoMapper(typeof(Mapping.Mapping));
}


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

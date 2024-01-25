using exercise.wwwapi.Controller;
using exercise.wwwapi.Data;
using exercise.wwwapi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using exercise.wwwapi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProductContext>(opt => opt.UseInMemoryDatabase("ProductDb"));
builder.Services.AddScoped<IRepository, ProductRepository>();

builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.ConfigureProductsEndpoint();

app.Run();


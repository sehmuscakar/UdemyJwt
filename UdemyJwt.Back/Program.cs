using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UdemyJwt.Back.Core.Application.Interfaces;
using UdemyJwt.Back.Core.Application.Mappings;
using UdemyJwt.Back.Persistance.Context;
using UdemyJwt.Back.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<UdemyJwtContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});

builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>()
    {
        new ProductProfile()
    }); 
});

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

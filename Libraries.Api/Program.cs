using AutoMapper;
using Libraries.Api;
using Libraries.Application;
using Libraries.Infrastructure;
using Libraries.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
var connectionString = "NO CONNECTION STRING";
if (builder.Environment.IsDevelopment())
{
    connectionString = builder.Configuration.GetConnectionString("LibraryDb");
}

builder.Services.AddDbContext<LibraryDbContext>(option => option.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterInfrastructureDependencies();
builder.Services.RegisterMediatRDependencies();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
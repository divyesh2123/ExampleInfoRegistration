using ExampleInfoRegistration.BLL.Interfaces;
using ExampleInfoRegistration.BLL.Services;
using ExampleInfoRegistration.BLL.Validators;
using ExampleInfoRegistration.DAL.Data;
using ExampleInfoRegistration.DAL.Interfaces;
using ExampleInfoRegistration.DAL.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository,
    UserRepository>();

// Business Service
builder.Services.AddScoped<IAuthService,
    AuthService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration
            .GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<PasswordService>();

builder.Services.AddValidatorsFromAssemblyContaining<
    RegisterRequestValidator>();



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

app.Val

app.Run();

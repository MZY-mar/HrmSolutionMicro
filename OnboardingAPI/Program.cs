using Microsoft.EntityFrameworkCore;
using Onboarding.ApplicationCore.Contract.Repository;
using Onboarding.ApplicationCore.Contract.Service;
using OnBoarding.Infrastructure.Data;
using OnBoarding.Infrastructure.Repository;
using OnBoarding.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = Environment.GetEnvironmentVariable("OnboardingDb");

builder.Services.AddDbContext<OnBoardDbContext>(options =>
{
    if (connectionString != null && connectionString.Length > 1)
    {
        options.UseSqlServer(connectionString);
    }
    else
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("OnboardingDb"));
    }
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//addcros
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// register repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeRoleRepositoryAsync, EmployeeRoleRepositoryAsync>();
builder.Services.AddScoped<IEmployeeStatusRepositoryAsync, EmployeeStatusRepositoryAsync>();
builder.Services.AddScoped<IEmployeeCategoryRepositoryAsync, EmployeeCategoryRepositoryAsync>();

// register services
builder.Services.AddScoped<IEmloyeeServiceAsync, EmployeeServiceAsync>();
builder.Services.AddScoped<IEmloyeeRoleServiceAsync, EmployeeRoleService>();
builder.Services.AddScoped<IEmloyeeStatusServiceAsync, EmployeeStatusService>();
builder.Services.AddScoped<IEmloyeeCategoryServiceAsync, EmployeeCategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.UseCors();
app.MapControllers();

app.Run();

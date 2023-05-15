using JWTAuthenticationManager;
using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Contract.Repository;
using Recruiting.ApplicationCore.Contract.Service;
using Recruiting.Infrastructure.Data;
using Recruiting.Infrastructure.Repository;
using Recruiting.Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCustomJwtTokenService();

var connectionString = Environment.GetEnvironmentVariable("RecruitingDb");

// builder.Services.AddDbContext<RecruitingDbContext>(options =>
// {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDb"));
// });

builder.Services.AddDbContext<RecruitingDbContext>(options =>
{
    if (connectionString != null && connectionString.Length > 1)
    {
        options.UseSqlServer(connectionString);
    }
    else
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDb"));
    }
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Submission
builder.Services.AddScoped<ISubmissionServiceAsync, SubmissionServiceAsync>();
builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();

// SubmissionStatus
builder.Services.AddScoped<ISubmissionStatusServiceAsync, SubmissionStatusServiceAsync>();
builder.Services.AddScoped<ISubmissionStatusRepository, SubmissionStatusRepository>();

builder.Services.AddScoped<IJobRequirementServiceAsync, JobRequirementServiceAsync>();
builder.Services.AddScoped<IJobRequirementRepository, JobRequirementRepository>();

builder.Services.AddScoped<ICandidateServiceAsync, CandidateServiceAsync>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();

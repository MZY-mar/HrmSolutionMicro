using Interview.ApplicationCore.Contract.Repository;
using Interview.ApplicationCore.Contract.Service;
using Interview.Infrastructure.Data;
using Interview.Infrastructure.Repository;
using Interview.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
// builder.Services.AddDbContext<InterviewManagementDbContext>(options =>
// {
//     options.UseSqlServer(builder.Configuration.GetConnectionString("InterviewDb"));
// });
var connectionString = Environment.GetEnvironmentVariable("interviewDb");

builder.Services.AddDbContext<InterviewManagementDbContext>(options =>
{
    if (connectionString != null && connectionString.Length > 1)
    {
        options.UseSqlServer(connectionString);
    }
    else
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("InterviewDb"));
    }
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddScoped<IInterviewServiceAsync, InterviewServiceAsync>();
builder.Services.AddScoped<IInterviewFeedbackServiceAsync, InterviewFeedbackServiceAsync>();
builder.Services.AddScoped<IInterviewerServiceAsync, InterviewerServiceAsync>();
builder.Services.AddScoped<IInterviewTypeServiceAsync, InterviewTypeServiceAsync>();
builder.Services.AddScoped<IRecruiterServiceAsync, RecruiterServiceAsync>();

builder.Services.AddScoped<IInterviewRepositoryAsync, InterviewRepositoryAsync>();
builder.Services.AddScoped<IInterviwerFeedbackRepositoryAsync, InterviwerFeedbackRepositoryAsync>();
builder.Services.AddScoped<IInterviewerRepositoryAsync, InterviewerRepositoryAsync>();
builder.Services.AddScoped<IInterviewTypeRepositoryAsync, InterviewTypeRepositoryAsync>();
builder.Services.AddScoped<IRecruiterRepositoryAsync, RecruiterRepository>();

builder.Services.AddControllers();

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

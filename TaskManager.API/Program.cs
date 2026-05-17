using Asp.Versioning;
using Scalar.AspNetCore;
using Serilog;
using TaskManager.API.Configurations;
using TaskManager.API.Middleware;
using TaskManager.Application;
using TaskManager.Infrastructure;
using TaskManager.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogConfiguration();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApi();

// ---------------- VERSIONING ----------------

builder.Services
	.AddApiVersioning(options =>
	{
		options.DefaultApiVersion = new ApiVersion(1, 0);

		options.AssumeDefaultVersionWhenUnspecified = true;

		options.ReportApiVersions = true;

		// URL versioning
		options.ApiVersionReader = new UrlSegmentApiVersionReader();
	})
	.AddApiExplorer(options =>
	{
		options.GroupNameFormat = "'v'VVV";

		options.SubstituteApiVersionInUrl = true;
	});

// --------------------------------------------
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddPersistence();

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseMiddleware<ExceptionMiddleware>();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapControllers();

app.Run();
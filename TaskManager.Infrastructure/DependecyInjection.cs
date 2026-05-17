using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Infrastructure.Repositories;

using TaskManager.Persistence.Database;

namespace TaskManager.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{



		// Repositories

		services.AddScoped<ITaskRepository,TaskRepository>();


		// Services


		return services;
	}
}
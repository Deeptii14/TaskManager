using Microsoft.Extensions.DependencyInjection;
using TaskManager.Persistence.Database;

namespace TaskManager.Persistence;

public static class DependencyInjection
{
	public static IServiceCollection AddPersistence(this IServiceCollection services)
	{
		// SQL Connection Factory
		services.AddScoped<ISqlConnectionFactory,SqlConnectionFactory>();

		return services;
	}
}
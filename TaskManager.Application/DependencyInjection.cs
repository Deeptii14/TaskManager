using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Application.Common.Behaviors;
using TaskManager.Application.Interfaces.Repositories;

namespace TaskManager.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		// MediatR
		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssembly(
				typeof(DependencyInjection).Assembly);
		});



		// Pipeline Behaviors
		services.AddTransient(typeof(IPipelineBehavior<,>),typeof(LoggingBehavior<,>));

		// Services
		//services.AddScoped<ITaskService, TaskService>();

		return services;
	}
}
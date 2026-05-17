using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace TaskManager.Application.Common.Behaviors;

public sealed class LoggingBehavior<TRequest,TResponse> : IPipelineBehavior<TRequest,TResponse> where TRequest : notnull
{
	private readonly ILogger<LoggingBehavior<TRequest,
	TResponse>> _logger;

	public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
	{
		_logger = logger;
	}

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		var requestName = typeof(TRequest).Name;

		var stopwatch = Stopwatch.StartNew();

		_logger.LogInformation("Handling request {RequestName}", requestName);

		var response = await next();

		stopwatch.Stop();

		var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

		if (elapsedMilliseconds > 1000)
		{
			_logger.LogWarning("Slow Request: {RequestName} took {ElapsedMilliseconds}ms", requestName, elapsedMilliseconds);
		}
		else
		{
			_logger.LogInformation("Completed request {RequestName} in {ElapsedMilliseconds}ms", requestName, elapsedMilliseconds);
		}

		return response;
	}
}
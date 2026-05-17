using Serilog;
using Serilog.Events;

namespace TaskManager.API.Configurations;

public static class SerilogExtensions
{
	public static WebApplicationBuilder AddSerilogConfiguration(
		this WebApplicationBuilder builder)
	{
		var logPath =
			builder.Configuration["Logging:LogPath"];

		var currentDate =
			DateTime.Now.ToString("yyyy-MM-dd");

		var informationFolder =
			Path.Combine(
				logPath!,
				"Information",
				currentDate);

		var errorFolder =
			Path.Combine(
				logPath!,
				"Errors",
				currentDate);

		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Information()

			.MinimumLevel.Override(
				"Microsoft",
				LogEventLevel.Warning)

			.MinimumLevel.Override(
				"Microsoft.AspNetCore",
				LogEventLevel.Warning)

			.Enrich.FromLogContext()

			.WriteTo.Console()

			// Information + Warning Logs
			.WriteTo.Logger(lc => lc
				.Filter.ByIncludingOnly(e =>
					e.Level == LogEventLevel.Information ||
					e.Level == LogEventLevel.Warning)

				.WriteTo.File(
					path: $"{informationFolder}/info-.txt",
					rollingInterval: RollingInterval.Infinite,
					rollOnFileSizeLimit: true,
					fileSizeLimitBytes: 4 * 1024 * 1024,
					retainedFileCountLimit: 30,
					shared: true,
					outputTemplate:
					"[{Timestamp:yyyy-MM-dd HH:mm:ss}] " +
					"[{Level:u3}] " +
					"[{SourceContext}] " +
					"{Message:lj}{NewLine}{Exception}"))

			// Error Logs
			.WriteTo.Logger(lc => lc
				.Filter.ByIncludingOnly(e =>
					e.Level == LogEventLevel.Error ||
					e.Level == LogEventLevel.Fatal)

				.WriteTo.File(
					path: $"{errorFolder}/error-.txt",
					rollingInterval: RollingInterval.Infinite,
					rollOnFileSizeLimit: true,
					fileSizeLimitBytes: 4 * 1024 * 1024,
					retainedFileCountLimit: 30,
					shared: true,
					outputTemplate:
					"[{Timestamp:yyyy-MM-dd HH:mm:ss}] " +
					"[{Level:u3}] " +
					"[{SourceContext}] " +
					"{Message:lj}{NewLine}{Exception}"))

			.CreateLogger();

		builder.Host.UseSerilog();

		return builder;
	}
}
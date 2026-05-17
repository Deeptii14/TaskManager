using Dapper;
using Microsoft.Extensions.Logging;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Entitties;
using TaskManager.Persistence.Database;
using TaskManager.Persistence.Database.Queries;

namespace TaskManager.Infrastructure.Repositories;

public sealed class TaskRepository : ITaskRepository
{
	private readonly ISqlConnectionFactory _connectionFactory;
	private readonly ILogger<TaskRepository> _logger;

	public TaskRepository(ISqlConnectionFactory connectionFactory,ILogger<TaskRepository> logger)
	{
		_connectionFactory = connectionFactory;
		_logger = logger;
	}

	public async Task<IEnumerable<TodoTask>> GetAllAsync()
	{
		using var connection = await _connectionFactory.CreateConnectionAsync();

		return await connection.QueryAsync<TodoTask>(TaskQueries.GetAll);
	}

	public async Task<TodoTask?> GetByIdAsync(int id)
	{
		using var connection = await _connectionFactory.CreateConnectionAsync();

		var task = await connection.QueryFirstOrDefaultAsync<TodoTask>(TaskQueries.GetById,new { Id = id });

		if (task is null)
		{
			_logger.LogWarning("Task not found with Id: {TaskId}",id);
		}

		return task;
	}

	public async Task<int> CreateAsync(TodoTask task)
	{
		using var connection = await _connectionFactory.CreateConnectionAsync();

		return await connection.ExecuteScalarAsync<int>(TaskQueries.Create,task);
	}

	public async Task<int> UpdateAsync(TodoTask task)
	{
		using var connection = await _connectionFactory.CreateConnectionAsync();

		return await connection.ExecuteAsync(TaskQueries.Update,task);
	}

	public async Task<int> DeleteAsync(int id)
	{
		using var connection = await _connectionFactory.CreateConnectionAsync();

		return await connection.ExecuteAsync(TaskQueries.Delete,new { Id = id });
	}
}
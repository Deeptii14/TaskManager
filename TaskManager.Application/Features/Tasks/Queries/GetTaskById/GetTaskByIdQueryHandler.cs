using MediatR;
using Microsoft.Extensions.Logging;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Entitties;

namespace TaskManager.Application.Features.Tasks.Queries.GetTaskById
{
	public class GetTaskByIdQueryHandler
		: IRequestHandler<GetTaskByIdQuery, TodoTask?>
	{
		private readonly ITaskRepository _repository;
		private readonly ILogger<GetTaskByIdQueryHandler> _logger;

		public GetTaskByIdQueryHandler(
			ITaskRepository repository,
			ILogger<GetTaskByIdQueryHandler> logger)
		{
			_repository = repository;
			_logger = logger;
		}

		public async Task<TodoTask?> Handle(
			GetTaskByIdQuery request,
			CancellationToken cancellationToken)
		{

			var task = await _repository.GetByIdAsync(request.Id);

			if (task is null)
			{
				_logger.LogWarning(
					"Task with Id {Id} not found",
					request.Id);
			}

			return task;
		}
	}
}
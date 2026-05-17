using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManager.Application.Features.Tasks.Queries.GetAllTasks;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Entitties;

namespace TaskManager.Application.Features.Tasks.Queries.GetTaskById
{
	public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IEnumerable<TodoTask>>
	{
		private readonly ITaskRepository _repository;
		private readonly ILogger<GetAllTasksQueryHandler> _logger;

		public GetAllTasksQueryHandler(ITaskRepository repository, ILogger<GetAllTasksQueryHandler> logger)
		{
			_repository = repository;
			_logger = logger;
		}

		public async Task<IEnumerable<TodoTask>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
		{
			return await _repository.GetAllAsync();
		}
	}
}

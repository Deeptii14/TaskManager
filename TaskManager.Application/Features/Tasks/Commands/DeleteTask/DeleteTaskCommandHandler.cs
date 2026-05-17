using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManager.Application.Common.Models;
using TaskManager.Application.Interfaces.Repositories;

namespace TaskManager.Application.Features.Tasks.Commands.DeleteTask
{
	public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, ApiResponse<string>>
	{
		private readonly ITaskRepository _repository;
		private readonly ILogger<DeleteTaskCommandHandler> _logger;

		public DeleteTaskCommandHandler(
			ITaskRepository repository,
			ILogger<DeleteTaskCommandHandler> logger)
		{
			_repository = repository;
			_logger = logger;
		}

		public async Task<ApiResponse<string>> Handle(
			DeleteTaskCommand request,
			CancellationToken cancellationToken)
		{

			var existingTask = await _repository.GetByIdAsync(request.Id);

			if (existingTask is null)
			{
				return new ApiResponse<string>
				{
					Success = false ,
					Message = "No Tasks found.",
				};
			}

			var result = await _repository.DeleteAsync(request.Id);

			return new ApiResponse<string>
			{
				Success = true,
				Message = "Task deleted successfully",
				Data = $"Task Id: {request.Id}"
			};
		}
	}
}

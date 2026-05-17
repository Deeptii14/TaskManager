using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.Logging;
using TaskManager.Application.Common.Models;
using TaskManager.Application.Interfaces.Repositories;

namespace TaskManager.Application.Features.Tasks.Commands.UpdateTask
{
	public class UpdateTaskCommandHandler
		: IRequestHandler<UpdateTaskCommand, ApiResponse<string>>
	{
		private readonly ITaskRepository _repository;
		private readonly ILogger<UpdateTaskCommandHandler> _logger;

		public UpdateTaskCommandHandler(
			ITaskRepository repository,
			ILogger<UpdateTaskCommandHandler> logger)
		{
			_repository = repository;
			_logger = logger;
		}

		public async Task<ApiResponse<string>> Handle(
			UpdateTaskCommand request,
			CancellationToken cancellationToken)
		{

			var existingTask = await _repository.GetByIdAsync(request.Id);

			if (existingTask is null)
			{
				_logger.LogWarning(
					"Task Not Found for Id {Id}",
					request.Id);

				return new ApiResponse<string>
				{
					Success = false,
					Message = "No Tasks Found",
				};
			}

			existingTask.Title = request.Title;
			existingTask.Description = request.Description;
			existingTask.IsCompleted = request.IsCompleted;

			var result = await _repository.UpdateAsync(existingTask);

			return new ApiResponse<string>
			{
				Success = true,
				Message = "Task updated successfully",
				Data = $"Task Id: {request.Id}"
			};
		}
	}

}
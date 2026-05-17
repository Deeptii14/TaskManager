using MediatR;
using Microsoft.Extensions.Logging;
using TaskManager.Application.Common.Models;
using TaskManager.Application.Features.Tasks.Commands.CreateTask;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Entitties;

public class CreateTaskCommandHandler
	: IRequestHandler<CreateTaskCommand, ApiResponse<string>>
{
	private readonly ITaskRepository _repository;
	private readonly ILogger<CreateTaskCommandHandler> _logger;

	public CreateTaskCommandHandler(ITaskRepository repository, ILogger<CreateTaskCommandHandler> logger)
	{
		_repository = repository;
		_logger = logger;
	}

	public async Task<ApiResponse<string>> Handle(
		CreateTaskCommand request,
		CancellationToken cancellationToken)
	{
		var task = new TodoTask
		{
			Title = request.Title,
			Description = request.Description
		};

		var result = await _repository.CreateAsync(task);

		return new ApiResponse<string>
		{
			Success = true,
			Message = "Task created successfully",
			Data = $"Task Id: {result}"
		};
	}
}
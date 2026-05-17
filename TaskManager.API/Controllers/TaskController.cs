using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Features.Tasks.Commands.CreateTask;
using TaskManager.Application.Features.Tasks.Commands.DeleteTask;
using TaskManager.Application.Features.Tasks.Commands.UpdateTask;
using TaskManager.Application.Features.Tasks.Queries.GetAllTasks;
using TaskManager.Application.Features.Tasks.Queries.GetTaskById;

namespace TaskManager.API.Controllers;


[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class TasksController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly ILogger<TasksController> _logger;

		public TasksController(
			IMediator mediator,
			ILogger<TasksController> logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		/// <summary>
		/// Get All Tasks
		/// </summary>
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{

			var result = await _mediator.Send(
				new GetAllTasksQuery());

			return Ok(result);
		}

		/// <summary>
		/// Get Task By Id
		/// </summary>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{

			var result = await _mediator.Send(
				new GetTaskByIdQuery(id));

			if (result is null)
			{
				return NotFound(new
				{
					Message = $"Task with Id {id} not found"
				});
			}

			return Ok(result);
		}
	/// <summary>
	/// Create Task
	/// </summary>
	[HttpPost]
	public async Task<IActionResult> Create(
		[FromBody] CreateTaskCommand command)
	{
		var result = await _mediator.Send(command);

		return Ok(result);
	}

	/// <summary>
	/// Update Task
	/// </summary>
	[HttpPut("{id}")]
	public async Task<IActionResult> Update(
		int id,
		[FromBody] UpdateTaskCommand command)
	{
		if (id != command.Id)
		{
			return BadRequest(new
			{
				Message = "Route Id and Body Id mismatch"
			});
		}

		var result = await _mediator.Send(command);

		return Ok(result);
	}

	/// <summary>
	/// Delete Task
	/// </summary>
	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		var result = await _mediator.Send(
			new DeleteTaskCommand(id));

		return Ok(result);
	}
}


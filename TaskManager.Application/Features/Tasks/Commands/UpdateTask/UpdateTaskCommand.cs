using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using TaskManager.Application.Common.Models;

namespace TaskManager.Application.Features.Tasks.Commands.UpdateTask
{
	public record UpdateTaskCommand(
		int Id,
		string Title,
		string Description,
		bool IsCompleted) : IRequest<ApiResponse<string>>;
}

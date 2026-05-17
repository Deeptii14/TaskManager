using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using TaskManager.Application.Common.Models;

namespace TaskManager.Application.Features.Tasks.Commands.DeleteTask
{
	public record DeleteTaskCommand(int Id) : IRequest<ApiResponse<string>>;
}

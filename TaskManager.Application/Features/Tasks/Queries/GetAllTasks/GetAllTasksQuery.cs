using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using TaskManager.Domain.Entitties;

namespace TaskManager.Application.Features.Tasks.Queries.GetAllTasks
{
	public record GetAllTasksQuery() : IRequest<IEnumerable<TodoTask>>;
}

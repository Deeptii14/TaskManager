using MediatR;
using TaskManager.Domain.Entitties;


namespace TaskManager.Application.Features.Tasks.Queries.GetTaskById
{
	public record GetTaskByIdQuery(int Id)
	: IRequest<TodoTask?>;
}

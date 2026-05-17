using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Domain.Entitties;

namespace TaskManager.Application.Interfaces.Repositories
{
	public interface ITaskRepository
	{
		Task<IEnumerable<TodoTask>> GetAllAsync();

		Task<TodoTask?> GetByIdAsync(int id);

		Task<int> CreateAsync(TodoTask task);

		Task<int> UpdateAsync(TodoTask task);

		Task<int> DeleteAsync(int id);
	}
}

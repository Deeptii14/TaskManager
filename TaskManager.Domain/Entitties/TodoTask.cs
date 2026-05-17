using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Domain.Entitties
{
	public class TodoTask
	{
		public int Id { get; set; }
		[Required]
		public string Title { get; set; } = string.Empty;
		[Required]
		public string Description { get; set; } = string.Empty;

		public bool IsCompleted { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}

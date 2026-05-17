using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediatR;
using TaskManager.Application.Common.Models;

namespace TaskManager.Application.Features.Tasks.Commands.CreateTask
{
	public class CreateTaskCommand : IRequest<ApiResponse<string>>
	{
		[Required(ErrorMessage = "Title is required")]
		[StringLength(100, MinimumLength = 3)]
		public required string Title { get; set; }

		[Required(ErrorMessage = "Description is required")]
		[StringLength(500, MinimumLength = 5)]
		public required string Description { get; set; }
	}
}

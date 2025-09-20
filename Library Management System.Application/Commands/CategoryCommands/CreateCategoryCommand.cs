using Library_Management_System.Application.DTOs;
using Library_Management_System.Domain.Entities;
using MediatR;

namespace Library_Management_System.Application.Commands.CategoryCommands
{
    public class CreateCategoryCommand:IRequest<Category>
    {
        public CategoryDto CategoryDto { get; set; }
    }
}

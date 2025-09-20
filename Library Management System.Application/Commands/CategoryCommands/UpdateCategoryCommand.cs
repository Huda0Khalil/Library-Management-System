using Library_Management_System.Application.DTOs;
using Library_Management_System.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Application.Commands.CategoryCommands
{
    public class UpdateCategoryCommand:IRequest<Category>
    {
        public int Id { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }
}

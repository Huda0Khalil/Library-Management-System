using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Application.Commands.CategoryCommands
{
    public class DeleteCategoryCommand: IRequest<bool>
    {
        public int Id { get; set; }
    }
}

using Library_Management_System.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Application.Queries.CategoryQueries
{
    public class GetAllCategoryQuery: IRequest<List<Category>>
    {
    }
}

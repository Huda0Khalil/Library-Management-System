using Library_Management_System.Domain.Entities;
using MediatR;

namespace Library_Management_System.Application.Queries.CategoryQueries
{
    public class GetCategoryQuery:IRequest<Category>
    {
        public int Id { get; set; }
    }
}

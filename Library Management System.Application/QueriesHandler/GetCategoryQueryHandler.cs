using Library_Management_System.Application.Queries.CategoryQueries;
using Library_Management_System.Domain.Entities;
using Library_Management_System.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Application.QueriesHandler
{
   public class GetCategoryQueryHandler: IRequestHandler<GetCategoryQuery, Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetCategoryQueryHandler(ICategoryRepository categoryRepository) 
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(request.Id);
            return category;
        }
    }
}

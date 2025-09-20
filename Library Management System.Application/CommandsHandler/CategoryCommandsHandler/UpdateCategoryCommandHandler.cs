using Library_Management_System.Application.Commands.CategoryCommands;
using Library_Management_System.Domain.Entities;
using Library_Management_System.Domain.Interfaces;
using MediatR;

namespace Library_Management_System.Application.CommandsHandler.CategoryCommandsHandler
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Category>
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryCommandHandler( ICategoryRepository categoryRepository) 
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            category.Name = request.CategoryDto.Name;
            category.Description = request.CategoryDto.Description;
            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();
            return category;
        }
    }
}

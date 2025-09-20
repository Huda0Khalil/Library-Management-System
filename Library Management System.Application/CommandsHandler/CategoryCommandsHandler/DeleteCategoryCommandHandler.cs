using Library_Management_System.Application.Commands.CategoryCommands;
using Library_Management_System.Domain.Entities;
using Library_Management_System.Domain.Interfaces;
using MediatR;

namespace Library_Management_System.Application.CommandsHandler.CategoryCommandsHandler
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository) 
        {
            this._categoryRepository = categoryRepository;
        }
        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = await this._categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
             _categoryRepository.Delete(category);
            await _categoryRepository.SaveChangesAsync();
            return true;
        }
    }
}

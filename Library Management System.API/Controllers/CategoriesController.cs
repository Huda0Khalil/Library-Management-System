using Library_Management_System.Application.Commands.CategoryCommands;
using Library_Management_System.Application.DTOs;
using Library_Management_System.Application.Queries.CategoryQueries;
using Library_Management_System.Domain.Entities;
using Library_Management_System.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediator _mediator;

        public CategoriesController(ICategoryRepository categoryRepository,IMediator mediator)
        {
            _categoryRepository = categoryRepository;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var query = new GetAllCategoryQuery();
            var categories = await _mediator.Send(query);
            if(categories == null || categories.Count == 0)
                return NotFound("No categories found.");    
            return Ok(categories);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var Query = new GetCategoryQuery { Id = id };
            var category = await _mediator.Send(Query);
            if (category == null)
                return NotFound();
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null)
                return BadRequest();
            var command = new CreateCategoryCommand { CategoryDto = categoryDto };
            var category = await _mediator.Send(command);
            if (category == null)
                return BadRequest("Category could not be created.");
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto categoryDto)
        {
            if (categoryDto == null || id <= 0)
                return BadRequest();
            var command = new UpdateCategoryCommand { Id = id, CategoryDto = categoryDto };
            var category = await _mediator.Send(command);
            if (category == null)
                return NotFound("Category not found.");
            return Ok(category);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id <= 0)
                return BadRequest();
            var command = new DeleteCategoryCommand { Id = id };
            var result = await _mediator.Send(command);
            if (!result)
                return NotFound("Category not found or could not be deleted.");
            return NoContent();
        }
    }
}

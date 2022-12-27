using Ecommerce.Data.Entities;
using Ecommerce.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.Internal.Mappers;
using Ecommerce.Application.Profiles;
using Ecommerce.Data.DTOs.CategoryDtos;
using Ecommerce.Data.DTOs;

namespace Ecommerce.Application.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryRepository categoryRepository, ILogger<CategoryController> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        [HttpPost , Route("insert")]
        public async Task<IActionResult> InsertCategory(CategoryInsertDto categoryInsertDto)
        {
            try
            {
                var insertedCategory = await _categoryRepository.Insert(ObjectMapper.Mapper.Map<Category>(categoryInsertDto));
                return Ok($"The Category {insertedCategory.Name} is added sucessfully!");

            }catch(Exception ex)
            {
                _logger.LogError("Exception while inserting Category", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("update")]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                await _categoryRepository.Update(ObjectMapper.Mapper.Map<Category>(categoryUpdateDto));
                return Ok($"The Category has been updated sucessfully!");
            }
            catch(InvalidOperationException ex)
            {
                _logger.LogError("Exception while updating Category", ex.Message);
                return BadRequest("Category does not exists.");

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("delete")]

        public async Task<IActionResult> DeleteCategory(CategoryDeleteDto categoryDeleteDto)
        {
            try
            {
                await _categoryRepository.Delete(ObjectMapper.Mapper.Map<Category>(categoryDeleteDto).Id);
                return Ok($"The Category has been deleted");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest("Category does not exists.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception while deleting Category", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<Category> allCategories =
                    await _categoryRepository.GetAll();

                IEnumerable<CategoryDto> data = ObjectMapper.Mapper.Map<IEnumerable<CategoryDto>>(allCategories);


                return Ok(data);

            }catch(Exception ex)
            {
                _logger.LogError("Exception while getting all the categories", ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                CategoryDto categoryDto = ObjectMapper.Mapper.Map<CategoryDto>(await _categoryRepository.GetById(id));
                return Ok(categoryDto);

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception while getting category", ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}

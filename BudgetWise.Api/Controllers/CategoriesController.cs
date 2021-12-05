using System;
using System.Linq;
using BudgetWise.Api.Entities;
using BudgetWise.Api.Extensions;
using BudgetWise.Api.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetWise.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    
    public class CategoriesController : ControllerBase
    {
        private readonly BudgetWiseDbContext _dbContext;

        public CategoriesController(BudgetWiseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryCreateRequest request)
        {
            var category = new CategoriesEntity()
            {
                Name = request.Name,
                UserId = HttpContext.GetCurrentUserId()
            };
            _dbContext.Categories.Add(category);

            _dbContext.SaveChanges();

            return Ok(category.Id);
        }
        
        [HttpGet]
        public IActionResult GetCategories()
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var categories = _dbContext.Categories.Where(c => c.UserId == userId)
                    .Select(c => new
                    {
                        id = c.Id,
                        name = c.Name
                    });

                return Ok(categories);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
        }

        [HttpGet("{categoryId:int}")]
        public IActionResult GetCategoryById(int categoryId)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();

                var category = _dbContext.Categories
                    .SingleOrDefault(c => c.UserId == userId && c.Id == categoryId);
                if (category is not null)
                {
                    
                }
                return Ok(new
                {
                    id = category.Id,
                    name = category.Name
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
        
        [HttpGet("{categoryId:int}/labels")]
        public IActionResult GetCategoryLabels(int categoryId)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var labels = _dbContext.Labels
                    .Include(le => le.Category)
                    .Where(le => le.Category.UserId == userId && le.CategoryId == categoryId);

                return Ok(labels.Select(l => new
                {
                    l.Id,
                    l.CategoryId,
                    l.Name,
                    l.DueDate,
                    l.Notes,
                    l.AppliedAmount,
                    l.PlannedAmount
                }));
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpDelete("{categoryId:int}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            try
            {
                _dbContext.Categories.Remove(new CategoriesEntity()
                {
                    Id = categoryId
                });

                _dbContext.SaveChanges();

                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}
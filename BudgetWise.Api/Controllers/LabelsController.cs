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
    
    public class LabelsController : ControllerBase
    {
        private readonly BudgetWiseDbContext _dbContext;

        public LabelsController(BudgetWiseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        [HttpPost]
        public IActionResult CreateLabel([FromBody] LabelCreateRequest request)
        {
            try
            {
                var label = new LabelsEntity()
                {
                    CategoryId = request.CategoryId,
                    Name = request.Name,
                    PlannedAmount = request.PlannedAmount,
                    AppliedAmount = request.AppliedAmount,
                    Notes = request.Notes,
                    DueDate = request.DueDate
                };
                _dbContext.Labels.Add(label);

                _dbContext.SaveChanges();

                return Ok(label.Id);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
        }

        [HttpGet("{labelId:int}")]
        public IActionResult GetLabelById(int labelId)
        {
            try
            {
                var userId = HttpContext.GetCurrentUserId();
                var label = _dbContext.Labels
                    .Include(le => le.Category)
                    .SingleOrDefault(le => le.Category.UserId == userId && le.Id == labelId);

                return Ok(new
                {
                    name = label.Name,
                    planned_amount = label.PlannedAmount,
                    applied_amount = label.AppliedAmount,
                    notes = label.Notes,
                    due_date = label.DueDate
                });
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
            
        }

        [HttpDelete("{labelId:int}")]
        public IActionResult DeleteLabel(int labelId)
        {
            try
            {
                _dbContext.Labels.Remove(new LabelsEntity()
                {
                    Id = labelId
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

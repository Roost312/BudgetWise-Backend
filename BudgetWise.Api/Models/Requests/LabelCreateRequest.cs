using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BudgetWise.Api.Models.Requests
{
    public class LabelCreateRequest
    {
        [Required]
        [MinLength(3)]
        [JsonPropertyName(("name"))]
        public string Name { get; set; }
        [Required]
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
        [Required]
        [JsonPropertyName("planned_amount")]
        public decimal PlannedAmount { get; set; }
        
        [JsonPropertyName("applied_amount")]
        public int? AppliedAmount { get; set; }
        
        [JsonPropertyName("notes")]
        public string? Notes { get; set; }
        
        [JsonPropertyName("due_date")]
        public DateTime? DueDate { get; set; }
        
    }
}
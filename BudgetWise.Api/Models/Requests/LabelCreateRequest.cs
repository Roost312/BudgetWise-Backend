using System;
using System.Text.Json.Serialization;

namespace BudgetWise.Api.Models.Requests
{
    public class LabelCreateRequest
    {
        [JsonPropertyName(("name"))]
        public string Name { get; set; }
        
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
        
        [JsonPropertyName("planned_amount")]
        public decimal PlannedAmount { get; set; }
        
        [JsonPropertyName("applied_amount")]
        public int AppliedAmount { get; set; }
        
        [JsonPropertyName("notes")]
        public string Notes { get; set; }
        
        [JsonPropertyName("due_date")]
        public DateTime DueDate { get; set; }
        
    }
}
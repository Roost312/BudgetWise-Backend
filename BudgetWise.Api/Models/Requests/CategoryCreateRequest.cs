using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BudgetWise.Api.Models.Requests
{
    public class CategoryCreateRequest
    {
        [JsonPropertyName("name")]
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace BudgetWise.Api.Models.Requests
{
    public class CategoryCreateRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
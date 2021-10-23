using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetWise.Api.Entities
{
    [Table("Categories")]
    public class CategoriesEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public IEnumerable<LabelsEntity> CategoryLabels { get; set; }
        public UsersEntity User { get; set; }
    }
}
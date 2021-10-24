using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetWise.Api.Entities
{
    [Table("Labels")]
    public class LabelsEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("planned_amount")]
        public decimal? PlannedAmount { get; set; }
        [Column("applied_amount")]
        public decimal? AppliedAmount { get; set; }
        [Column("notes")]
        public string? Notes { get; set; }
        [Column("due_date")]
        public DateTime? DueDate { get; set; }
        
        public CategoriesEntity Category { get; set; }
        public IEnumerable<TransactionsEntity> LabelTransactions { get; set; }
    }
}
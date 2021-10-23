using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetWise.Api.Entities
{
    [Table("Transactions")]
    public class TransactionsEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("label_id")]
        public int LabelId { get; set; }
        [Column("amount")]
        public decimal Amount { get; set; }
        [Column("date_applied")]
        public DateTime DateApplied { get; set; }
        [Column("apply_to_daily")]
        public bool ApplyToDaily { get; set; }
        [Column("active")]
        public bool Active { get; set; }
        
        public LabelsEntity Label { get; set; }
        public UsersEntity User { get; set; }
    }
}
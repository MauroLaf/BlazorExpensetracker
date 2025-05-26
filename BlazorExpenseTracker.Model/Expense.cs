using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorExpenseTracker.Model
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [StringLength(30)]
        public string ExpenseType { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}

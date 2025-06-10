using BlazorExpenseTracker.Model.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorExpenseTracker.Model
{
    public class Expense : IValidatableObject
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

        [Required]
        [ExpenseTransactionDateValidator(DaysInTheFuture = 30)]
        public DateTime TransactionDate { get; set; }
        [Required]
        public ExpenseType ExpenseType { get; set; }

        //al agregar la interfaz de validation puedo crera validaciones específicas

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            if (ExpenseType == ExpenseType.Income && Amount < 0)
            {
                errors.Add(new ValidationResult("Income amount cannot be negative.",
                    new[] { nameof(Amount) }));
            }
            else if (ExpenseType == ExpenseType.Expense && Amount > 0)
            {
                errors.Add(new ValidationResult("Expense amount must be negative.",
                    new[] { nameof(Amount) }));
            }
            return errors;
        }
    }
}

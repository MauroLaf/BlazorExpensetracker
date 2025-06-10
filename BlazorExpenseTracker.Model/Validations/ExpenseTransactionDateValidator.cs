using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExpenseTracker.Model.Validations
{
    public class ExpenseTransactionDateValidator: ValidationAttribute
    {
        public int DaysInTheFuture { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime transactionDate;
            if(DateTime.TryParse(value.ToString(), out transactionDate)) //el resultado del parseo lo pongo en transactionDate
            {
                if (transactionDate == DateTime.MinValue)
                {
                    return new ValidationResult("Transaction date cannot be empty.",
                        new[] { validationContext.MemberName });
                }
                else if (transactionDate > DateTime.Now.AddDays(DaysInTheFuture))
                {
                    return new ValidationResult($"Transaction date cannot be more than {DaysInTheFuture} days in the future.",
                        new[] { validationContext.MemberName });
                }
                return null;
            }

            return new ValidationResult("Invalid date.",
                new[] { validationContext.MemberName });
        }
    }
}

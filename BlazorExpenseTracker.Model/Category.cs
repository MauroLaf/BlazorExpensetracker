using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExpenseTracker.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Category Name is required")]
        public string Name { get; set; } = string.Empty;

        // Relación: Una categoría puede tener muchos gastos
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}

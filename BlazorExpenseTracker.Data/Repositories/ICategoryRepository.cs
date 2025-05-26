using BlazorExpenseTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExpenseTracker.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(); //me va a traer toda las categorias de bd, le indico que sera un iterable(ienumerable de tipo category, estoy usando un generic)
        Task<Category?> GetCategoryDetailsAsync(int id);
        Task<bool> InsertCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);

    }
}

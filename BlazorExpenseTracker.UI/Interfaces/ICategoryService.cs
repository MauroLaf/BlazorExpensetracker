using BlazorExpenseTracker.Model;

namespace BlazorExpenseTracker.UI.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryDetailsAsync(int id);
        Task SaveCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
    }
}

using BlazorExpenseTracker.Model;
using BlazorExpenseTracker.UI.Interfaces;
using System.Text.Json;
using System.Text;

namespace BlazorExpenseTracker.UI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task DeleteCategoryAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/category/{id}");
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Category>>(
                await _httpClient.GetStreamAsync($"api/category"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Category?> GetCategoryDetailsAsync(int id)
        {
            return await JsonSerializer.DeserializeAsync<Category>(
                await _httpClient.GetStreamAsync($"api/category/{id}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
        public async Task SaveCategoryAsync(Category category)
        {
            var jsonString = JsonSerializer.Serialize(category);
            Console.WriteLine($"JSON enviado al API: {jsonString}");

            var categoryJson = new StringContent(jsonString,
                Encoding.UTF8, "application/json");

            if (category.Id == 0)
                await _httpClient.PostAsync("api/category", categoryJson);
            else
                await _httpClient.PutAsync("api/category", categoryJson);
        }

    }
}

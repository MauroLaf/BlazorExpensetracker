using BlazorExpenseTracker.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorExpenseTracker.Data.Repositories
{
    //al heredera directamente de la interface me traigo todo el codigo y solo hago inyeccion de depedencia de dbconection, tambine puedo ponerlea en la interfaz pero aqui es mas visible
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;
            _context.Categories.Remove(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategoryDetailsAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id); //no confundir con los controllers o mvc que puedo usar iactionresult aqui uso "?" para que avise que puede dar null
            
        }

        public async Task<bool> InsertCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            return await _context.SaveChangesAsync() > 0; //por eso ponemos bool si devuelve 1 el resultado fue true
        }
        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.Id);
            if (existingCategory == null) return false;

            existingCategory.Name = category.Name;
            // Aquí puedes actualizar otros campos si existen

            return await _context.SaveChangesAsync() > 0;
        }


    }
}

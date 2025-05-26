using BlazorExpenseTracker.Model;
using Microsoft.EntityFrameworkCore;



namespace BlazorExpenseTracker.Data
{
    // Clase que representa el contexto de la base de datos para Entity Framework Core
    // Aquí declaramos las tablas que vamos a usar mediante DbSet
    public class AppDbContext : DbContext
    {
        // Constructor que recibe las opciones para configurar el contexto (cadena conexión, etc)
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options){}

        // DbSet que representa la tabla Categories en la base de datos
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Para mantener la precisión en Amount
            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasColumnType("decimal(18,2)");
        }
    }
}

using intro.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace intro.DAL.Context
{
    public class IntroContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public IntroContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Этот метод вызывается, когда создается модель
            //БД из кода. Здесь можно задать начальные настройки
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            
        }
    }
}

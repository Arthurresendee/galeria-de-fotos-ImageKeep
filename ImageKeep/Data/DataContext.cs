using ImageKeep.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageKeep.Data.DataContext{

    public class DataContext : DbContext
    {
        public DbSet<Foto> Fotos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ImageKeep.db");
        }
    }
}
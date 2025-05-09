using MarcasAutosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbOptions) : base(dbOptions) { }

        public DbSet<MarcaAuto> MarcaAuto { get; set; }

        //Agregar data seed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var seedDate = DateTime.SpecifyKind(new DateTime(2025, 05, 08), DateTimeKind.Utc);

            //Seeding de las 3 marcas de auto iniciales 
            modelBuilder.Entity<MarcaAuto>().HasData(
                    new MarcaAuto { 
                        Id = 1,
                        Name = "Ford", 
                        Country = "United States", 
                        FoundedYear = 1903, 
                        ImageUrl = "https://www.ford.es/content/dam/guxeu/global-shared/header/ford_oval_blue_logo.svg",
                        IsActive = true,
                        Updated = seedDate,
                        Created = seedDate
                    },
                    new MarcaAuto
                    {
                        Id = 2,
                        Name = "BMW",
                        Country = "Germany",
                        FoundedYear = 1916,
                        ImageUrl = "https://www.bmw.com/etc.clientlibs/settings/wcm/designs/bmwcom/base/resources/ci2020/img/logo-bmw-com-gray.svg",
                        IsActive = true,
                        Updated = seedDate,
                        Created = seedDate
                    },
                    new MarcaAuto
                    {
                        Id = 3,
                        Name = "Mazda",
                        Country = "Japan",
                        FoundedYear = 1920,
                        ImageUrl = "https://dealerinspire-shared-assets.s3.amazonaws.com/public/logos/mazda/mazda-dark-no-space-desktop-logo.png",
                        IsActive = true,
                        Updated = seedDate,
                        Created = seedDate
                    }
                ); 
        }
    }
}

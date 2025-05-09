using MarcasAutosApi.Controllers;
using MarcasAutosApi.Data;
using MarcasAutosApi.Models;
using MarcasAutosApi.Repositories;
using MarcasAutosApi.Repositories.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutosApi.Tests
{
    public class MarcasAutosControllerTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "MarcasAutosTestDb")
                .Options;

            var context = new AppDbContext(options);

            // Seed inicial
            context.MarcaAuto.AddRange(
                new MarcaAuto
                {
                    Id = 1,
                    Name = "Ford",
                    Country = "United States",
                    FoundedYear = 1903,
                    ImageUrl = "https://www.ford.es/content/dam/guxeu/global-shared/header/ford_oval_blue_logo.svg",
                    IsActive = true                  
                },
                new MarcaAuto
                {
                    Id = 2,
                    Name = "BMW",
                    Country = "Germany",
                    FoundedYear = 1916,
                    ImageUrl = "https://www.bmw.com/etc.clientlibs/settings/wcm/designs/bmwcom/base/resources/ci2020/img/logo-bmw-com-gray.svg",
                    IsActive = true
                }
            );
            context.SaveChanges();

            return context;
        }

        [Fact]
        public async Task Get_ReturnsAllMarcasAutos()
        {
            // Arrange
            var context = GetDbContext();
            IMarcaAutoRepository repo = new MarcaAutoRepository(context);
            var controller = new MarcasAutosController(repo);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var marcas = Assert.IsAssignableFrom<ICollection<MarcaAuto>>(okResult.Value);
            Assert.Equal(2, marcas.Count);
        }
    }
}

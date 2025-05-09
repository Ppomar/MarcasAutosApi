using MarcasAutosApi.Data;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutosApi.Helpers.Infra
{   
    public static class MigrationManager
    {
        // Motodo para migrar la base de datos en el contenedor
        public static IHost MigrateDatabase(this IHost host)
        {
            
            using var scope = host.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            db.Database.Migrate();
            return host;
        }
    }
}

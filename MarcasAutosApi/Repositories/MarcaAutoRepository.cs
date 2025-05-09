using MarcasAutosApi.Data;
using MarcasAutosApi.Models;
using MarcasAutosApi.Models.Dto;
using MarcasAutosApi.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutosApi.Repositories
{
    public class MarcaAutoRepository : IMarcaAutoRepository
    {
        private readonly AppDbContext _appDbContext;

        public MarcaAutoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Crear una nueva marca
        /// </summary>
        /// <param name="marcaAutoDto">MarcaAutoDto con los datos necesarios</param>
        /// <returns>MarcaAuto?</returns>
        public async Task<MarcaAuto?> Create(MarcaAutoDto marcaAutoDto)
        {
            var marcaAutoExisting = await _appDbContext.MarcaAuto.FirstOrDefaultAsync(ma => ma.Name.ToLower().Trim() == marcaAutoDto.Name.ToLower().Trim());

            if (marcaAutoExisting != null) return null;

            var entity = new MarcaAuto
            {
                Name = marcaAutoDto.Name,
                Country = marcaAutoDto.Country,
                ImageUrl = marcaAutoDto.ImageUrl,
                IsActive = marcaAutoDto.IsActive,
                FoundedYear = marcaAutoDto.FoundedYear,
                Updated = DateTime.UtcNow
            };

            await _appDbContext.MarcaAuto.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Eliminar una marca de auto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool?</returns>
        public async Task<bool?> Delete(int id)
        {
            var marcaAutoExisting = await _appDbContext.MarcaAuto.FirstOrDefaultAsync(ma => ma.Id == id);

            if (marcaAutoExisting == null) return null;

            _appDbContext.MarcaAuto.Remove(marcaAutoExisting);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Obtener lista de marcas de auto completa
        /// </summary>
        /// <returns>List<MarcaAuto></returns>
        public async Task<ICollection<MarcaAuto>> Get()
        {
            return await _appDbContext.MarcaAuto.ToListAsync();
        }

        /// <summary>
        /// Obtener una marca de auto por id si existe
        /// </summary>
        /// <param name="id">id de la marca de auto</param>
        /// <returns>MarcaAuto?</returns>
        public async Task<MarcaAuto?> Get(int id)
        {

            return await _appDbContext.MarcaAuto.FirstOrDefaultAsync(ma => ma.Id == id);
        }

        /// <summary>
        /// Actualizar una marca de auto
        /// </summary>
        /// <param name="marcaAutoDto">MarcaAutoDto condatos actualizados</param>
        /// <returns>MarcaAuto?</returns>
        public async Task<MarcaAuto?> Update(MarcaAutoDto marcaAutoDto)
        {
            var marcaAutoExisting = await _appDbContext.MarcaAuto.FirstOrDefaultAsync(ma => ma.Id == marcaAutoDto.Id);
            var marcaAutoNameExisting = await _appDbContext.MarcaAuto.FirstOrDefaultAsync(ma => ma.Name.ToLower().Trim() == marcaAutoDto.Name.ToLower().Trim() && ma.Id != marcaAutoDto.Id);


            if (marcaAutoExisting == null || marcaAutoNameExisting != null) return null;

            marcaAutoExisting.Name = marcaAutoDto.Name;
            marcaAutoExisting.Country = marcaAutoDto.Country;
            marcaAutoExisting.ImageUrl = marcaAutoDto.ImageUrl;
            marcaAutoExisting.IsActive = marcaAutoDto.IsActive;
            marcaAutoExisting.FoundedYear = marcaAutoDto.FoundedYear;
            marcaAutoExisting.Updated = DateTime.UtcNow;

            _appDbContext.Update(marcaAutoExisting);
            await _appDbContext.SaveChangesAsync();

            return marcaAutoExisting;
        }
    }
}

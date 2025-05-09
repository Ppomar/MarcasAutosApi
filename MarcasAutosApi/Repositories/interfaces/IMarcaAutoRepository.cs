using MarcasAutosApi.Models;
using MarcasAutosApi.Models.Dto;

namespace MarcasAutosApi.Repositories.interfaces
{
    public interface IMarcaAutoRepository
    {
               
        /// <summary>
        /// Crear una nueva marca
        /// </summary>
        /// <param name="marcaAutoDto">MarcaAutoDto con los datos necesarios</param>
        /// <returns>MarcaAuto?</returns>
        public Task<MarcaAuto?> Create(MarcaAutoDto marcaAutoDto);

        /// <summary>
        /// Eliminar una marca de auto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool?</returns>
        public Task<bool?> Delete(int id);

        /// <summary>
        /// Obtener lista de marcas de auto completa
        /// </summary>
        /// <returns>List<MarcaAuto></returns>
        public Task<ICollection<MarcaAuto>> Get();

        /// <summary>
        /// Obtener una marca de auto por id si existe
        /// </summary>
        /// <param name="id">id de la marca de auto</param>
        /// <returns>MarcaAuto?</returns>
        public Task<MarcaAuto?> Get(int id);

        /// <summary>
        /// Actualizar una marca de auto
        /// </summary>
        /// <param name="marcaAutoDto">MarcaAutoDto condatos actualizados</param>
        /// <returns>MarcaAuto?</returns>
        public Task<MarcaAuto?> Update(MarcaAutoDto marcaAutoDto);      
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliothèqueUniversitaire.App.Services
{
    public interface IService <TKey, TEntity>
    {
        /// <summary>
        /// Fetch objects by id from database.
        /// </summary>
        Task<TEntity> GetByIdAsync(TKey id);

        /// <summary>
        /// Fetch all objects from database.
        /// </summary>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Preserve objects in database.
        /// </summary>
        void Save(params TEntity[] objs);

        /// <summary>
        /// Preserve objects in database.
        /// </summary>
        Task SaveAsync(params TEntity[] objs);

        /// <summary>
        /// Update objects in database.
        /// </summary>
        Task UpdateAsync(params TEntity[] objs);

        /// <summary>
        /// Delete collection of objects from database.
        /// </summary>
        Task DeleteAsync(params TEntity[] objs);

    }
}

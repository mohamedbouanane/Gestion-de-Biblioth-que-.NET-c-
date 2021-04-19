using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliothèqueUniversitaire.Data.Repositories
{
    public interface ICrudRepository<Entity, Id>
    {
        /// <summary>
        /// Fetch objects by id from database.
        /// </summary>
        Task<Entity> GetByIdAsync(Id id);

        /// <summary>
        /// Fetch all objects from database.
        /// </summary>
        IEnumerable<Entity> GetAll();

        /// <summary>
        /// Preserve objects in database.
        /// </summary>
        Task SaveAsync(params Entity[] objs);

        /// <summary>
        /// Update objects in database.
        /// </summary>
        Task UpdateAsync(params Entity[] objs);

        /// <summary>
        /// Preserve / Update objects in database (not recomended to use).
        /// </summary>
        Task SaveOrUpdateAsync(params Entity[] objs);

        /// <summary>
        /// Delete collection of objects from database.
        /// </summary>
        Task DeleteAsync(params Entity[] objs);

        /// <summary>
        /// Delete object from database by id.
        /// </summary>
        /// <param name="id"></param>
        void DeleteById(Id id);
    }
}

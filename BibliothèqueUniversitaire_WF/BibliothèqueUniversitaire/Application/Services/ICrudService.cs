using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliothèqueUniversitaire.App.Services
{
    public interface ICrudService <Entity, Id>
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
        void SaveAsync(params Entity[] objs);

        /// <summary>
        /// Update objects in database.
        /// </summary>
        void UpdateAsync(params Entity[] objs);

        /// <summary>
        /// Delete collection of objects from database.
        /// </summary>
        void DeleteAsync(params Entity[] objs);
    }
}

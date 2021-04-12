using BibliothèqueUniversitaire.Models;
using System.Collections.Generic;

namespace BibliothèqueUniversitaire.Services
{
    public interface ICrudService<Entity, Id>
    {
        /// <summary>
        /// Fetch all objects from database.
        /// </summary>
        IEnumerable<Entity> GetAll();

        void Save(Entity obj);

        void Update(Entity obj);
        
        void Delete(Entity obj);


    }
}

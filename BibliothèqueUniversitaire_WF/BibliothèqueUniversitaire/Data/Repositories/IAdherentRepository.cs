using BibliothèqueUniversitaire.Models;
using System.Collections.Generic;

namespace BibliothèqueUniversitaire.Data.Repositories
{
    public interface IAdherentRepository : ICrudRepository<AdherentEntity, long>
    {
        /// <summary>
        /// Retourne tout les couples (emprunteur, titre du livre emprunté).
        /// </summary>
        IEnumerable<AdherentEntity> GetAllEmpruntsEnCoursEtLesPénalités();
    }
}

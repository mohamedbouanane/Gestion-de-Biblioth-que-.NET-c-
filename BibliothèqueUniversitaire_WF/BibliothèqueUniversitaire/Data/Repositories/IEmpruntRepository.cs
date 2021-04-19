using BibliothèqueUniversitaire.Models;
using System.Collections.Generic;

namespace BibliothèqueUniversitaire.Data.Repositories
{
    public interface IEmpruntRepository : ICrudRepository<EmpruntEntity, long>
    {
        /// <summary>
        /// Retourne tout les couples (emprunteur, titre du livre emprunté).
        /// </summary>
        IEnumerable<EmpruntEntity> GetAllEmprunts();

        /// <summary>
        /// Retourne tout les couples (emprunteur, titre du livre emprunté).
        /// </summary>
        IEnumerable<EmpruntEntity> GetAllEmpruntsEnCoursEtLesPénalités();

    }
}

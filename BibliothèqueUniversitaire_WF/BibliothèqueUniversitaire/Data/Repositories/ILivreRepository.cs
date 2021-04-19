using BibliothèqueUniversitaire.Models;
using System.Collections.Generic;

namespace BibliothèqueUniversitaire.Data.Repositories
{
    public interface ILivreRepository : ICrudRepository<LivreEntity, long>
    {
        /// <summary>
        /// Retourne tout les livres qui n'ont pas étaient encore rendue.
        /// </summary>
        IEnumerable<LivreEntity> GetAllLivresNonRendue();

        /// <summary>
        /// Retourne tous les livres qui n’ont pas été achetés directement à leur éditeur.
        /// </summary>
        IEnumerable<LivreEntity> GetAllLivresAchetéIndirectementDeLEditeur();


    }
}

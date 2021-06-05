
using BibliothèqueUniversitaire.Infra.Domain.Models;
using System.Collections.Generic;
using DynamicRepository;

namespace BibliothèqueUniversitaire.Infra.Data.Repositories
{
    public interface ILivreRepository : IRepository<long, LivreEntity>
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

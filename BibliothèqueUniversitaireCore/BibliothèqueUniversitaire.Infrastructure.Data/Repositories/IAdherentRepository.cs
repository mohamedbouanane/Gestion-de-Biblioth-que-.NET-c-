
using BibliothèqueUniversitaire.Infra.Domain.Models;
using System.Collections.Generic;
using DynamicRepository;

namespace BibliothèqueUniversitaire.Infra.Data.Repositories
{
    public interface IAdherentRepository : IRepository<long, AdherentEntity>
    {
        /// <summary>
        /// Q3 : Retourne tout les couples (emprunteur, titre du livre emprunté).
        /// </summary>
        public IEnumerable<AdherentEntity> GetAllAdherentEmprunts();

        /// <summary>
        /// Q4 : Afficher, pour chaque utilisateur de la bibliothèque, ses emprunts en cours 
        /// (livre, date de retour attendue), ainsi que l’éventuelle pénalité due à la bibliothèque. 
        /// On mettra un utilisateur par page
        /// </summary>
        public IEnumerable<AdherentEntity> GetAllEmpruntsAdherentEnCoursEtLesPénalités();

    }
}

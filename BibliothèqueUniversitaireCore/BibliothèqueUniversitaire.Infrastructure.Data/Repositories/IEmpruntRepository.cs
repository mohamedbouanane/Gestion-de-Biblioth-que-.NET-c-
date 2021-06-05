
using BibliothèqueUniversitaire.Infra.Domain.Models;
using System.Collections.Generic;
using DynamicRepository;

namespace BibliothèqueUniversitaire.Infra.Data.Repositories
{
    public interface IEmpruntRepository : IRepository<long, EmpruntEntity>
    {

        /// <summary>
        /// Q2 : Retourne tout les couples (emprunteur, titre du livre emprunté).
        /// </summary>
        IEnumerable<EmpruntEntity> GetAllEmprunts();

        /// <summary>
        /// Q3 : Retourne tout les les empruntes et les livre emprunté ave.
        /// </summary>
        IEnumerable<EmpruntEntity> GetAllEmpruntsEnCoursEtLesPénalités();

    }
}

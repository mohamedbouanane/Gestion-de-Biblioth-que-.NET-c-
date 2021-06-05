
using BibliothèqueUniversitaire.Infra.Domain.Models;
using System.Collections.Generic;

namespace BibliothèqueUniversitaire.App.Services
{
    public interface IAdherentService : IService<long, AdherentEntity>
    {
        public IEnumerable<AdherentEntity> GetAllAdherentEmprunts();

        public IEnumerable<AdherentEntity> GetAllEmpruntsAdherentEnCoursEtLesPénalités();

    }
}

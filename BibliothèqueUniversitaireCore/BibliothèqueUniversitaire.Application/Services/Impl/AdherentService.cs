
using BibliothèqueUniversitaire.Infra.Data.Repositories;
using BibliothèqueUniversitaire.Infra.Domain.Models;
using System.Collections.Generic;

namespace BibliothèqueUniversitaire.App.Services.Impl
{
    public class AdherentService : Service<long, AdherentEntity, IAdherentRepository>, IAdherentService
    {
        public AdherentService(IAdherentRepository repository) : base(repository) { }

        public IEnumerable<AdherentEntity> GetAllAdherentEmprunts()
        {
            return _repository.GetAllAdherentEmprunts();
        }

        public IEnumerable<AdherentEntity> GetAllEmpruntsAdherentEnCoursEtLesPénalités()
        {
            return _repository.GetAllEmpruntsAdherentEnCoursEtLesPénalités();
        }
    }
}

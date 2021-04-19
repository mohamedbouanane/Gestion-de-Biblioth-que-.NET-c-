
using BibliothèqueUniversitaire.Data.Repositories.Impl;
using BibliothèqueUniversitaire.Models;

namespace BibliothèqueUniversitaire.App.Services.Impl
{
    public class AdherentService : AbsCrudService<AdherentEntity, long>, IAdherentService
    {
        public AdherentService(AdherentRepository repository) : base(repository) { }

    }
}

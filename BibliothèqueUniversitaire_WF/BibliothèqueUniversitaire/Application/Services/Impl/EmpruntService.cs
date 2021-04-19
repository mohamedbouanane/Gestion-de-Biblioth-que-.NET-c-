
using BibliothèqueUniversitaire.Data.Repositories.Impl;
using BibliothèqueUniversitaire.Models;

namespace BibliothèqueUniversitaire.App.Services.Impl
{
    public class EmpruntService : AbsCrudService<EmpruntEntity, long>, IEmpruntService
    {
        public EmpruntService(EmpruntRepository repository) : base(repository) { }

    }
}

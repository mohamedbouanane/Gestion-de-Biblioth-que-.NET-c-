
using BibliothèqueUniversitaire.Data.Repositories.Impl;
using BibliothèqueUniversitaire.Models;

namespace BibliothèqueUniversitaire.App.Services.Impl
{
    public class LivreService : AbsCrudService<LivreEntity, long>, ILivreService
    {
        public LivreService(LivreRepository repository) : base(repository) { }

    }
}

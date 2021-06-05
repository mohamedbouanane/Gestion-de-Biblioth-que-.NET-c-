
using BibliothèqueUniversitaire.Infra.Data.Repositories;
using BibliothèqueUniversitaire.Infra.Domain.Models;

namespace BibliothèqueUniversitaire.App.Services.Impl
{
    public class AuteurService : Service<long, AuteurEntity, IAuteurRepository>, IAuteurService
    {
        public AuteurService(IAuteurRepository repository) : base(repository) { }

    }
}

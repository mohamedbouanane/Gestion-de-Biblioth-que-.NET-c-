
using BibliothèqueUniversitaire.Infra.Data.Repositories;
using BibliothèqueUniversitaire.Infra.Domain.Models;
using System.Collections.Generic;

namespace BibliothèqueUniversitaire.App.Services.Impl
{
    public class EmpruntService : Service<long, EmpruntEntity, IEmpruntRepository>, IEmpruntService
    {
        public EmpruntService(IEmpruntRepository repository) : base(repository) { }

    }
}

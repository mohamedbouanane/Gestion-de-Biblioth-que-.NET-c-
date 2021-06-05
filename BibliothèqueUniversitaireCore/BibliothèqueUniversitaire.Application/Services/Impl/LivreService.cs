
using BibliothèqueUniversitaire.Infra.Data.Repositories;
using BibliothèqueUniversitaire.Infra.Domain.Models;
using System.Collections.Generic;

namespace BibliothèqueUniversitaire.App.Services.Impl
{
    public class LivreService : Service<long, LivreEntity, ILivreRepository>, ILivreService
    {
        public LivreService(ILivreRepository repository) : base(repository) { }


        public IEnumerable<LivreEntity> GetAllLivresAchetéIndirectementDeLEditeur()
        {
            return _repository.GetAllLivresAchetéIndirectementDeLEditeur();
        }

        public IEnumerable<LivreEntity> GetAllLivresNonRendue()
        {
            return _repository.GetAllLivresNonRendue();
        }

    }
}


using BibliothèqueUniversitaire.Infra.Domain.Models;
using System.Collections.Generic;

namespace BibliothèqueUniversitaire.App.Services
{
    public interface ILivreService : IService<long, LivreEntity>
    {
        public IEnumerable<LivreEntity> GetAllLivresAchetéIndirectementDeLEditeur();

        public IEnumerable<LivreEntity> GetAllLivresNonRendue();

    }
}

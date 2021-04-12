using BibliothèqueUniversitaire.Infra.Data.Context;
using BibliothèqueUniversitaire.Infra.Domain.Models;
using System.Collections.Generic;

namespace BibliothèqueUniversitaire.Infra.Domain.Repositories.Impl
{
    public class LivreRepository : ILivreRepository
    {
        private AppDbContext appDbContext;

        public LivreRepository(AppDbContext context)
        {
            appDbContext = context;
        }

        public IEnumerable<LivreEntity> GetLivres()
        {
            return appDbContext.Livres;
        }





    }
}

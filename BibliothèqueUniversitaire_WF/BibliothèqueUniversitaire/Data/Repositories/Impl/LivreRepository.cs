using BibliothèqueUniversitaire.Ifrostructure.Context;
using BibliothèqueUniversitaire.Models;
using System.Collections.Generic;

namespace BibliothèqueUniversitaire.Data.Repositories.Impl
{
    public class LivreRepository : AbsCrudRepository<LivreEntity, long>, ILivreRepository
    {
        public LivreRepository(ModelContext context):base(context)
        {
        }

        public IEnumerable<LivreEntity> GetAllLivresAchetéIndirectementDeLEditeur()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<LivreEntity> GetAllLivresNonRendue()
        {
            throw new System.NotImplementedException();
        }
    }
}

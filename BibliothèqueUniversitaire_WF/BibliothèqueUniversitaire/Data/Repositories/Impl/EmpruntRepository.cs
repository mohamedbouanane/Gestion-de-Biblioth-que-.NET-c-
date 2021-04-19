using BibliothèqueUniversitaire.Ifrostructure.Context;
using BibliothèqueUniversitaire.Models;
using System.Collections.Generic;

namespace BibliothèqueUniversitaire.Data.Repositories.Impl
{
    public class EmpruntRepository : AbsCrudRepository<EmpruntEntity, long>, IEmpruntRepository
    {
        public EmpruntRepository(ModelContext context) : base(context)
        {
        }

        public IEnumerable<EmpruntEntity> GetAllEmprunts()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<EmpruntEntity> GetAllEmpruntsEnCoursEtLesPénalités()
        {
            throw new System.NotImplementedException();
        }
    }
}

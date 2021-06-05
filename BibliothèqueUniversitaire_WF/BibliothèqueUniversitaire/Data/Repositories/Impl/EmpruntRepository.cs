using BibliothèqueUniversitaire.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace BibliothèqueUniversitaire.Data.Repositories.Impl
{
    public class EmpruntRepository //: Repository<EmpruntEntity, long>, IEmpruntRepository
    {
        public EmpruntRepository(DbContext context) //: base(context)
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

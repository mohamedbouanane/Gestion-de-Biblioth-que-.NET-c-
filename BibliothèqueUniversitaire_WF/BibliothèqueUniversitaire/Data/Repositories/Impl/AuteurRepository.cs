using BibliothèqueUniversitaire.Ifrostructure.Context;
using BibliothèqueUniversitaire.Models;

namespace BibliothèqueUniversitaire.Data.Repositories.Impl
{
    public class AuteurRepository : AbsCrudRepository<AuteurEntity, long>, IAuteurRepository
    {
        public AuteurRepository(ModelContext context) : base(context)
        {
        }
    }
}

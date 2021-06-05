using BibliothèqueUniversitaire.Models;
using System.Data.Entity;

namespace BibliothèqueUniversitaire.Data.Repositories.Impl
{
    public class AuteurRepository //: Repository<long, AuteurEntity>, IAuteurRepository
    {
        public AuteurRepository(DbContext context) //: base(context)
        {
        }
    }
}

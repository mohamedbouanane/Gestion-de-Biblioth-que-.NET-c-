using BibliothèqueUniversitaire.Context;
using BibliothèqueUniversitaire.Models;

namespace BibliothèqueUniversitaire.Services.Impl
{
    public class LivreService : CrudService<LivreEntity, long>, ILivreService
    {
        public LivreService(AppDbContext context):base(context)
        {
        }
    }
}

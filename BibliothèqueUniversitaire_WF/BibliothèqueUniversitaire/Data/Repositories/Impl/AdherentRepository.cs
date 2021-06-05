using BibliothèqueUniversitaire.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BibliothèqueUniversitaire.Data.Repositories.Impl
{
    public class AdherentRepository //: Repository<AdherentEntity, long>, IAdherentRepository
    {

        public AdherentRepository(DbContext context) //: base(context)
        {
        }

        public IEnumerable<AdherentEntity> GetAllEmpruntsEnCoursEtLesPénalités()
        {
            throw new System.NotImplementedException();
        }

        //public async Task<bool> ExistsByIdAsync(long id) => 
        //    await _context.Adherents.AnyAsync(i => i.Id  == id);
        
    }
}

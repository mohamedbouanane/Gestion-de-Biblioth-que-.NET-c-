
using BibliothèqueUniversitaire.Infra.Domain.Models;
using System.Collections.Generic;
using DynamicRepository.EFCore;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BibliothèqueUniversitaire.Infra.Data.Repositories.Impl
{
    public class AdherentRepository : Repository<long, AdherentEntity>, IAdherentRepository
    {
        public AdherentRepository(DbContext context) : base(context) {}

        public IEnumerable<AdherentEntity> GetAllAdherentEmprunts()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AdherentEntity> GetAllEmpruntsAdherentEnCoursEtLesPénalités()
        {
            throw new System.NotImplementedException();
        }

        //public async Task<bool> ExistsByIdAsync(long id) => 
        //    await _context.Adherents.AnyAsync(i => i.Id  == id);

    }
}


using BibliothèqueUniversitaire.Infra.Domain.Models;
using DynamicRepository.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BibliothèqueUniversitaire.Infra.Data.Repositories.Impl
{
    public class LivreRepository : Repository<long, LivreEntity>, ILivreRepository
    {
        public LivreRepository(DbContext context):base(context) {}

        public IEnumerable<LivreEntity> GetAllLivresNonRendue()
        {
            return Context.Set<EmpruntEntity>().Select(s => s.LivreEmprunté);
        }

        public IEnumerable<LivreEntity> GetAllLivresAchetéIndirectementDeLEditeur()
        {
            throw new System.NotImplementedException();
        }

    }
}

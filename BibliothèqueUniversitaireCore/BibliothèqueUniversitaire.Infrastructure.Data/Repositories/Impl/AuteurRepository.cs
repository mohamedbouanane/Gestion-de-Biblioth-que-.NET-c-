
using BibliothèqueUniversitaire.Infra.Domain.Models;
using Microsoft.EntityFrameworkCore;
using DynamicRepository.EFCore;

namespace BibliothèqueUniversitaire.Infra.Data.Repositories.Impl
{
    public class AuteurRepository : Repository<long, AuteurEntity>, IAuteurRepository
    {
        public AuteurRepository(DbContext context) : base(context) { }


    }
}

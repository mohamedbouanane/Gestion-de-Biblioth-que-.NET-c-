
using BibliothèqueUniversitaire.Infra.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DynamicRepository.EFCore;

namespace BibliothèqueUniversitaire.Infra.Data.Repositories.Impl
{
    public class EmpruntRepository : Repository<long, EmpruntEntity>, IEmpruntRepository
    {
        public EmpruntRepository(DbContext context) : base(context) {}


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

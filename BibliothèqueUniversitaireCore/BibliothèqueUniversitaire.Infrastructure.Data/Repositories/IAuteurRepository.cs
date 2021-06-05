
using BibliothèqueUniversitaire.Infra.Domain.Models;
using DynamicRepository;

namespace BibliothèqueUniversitaire.Infra.Data.Repositories
{
    public interface IAuteurRepository : IRepository<long, AuteurEntity>
    {
    }
}

using BibliothèqueUniversitaire.Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliothèqueUniversitaire.App.Services.Impl
{
    public abstract class AbsCrudService<Entity, Id> : ICrudService<Entity, Id> //where Repository : ICrudRepository<Entity, Id>
    {
        // to do later : convert les entités en DTO

        public ICrudRepository<Entity, Id> _repository;

        public AbsCrudService(ICrudRepository<Entity, Id> repository)
        {
            _repository = repository;
        }


        public virtual async Task<Entity> GetByIdAsync(Id id)
        {
            return await _repository.GetByIdAsync(id) ;
        }

        public virtual IEnumerable<Entity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void DeleteAsync(params Entity[] objs)
        {
            _repository.DeleteAsync(objs);
        }

        public virtual void SaveAsync(params Entity[] objs)
        {
            _repository.SaveAsync(objs);
        }

        public virtual void UpdateAsync(params Entity[] objs)
        {
            _repository.UpdateAsync(objs);
        }
    }
}

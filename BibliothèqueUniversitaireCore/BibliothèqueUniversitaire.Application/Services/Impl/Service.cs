
using System.Collections.Generic;
using System.Threading.Tasks;
using DynamicRepository;

namespace BibliothèqueUniversitaire.App.Services.Impl
{
    public abstract class Service<TKey, TEntity, TRepository> : IService<TKey, TEntity> where TEntity : class where TRepository : IRepository<TKey, TEntity>
    {
        // to do later : convertir les entités en DTO

        protected virtual TRepository _repository { get; set; }

        public Service(TRepository repository)
        {
            _repository = repository;
        }


        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _repository.GetAsync(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.List();
            //return _repository.ListAll(); ??
        }

        public virtual async Task DeleteAsync(params TEntity[] objs)
        {
            foreach(TEntity e in objs)
                await _repository.DeleteAsync(e);
        }

        public virtual async Task SaveAsync(params TEntity[] objs)
        {
            foreach (TEntity e in objs)
                await _repository.InsertAsync(e);
        }

        public virtual void Save(params TEntity[] objs)
        {
            foreach (TEntity e in objs)
                _repository.Insert(e);
        }

        public virtual async Task UpdateAsync(params TEntity[] objs)
        {
            foreach (TEntity e in objs)
                await _repository.UpdateAsync(e);
        }
    }
}

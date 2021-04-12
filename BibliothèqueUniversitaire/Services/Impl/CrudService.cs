using BibliothèqueUniversitaire.Context;
using BibliothèqueUniversitaire.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Forms;

namespace BibliothèqueUniversitaire.Services.Impl
{
    public abstract class CrudService<Entity, Id> : ICrudService<Entity, Id>
    {

        private AppDbContext appDbContext;

        public CrudService(AppDbContext context)
        {
            appDbContext = context;
        }

        private DbSet GetEntityDbSet() => appDbContext.Set(typeof(Entity));

        public IEnumerable<Entity> GetAll()
        {
            //appDbContext.Livres.;
            return (IEnumerable<Entity>)GetEntityDbSet();
        }

        public void Save(Entity obj)
        {
            //MessageBox.Show(GetEntityDbSet().ToString());
            //appDbContext.Livres.Add(obj);
            GetEntityDbSet().Add(obj);
            appDbContext.SaveChanges();
        }

        public void Update(Entity obj)
        {
            //GetEntityDbSet().r(obj);
            //appDbContext.SaveChanges();
        }

        public void Delete(Entity obj)
        {
            GetEntityDbSet().Remove(obj);
            appDbContext.SaveChanges();
        }

    }
}

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using BibliothèqueUniversitaire.Ifrostructure.Context;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Optional.Unsafe;
using Optional;

namespace BibliothèqueUniversitaire.Data.Repositories.Impl
{
    public abstract class AbsCrudRepository<Entity, Id> : ICrudRepository<Entity, Id> where Entity : class
    {
        // To do :
        // add : Injection des dépendances
        // Gestion de la concurence 

        protected ModelContext _context;

        public AbsCrudRepository(ModelContext context)
        {
            this._context = context;
        }

        
        public virtual async Task<Entity> GetByIdAsync(Id id)
        {
            return await Task.Run(() => _context.Set<Entity>().FindAsync(id));
        }

        public virtual IEnumerable<Entity> GetAll()
        {
            return _context.Set<Entity>();
        }

        public virtual async Task SaveAsync(params Entity[] objs)
        {
            using (var tran = _context.Database.BeginTransaction())
                try
                {
                    _context.Set<Entity>().AddRange(objs);
                    await _context.SaveChangesAsync();
                    tran.Commit();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    tran.Rollback();
                    MessageBox.Show(e.ToString());
                }
                catch (DbEntityValidationException e)
                {
                    tran.Rollback();
                    MessageBox.Show(e.ToString());
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    MessageBox.Show(e.ToString());
                }
        }

        // To test & adapt to liste
        public virtual async Task UpdateAsync(params Entity[] objs)
        {
            using (var tran = _context.Database.BeginTransaction())
                try
                {
                    //context.Set<Entity>().Find(objs);
                    _context.Entry(objs[0]).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    tran.Commit();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    tran.Rollback();
                    MessageBox.Show(e.ToString());
                }
                catch (DbEntityValidationException e)
                {
                    tran.Rollback();
                    MessageBox.Show(e.ToString());
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    MessageBox.Show(e.ToString());
                }
        }

        /*
        public virtual async Task UpdateAsync(params Entity[] objs)
        {
            using (var tran = context.Database.BeginTransaction())
                try
                {
                    //context.Set<Entity>().Find(objs);
                    //context.Entry(objs).CurrentValues.SetValues
                    await context.SaveChangesAsync();
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    MessageBox.Show(e.ToString());
                }
        }
*/

        // https://www.michaelgmccarthy.com/2016/08/24/entity-framework-addorupdate-is-a-destructive-operation/
        public virtual async Task SaveOrUpdateAsync(params Entity[] objs)
        {
            using (var tran = _context.Database.BeginTransaction())
                try
                {
                    _context.Set<Entity>().AddOrUpdate(objs);
                    await _context.SaveChangesAsync();
                    tran.Commit();
                    
                }/*
                catch (DbUpdateConcurrencyException e)
                {
                    tran.Rollback();
                }
                catch (DbEntityValidationException e)
                {
                    tran.Rollback();
                }*/
                catch (Exception e)
                {
                    tran.Rollback();
                    MessageBox.Show(e.ToString());
                }
        }

        public virtual async Task DeleteAsync(params Entity[] objs)
        {
            using (var tran = _context.Database.BeginTransaction())
                try
                {
                    _context.Set<Entity>().RemoveRange(objs);
                    await _context.SaveChangesAsync();
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    MessageBox.Show(e.ToString());
                }
        }

        public virtual void DeleteById(Id id)
        {

        }

    }
}

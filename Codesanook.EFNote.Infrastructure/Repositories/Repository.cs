using Codesanook.EFNote.Core;
using Codesanook.EFNote.Core.DomainModels;
using Codesanook.EFNote.Core.Repositories;
using System.Data.Entity;
using System.Linq;

namespace Codesanook.EFNote.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly NoteDbContext dbContext;

        public Repository(NoteDbContext dbContext) => this.dbContext = dbContext;

        public virtual T GetById(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

        public virtual IQueryable<T> List()
        {
            return dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }
    }
}




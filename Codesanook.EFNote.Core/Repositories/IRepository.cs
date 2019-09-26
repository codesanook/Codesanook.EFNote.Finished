using Codesanook.EFNote.Core.DomainModels;
using System.Linq;

namespace Codesanook.EFNote.Core.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        //https://deviq.com/repository-pattern/
        T GetById(int id);
        IQueryable<T> List();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}




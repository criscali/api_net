using primerApi.Abstraccions;
using System;
using System.Collections.Generic;
namespace primerApi.Repository
{
    public interface IRepository<T>: Icrud<T>
    {

    }
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        public List<T> lista;
        IDbContext<T> _dbContext;

        public Repository(IDbContext<T> dbContext)
        {
            lista = new List<T>();
            _dbContext = dbContext;
        }
        public void Delete(int id)
        {
            _dbContext.Delete(id);
        }

        public IList<T> GetAll()
        {
            return _dbContext.GetAll();
        }

        public T GetbyId(int id)
        {
            return _dbContext.GetbyId(id);
        }

        public T Save(T entity)
        {
            return _dbContext.Save(entity);
        }
    }

}
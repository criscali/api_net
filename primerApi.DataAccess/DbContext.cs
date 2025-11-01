using Microsoft.EntityFrameworkCore;
using primerApi.Abstraccions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primerApi.DataAccess
{
    public class DbContext<T> : IDbContext<T> where T : class,  IEntity
    {
        DbSet<T> _lista;
        ApiDbContext _apiDbContext;

        public DbContext(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
            _lista = apiDbContext.Set<T>();
        }

        public IList<T> CargarExcel(string rutaArchivo)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _apiDbContext.Set<T>().Remove(GetbyId(id));
        }

        public IList<T> GetAll()
        {
            return _lista.ToList();
        }

        public T GetbyId(int id)
        {
            return _lista.Where(i => i.Equals(id)).FirstOrDefault();
        }

        public T Save(T entity)
        {
            _lista.Add(entity);
            _apiDbContext.SaveChanges();
            return entity;

        }
    }
}

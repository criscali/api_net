using Microsoft.EntityFrameworkCore;
using primerApi.Abstraccions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primerApi.DataAccess
{
    public class DbContext<T> : IDbContext<T> where T : class, IEntity
    {
        DbSet<T> _lista;

        public DbContext()
        {
            
        }
        public void Delete(int id)
        {
            var e = _lista.Where(u => u.Id.Equals(id)).FirstOrDefault();
            if(e != null)
            {
                _lista.Remove(e);
            }
        }

        public IList<T> GetAll()
        {
            
            
        }

        public T GetbyId(int id)
        {
            
        }

        public T Save(T entity)
        {
            if(entity.Id.Equals(0))
            {
                _lista.Add(entity);
            }
            return entity;
        }
    }
}

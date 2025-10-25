using primerApi.Abstraccions;
using primerApi.Repository;

namespace primerApi.Application
{
    public interface IApplication<T> : Icrud<T>
    {
    }
    public class Application<T> : IApplication<T> where T : IEntity
    {
        private readonly IRepository<T> _repository;
        public Application(IRepository<T> repository)
        { 
            _repository = repository;
        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetbyId(int id)
        {
            return _repository.GetbyId(id);
        }

        public T Save(T entity)
        {
            return _repository.Save(entity);
        }
    }
}

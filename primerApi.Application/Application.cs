using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using primerApi.Abstraccions;
using primerApi.Repository;
using primerApi.Services.Cargues;

namespace primerApi.Application
{
    public interface IApplication<T> : Icrud<T>, ICargarExcel<T>
    {
    }
    public class Application<T> : IApplication<T> where T : IEntity
    {
        private readonly IRepository<T> _repository;
        private readonly ICargarExcel<T> _cargueExcel;
        public Application(IRepository<T> repository, ICargarExcel<T> cargarExcel)
        { 
            _repository = repository;
            _cargueExcel = cargarExcel;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public string CrearExcel(IFormFile rutaArchivo)
        {
            _cargueExcel.CrearExcel(rutaArchivo);
            return "Excel generado correctamente";
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

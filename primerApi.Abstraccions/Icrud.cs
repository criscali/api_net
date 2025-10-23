namespace primerApi.Abstraccions
{
    public interface Icrud<T>
    {
        T Save(T entity);   
        IList<T> GetAll();
        T GetbyId(int id);
        void Delete(int id);

    }

}

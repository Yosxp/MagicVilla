namespace MagicVilla.Infraestructura.Interface
{
    public interface IRepositorio<T> where T : class
    {
        T Add(T entity);

        T Edit(T entity);

        void Delete(T entity);

        T GetById(int id);

        IQueryable<T> GetAll();
    }
}

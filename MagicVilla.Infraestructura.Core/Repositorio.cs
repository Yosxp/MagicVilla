using MagicVilla.Infraestructura.Interface;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla.Infraestructura.Core
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly IContextoDB _contexto;
        private readonly DbSet<T> _dbSet;

        public Repositorio(IContextoDB pContexto)
        {
            _contexto = pContexto;
            _dbSet = _contexto.Instance.Set<T>();
        }

        public T Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            return _dbSet.Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _dbSet.Remove(entity);
        }

        public T Edit(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

   
    }
}



namespace tema2.DAO
{
    public interface IRepository<T>
    {
        
        public IEnumerable<T> readAll();
        public T read(int id);
        public void create(T entity);
        public void update(T entity);
        public void delete(T entity);

    }
}

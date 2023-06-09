using Microsoft.EntityFrameworkCore;



namespace tema2.DAO
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly MyDbContext _context;
        private readonly DbSet<T> _entities;

        protected GenericRepository(MyDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public virtual IEnumerable<T> readAll()
        {
            return _entities.ToList();
        }
        public virtual T read(int id)
        {
            return _entities.Find(id);
        }
        public void create(T entity){
            _entities.Add(entity);

        }
        public virtual void update(T entity){
            _entities.Update(entity);
        }
        public virtual void delete(T entity){
            _entities.Remove(entity);
        }

    }
}
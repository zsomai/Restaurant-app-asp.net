using tema2.Models;

namespace tema2.DAO
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _dbContext;
        private GenericRepository<Meal> _mealRepo;
        private GenericRepository<Order> _orderRepo;
        private GenericRepository<MealOrder> _mealOrderRepo;
        public UnitOfWork(MyDbContext dbContext){
            _dbContext = dbContext;
        }

        public GenericRepository<Meal> MealRepo
        {
            get 
            {
                if (_mealRepo == null){
                    _mealRepo = new MealRepository(_dbContext); 
                }
                return _mealRepo;
            } 
        }
        
        public GenericRepository<Order> OrderRepo
        {
            get
            {
                if (_orderRepo == null){
                    _orderRepo = new OrderRepository(_dbContext); 
                }
                return _orderRepo;
            }
        }
    

        public GenericRepository<MealOrder> MealOrderRepo
        {
            get
            {
                if (_mealOrderRepo == null){
                    _mealOrderRepo = new OrderMealRepository(_dbContext); 
                }
                return _mealOrderRepo;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task Save()
        {
           await _dbContext.SaveChangesAsync();
        }

    }
}
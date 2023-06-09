using tema2.Models;


namespace tema2.DAO
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Meal>  MealRepo  {get;}
        GenericRepository<Order> OrderRepo {get;}
        GenericRepository<MealOrder> MealOrderRepo {get;}
        Task Save();

    }
}
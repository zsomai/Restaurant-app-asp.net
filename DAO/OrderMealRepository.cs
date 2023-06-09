namespace tema2.DAO
{
    public class OrderMealRepository : GenericRepository<tema2.Models.MealOrder>
    {
        public OrderMealRepository(MyDbContext context) : base(context)
        {
        }
    }
}



namespace tema2.DAO
{
    public class MealRepository : GenericRepository<tema2.Models.Meal>
    {
        public MealRepository(MyDbContext context) : base(context)
        {
        }
    }
}

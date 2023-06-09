using tema2.Models;

namespace tema2.DAO
{   
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository(MyDbContext context) : base(context)
        {

        }
    }
}

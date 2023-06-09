using tema2.Models;

namespace tema2.BL
{
    public interface IMealOrderService
    {
        IEnumerable<MealOrder> getAll();
        MealOrder getOne(int id);
        void update(MealOrder entity);
        void remove(MealOrder entity);
        void save(MealOrder entity);
        List<Tuple<int, int>> getMealIdsToOrder(int orderId);
    }
}
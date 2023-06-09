using tema2.Models;

namespace tema2.BL
{
    public interface IMealService
    {
        IEnumerable<Meal> getAll();
        Meal getOne(int id);
        Task update(Meal entity);
        Task remove(Meal entity);
        Task save(Meal entity);
        Task DecreaseQuantity(Meal entity, int quantity);
        Task remove_by_id(int id);
    }
}

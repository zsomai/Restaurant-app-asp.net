using tema2.DAO;
using tema2.Models;
namespace tema2.BL
{
    public class MealOrderService : IMealOrderService
    {
        private UnitOfWork _unitOfWork;

        public MealOrderService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<MealOrder> getAll()
        {
            return _unitOfWork.MealOrderRepo.readAll();
        }

        public MealOrder getOne(int id)
        {
            return _unitOfWork.MealOrderRepo.read(id);
        }

        public void update(MealOrder entity)
        {
            _unitOfWork.MealOrderRepo.update(entity);
        }

        public void remove(MealOrder entity)
        {
            _unitOfWork.MealOrderRepo.delete(entity);
        }

        public void save(MealOrder entity)
        {
            _unitOfWork.MealOrderRepo.create(entity);
        }

        public List<Tuple<int, int>> getMealIdsToOrder(int orderId)
        {
            //Todo : add filter
            IEnumerable<MealOrder> all = getAll();
            List<Tuple<int, int>> results = new List<Tuple<int, int>>();
            foreach (MealOrder order in all)
            {
                if(order.OrderId == orderId){
                    results.Add(new Tuple<int, int>(order.MealId, order.Quantity));
                }
            }
            return results;
        }
    }
}
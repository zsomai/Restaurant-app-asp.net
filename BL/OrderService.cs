using tema2.DAO;
using tema2.Models;
using tema2.Utils;

namespace tema2.BL
{
    public class OrderService : IOrderService
    {
        private UnitOfWork _unitOfWork;
        private MealOrderService _mealOrderService;
        private MealService _mealService;
        public OrderService(UnitOfWork unitOfWork, MealOrderService mealOrderService, MealService mealService)
        {
            _unitOfWork = unitOfWork;
            _mealOrderService = mealOrderService;
            _mealService = mealService;
        }
        private ViewOrder convertViewOrder(Order order){
            List<Tuple<int, int>> idQuantityList = _mealOrderService.getMealIdsToOrder(order.Id);
            ViewOrder orderView = new ViewOrder{Id = order.Id, Status = order.Status, Date = order.Date, Meals = new List<Tuple<Meal, int>>()};
            foreach (var item in idQuantityList)
            { 
                Meal m = _mealService.getOne(item.Item1);
                Console.WriteLine(m.Name);
                orderView.Meals.Add(new Tuple<Meal, int>(m, item.Item2));
            }
            return orderView;
        }
        public List<ViewOrder> getAll()
        {
            List<ViewOrder> res = new List<ViewOrder>();
            IEnumerable<Order> orders = _unitOfWork.OrderRepo.readAll();
            foreach (Order order in orders){
                res.Add(convertViewOrder(order));
            }
            return res;
        }

        public ViewOrder getOne(int id)
        {   
            return convertViewOrder(_unitOfWork.OrderRepo.read(id));
        }

        public async Task update(Order entity)
        {
            _unitOfWork.OrderRepo.update(entity);
            await _unitOfWork.Save();
        }

        public IEnumerable<Meal> getAllMeals(){
            return _mealService.getAll();
        }


        public async Task remove(Order entity)
        {
            _unitOfWork.OrderRepo.delete(entity);
            await _unitOfWork.Save();
        }

        public async Task save(Order entity)
        {
            _unitOfWork.OrderRepo.create(entity);
            await _unitOfWork.Save();
        }

        public async Task modifyStatus(Order order, Status status)
        {
            order.Status = status;
            await update(order);
        }

        public List<ViewOrder> showOrdersBetween(DateTime start, DateTime end)
        {
            List<ViewOrder> orders = (List<ViewOrder>)getAll();
            List<ViewOrder> filtered = new List<ViewOrder>();

            foreach(ViewOrder order in orders)
            {
                if(order.Date >=  start && order.Date <= end)
                {
                    filtered.Add(order);
                }
            }
            return filtered;
        }

        public async Task ProcessOrder(Order order, Dictionary<int, int> meals){
             
            _unitOfWork.OrderRepo.create(order);
            await _unitOfWork.Save();
            int orderId = order.Id;
            foreach(var item in meals){
                Meal meal =  _mealService.getOne(item.Key);
                if(meal.Stock >= item.Value && item.Value != 0){
                    _mealOrderService.save(new MealOrder{MealId = item.Key, OrderId = orderId, Quantity = item.Value});
                    await _mealService.DecreaseQuantity(meal, item.Value);
                }    
            }
            await _unitOfWork.Save();
        }

    }
}
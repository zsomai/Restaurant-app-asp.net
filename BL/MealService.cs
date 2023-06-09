using tema2.DAO;
using tema2.Models;
namespace tema2.BL
{
    public class MealService : IMealService
    {
        private UnitOfWork _unitOfWork;

        public MealService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Meal> getAll()
        {
            return _unitOfWork.MealRepo.readAll();
        }

        public Meal getOne(int id)
        {
            return _unitOfWork.MealRepo.read(id);
        }

        public async Task update(Meal entity)
        {
            _unitOfWork.MealRepo.update(entity);
            await _unitOfWork.Save();

        }

        public async Task remove(Meal entity)
        {
            _unitOfWork.MealRepo.delete(entity);
            await _unitOfWork.Save();

        }

        public async Task save(Meal entity)
        {
            _unitOfWork.MealRepo.create(entity);
            await _unitOfWork.Save();

        }

        public async Task DecreaseQuantity(Meal entity, int quantity){
            entity.Stock -= quantity;
            await update(entity);
        }
        public async Task remove_by_id(int id){
            await remove(getOne(id));
        }
    }
}
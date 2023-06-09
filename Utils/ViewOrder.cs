using tema2.Models;
namespace tema2.Utils
{
    public class ViewOrder
    {
        public int Id {get; set;}
        public Status Status{get; set; }
        public DateTime Date{get; set; }
        public List<Tuple<Meal, int>> Meals {get; set; }
        private float calculatePrice(){
            float price = 0;
            foreach(var m in Meals){
                price += m.Item1.Price * m.Item2;
            }
            return price;
        }
        public decimal CalculatedPrice => (decimal)calculatePrice();

    }
}
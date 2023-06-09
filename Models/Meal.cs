
namespace tema2.Models
{
    public class Meal
    {
        private String _name;
        private float _price;
        private int _stock;
        private int _id;
        public Meal(string name, float price, int stock, int id)
        {
            _name = name;
            _price = price;
            _stock = stock;
            _id = id;
        }



        public Meal(string name, float price, int stock)
        {
            _name = name;
            _price = price;
            _stock = stock;
        }
        public Meal(string name, string price, string stock)
        {
            _name = name;
            _price = float.Parse(price);
            _stock = Int32.Parse(stock);
        }
        public Meal(string name, string price, string stock, string id)
        {
            _name = name;
            _price = float.Parse(price);
            _stock = Int32.Parse(stock);
            _id = Int32.Parse(id);
        }
        public Meal(){
            
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

   
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException(nameof(value));
        }


        public float Price
        {
            get => _price;
            set => _price = value;
        }

        public int Stock
        {
            get => _stock;
            set => _stock = value;
        }

        public override bool Equals(object? obj)
        {
            return obj is Meal meal &&
                   _name == meal._name &&
                   _price == meal._price &&
                   _stock == meal._stock &&
                   _id == meal._id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_name, _price, _stock, _id);
        }
    }
}

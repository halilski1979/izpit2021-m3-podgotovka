using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefsKingdom
{
    public class Chef
    {
        private string name;
        private string department;
        private List<Dish> dishes = new List<Dish>();
        private double price;
        bool isOnABreak;

        

        public Chef(string name, string department)
        {
            this.Name = name;
            this.Department = department;
            this.IsOnABreak = false;
           
        }

        public void AddDish(Dish dish)
        {
            dishes.Add(dish);
        }

        public bool RemoveDish(Dish dish)
        {
            return dishes.Remove(dish);
        }

        public bool RemoveAllByFoodGroup(string foodGroup)
        {
            var removedDishes = dishes.Where(x => x.FoodGroup == foodGroup).ToList();
            foreach (var dish in removedDishes)
            {
                if (dish.FoodGroup==foodGroup)
                {
                    dishes.Remove(dish);
                }
            }

            if (removedDishes.Count!=0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CountExpensiveDishesOfFoodGroup(string foodGroup, double priceLevel)
        {
            return dishes.Where(x => x.FoodGroup == foodGroup).Select(x => x.Price >= priceLevel).ToList().Count();
        }

        public void StartCooking()
        {
            this.IsOnABreak = false;

        }


        public Dish DeliverDish(string dishName)

        {
            foreach (var item in dishes)
            {
                if (item.Name==dishName)
                {
                    return item;
                }
               
            }
            return null;
        }

        public void GiveChefABreak()
        {
            this.IsOnABreak = true;

        }

        public bool IsChefAvailable()
        {
            if (isOnABreak)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length<=2)
                {
                    throw new ArgumentException("Invalid name");
                }
                name = value;
            }

        }
        public string Department { get => department; set => department = value; }
        public List<Dish> Dishes { get => dishes; set => dishes = value; }
        public double Price { get => price; set => price = value; }
        public bool IsOnABreak { get => isOnABreak; set => isOnABreak = value; }

        public override string ToString()
        {
            string chef = $"Chef {this.Name} from departnebt {this.Department.ToUpper()} is able to cook the following dishes: \n";
            List<string> iastia = new List<string>();

            foreach (var iastie in dishes)
            {
                string buffer = $"Dish: {iastie.Name} of type {iastie.FoodGroup}. Price {iastie.Price}";
                iastia.Add(buffer);
            }

            return chef+string.Join(" ",iastia);
        }
    }
}

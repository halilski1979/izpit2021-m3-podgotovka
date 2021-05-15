using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChefsKingdom
{
    public class Dish
    {
        private string name;
        private string foodGroup;
        private double price;

        public Dish(string name, string foodGroup, double price)
        {
            this.Name = name;
            this.FoodGroup = foodGroup;
            this.Price = price;
        }

        public string Name { get => name; set => name = value; }
        public string FoodGroup { get => foodGroup; set => foodGroup = value; }

        public double Price
        {
            get => price;
            set
            {
                if (value<=0)
                {
                    throw new ArgumentException("Invalid dish price!");
                }
                price = value;
            }
             
        }

        public override string ToString()
        {
            return $"Dish:{this.name} of type {this.foodGroup}. Price {this.price}";
        }


    }
}

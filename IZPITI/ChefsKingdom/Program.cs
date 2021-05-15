using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChefsKingdom
{
    class Program
    {
        static Dictionary<string, Dish> dishes = new Dictionary<string, Dish>();
        static Dictionary<string, Chef> chefs = new Dictionary<string, Chef>();


        static void Main(string[] args)
        {
            string command;


            while ((command = Console.ReadLine()) != "End")
            {


                var commandArgs = command.Split(' ').ToArray();


                switch (commandArgs[0])
                {
                    case "CreateDish":


                        CreateDish(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintDishInfoByName":


                        PrintDishInfoByName(commandArgs.Skip(1).ToArray());
                        break;
                    case "AddChef":


                        AddChef(commandArgs.Skip(1).ToArray());
                        break;
                    case "PrintChefInfoByName":


                        PrintChefInfoByName(commandArgs.Skip(1).ToArray());
                        break;
                    case "AddDishToSpecificChef":


                        AddDishToSpecificChef(commandArgs.Skip(1).ToArray());
                        break;
                    case "RemoveDishFromSpecificChef":


                        RemoveDishFromSpecificChef(commandArgs.Skip(1).ToArray());
                        break;
                    case "RemoveAllDishesByFoodGroupFromSpecificChef":


                       RemoveAllDishesByFoodGroupFromSpecificChef(commandArgs.Skip(1).ToArray());
                        break;
                    case "CountExpensiveDishesOfFoodGroupFromSpecificChef":


                        CountExpensiveDishesOfFoodGroupFromSpecificChef(commandArgs.Skip(1).ToArray());
                        break;
                    case "StartCookingChef":


                        StartCookingChef(commandArgs.Skip(1).ToArray());
                        break;




                    case "DeliverDish":


                        DeliverDish(commandArgs.Skip(1).ToArray());
                        break;
                    case "GiveChefABreak":


                       GiveChefABreak(commandArgs.Skip(1).ToArray());
                        break;
                    case "IsChefAvailable":


                       IsChefAvailable(commandArgs.Skip(1).ToArray());
                        break;


                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }
        }

        private static void CreateDish(string[] dishInfo)
        {
            string name = dishInfo[0];
            string foodGroup = dishInfo[1];
            double price = double.Parse(dishInfo[2]);

            if (dishes.ContainsKey(name))
            {
                Console.WriteLine("Cannot add dish. Already exist!");
                return;
            }

            try
            {
                Dish dish = new Dish(name,foodGroup,price);
                dishes.Add(name,dish);
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        private static void  PrintDishInfoByName(string [] dishInfo)
        {
            string dishName = dishInfo[0];
            if (!dishes.ContainsKey(dishName))
            {
                Console.WriteLine("Invalid dish");
                return;
            }

            Console.WriteLine(dishes[dishName].ToString());

        }

        private static void AddChef(string [] chefInfo)
        {
            string name = chefInfo[0];
            string department = chefInfo[1];
            if (chefs.ContainsKey(name))
            {
                Console.WriteLine("Cannot add shef");
                return;
            }
            try
            {
                Chef chef = new Chef(name,department);
                chefs.Add(name,chef);
            }
            catch (ArgumentException a)
            {

                Console.WriteLine(a.Message);
            }
        }

        private static void PrintChefInfoByName(string [] chefInfo)
        {
            string name = chefInfo[0];

            if (!chefs.ContainsKey(name))
            {
                Console.WriteLine("Invalid chef");
                return;
            }

            Console.WriteLine(chefs[name].ToString());
        }

        private static void AddDishToSpecificChef(string [] info)
        {
            string dishName = info[0];
            string chefName = info[1];

            if (!chefs.ContainsKey(chefName))
            {
                Console.WriteLine("Non existing chef");
                return;
            }
            if (!dishes.ContainsKey(dishName))
            {
                Console.WriteLine("Non existing dish");
                return;
            }

            Chef chef = chefs[chefName];
            Dish dish = dishes[dishName];
            chef.AddDish(dish);
        }

        private static void RemoveDishFromSpecificChef(string [] info)
        {
            string dishName = info[0];
            string chefName = info[1];
            if (!chefs.ContainsKey(chefName))
            {
                Console.WriteLine("Non existing chef");
                return;
            }
            if (!dishes.ContainsKey(dishName))
            {
                Console.WriteLine("Non existing dish");
                return;
            }

            Chef chef = chefs[chefName];
            Dish dish = dishes[dishName];

            bool removed = chef.RemoveDish(dish);
            if (removed)
            {
                Console.WriteLine($"Uspehno iztrivane na  {dish.Name} ot chef {chef.Name}");
            }
            else
            {
                Console.WriteLine("Ne moje da byde iztrito");
            }
        }


        private static void RemoveAllDishesByFoodGroupFromSpecificChef(string [] info)
        {

            string foodGroup = info[0];
            string chefName = info[1];
         
            if (!chefs.ContainsKey(chefName))
            {
                Console.WriteLine("Non existing chef");
                return;
            }

            Chef chef = chefs[chefName];
            bool removed = chef.RemoveAllByFoodGroup(foodGroup);

            if (removed)
            {
                Console.WriteLine($"Uspeshno iztrivane na grupata{foodGroup}  ot chef {chef.Name}");
            }
            else
            {
                Console.WriteLine("Deleted failed");
            }
        }

        private static void CountExpensiveDishesOfFoodGroupFromSpecificChef(string [] info)
        {
            string foodGroup = info[0];
            double priceLevel = double.Parse(info[1]);
            string chefName = info[2];

            if (!chefs.ContainsKey(chefName))
            {
                Console.WriteLine("Non exist chef");
                return;
            }

            Chef chef = chefs[chefName];
            int broy = chef.CountExpensiveDishesOfFoodGroup(foodGroup,priceLevel);

            Console.WriteLine(broy);
        }


       private static void StartCookingChef(string[] info)
        {
            string chefName = info[0];

            if (!chefs.ContainsKey(chefName))
            {
                Console.WriteLine("Non exist chef");
                return;
            }

            Chef chef = chefs[chefName];
            chef.StartCooking();

        }

        private static void DeliverDish(string[] info)
        {
            string dishName = info[0];
            string chefName = info[1];

            if (!chefs.ContainsKey(chefName))
            {
                Console.WriteLine("Non exist chef");
                return;
            }

            if (!dishes.ContainsKey(dishName))
            {
                Console.WriteLine("Non exist dish");
                return;
            }

            Chef chef = chefs[chefName];
            Dish cooked = chef.DeliverDish(dishName);

            if (cooked==null)
            {
                Console.WriteLine($"Chef {chef.Name} faailed to cook {dishName}");
            }
            else
            {
                Console.WriteLine($"Chef {chef.Name} successfull to cook {dishName}");
            }
        }
        

        public static void GiveChefABreak(string  [] info)
        {
            string chefName =info[0];
            if (!chefs.ContainsKey(chefName))
            {
                Console.WriteLine("Non exist chef");
                return;
            }

            Chef chef = chefs[chefName];
            chef.GiveChefABreak();

        }

        private static void IsChefAvailable(string [] info)
        {
            string chefName = info[0];

            if (!chefs.ContainsKey(chefName))
            {
                Console.WriteLine("Non exist chef");
                return;
            }

            Chef chef = chefs[chefName];
            bool isAvaliable = chef.IsChefAvailable();
            if (isAvaliable)
            {
                Console.WriteLine($"Chef {chef.Name} is avaliable");
            }
            else
            {
                Console.WriteLine($"Chef {chef.Name} is not avaliable");
            }
        }
    }
}


using System.Threading.Tasks;

namespace BlazingPizza.Data
{
    public class PizzaService
    {
        // Simulate async fetching from database
        public Task<Pizza[]> GetPizzasAsync()
        {
            Pizza[] pizzas = new Pizza[]
            {
                new Pizza { PizzaId = 1, Name = "Margherita", Description = "Classic with tomato and cheese", Price = 7.5m, Vegetarian = true, Vegan = false },
                new Pizza { PizzaId = 2, Name = "Pepperoni", Description = "Pepperoni and cheese", Price = 8.0m, Vegetarian = false, Vegan = false },
                new Pizza { PizzaId = 3, Name = "Vegan Delight", Description = "Veggies and vegan cheese", Price = 9.0m, Vegetarian = true, Vegan = true }
            };

            return Task.FromResult(pizzas);
        }
    }
}
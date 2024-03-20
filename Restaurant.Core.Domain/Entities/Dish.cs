using Restaurant.Core.Domain.Common;

namespace Restaurant.Core.Domain.Entities
{
    public class Dish : AuditableBaseEntity
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int People { get; set; }

        public int Category { get; set; }


        //navigation property
        public ICollection<Ingredient>? Ingredients { get; set; }
        public List<IngredientDish>? IngredientDishes { get; set; }

        public ICollection<Order>? Orders { get; set; }
        public List<OrderDish>? OrderDishes { get; set; }

    }
}

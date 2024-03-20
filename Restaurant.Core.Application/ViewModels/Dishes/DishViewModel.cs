using Restaurant.Core.Application.ViewModels.CommonViewModel;
using Restaurant.Core.Application.ViewModels.Ingredients;
using Restaurant.Core.Application.ViewModels.Orders;

namespace Restaurant.Core.Application.ViewModels.Dishes
{
    public class DishViewModel : AuditableBaseViewModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int People { get; set; }
        public int Category { get; set; }

        // Navegation Property
        public ICollection<IngredientViewModel> Ingredients { get; set; }
        public ICollection<OrderViewModel> Orders { get; set; }
    }
}

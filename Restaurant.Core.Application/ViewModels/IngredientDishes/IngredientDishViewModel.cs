using Restaurant.Core.Application.ViewModels.CommonViewModel;

namespace Restaurant.Core.Application.ViewModels.IngredientDishes
{
    public class IngredientDishViewModel : AuditableBaseViewModel
    {
        public int IngredientId { get; set; }
        public int DishId { get; set; }
    }
}

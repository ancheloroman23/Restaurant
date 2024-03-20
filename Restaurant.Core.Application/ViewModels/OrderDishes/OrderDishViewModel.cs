using Restaurant.Core.Application.ViewModels.CommonViewModel;

namespace Restaurant.Core.Application.ViewModels.OrderDishes
{
    public class OrderDishViewModel : AuditableBaseViewModel
    {
        public int DishId { get; set; }
        public int OrderId { get; set; }
    }
}

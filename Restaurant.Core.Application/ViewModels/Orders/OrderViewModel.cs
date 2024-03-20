using Restaurant.Core.Application.ViewModels.CommonViewModel;
using Restaurant.Core.Application.ViewModels.Dishes;
using Restaurant.Core.Application.ViewModels.Tables;

namespace Restaurant.Core.Application.ViewModels.Orders
{
    public class OrderViewModel : AuditableBaseViewModel
    {
        public int TableId { get; set; }
        public double TotalPrice { get; set; }
        public int Status { get; set; }

        //Navegation Property
        public ICollection<DishViewModel> Dishes { get; set; }
        public TableViewModel Table { get; set; }
    }
}

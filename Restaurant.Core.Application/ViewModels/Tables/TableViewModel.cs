using Restaurant.Core.Application.ViewModels.CommonViewModel;
using Restaurant.Core.Application.ViewModels.Orders;

namespace Restaurant.Core.Application.ViewModels.Tables
{
    public class TableViewModel : AuditableBaseViewModel
    {
        public int CapacityTable { get; set; }

        public string Description { get; set; }

        public int Status { get; set; }


        //Navegation Property
        public ICollection<OrderViewModel> Orders { get; set; }
    }
}

using Restaurant.Core.Application.ViewModels.CommonViewModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Core.Application.ViewModels.Orders
{
    public class SaveOrderViewModel : AuditableBaseViewModel
    {
        public override int Id { get; set; }

        public double SubTotal { get; set; }
        public int Status { get; set; }


        [Required(ErrorMessage = "Colocar el Id de la mesa donde esta la orden")]
        [DataType(DataType.Text)]
        public int TableId { get; set; }

        public List<int> Dishes { get; set; }
    }
}

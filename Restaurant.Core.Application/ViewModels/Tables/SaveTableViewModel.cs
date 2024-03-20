using Restaurant.Core.Application.ViewModels.CommonViewModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Core.Application.ViewModels.Tables
{
    public class SaveTableViewModel : AuditableBaseViewModel
    {
        public override int Id { get; set; }

        [Required(ErrorMessage = "Colocar la cantidad maxima de personas que quieren la mesa")]
        [DataType(DataType.Text)]
        public int CapacityTable { get; set; }

        [Required(ErrorMessage = "Colocar una descripcion a la mesa")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        public int Status { get; set; }
    }
}

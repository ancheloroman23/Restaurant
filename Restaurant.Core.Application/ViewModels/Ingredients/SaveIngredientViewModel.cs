using Restaurant.Core.Application.ViewModels.CommonViewModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Core.Application.ViewModels.Ingredients
{
    public class SaveIngredientViewModel : AuditableBaseViewModel
    {
        public override int Id { get; set; }

        [Required(ErrorMessage = "Colocar el nombre del ingrediente")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}

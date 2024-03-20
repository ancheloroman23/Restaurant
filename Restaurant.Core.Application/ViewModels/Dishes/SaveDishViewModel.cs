using Restaurant.Core.Application.ViewModels.CommonViewModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Core.Application.ViewModels.Dishes
{
    public class SaveDishViewModel : AuditableBaseViewModel
    {
        public override int Id { get; set; }

        [Required(ErrorMessage = "Colocar un nombre")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Colocar un precio")]
        [DataType(DataType.Text)]
        public double Price { get; set; }

        [Required(ErrorMessage = "Colocar cantidad de personas maxima")]
        [DataType(DataType.Text)]
        public int People { get; set; }

        [Required(ErrorMessage = "Colocar una categoria")]
        [DataType(DataType.Text)]
        public int Category { get; set; }
        public List<int> Ingredients { get; set; }
    }
}

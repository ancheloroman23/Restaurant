using Restaurant.Core.Application.ViewModels.CommonViewModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Core.Application.ViewModels.User
{
    public class SaveUserViewModel : AuditableBaseViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Colocar un nombre")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Colocar un apellido")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Colocar un nombre de Usuario")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Colocar un Email")]
        [DataType(DataType.Text)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Colocar una Clave")]
        [DataType(DataType.Text)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Colocar una Clave")]
        [Compare(nameof(Password), ErrorMessage = "La Clave no coinciden")]
        public string ConfirmPassword { get; set; }
    }
}

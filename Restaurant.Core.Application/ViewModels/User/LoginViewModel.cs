using Restaurant.Core.Application.ViewModels.CommonViewModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Core.Application.ViewModels.User
{
    public class LoginViewModel : AuditableBaseViewModel
    {
        [Required(ErrorMessage = "Colocar el nombre de Usuario")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Colocar el nombre de Clave")]
        [DataType(DataType.Text)]
        public string Password { get; set; }
    }
}

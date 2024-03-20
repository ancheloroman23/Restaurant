using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.ViewModels.User;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginViewModel login);
        Task<RegisterResponse> AddAdmin(SaveUserViewModel saveViewModel);
        Task<RegisterResponse> AddWaiter(SaveUserViewModel saveViewModel);        
    }
}

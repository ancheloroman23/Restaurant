using Restaurant.Core.Application.Dtos.Account;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<RegisterResponse> RegisterAdminAsync(RegisterRequest request);
        Task<RegisterResponse> RegisterWaiterAsync(RegisterRequest request);
    }
}

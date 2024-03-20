using AutoMapper;
using Restaurant.Core.Application.Dtos.Account;
using Restaurant.Core.Application.Interfaces.Services;
using Restaurant.Core.Application.ViewModels.User;

namespace Restaurant.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public UserService(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<RegisterResponse> AddAdmin(SaveUserViewModel saveViewModel)
        {
            RegisterRequest request = _mapper.Map<RegisterRequest>(saveViewModel);
            RegisterResponse response = await _accountService.RegisterAdminAsync(request);
            return response;
        }

        public async Task<RegisterResponse> AddWaiter(SaveUserViewModel saveViewModel)
        {
            RegisterRequest request = _mapper.Map<RegisterRequest>(saveViewModel);
            RegisterResponse response = await _accountService.RegisterWaiterAsync(request);
            return response;
        }

        public async Task<LoginResponse> Login(LoginViewModel login)
        {
            LoginRequest request = _mapper.Map<LoginRequest>(login);
            LoginResponse response = await _accountService.LoginAsync(request);
            return response;
        }
    }
}

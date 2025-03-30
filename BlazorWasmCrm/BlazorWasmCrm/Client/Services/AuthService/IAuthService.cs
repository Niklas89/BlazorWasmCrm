using BlazorWasmCrm.Shared;

namespace BlazorWasmCrm.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
    }
}

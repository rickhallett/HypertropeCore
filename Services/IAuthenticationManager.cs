using System.Threading.Tasks;
using HypertropeCore.DataTransferObjects;

namespace HypertropeCore.Services
{
    public interface IAuthenticationManager
    {
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);

        Task<string> CreateToken();
    }
}
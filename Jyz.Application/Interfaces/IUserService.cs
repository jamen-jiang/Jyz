using Jyz.Application.Dtos;
using System.Threading.Tasks;

namespace Jyz.Application.Interfaces
{
    public  interface IUserService
    {
        Task<LoginResDto> Login(LoginReqDto info);
    }
}

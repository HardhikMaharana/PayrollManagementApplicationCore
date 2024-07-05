using SharedClassLib.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SharedClassLib.DTO.ServiceResponses;

namespace SharedClassLib.Contracts
{
    internal interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount(LoginDto loginDto);
        Task<LoginResponse> LogInAccountUser(UserDto userDto);
    }
}

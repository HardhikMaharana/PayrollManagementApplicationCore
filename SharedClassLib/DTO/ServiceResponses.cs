using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedClassLib.DTO
{
    public class ServiceResponses
    {
        public record class GeneralResponse (bool flag,string message);
        public record class LoginResponse (bool flag,string token,string message);
    }
}

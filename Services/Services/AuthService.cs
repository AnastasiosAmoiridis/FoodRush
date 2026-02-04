using Microsoft.Extensions.Configuration;
using Services.Interfaces;

namespace Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration; 

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }      
    }
}

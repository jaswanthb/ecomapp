using eCommerce.App.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private AuthService _authService;
        public LoginController(AuthService authService)
        {
            _authService = authService;
        }
        [HttpGet("login")]
        public string Login(string userName, string password)
        {
            var tkn = _authService.Create(userName, password);

            return tkn;
        }

    }
}

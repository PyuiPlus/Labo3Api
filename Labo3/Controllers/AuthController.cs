using BLL.Iterfaces;
using BLL.Models.Forms;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace APILabo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService _jwtService;

        public AuthController(IAuthService authService, IJwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginForm form)
        {

            Users? user = _authService.Login(form);

            if (user is null)
            {
                return BadRequest();
            }

            return Ok(_jwtService.CreateToken(user));
        }
    }
}

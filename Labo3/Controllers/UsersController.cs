using BLL.Iterfaces;
using BLL.Models.DTO;
using BLL.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILabo3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<UsersDTO> GetById(int id) 
        {
            UsersDTO user = _usersService.GetById(id);

            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public ActionResult<UsersDTO> Create(RegisterForm form)
        {
            UsersDTO users = _usersService.Create(form);

            return users == null ? BadRequest() : Ok(users);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            bool result = _usersService.Delete(id);

            return result ? NoContent() : BadRequest();
        }

    }
}

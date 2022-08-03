using CCSA_Web.DTO;

using CCSANoteApp.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCSA_Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public IUserService UserService { get; }
        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(string username, string email, string password)
        {
            UserService.CreateUser(username,  email, password);
            return Ok("User Created Successfully");
        }
        [HttpPost("byUser")]
        public IActionResult CreateUser([FromBody] UserDTO userDTO)
        {
            UserService.CreateUser(userDTO.Username,userDTO.Email,userDTO.Password);
            return Ok("User Created Successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            UserService.DeleteUser(id);
            return Ok("User Deleted Successfully");
        }
        [HttpGet("user/{id}")]
        public IActionResult GetUser(Guid id)
        {
            return Ok(UserService.GetUser(id));
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(UserService.GetUsers());
        }
        [HttpPut("updateemail")]
        public IActionResult UpdateEmail(Guid id, string email)
        {
            UserService.UpdateEmail(id, email);
            return Ok("Updated Successfully");
        }
        [HttpPut("updatename")]
        public IActionResult UpdateName(Guid id, string name)
        {
            UserService.UpdateName(id, name);
            return Ok("Updated Successfully");
        }
    }
}

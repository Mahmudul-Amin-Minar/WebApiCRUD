using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Contract;

namespace WebApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        //Get all users
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAllRecords()
        {
            var response = _user.GetAllRepo();
            return Ok(response);
        }

        //Get signle user
        [HttpGet]
        [Route("get")]
        public IActionResult GetSingleRecord(int id)
        {
            return Ok(_user.GetSingleRepo(id));
        }

        //Add user
        [HttpPost("add")]
        public IActionResult AddUser(User user)
        {
            return Ok(_user.AddUserRepo(user));
        }

        //Remove User
        [HttpDelete]
        public IActionResult RemoveUser(int id)
        {
            return Ok(_user.RemoveUser(id));
        }

        //Update User
        [HttpPut("update")]
        public IActionResult UpdateUser(User user)
        {
            return Ok(_user.UpdateUserRepo(user));
        }
    }
}

using LibraryBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("getUsers")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IEnumerable<UserModel>>> getUsers()
        {
            var listUsers = UserConstants.Users.Where(x => x.Role == "User") .ToList();
            return Ok(listUsers);
        }

    }


}

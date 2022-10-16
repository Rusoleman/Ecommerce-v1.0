using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.db;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Lastname { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
        }

        [HttpGet(Name = "get_users")]
        public List<User> GetUsers()
        {
            return ADO_Users.ReturnUsers();
        }
    }

}

using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.CrossCutting.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServiceApp _userServiceApp;

        public UserController(IUserServiceApp userServiceApp)
        {
            _userServiceApp = userServiceApp;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SelectAsync(int id)
        {
            return Ok(await _userServiceApp.SelectAsync(id));
        }

        [HttpGet("name/{name}")]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserByName(string name)
        {
            name = WebUtility.UrlDecode(name);
            return Ok(await _userServiceApp.GetUserByName(name));
        }

        [HttpGet("email/{email}")]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            return Ok(await _userServiceApp.GetUserByEmail(email));
        }
        [HttpPost]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertAsync([FromServices] IHttpContextAccessor context, [FromBody] UserPayloadViewModel payload)
        {
            return Created(context.HttpContext.Request.Path, await _userServiceApp.InsertAsync(payload));
        }

        [HttpPut]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] UserViewModel payload)
        {
            return Ok(await _userServiceApp.UpdateAsync(payload));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _userServiceApp.DeleteAsync(id));
        }
    }
}

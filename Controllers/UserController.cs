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
        public async Task<UserViewModel> SelectAsync(int id)
        {
            return await _userServiceApp.SelectAsync(id);
        }

        [HttpGet("name/{name}")]

        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<UserViewModel> GetByName(string name)
        {
            name = WebUtility.UrlDecode(name);
            return await _userServiceApp.GetByName(name);
        }

        [HttpPost]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertAsync([FromServices] IHttpContextAccessor context, [FromBody] UserPayloadViewModel payload)
        {
            return Created(context.HttpContext.Request.Path, await _userServiceApp.InsertAsync(payload));
        }

        [HttpPut]

        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<UserViewModel> UpdateAsync([FromBody] UserViewModel payload)
        {
            return await _userServiceApp.UpdateAsync(payload);
        }

        [HttpDelete("{id}")]

        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<bool> DeleteAsync(long id)
        {
            return await _userServiceApp.DeleteAsync(id);

        }
    }
}

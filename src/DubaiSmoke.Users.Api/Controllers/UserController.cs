using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.ViewModels;
using ErrorHandler.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using ValidatorsHelper.Validators;
using static ErrorHandler.Models.ErrorHandlerNotification;

namespace DubaiSmoke.Users.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserServiceApp _userServiceApp;

        public UserController(IUserServiceApp userServiceApp, ErrorHandlerNotification notifications) : base(notifications)
        {
            _userServiceApp = userServiceApp;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SelectAsync(int id)
        {
            return Response(await _userServiceApp.SelectAsync(id));
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginPayloadViewModel payload)
        {
            return Response(await _userServiceApp.LoginAsync(payload));
        }


        [HttpPost("register")]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertAsync([FromBody] UserPayloadViewModel payload)
        {
            return Response(await _userServiceApp.InsertAsync(payload));
        }

        [HttpPut("update")]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] UserViewModel payload)
        {
            return Response(await _userServiceApp.UpdateAsync(payload));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Response(await _userServiceApp.DeleteAsync(id));
        }
    }
}

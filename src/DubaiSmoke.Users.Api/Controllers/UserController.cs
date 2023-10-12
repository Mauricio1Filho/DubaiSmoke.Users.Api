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
        private readonly IUserServiceApp _serviceApp;

        public UserController(IUserServiceApp serviceApp, ErrorHandlerNotification notifications) : base(notifications) => _serviceApp = serviceApp;

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SelectAsync([FromRoute] int id) => Response(await _serviceApp.SelectAsync(id));

        [HttpPost("login")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Login([FromBody] LoginPayloadViewModel payload) => Response(await _serviceApp.LoginAsync(payload));


        [HttpPost]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> InsertAsync([FromBody] UserPayloadViewModel payload) => Response(await _serviceApp.InsertAsync(payload));

        [HttpPut]
        [ProducesResponseType(typeof(UserViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> UpdateAsync([FromBody] UserViewModel payload) => Response(await _serviceApp.UpdateAsync(payload));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id) => Response(await _serviceApp.DeleteAsync(id));
    }
}

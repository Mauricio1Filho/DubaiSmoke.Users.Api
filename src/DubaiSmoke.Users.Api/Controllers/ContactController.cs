using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.ViewModels;
using ErrorHandler.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ValidatorsHelper.Validators;
using static ErrorHandler.Models.ErrorHandlerNotification;

namespace DubaiSmoke.Users.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : BaseController
    {
        private readonly IContactServiceApp _serviceApp;

        public ContactController(IContactServiceApp serviceApp, ErrorHandlerNotification notifications) : base(notifications) => _serviceApp = serviceApp;

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContactViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SelectAsync([FromRoute] long id) => Response(await _serviceApp.SelectAsync(id));

        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(List<ContactViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SelectByUserIdAsync([FromRoute] long userId) => Response(await _serviceApp.SelectByUserIdAsync(userId));

        [HttpPost("register")]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> InsertAsync([FromBody] ContactPayloadViewModel payload) => Response(await _serviceApp.InsertAsync(payload));

        [HttpPut("update")]
        [ProducesResponseType(typeof(ContactViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> UpdateAsync([FromBody] ContactPayloadViewModel payload) => Response(await _serviceApp.UpdateAsync(payload));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id) => Response(await _serviceApp.DeleteAsync(id));
    }
}

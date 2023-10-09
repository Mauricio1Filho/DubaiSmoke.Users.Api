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
    public class ContactTypeController : BaseController
    {
        private readonly IContactTypeServiceApp _serviceApp;

        public ContactTypeController(IContactTypeServiceApp serviceApp, ErrorHandlerNotification notifications) : base(notifications) => _serviceApp = serviceApp;

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContactTypeViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SelectAsync([FromRoute] int id) => Response(await _serviceApp.SelectAsync(id));

        [HttpPost("register")]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> InsertAsync([FromBody] ContactTypePayloadViewModel payload) => Response(await _serviceApp.InsertAsync(payload));

        [HttpPut("update")]
        [ProducesResponseType(typeof(ContactTypeViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> UpdateAsync([FromBody] ContactTypeViewModel payload) => Response(await _serviceApp.UpdateAsync(payload));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id) => Response(await _serviceApp.DeleteAsync(id));
    }
}


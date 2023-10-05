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
        private readonly IContactServiceApp _contactServiceApp;

        public ContactController(IContactServiceApp contactServiceApp, ErrorHandlerNotification notifications) : base(notifications)
        {
            _contactServiceApp = contactServiceApp;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContactViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SelectAsync(long id)
        {
            return Response(await _contactServiceApp.SelectAsync(id));
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(List<ContactViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SelectByUserIdAsync(long userId)
        {
            return Response(await _contactServiceApp.SelectByUserIdAsync(userId));
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertAsync([FromBody] ContactPayloadViewModel payload)
        {
            return Response(await _contactServiceApp.InsertAsync(payload));
        }

        [HttpPut("update")]
        [ProducesResponseType(typeof(ContactViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] ContactPayloadViewModel payload)
        {
            return Response(await _contactServiceApp.UpdateAsync(payload));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Response(await _contactServiceApp.DeleteAsync(id));
        }
    }
}

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
        private readonly IContactTypeServiceApp _contactTypeServiceApp;
        public ContactTypeController(IContactTypeServiceApp contactTypeServiceApp, ErrorHandlerNotification notifications) : base(notifications)
        {
            _contactTypeServiceApp = contactTypeServiceApp;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContactTypeViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SelectAsync(int id)
        {
            return Response(await _contactTypeServiceApp.SelectAsync(id));
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertAsync([FromBody] ContactTypePayloadViewModel payload)
        {
            return Response(await _contactTypeServiceApp.InsertAsync(payload));
        }

        [HttpPut("update")]
        [ProducesResponseType(typeof(ContactTypeViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] ContactTypeViewModel payload)
        {
            return Response(await _contactTypeServiceApp.UpdateAsync(payload));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Response(await _contactTypeServiceApp.DeleteAsync(id));
        }
    }
}


using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.CrossCutting.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactServiceApp _contactServiceApp;

        public ContactController(IContactServiceApp contactServiceApp)
        {
            _contactServiceApp = contactServiceApp;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ContactViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SelectAsync(long id)
        {
            return Ok(await _contactServiceApp.SelectAsync(id));
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(List<ContactViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SelectByUserIdAsync(long userId)
        {
            return Ok(await _contactServiceApp.SelectByUserIdAsync(userId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertAsync([FromServices] IHttpContextAccessor context, [FromBody] ContactPayloadViewModel payload)
        {
            return Created(context.HttpContext.Request.Path, await _contactServiceApp.InsertAsync(payload));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ContactViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] ContactPayloadViewModel payload)
        {
            return Ok(await _contactServiceApp.UpdateAsync(payload));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _contactServiceApp.DeleteAsync(id));
        }
    }
}

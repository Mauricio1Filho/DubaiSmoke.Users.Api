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
    public class ContactTypeController : ControllerBase
    {
        private readonly IContactTypeServiceApp _contactTypeServiceApp;
        public ContactTypeController(IContactTypeServiceApp contactTypeServiceApp)
        {
            _contactTypeServiceApp = contactTypeServiceApp;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SelectAsync(int id)
        {
            return Ok(await _contactTypeServiceApp.SelectAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertAsync([FromServices] IHttpContextAccessor context,[FromBody] ContactTypePayloadViewModel payload)
        {
            return Created(context.HttpContext.Request.Path, await _contactTypeServiceApp.InsertAsync(payload));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ContactTypeViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] ContactTypeViewModel payload)
        {
            return Ok(await _contactTypeServiceApp.UpdateAsync(payload));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _contactTypeServiceApp.DeleteAsync(id));
        }
    }
}


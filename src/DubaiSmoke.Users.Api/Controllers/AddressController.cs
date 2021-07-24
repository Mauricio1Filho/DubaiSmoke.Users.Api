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
    public class AddressController : ControllerBase
    {
        private readonly IAddressServiceApp _addressServiceApp;

        public AddressController(IAddressServiceApp addressServiceApp)
        {
            _addressServiceApp = addressServiceApp;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SelectAsync(int id)
        {
            return Ok(await _addressServiceApp.SelectAsync(id));
        }

        [HttpGet("User/{userId}")]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAddressByUserId(int userId)
        {
            return Ok(await _addressServiceApp.GetAddressByUserId(userId));
        }

        [HttpPost]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertAsync([FromServices] IHttpContextAccessor context, [FromBody] AddressPayloadViewModel payload)
        {
            return Created(context.HttpContext.Request.Path, await _addressServiceApp.InsertAsync(payload));
        }

        [HttpPut]
        [ProducesResponseType(typeof(AddressViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] AddressPayloadViewModel payload)
        {
            return Ok(await _addressServiceApp.UpdateAsync(payload));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(await _addressServiceApp.DeleteAsync(id));
        }
    }
}

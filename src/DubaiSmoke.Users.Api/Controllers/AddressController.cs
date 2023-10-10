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
    public class AddressController : BaseController
    {
        private readonly IAddressServiceApp _serviceApp;

        public AddressController(IAddressServiceApp serviceApp, ErrorHandlerNotification notifications) : base(notifications) => _serviceApp = serviceApp;

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AddressViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> SelectAsync([FromRoute] int id) => Response(await _serviceApp.SelectAsync(id));

        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(List<AddressViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAddressByUserId([FromRoute] int userId) => Response(await _serviceApp.GetAddressByUserId(userId));

        [HttpPost]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> InsertAsync([FromBody] AddressPayloadViewModel payload) => Response(await _serviceApp.InsertAsync(payload));

        [HttpPut]
        [ProducesResponseType(typeof(AddressViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.UnprocessableEntity)]
        public async Task<IActionResult> UpdateAsync([FromBody] AddressPayloadViewModel payload) => Response(await _serviceApp.UpdateAsync(payload));

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id) => Response(await _serviceApp.DeleteAsync(id));
    }
}

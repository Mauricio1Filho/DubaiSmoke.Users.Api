using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.ViewModels;
using ErrorHandler.Models;
using Microsoft.AspNetCore.Http;
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
        private readonly IAddressServiceApp _addressServiceApp;

        public AddressController(IAddressServiceApp addressServiceApp, ErrorHandlerNotification notifications) : base(notifications)
        {
            _addressServiceApp = addressServiceApp;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AddressViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> SelectAsync(int id)
        {
            return Response(await _addressServiceApp.SelectAsync(id));
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(List<AddressViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAddressByUserId(int userId)
        {
            return Response(await _addressServiceApp.GetAddressByUserId(userId));
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertAsync([FromBody] AddressPayloadViewModel payload)
        {
            return Response(await _addressServiceApp.InsertAsync(payload));
        }

        [HttpPut("update")]
        [ProducesResponseType(typeof(AddressViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] AddressPayloadViewModel payload)
        {
            return Response(await _addressServiceApp.UpdateAsync(payload));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ClientError), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Response(await _addressServiceApp.DeleteAsync(id));
        }
    }
}

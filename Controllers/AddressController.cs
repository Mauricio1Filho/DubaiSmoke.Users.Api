using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.CrossCutting.DTO;
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
        public async Task<AddressViewModel> SelectAsync(int id)
        {
            return await _addressServiceApp.SelectAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<long> InsertAsync([FromBody] AddressViewModel payload)
        {
            return await _addressServiceApp.InsertAsync(payload);
        }

        [HttpPut]

        public async Task<AddressViewModel> UpdateAsync([FromBody] AddressViewModel payload)
        {
            return await _addressServiceApp.UpdateAsync(payload);
        }

        [HttpDelete("{id}")]

        public async Task<bool> DeleteAsync(long id)
        {
            return await _addressServiceApp.DeleteAsync(id);

        }
    }
}

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
    public class ContactController : ControllerBase
    {
        private readonly IContactServiceApp _contactServiceApp;

        public ContactController(IContactServiceApp contactServiceApp)
        {
            _contactServiceApp = contactServiceApp;
        }

        [HttpGet("{id}")]
        public async Task<ContactViewModel> SelectAsync(long id)
        {
            return await _contactServiceApp.SelectAsync(id);
        }

        [HttpGet("user/{userId}")]
        public async Task<ContactViewModel> SelectByUserIdAsync(long userId)
        {
            return await _contactServiceApp.SelectByUserIdAsync(userId);
        }


        [HttpPost]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<long> InsertAsync([FromBody] ContactViewModel payload)
        {
            return await _contactServiceApp.InsertAsync(payload);
        }

        [HttpPut]

        public async Task<ContactViewModel> UpdateAsync([FromBody] ContactViewModel payload)
        {
            return await _contactServiceApp.UpdateAsync(payload);
        }

        [HttpDelete("{id}")]

        public async Task<bool> DeleteAsync(long id)
        {
            return await _contactServiceApp.DeleteAsync(id);

        }
    }
}

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
    public class ContactTypeController : ControllerBase
    {
        private readonly IContactTypeServiceApp _contactTypeServiceApp;

        public ContactTypeController(IContactTypeServiceApp contactTypeServiceApp)
        {
            _contactTypeServiceApp = contactTypeServiceApp;
        }

        [HttpGet("{id}")]
        public async Task<ContactTypeViewModel> SelectAsync(int id)
        {
            return await _contactTypeServiceApp.SelectAsync(id);
        }

        [HttpPost]
        [ProducesResponseType(typeof(long), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(BadRequestResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<long> InsertAsync([FromBody] ContactTypeViewModel payload)
        {
            return await _contactTypeServiceApp.InsertAsync(payload);
        }

        [HttpPut]

        public async Task<ContactTypeViewModel> UpdateAsync([FromBody] ContactTypeViewModel payload)
        {
            return await _contactTypeServiceApp.UpdateAsync(payload);
        }

        [HttpDelete("{id}")]

        public async Task<bool> DeleteAsync(long id)
        {
            return await _contactTypeServiceApp.DeleteAsync(id);

        }
    }
}


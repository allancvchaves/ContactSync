using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MockAPI.Dtos;

namespace MockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMailChimpService _mailChimpService;
        private readonly IMockAPIService _mockAPIService;

        public ContactsController(IMailChimpService mailChimpService, IMockAPIService mockAPIService)
        {
            _mailChimpService = mailChimpService;
            _mockAPIService = mockAPIService;
        }

        [HttpGet("sync")]
        public async Task<SyncContactsDto> SyncContacts()
        {
            var contactsToAdd = await _mockAPIService.GetMockContacts();

            var addedContacts = await _mailChimpService.SyncToMailChimp(contactsToAdd);

            return new SyncContactsDto(addedContacts); ;
        }

    }
}

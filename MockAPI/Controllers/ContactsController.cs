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

        public ContactsController(IMailChimpService mailChimpService)
        {
            _mailChimpService = mailChimpService;
        }

        [HttpGet("sync")]
        public async Task<SyncContactsDto> SyncContacts()
        {
            var (contactList, syncCount) = await _mailChimpService.SyncToMailChimp();
            var dto = new SyncContactsDto(contactList) { SyncedContacts = syncCount };
            return dto;
        }

        [HttpGet("clear")]
        public async Task ClearList()
        {
            await _mailChimpService.RemoveAllMembers();
        }

    }
}

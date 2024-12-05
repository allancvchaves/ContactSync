using Application.Entities;

namespace MockAPI.Dtos
{
    public class SyncContactsDto(List<Contact> contacts)
    {
        public List<ContactDto> Contacts { get; set; } = contacts.ConvertAll(c => new ContactDto(c));
        public int SyncedContacts { get; set; }
    }

    public class ContactDto(Contact contact)
    {
        public string FirstName { get; set; } = contact.FirstName;
        public string LastName { get; set; } = contact.LastName;
        public string Email { get; set; } = contact.Email;
    }
}

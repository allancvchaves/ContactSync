using Application.Entities;

namespace API.Dtos
{
    public class SyncContactsDto
    {
        public int SyncedContacts { get; set; }
        public List<ContactDto> Contacts { get; set; }
        public SyncContactsDto(List<Contact> contacts)
        {
            Contacts = contacts.ConvertAll(c => new ContactDto(c));
            SyncedContacts = contacts.Count;
        }
    }

    public class ContactDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ContactDto()
        {

        }

        public ContactDto(Contact contact)
        {
            FirstName = contact.FirstName;
            LastName = contact.LastName;
            Email = contact.Email;
        }
    }
}

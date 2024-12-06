using Application.Entities;

namespace MockAPI.Dtos
{
    public class SyncContactsDto
    {
        public List<ContactDto> Contacts { get; set; }
        public int SyncedContacts { get; set; }


        public SyncContactsDto(List<Contact> contacts)
        {
            Contacts = contacts.ConvertAll(c => new ContactDto(c));
        }
    }

    public class ContactDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ContactDto(Contact contact)
        {
            FirstName = contact.FirstName;
            LastName = contact.LastName;
            Email = contact.Email;
        }
    }
}

using Application.Entities;

namespace Application.Interfaces
{
    public interface IMockAPIService
    {
        public Task<List<Contact>> GetMockContacts();
    }
}

namespace Application.Interfaces
{
    public interface IMailChimpService
    {
        public Task<(List<Entities.Contact> Contacts, int SyncCount)> SyncToMailChimp();
        public Task RemoveAllMembers();
    }
}

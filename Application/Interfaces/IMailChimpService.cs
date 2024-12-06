namespace Application.Interfaces
{
    public interface IMailChimpService
    {
        public Task<List<Entities.Contact>> SyncToMailChimp(List<Entities.Contact> contacts);
    }
}

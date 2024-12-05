using Application.Interfaces;
using MailChimp.Net;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using Microsoft.Extensions.Configuration;

namespace Application.Services
{
    public class MailChimpService : IMailChimpService
    {
        private readonly IMailChimpManager _mailChimpManager;

        public MailChimpService(IConfiguration configuration)
        {
            var apiKey = configuration["MailChimpApiKey"]
                ?? throw new InvalidOperationException("Mailchimp API Key is missing in appsettings.json");
            _mailChimpManager = new MailChimpManager(apiKey);
        }

        public async Task<(List<Entities.Contact> Contacts, int SyncCount)> SyncToMailChimp()
        {
            // Get or create the list
            var list = (await _mailChimpManager.Lists.GetAllAsync()).FirstOrDefault() ?? await CreateList();

            // Generate and synchronize contacts
            var contacts = Entities.Contact.GenerateContactList();
            var syncCount = await AddListMembers(contacts, list.Id);

            return (contacts, syncCount);
        }

        public async Task RemoveAllMembers()
        {
            try
            {
                var listCollection = await _mailChimpManager.Lists.GetAllAsync();
                var defaultList = listCollection.FirstOrDefault()
                    ?? throw new Exception("No list was found in this account.");

                var membersToDelete = await _mailChimpManager.Members.GetAllAsync(defaultList.Id);
                var apiMembers = membersToDelete
                    .Where(m => m.Source?.Equals("API - Generic", StringComparison.OrdinalIgnoreCase) == true)
                    .ToList();

                if (apiMembers.Count == 0)
                    return;

                foreach (var member in apiMembers)
                {
                    await _mailChimpManager.Members.DeleteAsync(defaultList.Id, member.EmailAddress);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while deleting members.", ex);
            }
        }

        private async Task<int> AddListMembers(List<Entities.Contact> contacts, string listId)
        {
            var existingEmails = (await _mailChimpManager.Members.GetAllAsync(listId))
                .Select(m => m.EmailAddress)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            var newMembers = contacts
                .Where(contact => !existingEmails.Contains(contact.Email))
                .Select(contact => new Member
                {
                    EmailAddress = contact.Email,
                    StatusIfNew = Status.Subscribed,
                    MergeFields = new Dictionary<string, object>
                    {
                        { "FNAME", contact.FirstName },
                        { "LNAME", contact.LastName }
                    }
                })
                .ToList();

            int syncCount = 0;

            foreach (var member in newMembers)
            {
                try
                {
                    await _mailChimpManager.Members.AddOrUpdateAsync(listId, member);
                    syncCount++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding member {member.EmailAddress}: {ex.Message}");
                }
            }

            return syncCount;
        }

        //My Mailchimp account doesn't support more than one list
        //but I made this method to add a new one if the default one was deleted.
        private async Task<List> CreateList()
        {
            var list = new List
            {
                Name = "Allan Chaves",
                PermissionReminder = "Reminder",
                EmailTypeOption = false,
                Contact = new MailChimp.Net.Models.Contact
                {
                    Company = "Zion",
                    City = "Paranagua",
                    Country = "Brazil",
                    Address1 = "191 Rio de Janeiro Street"
                },
                CampaignDefaults = new CampaignDefaults
                {
                    FromEmail = "allancvchaves@gmail.com",
                    FromName = "Allan Chaves",
                    Subject = "Test subject",
                    Language = "English"
                }
            };

            var createdList = await _mailChimpManager.Lists.AddOrUpdateAsync(list);

            return createdList;
        }

    }
}

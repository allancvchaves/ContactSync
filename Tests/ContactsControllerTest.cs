using Application.Entities;
using Application.Interfaces;
using MockAPI.Controllers;
using MockAPI.Dtos;
using Moq;

namespace Tests
{
    public class ContactsControllerTest
    {
        private Mock<IMockAPIService> _mockAPIService;
        private Mock<IMailChimpService> _mailChimpService;
        private ContactsController _controller;

        [SetUp]
        public void SetUp()
        {
            _mockAPIService = new Mock<IMockAPIService>();
            _mailChimpService = new Mock<IMailChimpService>();
            _controller = new ContactsController(_mailChimpService.Object, _mockAPIService.Object);
        }

        [Test]
        public async Task SyncContacts_ReturnsSyncContactsDto()
        {
            // Arrange
            var mockContacts = new List<Contact>
            {
                new Contact { FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new Contact { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" }
            };


            // Mock the service methods
            _mockAPIService.Setup(service => service.GetMockContacts()).ReturnsAsync(mockContacts);
            _mailChimpService.Setup(service => service.SyncToMailChimp(mockContacts)).ReturnsAsync(mockContacts);

            // Act
            var result = await _controller.SyncContacts();

            // Assert
            var okResult = result as SyncContactsDto;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.Contacts.Count, Is.EqualTo(mockContacts.Count));
            Assert.That(okResult.Contacts[0].Email, Is.EqualTo(mockContacts[0].Email));
        }
    }
}

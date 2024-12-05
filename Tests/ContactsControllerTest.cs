using Application.Entities;
using Application.Interfaces;
using MockAPI.Controllers;
using MockAPI.Dtos;
using Moq;

namespace Tests
{
    public class ContactsControllerTest
    {
        private Mock<IMailChimpService> _mailChimpServiceMock;
        private ContactsController _controller;

        [SetUp]
        public void SetUp()
        {
            _mailChimpServiceMock = new Mock<IMailChimpService>();
            _controller = new ContactsController(_mailChimpServiceMock.Object);
        }

        [Test]
        public async Task SyncContacts_ReturnsSyncContactsDto()
        {
            // Arrange
            var contacts = new List<Contact>
            {
                new() { FirstName = "Michael", LastName = "Johnson", Email = "michael.johnson@gmail.com" },
                new() { FirstName = "Emily", LastName = "Davis", Email = "emily.davis@hotmail.com" },
            };

            const int expectedSyncCount = 2;

            _mailChimpServiceMock
                .Setup(service => service.SyncToMailChimp())
                .ReturnsAsync((contacts, expectedSyncCount));

            // Act
            var result = await _controller.SyncContacts();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<SyncContactsDto>());
            Assert.That(result.SyncedContacts, Is.EqualTo(expectedSyncCount));
            Assert.That(result.Contacts, Has.Count.EqualTo(contacts.Count));
        }

        [Test]
        public void SyncContacts_ThrowsException_WhenServiceFails()
        {
            // Arrange
            _mailChimpServiceMock
                .Setup(service => service.SyncToMailChimp())
                .ThrowsAsync(new InvalidOperationException("Something went wrong"));

            // Act & Assert
            var exception = Assert.ThrowsAsync<InvalidOperationException>(_controller.SyncContacts);
            Assert.That(exception.Message, Is.EqualTo("Something went wrong"));
        }

        [Test]
        public async Task ClearList_ShouldCallRemoveAllMembersOnce()
        {
            // Act
            await _controller.ClearList();

            // Assert
            _mailChimpServiceMock.Verify(service => service.RemoveAllMembers(), Times.Once,
                "RemoveAllMembers should be called exactly once.");
        }

    }
}

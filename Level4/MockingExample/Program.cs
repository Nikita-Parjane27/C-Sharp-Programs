// Install: dotnet add package Moq
// dotnet add package xunit

using System;
using Moq;
using Xunit;

// Interface to mock
public interface IEmailService
{
    bool SendEmail(string to, string message);
}

// Class that depends on the interface
public class NotificationService
{
    private readonly IEmailService _emailService;

    public NotificationService(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public string Notify(string userEmail, string msg)
    {
        bool sent = _emailService.SendEmail(userEmail, msg);
        return sent ? "Notification sent!" : "Failed to send!";
    }
}

// Test class
public class NotificationServiceTests
{
    [Fact]
    public void Notify_WhenEmailSent_ReturnsSuccessMessage()
    {
        // Arrange
        var mockEmail = new Mock<IEmailService>();
        mockEmail.Setup(e => e.SendEmail(It.IsAny<string>(), It.IsAny<string>()))
                 .Returns(true);

        var service = new NotificationService(mockEmail.Object);

        // Act
        string result = service.Notify("nikita@example.com", "Hello!");

        // Assert
        Assert.Equal("Notification sent!", result);
        mockEmail.Verify(e => e.SendEmail("nikita@example.com", "Hello!"), Times.Once);
    }

    [Fact]
    public void Notify_WhenEmailFails_ReturnsFailureMessage()
    {
        var mockEmail = new Mock<IEmailService>();
        mockEmail.Setup(e => e.SendEmail(It.IsAny<string>(), It.IsAny<string>()))
                 .Returns(false);

        var service = new NotificationService(mockEmail.Object);
        string result = service.Notify("test@test.com", "Hi");

        Assert.Equal("Failed to send!", result);
    }
}
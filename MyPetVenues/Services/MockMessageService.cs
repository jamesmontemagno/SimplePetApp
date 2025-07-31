using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class MockMessageService : IMessageService
{
    private static List<Message> _messages = new();
    private static List<UserPrivacySettings> _privacySettings = new();
    private static int _nextMessageId = 1;
    private static int _nextPrivacyId = 1;

    public Task<List<Message>> GetUserMessagesAsync(int userId)
    {
        var messages = _messages
            .Where(m => m.RecipientId == userId || m.SenderId == userId)
            .OrderByDescending(m => m.CreatedDate)
            .ToList();
        return Task.FromResult(messages);
    }

    public Task<Message?> GetMessageAsync(int id)
    {
        var message = _messages.FirstOrDefault(m => m.Id == id);
        return Task.FromResult(message);
    }

    public Task<Message> SendMessageAsync(Message message)
    {
        message.Id = _nextMessageId++;
        message.CreatedDate = DateTime.UtcNow;
        message.Status = MessageStatus.Sent;
        _messages.Add(message);
        return Task.FromResult(message);
    }

    public Task<bool> MarkAsReadAsync(int messageId)
    {
        var message = _messages.FirstOrDefault(m => m.Id == messageId);
        if (message != null)
        {
            message.IsRead = true;
            message.ReadDate = DateTime.UtcNow;
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<bool> DeleteMessageAsync(int id)
    {
        var message = _messages.FirstOrDefault(m => m.Id == id);
        if (message != null)
        {
            _messages.Remove(message);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<UserPrivacySettings> GetPrivacySettingsAsync(int userId)
    {
        var settings = _privacySettings.FirstOrDefault(p => p.UserId == userId);
        if (settings == null)
        {
            settings = new UserPrivacySettings
            {
                Id = _nextPrivacyId++,
                UserId = userId
            };
            _privacySettings.Add(settings);
        }
        return Task.FromResult(settings);
    }

    public Task<UserPrivacySettings> UpdatePrivacySettingsAsync(UserPrivacySettings settings)
    {
        var existing = _privacySettings.FirstOrDefault(p => p.UserId == settings.UserId);
        if (existing != null)
        {
            existing.AllowMessagesFromAnyone = settings.AllowMessagesFromAnyone;
            existing.AllowEventInvites = settings.AllowEventInvites;
            existing.ShowProfileToEveryone = settings.ShowProfileToEveryone;
            existing.ShowLocationHistory = settings.ShowLocationHistory;
            return Task.FromResult(existing);
        }
        
        settings.Id = _nextPrivacyId++;
        _privacySettings.Add(settings);
        return Task.FromResult(settings);
    }
}
using MyPetVenues.Models;

namespace MyPetVenues.Services;

public interface IReviewService
{
    Task<List<Review>> GetReviewsByLocationAsync(int locationId);
    Task<List<Review>> GetReviewsByUserAsync(int userId);
    Task<Review?> GetReviewAsync(int id);
    Task<Review> CreateReviewAsync(Review review);
    Task<Review> UpdateReviewAsync(Review review);
    Task<bool> DeleteReviewAsync(int id);
    Task<bool> VoteHelpfulAsync(int reviewId, int userId);
    Task<double> GetAverageRatingAsync(int locationId);
}

public interface ICommentService
{
    Task<List<Comment>> GetCommentsByLocationAsync(int locationId);
    Task<List<Comment>> GetRepliesAsync(int parentCommentId);
    Task<Comment?> GetCommentAsync(int id);
    Task<Comment> CreateCommentAsync(Comment comment);
    Task<Comment> UpdateCommentAsync(Comment comment);
    Task<bool> DeleteCommentAsync(int id);
    Task<bool> LikeCommentAsync(int commentId, int userId);
}

public interface IEventService
{
    Task<List<Event>> GetEventsAsync();
    Task<List<Event>> GetEventsByLocationAsync(int locationId);
    Task<List<Event>> GetEventsByUserAsync(int userId);
    Task<Event?> GetEventAsync(int id);
    Task<Event> CreateEventAsync(Event eventItem);
    Task<Event> UpdateEventAsync(Event eventItem);
    Task<bool> DeleteEventAsync(int id);
    Task<EventRsvp> RsvpToEventAsync(int eventId, int userId, RsvpStatus status);
    Task<List<EventRsvp>> GetEventAttendeesAsync(int eventId);
}

public interface IMessageService
{
    Task<List<Message>> GetUserMessagesAsync(int userId);
    Task<Message?> GetMessageAsync(int id);
    Task<Message> SendMessageAsync(Message message);
    Task<bool> MarkAsReadAsync(int messageId);
    Task<bool> DeleteMessageAsync(int id);
    Task<UserPrivacySettings> GetPrivacySettingsAsync(int userId);
    Task<UserPrivacySettings> UpdatePrivacySettingsAsync(UserPrivacySettings settings);
}
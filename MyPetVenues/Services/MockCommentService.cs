using MyPetVenues.Models;

namespace MyPetVenues.Services;

public class MockCommentService : ICommentService
{
    private static List<Comment> _comments = new();
    private static int _nextId = 1;

    public Task<List<Comment>> GetCommentsByLocationAsync(int locationId)
    {
        var comments = _comments
            .Where(c => c.LocationId == locationId && c.ParentCommentId == null)
            .ToList();
        return Task.FromResult(comments);
    }

    public Task<List<Comment>> GetRepliesAsync(int parentCommentId)
    {
        var replies = _comments.Where(c => c.ParentCommentId == parentCommentId).ToList();
        return Task.FromResult(replies);
    }

    public Task<Comment?> GetCommentAsync(int id)
    {
        var comment = _comments.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(comment);
    }

    public Task<Comment> CreateCommentAsync(Comment comment)
    {
        comment.Id = _nextId++;
        comment.CreatedDate = DateTime.UtcNow;
        _comments.Add(comment);
        return Task.FromResult(comment);
    }

    public Task<Comment> UpdateCommentAsync(Comment comment)
    {
        var existing = _comments.FirstOrDefault(c => c.Id == comment.Id);
        if (existing != null)
        {
            existing.Content = comment.Content;
            existing.UpdatedDate = DateTime.UtcNow;
            return Task.FromResult(existing);
        }
        return Task.FromResult(comment);
    }

    public Task<bool> DeleteCommentAsync(int id)
    {
        var comment = _comments.FirstOrDefault(c => c.Id == id);
        if (comment != null)
        {
            _comments.Remove(comment);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<bool> LikeCommentAsync(int commentId, int userId)
    {
        var comment = _comments.FirstOrDefault(c => c.Id == commentId);
        if (comment != null)
        {
            comment.LikesCount++;
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}
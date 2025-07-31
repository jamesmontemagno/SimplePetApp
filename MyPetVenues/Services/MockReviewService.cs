using MyPetVenues.Models;

namespace MyPetVenues.Services;

// Mock implementations for demo purposes
public class MockReviewService : IReviewService
{
    private static List<Review> _reviews = new();
    private static int _nextId = 1;

    public Task<List<Review>> GetReviewsByLocationAsync(int locationId)
    {
        var reviews = _reviews.Where(r => r.LocationId == locationId).ToList();
        return Task.FromResult(reviews);
    }

    public Task<List<Review>> GetReviewsByUserAsync(int userId)
    {
        var reviews = _reviews.Where(r => r.UserId == userId).ToList();
        return Task.FromResult(reviews);
    }

    public Task<Review?> GetReviewAsync(int id)
    {
        var review = _reviews.FirstOrDefault(r => r.Id == id);
        return Task.FromResult(review);
    }

    public Task<Review> CreateReviewAsync(Review review)
    {
        review.Id = _nextId++;
        review.CreatedDate = DateTime.UtcNow;
        _reviews.Add(review);
        return Task.FromResult(review);
    }

    public Task<Review> UpdateReviewAsync(Review review)
    {
        var existing = _reviews.FirstOrDefault(r => r.Id == review.Id);
        if (existing != null)
        {
            existing.Title = review.Title;
            existing.Content = review.Content;
            existing.Rating = review.Rating;
            existing.UpdatedDate = DateTime.UtcNow;
            return Task.FromResult(existing);
        }
        return Task.FromResult(review);
    }

    public Task<bool> DeleteReviewAsync(int id)
    {
        var review = _reviews.FirstOrDefault(r => r.Id == id);
        if (review != null)
        {
            _reviews.Remove(review);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<bool> VoteHelpfulAsync(int reviewId, int userId)
    {
        var review = _reviews.FirstOrDefault(r => r.Id == reviewId);
        if (review != null)
        {
            review.HelpfulVotes++;
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<double> GetAverageRatingAsync(int locationId)
    {
        var locationReviews = _reviews.Where(r => r.LocationId == locationId).ToList();
        if (locationReviews.Any())
        {
            return Task.FromResult(locationReviews.Average(r => r.Rating));
        }
        return Task.FromResult(0.0);
    }
}
namespace MyPetVenues.Models;

public class Review
{
    public int Id { get; set; }
    public string ReviewerName { get; set; } = string.Empty;
    public double Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string? PetName { get; set; }
    public int HelpfulCount { get; set; }
}

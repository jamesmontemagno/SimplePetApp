namespace MyPetVenues.Models;

public class Amenity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public AmenityCategory Category { get; set; }
}

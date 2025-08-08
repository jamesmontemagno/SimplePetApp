using System.ComponentModel.DataAnnotations;

namespace MyPetVenues.Models;

public record Venue(
    int Id,
    string Name,
    string Description,
    string Address,
    string City,
    string State,
    string ZipCode,
    VenueCategory Category,
    List<PetType> AllowedPetTypes,
    List<string> Amenities,
    List<string> Restrictions,
    double Rating,
    int ReviewCount,
    string? ImageUrl,
    string? Website,
    string? Phone
);

public enum VenueCategory
{
    [Display(Name = "Café")]
    Cafe,
    [Display(Name = "Restaurant")]
    Restaurant,
    [Display(Name = "Park")]
    Park,
    [Display(Name = "Hotel")]
    Hotel,
    [Display(Name = "Beach")]
    Beach,
    [Display(Name = "Trail")]
    Trail,
    [Display(Name = "Shop")]
    Shop,
    [Display(Name = "Grooming")]
    Grooming,
    [Display(Name = "Veterinary")]
    Veterinary,
    [Display(Name = "Other")]
    Other
}

public enum PetType
{
    [Display(Name = "Dogs")]
    Dog,
    [Display(Name = "Cats")]
    Cat,
    [Display(Name = "Birds")]
    Bird,
    [Display(Name = "Rabbits")]
    Rabbit,
    [Display(Name = "Reptiles")]
    Reptile,
    [Display(Name = "Fish")]
    Fish,
    [Display(Name = "Small Animals")]
    SmallAnimal,
    [Display(Name = "Farm Animals")]
    FarmAnimal
}
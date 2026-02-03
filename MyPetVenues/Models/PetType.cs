namespace MyPetVenues.Models;

public enum PetType
{
    Dog,
    Cat,
    Rabbit,
    Bird,
    Fish,
    Reptile,
    SmallAnimal,
    Exotic,
    All
}

public static class PetTypeExtensions
{
    public static string GetEmoji(this PetType petType) => petType switch
    {
        PetType.Dog => "🐕",
        PetType.Cat => "🐱",
        PetType.Rabbit => "🐰",
        PetType.Bird => "🐦",
        PetType.Fish => "🐠",
        PetType.Reptile => "🦎",
        PetType.SmallAnimal => "🐹",
        PetType.Exotic => "🦔",
        PetType.All => "🐾",
        _ => "🐾"
    };

    public static string GetDisplayName(this PetType petType) => petType switch
    {
        PetType.Dog => "Dogs",
        PetType.Cat => "Cats",
        PetType.Rabbit => "Rabbits",
        PetType.Bird => "Birds",
        PetType.Fish => "Fish",
        PetType.Reptile => "Reptiles",
        PetType.SmallAnimal => "Small Animals",
        PetType.Exotic => "Exotic Pets",
        PetType.All => "All Pets",
        _ => "All Pets"
    };
}

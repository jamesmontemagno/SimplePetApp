namespace MyPetVenues.Models;

public sealed record VenueRules(
    bool LeashedOnly,
    bool OutdoorOnly,
    bool SmallDogsOnly,
    string? Notes);

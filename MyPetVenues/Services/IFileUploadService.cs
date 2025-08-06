using Microsoft.AspNetCore.Components.Forms;

namespace MyPetVenues.Services;

public interface IFileUploadService
{
    Task<string> UploadPetImageAsync(IBrowserFile file, string petId);
    Task<string> UploadUserImageAsync(IBrowserFile file, string userId);
    Task<bool> DeleteImageAsync(string imagePath);
}
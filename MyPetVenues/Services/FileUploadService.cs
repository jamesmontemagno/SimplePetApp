using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace MyPetVenues.Services;

public class FileUploadService : IFileUploadService
{
    private readonly IJSRuntime _jsRuntime;
    private const long MaxFileSize = 5 * 1024 * 1024; // 5MB
    private readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

    public FileUploadService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<string> UploadPetImageAsync(IBrowserFile file, string petId)
    {
        return await UploadImageAsync(file, "pets", petId);
    }

    public async Task<string> UploadUserImageAsync(IBrowserFile file, string userId)
    {
        return await UploadImageAsync(file, "users", userId);
    }

    private async Task<string> UploadImageAsync(IBrowserFile file, string category, string entityId)
    {
        try
        {
            // Validate file
            if (file.Size > MaxFileSize)
            {
                throw new InvalidOperationException($"File size must be less than {MaxFileSize / (1024 * 1024)}MB");
            }

            var extension = Path.GetExtension(file.Name).ToLowerInvariant();
            if (!AllowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException("Only image files (jpg, jpeg, png, gif) are allowed");
            }

            // Generate unique filename
            var fileName = $"{entityId}_{DateTime.UtcNow.Ticks}{extension}";
            var relativePath = $"images/{category}/{fileName}";
            
            // For Blazor WebAssembly, we'll simulate file upload by converting to base64
            // In a real application, you would upload to a server or cloud storage
            using var stream = file.OpenReadStream(MaxFileSize);
            var buffer = new byte[stream.Length];
            var totalBytesRead = 0;
            int bytesRead;
            while (totalBytesRead < buffer.Length)
            {
                bytesRead = await stream.ReadAsync(buffer.AsMemory(totalBytesRead));
                if (bytesRead == 0) break;
                totalBytesRead += bytesRead;
            }
            var base64 = Convert.ToBase64String(buffer);
            var dataUrl = $"data:{file.ContentType};base64,{base64}";
            
            // Store the image data in localStorage with the file path as key
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", $"image_{relativePath}", dataUrl);
            
            return relativePath;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"File upload failed: {ex.Message}");
        }
    }

    public async Task<bool> DeleteImageAsync(string imagePath)
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", $"image_{imagePath}");
            return true;
        }
        catch
        {
            return false;
        }
    }
}
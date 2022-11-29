using Spotboard.Data;

namespace Spotboard.Interfaces;

public interface ISpotifyService
{
    void Authorize();
    string? GetAuthCode();
    Task GenerateTokenAsync(string code);
    Task<UserProfile> GetUserProfileAsync();
}

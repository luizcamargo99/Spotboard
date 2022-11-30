using Spotboard.Data;
using Spotboard.Enums;

namespace Spotboard.Interfaces;

public interface ISpotifyService
{
    void Authorize();
    string? GetAuthCode();
    Task<AuthorizationResponse?> GenerateTokenAsync(string code);
    Task<UserProfile> GetUserProfileAsync();
    Task<TopItemsResponse> GetTopItemsAsync(EItemType itemType, ETimeRange timeRange, int? limit);
}

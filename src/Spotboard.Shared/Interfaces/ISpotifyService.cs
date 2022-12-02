using Spotboard.Shared.Data;
using Spotboard.Shared.Enums;

namespace Spotboard.Shared.Interfaces;

public interface ISpotifyService
{
    void Authorize();
    string? GetAuthCode();
    Task<AuthorizationResponse?> GenerateTokenAsync(string code);
    Task<UserProfile> GetUserProfileAsync();
    Task<TopItemsResponse> GetTopItemsAsync(EItemType itemType, ETimeRange timeRange, int? limit);
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Spotboard.Shared.Constants;
using Spotboard.Shared.Data;
using Spotboard.Shared.Enums;
using Spotboard.Shared.Extensions;
using Spotboard.Shared.Interfaces;
using System.Text;

namespace Spotboard.Shared.Services;

public class SpotifyService : ISpotifyService
{
    private const string _clientId = "d31b5ace39af42a89bd0e76f0e892563";
    private const string _clientSecret = "1c08d91398254851877e424b84081615";
    private readonly IHttpService _httpService;
    private readonly NavigationManager _navigationManager;
    private readonly IRepository<AuthorizationResponse> _authRepository;

    public SpotifyService(IHttpService httpService, NavigationManager navigationManager, IRepository<AuthorizationResponse> authRepository)
    {
        _httpService = httpService;
        _navigationManager = navigationManager;
        _authRepository = authRepository;
        _httpService.UnauthorizedStatus += UnauthorizedEvent;
    }

    public void Authorize()
    {
        StringBuilder builder = new();
        builder.Append(string.Concat(UrlConstant.AuthBaseUri, UrlConstant.AuthorizeEndpoint));
        builder.Append($"?response_type={EResponseType.Code.ToDescription()}");
        builder.Append($"&client_id={_clientId}");
        builder.Append($"&scope={EAuthorizationScopes.UserTopRead.ToDescription()}");
        builder.Append($"&redirect_uri={UrlConstant.RedirectUri}");
        builder.Append($"&state={new Random().Next(0, 1000000000)}");
        builder.Append("&show_dialog=true");

        var url = builder.ToString();
        _navigationManager.NavigateTo(url, forceLoad: true);
    }

    public string? GetAuthCode()
    {
        var uri = _navigationManager.ToAbsoluteUri(_navigationManager.Uri);
        var queryStrings = QueryHelpers.ParseQuery(uri.Query);

        if (queryStrings.TryGetValue("code", out var code))
        {
            return code;
        }

        return null;
    }

    public async Task<AuthorizationResponse?> GenerateTokenAsync(string code)
    {
        var authModel = await _authRepository.GetAsync();

        if (authModel is not null)
        {
            return authModel;
        }

        var secret = string.Concat(_clientId, ":", _clientSecret);
        _httpService.SetHeader("Basic", secret.ToBase64String());
        List<KeyValuePair<string, string>> requestData = new();
        requestData.Add(new("grant_type", EGrantType.AuthorizationCode.ToDescription()));
        requestData.Add(new("code", code));
        requestData.Add(new("redirect_uri", UrlConstant.RedirectUri));
        return await _httpService.RequestAsync<AuthorizationResponse?>(() => _httpService.PostAsync(string.Concat(UrlConstant.AuthBaseUri, UrlConstant.GetTokenEndpoint), new FormUrlEncodedContent(requestData)));
    }

    public async Task<UserProfile> GetUserProfileAsync()
    {
        var authModel = await _authRepository.GetAsync();

        if (authModel is null)
        {
            _navigationManager.NavigateTo("/", forceLoad: true, replace: true);
            return new();
        }

        _httpService.SetHeader("Bearer", authModel.AccessToken);
        return await _httpService.RequestAsync<UserProfile?>(() => _httpService.GetAsync(string.Concat(UrlConstant.APIBaseUri, UrlConstant.GetUserProfileEndpoint)));
    }

    private void UnauthorizedEvent(object? sender, EventArgs args)
    {
        Task.Delay(1).ContinueWith(async (x) =>
        {
            await _authRepository.SaveAsync(null);
            _navigationManager.NavigateTo("/", forceLoad: true, replace: true);
        });
    }

    public async Task<TopItemsResponse> GetTopItemsAsync(EItemType itemType, ETimeRange timeRange, int? limit = 10)
    {
        string query = $"?time_range={timeRange.ToDescription()}&limit={limit}";
        return await _httpService.RequestAsync<TopItemsResponse?>(() => _httpService.GetAsync(string.Concat(UrlConstant.APIBaseUri, UrlConstant.GetUserTopItemsEndpoint, $"/{itemType.ToDescription()}"), query));
    }
}

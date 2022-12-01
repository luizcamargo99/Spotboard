namespace Spotboard.Shared.Constants; 
public static class UrlConstant 
{ 
    public const string RedirectUri = "https://spotboard.azurewebsites.net/home";
    public const string AuthBaseUri = "https://accounts.spotify.com";
    public const string APIBaseUri = "https://api.spotify.com/v1";
    public const string GetTokenEndpoint = "/api/token";
    public const string GetUserProfileEndpoint = "/me";
    public const string GetUserTopItemsEndpoint = "/me/top";
    public const string AuthorizeEndpoint = "/authorize";
}

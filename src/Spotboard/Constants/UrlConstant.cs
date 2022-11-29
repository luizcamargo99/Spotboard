namespace Spotboard.Constants; 
public static class UrlConstant 
{ 
    public const string RedirectUri = "https://localhost:7008/callback";
    public const string AuthBaseUri = "https://accounts.spotify.com";
    public const string APIBaseUri = "https://api.spotify.com/v1";
    public const string GetTokenEndpoint = "/api/token";
    public const string GetUserProfileEndpoint = "/me";
    public const string AuthorizeEndpoint = "/authorize";
}

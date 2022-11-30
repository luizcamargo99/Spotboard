using System.ComponentModel;

namespace Spotboard.Enums;

public enum EGrantType
{
    [Description("authorization_code")]
    AuthorizationCode,
    [Description("refresh_token")]
    RefreshToken
}


using System.ComponentModel;

namespace Spotboard.Shared.Enums;

public enum EAuthorizationScopes
{
    [Description("user-top-read")]
    UserTopRead,
    [Description("user-read-private")]
    UserReadPrivate,
    [Description("user-read-email")]
    UserReadEmail
}

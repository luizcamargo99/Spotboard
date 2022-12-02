using Spotboard.Shared.Attributes;
using System.ComponentModel;

namespace Spotboard.Shared.Enums;
public enum ETimeRange
{

    [Description("short_term")]
    [DescriptionAux("Last Month")]
    ShortTerm,

    [Description("medium_term")]
    [DescriptionAux("Last 6 Months")]
    MediumTerm,

    [Description("long_term")]
    [DescriptionAux("All Time")]
    LongTerm
}

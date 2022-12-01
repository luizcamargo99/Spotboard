﻿using System.ComponentModel;

namespace Spotboard.Shared.Enums;
public enum ETimeRange
{
    [Description("long_term")]
    LongTerm,
    [Description("medium_term")]
    MediumTerm,
    [Description("short_term")]
    ShortTerm
}
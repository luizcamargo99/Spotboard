using Spotboard.Shared.Attributes;
using System.ComponentModel;

namespace Spotboard.Shared.Extensions;

public static class EnumExtension
{
    public static string ToDescription<TEnum>(this TEnum enumValue) where TEnum : struct
    {
        return typeof(TEnum).GetMember(enumValue.ToString())
            .SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>()).FirstOrDefault().Description;
    }

    public static string ToDescriptionAux<TEnum>(this TEnum enumValue) where TEnum : struct
    {
        return typeof(TEnum).GetMember(enumValue.ToString())
            .SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAuxAttribute), true).Cast<DescriptionAuxAttribute>()).FirstOrDefault().Description;
    }

    public static T ParseEnum<T>(this string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }

    public static IEnumerable<T> GetValues<T>()
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }
}

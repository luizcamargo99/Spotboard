using System.ComponentModel;

namespace Spotboard.Extensions
{
    public static class EnumExtension
    {
        public static string ToDescription<TEnum>(this TEnum enumValue) where TEnum : struct
        {
            return typeof(TEnum).GetMember(enumValue.ToString())
                .SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>()).FirstOrDefault().Description;
        }
    }
}

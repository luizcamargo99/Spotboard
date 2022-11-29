using System.Text;

namespace Spotboard.Extensions
{
    public static class StringExtension
    {
        public static string ToBase64String(this string str)
        {
            var secretBytes = Encoding.Default.GetBytes(str);
            return Convert.ToBase64String(secretBytes);
        }
    }
}

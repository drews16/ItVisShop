using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ItVisShop.Domain.Extensions
{   public static class EnumExtension
    {
        public static string GetDisplayName(this System.Enum enumValue)
        {
            return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                ?.GetName();
        }

        public static List<T> GetEnumList<T>()
        {
            T[] arr = (T[])System.Enum.GetValues(typeof(T));
            return new List<T>();
        }
    }
}

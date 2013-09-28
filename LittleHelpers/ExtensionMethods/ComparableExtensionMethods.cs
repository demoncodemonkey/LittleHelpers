using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

#if LITTLEHELPERS_NEEDS_EXPLICIT_USING_DIRECTIVES
namespace demoncodemonkey.LittleHelpers
{
#endif

	public static class ComparableExtensionMethods
	{
		public static bool IsBetween<T>(this T value, T min, T max)
			where T : IComparable<T>
		{
			if (min.CompareTo(max) > 0)
				Utils.Swap(ref min, ref max);
			return (value.CompareTo(min) >= 0) && (value.CompareTo(max) <= 0);
		}

		public static bool IsNotBetween<T>(this T value, T min, T max)
			where T : IComparable<T>
		{
			return !value.IsBetween(min, max);
		}
	}

#if LITTLEHELPERS_NEEDS_EXPLICIT_USING_DIRECTIVES
}
#endif

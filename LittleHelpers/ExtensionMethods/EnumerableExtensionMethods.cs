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

	public static class EnumerableExtensionMethods
	{
		public static bool IsEmpty<T>(this IEnumerable<T> @this)
		{
			if (@this.IsNull())
				throw new ArgumentNullException("@this is null");
			return @this.Count() == 0;
		}

		public static bool IsNotEmpty<T>(this IEnumerable<T> @this)
		{
			return !@this.IsEmpty();
		}

		public static string CombineItemContents<T>(this IEnumerable<T> @this, string separator = ", ")
		{
			if (@this.IsNull())
				throw new ArgumentNullException("@this is null");
			if (separator.IsNull())
				throw new ArgumentNullException("separator is null");
			var itemsContents = @this.GetItemsContents().ToList();
			if (itemsContents.IsEmpty())
				return "Empty list";
			return string.Join(separator, itemsContents);
		}

		public static IEnumerable<string> GetItemsContents<T>(this IEnumerable<T> @this)
		{
			if (@this.IsNull())
				throw new ArgumentNullException("@this is null");
			foreach (T item in @this)
				yield return item.ToString();
		}
	}

#if LITTLEHELPERS_NEEDS_EXPLICIT_USING_DIRECTIVES
}
#endif
